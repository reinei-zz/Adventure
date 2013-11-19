using System.Collections.Generic;
using libtcod;

namespace Adventure
{
	enum Tiles : byte
	{
		Air,
		Stone
	}

	enum TileMode : byte
	{
		Solid,
		Passable,
		Liquid
	}

	internal struct Tile
	{
		public static Dictionary<Tiles, ConsoleChar> Visuals = new Dictionary<Tiles,ConsoleChar>()
		{
			{ Tiles.Air, new ConsoleChar(' ', TCODColor.white, TCODColor.black)},
			{ Tiles.Stone, new ConsoleChar('O', TCODColor.darkGrey, TCODColor.lightGrey)}
        };

		public Tiles Identifier;
		public TileMode Mode;

		public Tile(Tiles identifier, TileMode mode)
		{
			this.Identifier = identifier;
			this.Mode = mode;
		}

		public ConsoleChar Visual()
		{
			return Visuals[this.Identifier];
		}
	}
}