namespace Adventure
{
	enum TileMode : byte
	{
		Solid,
		Passable,
		Liquid
	}

	internal struct Tile
	{
		public string Identifier;
		public char Visual;
		public TileMode Mode;

		public Tile(string identifier, char visual, TileMode mode)
		{
			this.Identifier = identifier;
			this.Visual = visual;
			this.Mode = mode;
		}
	}
}