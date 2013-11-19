﻿namespace Adventure
{
	internal class WorldGen
	{
		public static Chunk Generate(Position pos)
		{
			Chunk c = new Chunk(pos);

			for (short x = 0; x < Chunk.Size; x++)
			{
				for (short y = 0; y < Chunk.Size; y++)
				{
					for (short z = 0; z < Chunk.Size; z++)
					{
						c.Tiles[x, y, z] = new Tile(Tiles.Air, TileMode.Passable);
					}
				}
			}

			return c;
		}
	}
}