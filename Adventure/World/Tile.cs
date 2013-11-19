using System.Collections.Generic;
using libtcod;

namespace Adventure
{
	internal enum Tiles : byte
	{
		Air,
		Stone
	}

	internal enum TileMode : byte
	{
		Solid,
		Passable,
		Liquid
	}

	internal struct Tile
	{
		public static Dictionary<Tiles, ConsoleChar> Visuals = new Dictionary<Tiles, ConsoleChar>()
		{
			{ Tiles.Air, new ConsoleChar(' ', TCODColor.white, TCODColor.black) },
			{ Tiles.Stone, new ConsoleChar('O', TCODColor.darkGrey, TCODColor.lightGrey) }
        };

		public static Dictionary<Tiles, TileMode> Modes = new Dictionary<Tiles, TileMode>()
		{
			{ Tiles.Air, TileMode.Passable },
			{ Tiles.Stone, TileMode.Solid }
		};

		public Tiles Identifier;

		public Tile(Tiles identifier)
		{
			this.Identifier = identifier;
		}

		public ConsoleChar Visual()
		{
			return Visuals[this.Identifier];
		}

		public TileMode Mode()
		{
			return Modes[this.Identifier];
		}
	}
}