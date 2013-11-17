namespace Adventure
{
	internal struct Tile
	{
		public string Identifier;
		public char Visual;

		public Tile(string identifier, char visual)
		{
			this.Identifier = identifier;
			this.Visual = visual;
		}
	}
}