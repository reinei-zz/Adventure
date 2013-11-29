using System.Collections.Generic;
using libtcod;

namespace Adventure
{
	internal class World
	{
		public long Turns_Total;

		private Dictionary<Position, Chunk> LoadedChunks = new Dictionary<Position, Chunk>();

		public void Update(TCODKey k, TCODMouseData m)
		{
			List<Position> unload = new List<Position>();
			SortedList<long, Entitys.Entity> entitys = new SortedList<long,Entitys.Entity>();
			long sleep_lowest = 1;
			bool tick_unlocked = true;

			//Update loaded chunks
			foreach (KeyValuePair<Position, Chunk> kv in LoadedChunks)
			{
				kv.Value.Update();

				//If timed out add to unload list
				if (kv.Value.Idle > Chunk.Timeout)
				{
					unload.Add(kv.Key);
				}
			}

			//Unload chunks
			foreach (Position p in unload)
			{
				LoadedChunks[p].SaveToFile();
				LoadedChunks.Remove(p);
			}

			//Tick next entity
			foreach (KeyValuePair<Position, Chunk> kv in LoadedChunks)
			{
				foreach (Entitys.Entity e in kv.Value.Entitys)
				{
					entitys.Add(e.Sleep, e);
				}
			}
			if (entitys.Count > 0)
			{
				sleep_lowest = entitys.Values[0].Sleep;
				tick_unlocked = entitys.Values[0].Event_Tick(k, m);
			}
			if (tick_unlocked)
			{
				foreach (KeyValuePair<long, Entitys.Entity> kv in entitys)
				{
					kv.Value.Sleep -= sleep_lowest;
				}
				Turns_Total += sleep_lowest;
			}
		}

		public void SetTile(Position pos, Tile tile)
		{
			Position chunkpos = GetChunkPosition(pos);
			Position chunkindex = GetChunkTileIndex(pos, chunkpos);
			Chunk c = GetChunk(chunkpos);
			c.Idle = 0;
			c.Tiles[chunkindex.x, chunkindex.y, chunkindex.z] = tile;
		}

		public Tile GetTile(Position pos)
		{
			Position chunkpos = GetChunkPosition(pos);
			Position chunkindex = GetChunkTileIndex(pos, chunkpos);
			Chunk c = GetChunk(chunkpos);
			c.Idle = 0;
			return c.Tiles[chunkindex.x, chunkindex.y, chunkindex.z];
		}

		public Position GetChunkPosition(Position tilepos)
		{
			long x = tilepos.x / Chunk.Size;
			long y = tilepos.y / Chunk.Size;
			long z = tilepos.z / Chunk.Size;
			if (tilepos.x < 0) x--;
			if (tilepos.y < 0) y--;
			if (tilepos.z < 0) z--;
			return new Position(x, y, z);
		}

		public Position GetChunkTileIndex(Position tilepos, Position chunkpos)
		{
			long x = tilepos.x - chunkpos.x * Chunk.Size;
			long y = tilepos.y - chunkpos.y * Chunk.Size;
			long z = tilepos.z - chunkpos.z * Chunk.Size;
			if (tilepos.x < 0) x = -(x - Chunk.Size);
			if (tilepos.y < 0) y = -(y - Chunk.Size);
			if (tilepos.z < 0) z = -(z - Chunk.Size);
			return new Position(x, y, z);
		}

		public Chunk GetChunk(Position chunkpos)
		{
			Chunk c;
			if (LoadedChunks.TryGetValue(chunkpos, out c))
			{
				return LoadedChunks[chunkpos];
			}
			else
			{
				c = Chunk.LoadFromFile(chunkpos);
				if (c == null)
				{
					LoadedChunks[chunkpos] = WorldGen.Generate(chunkpos);
				}
				return LoadedChunks[chunkpos];
			}
		}

		public void AddEntity(Entitys.Entity e)
		{
			Position chunkpos = GetChunkPosition(e.Pos);
			GetChunk(chunkpos).Entitys.Add(e);
		}

		public void MoveEntity(Entitys.Entity e, Position dest)
		{
			Position chunkpos_before = GetChunkPosition(e.Pos);
			e.Pos = dest;
			Position chunkpos_after = GetChunkPosition(e.Pos);
			if (chunkpos_before != chunkpos_after)
			{
				GetChunk(chunkpos_before).Entitys.Remove(e);
				GetChunk(chunkpos_after).Entitys.Add(e);
			}
		}

		public List<Entitys.Entity> GetEntitys(Position chunkpos)
		{
			Chunk c = GetChunk(chunkpos);
			c.Idle = 0;
			return c.Entitys;
		}

		public List<Entitys.Entity> GetEntitys_Range(Position pos, long range)
		{
			List<Entitys.Entity> Entitys = new List<Entitys.Entity>();
			List<Position> ChunksInRange = new List<Position>();
			Position Chunk_Start = GetChunkPosition(pos.translate(-range, -range, -range));
			Position Chunk_End = GetChunkPosition(pos.translate(range, range, range));

			//Get all chunks in range
			for (long x = Chunk_Start.x; x <= Chunk_End.x; x++)
			{
				for (long y = Chunk_Start.y; y <= Chunk_End.y; y++)
				{
					for (long z = Chunk_Start.z; z <= Chunk_End.z; z++)
					{
						ChunksInRange.Add(new Position(x, y, z));
					}
				}
			}

			//Get all entitys in range
			foreach (Position p in ChunksInRange)
			{
				List<Entitys.Entity> ChunkEntitys = GetChunk(p).Entitys;
				foreach (Entitys.Entity e in ChunkEntitys)
				{
					if (pos.Distance(e.Pos) <= range)
					{
						Entitys.Add(e);
					}
				}
			}

			return Entitys;
		}

		//Events

		public enum NoiseType
		{
			Step
		}

		public static Dictionary<NoiseType, long> NoiseRanges = new Dictionary<NoiseType, long>()
		{
			{ NoiseType.Step, 10}
        };

		public void Event_Noise(Position pos, NoiseType type)
		{
			long range = NoiseRanges[type];
			foreach (Entitys.Entity e in GetEntitys_Range(pos, range))
			{
				e.Event_Noise(pos, 1 - pos.Distance(e.Pos) / range);
			}
		}
	}

	internal class Chunk
	{
		public static short Size = 20;
		public static short Timeout = 15;

		public Position Pos;
		public Tile[, ,] Tiles = new Tile[Size, Size, Size];
		public List<Entitys.Entity> Entitys = new List<Entitys.Entity>();
		public short Idle = 0;

		public Chunk(Position pos)
		{
			this.Pos = pos;
		}

		public void Update()
		{
			this.Idle++;
		}

		public void SaveToFile()
		{
			//TODO
		}

		public static Chunk LoadFromFile(Position chunkpos)
		{
			//TODO
			return null;
		}
	}
}