using System.Collections.Generic;
using libtcod;

namespace Adventure
{
	public enum Tile : byte
	{
		Air,
		Stone
	}

	public enum TileMode : byte
	{
		Solid,
		Passable,
		Liquid
	}

	public class Tiles
	{
		public static ConsoleChar[] Visuals = new ConsoleChar[]
		{
			/* Air */		new ConsoleChar(' ', TCODColor.white, TCODColor.black),
			/* Stone */		new ConsoleChar('O', TCODColor.darkGrey, TCODColor.lightGrey)
        };

		public static TileMode[] Modes = new TileMode[]
		{
			/* Air */		TileMode.Passable,
			/* Stone */		TileMode.Solid
		};
	}
}