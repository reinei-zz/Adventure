using System.Collections.Generic;

namespace Adventure
{
	public enum Directions
	{
		None,
		Up,
		Down,
		Left,
		Right,
		UpLeft,
		UpRight,
		DownLeft,
		DownRight,
		FloorUp,
		FloorDown
	};

	public static class Direction
	{
		public static Dictionary<Directions, Position> DirectionPositions = new Dictionary<Directions, Position>()
			{
				{ Directions.None, new Position(0, 0, 0)},
				{ Directions.Up, new Position(0, 0, -1)},
				{ Directions.Down, new Position(0, 0, 1)},
				{ Directions.Left, new Position(-1, 0, 0)},
				{ Directions.Right, new Position(1, 0, 0)},
				{ Directions.UpLeft, new Position(-1, 0, -1)},
				{ Directions.UpRight, new Position(1, 0, -1)},
				{ Directions.DownLeft, new Position(-1, 0, 1)},
				{ Directions.DownRight, new Position(1, 0, 1)},
				{ Directions.FloorUp, new Position(0, -1, 0)},
				{ Directions.FloorDown, new Position(0, 1, 0)}
            };
	}
}