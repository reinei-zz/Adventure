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
			Position chunkpos = new Position(pos.x / Chunk.Size, pos.y / Chunk.Size, pos.z / Chunk.Size);
			Chunk c = GetChunk(chunkpos);
			c.Idle = 0;
			c.Tiles[pos.x - (chunkpos.x * Chunk.Size), pos.y - (chunkpos.y * Chunk.Size), pos.z - (chunkpos.z * Chunk.Size)] = tile;
		}

		public Tile GetTile(Position pos)
		{
			Position chunkpos = new Position(pos.x / Chunk.Size, pos.y / Chunk.Size, pos.z / Chunk.Size);
			Chunk c = GetChunk(chunkpos);
			c.Idle = 0;
			return c.Tiles[pos.x - (chunkpos.x * Chunk.Size), pos.y - (chunkpos.y * Chunk.Size), pos.z - (chunkpos.z * Chunk.Size)];
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
	}

	internal class Chunk
	{
		public static short Size = 20;
		public static short Timeout = 15;

		public Position Pos;
		public Tile[, ,] Tiles = new Tile[Size, Size, Size];
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