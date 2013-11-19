namespace Adventure
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

						Tiles tile = Tiles.Air;

						if (y <= 0)
						{
							tile = Tiles.Stone;
						}


						c.Tiles[x, y, z] = new Tile(tile);
					}
				}
			}

			return c;
		}
	}
}