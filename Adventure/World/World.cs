using System.Collections.Generic;

namespace Adventure
{
	internal class World
	{
		private Dictionary<Position, Chunk> LoadedChunks = new Dictionary<Position, Chunk>();

		public void SetTile(Position pos, Tile tile)
		{
			Position chunkpos = new Position(pos.x / Chunk.Size, pos.y / Chunk.Size, pos.z / Chunk.Size);
			GetChunk(chunkpos).tiles[pos.x - (chunkpos.x * Chunk.Size), pos.y - (chunkpos.y * Chunk.Size), pos.z - (chunkpos.z * Chunk.Size)] = tile;
		}

		public Tile GetTile(Position pos)
		{
			Position chunkpos = new Position(pos.x / Chunk.Size, pos.y / Chunk.Size, pos.z / Chunk.Size);
			return GetChunk(chunkpos).tiles[pos.x - (chunkpos.x * Chunk.Size), pos.y - (chunkpos.y * Chunk.Size), pos.z - (chunkpos.z * Chunk.Size)];
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
				LoadedChunks[chunkpos] = WorldGen.Generate(chunkpos);
				return LoadedChunks[chunkpos];
			}
		}
	}

	internal class Chunk
	{
		public static int Size = 20;

		public Position Pos;
		public Tile[, ,] tiles = new Tile[Size, Size, Size];

		public Chunk(Position pos)
		{
			this.Pos = pos;
		}
	}
}