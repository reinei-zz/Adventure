using System;
using System.Collections.Generic;
using libtcod;

namespace Adventure
{
	public enum Tile : byte
	{
		Air,
		Stone,
		Grass
	}

	public enum TileMode : byte
	{
		Solid,
		Passable,
		Liquid
	}

	[Flags]
	public enum TileFlags : byte
	{
		transparent = 1,
	}

	public class Tiles
	{
		public static void Init()
		{
			
		}

		public static ConsoleChar[] Visuals = new ConsoleChar[]
		{
			/* Air */		new ConsoleChar(' ', TCODColor.white, TCODColor.black),
			/* Stone */		new ConsoleChar('O', TCODColor.darkGrey, TCODColor.lightGrey),
			/* Grass */		new ConsoleChar('.', TCODColor.darkerGreen, TCODColor.darkGreen)
        };

		public static ConsoleChar[] BelowVisuals = new ConsoleChar[]
		{
			/* Air */		Visuals[0],
			/* Stone */		new ConsoleChar(' ', TCODColor.darkGrey, TCODColor.lightGrey),
			/* Grass */		new ConsoleChar(' ', TCODColor.darkestGreen, TCODColor.darkerGreen),
		};

		public static TileMode[] Modes = new TileMode[]
		{
			/* Air */		TileMode.Passable,
			/* Stone */		TileMode.Solid,
			/* Grass */		TileMode.Solid
		};

		public static TileFlags[] TFlags = new TileFlags[]
		{
			/* Air */		TileFlags.transparent,
			/* Stone */		0,
			/* Stone */		0,
		};
	}
}