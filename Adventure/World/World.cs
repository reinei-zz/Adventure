using System.Collections.Generic;

namespace Adventure
{
	internal class World
	{
		private Dictionary<Position, Chunk> LoadedChunks = new Dictionary<Position, Chunk>();

		public void Update()
		{
			List<Position> unload = new List<Position>();

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
		}

		public void SetTile(Position pos, Tile tile)
		{
			Position chunkpos = GetChunk_Position(pos);
			Chunk c = GetChunk(chunkpos);
			c.Idle = 0;
			c.Tiles[pos.x - (chunkpos.x * Chunk.Size), pos.y - (chunkpos.y * Chunk.Size), pos.z - (chunkpos.z * Chunk.Size)] = tile;
		}

		public Tile GetTile(Position pos)
		{
			Position chunkpos = GetChunk_Position(pos);
			Chunk c = GetChunk(chunkpos);
			c.Idle = 0;
			return c.Tiles[pos.x - (chunkpos.x * Chunk.Size), pos.y - (chunkpos.y * Chunk.Size), pos.z - (chunkpos.z * Chunk.Size)];
		}

		public Position GetChunk_Position(Position tilepos)
		{
			return new Position(tilepos.x / Chunk.Size, tilepos.y / Chunk.Size, tilepos.z / Chunk.Size);
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
			Position Chunk_Start = GetChunk_Position(pos.translate(-range, -range, -range));
			Position Chunk_End = GetChunk_Position(pos.translate(range, range, range));

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
				e.Event_Noise(pos, pos.Distance(e.Pos) / range);
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