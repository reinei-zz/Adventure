namespace Adventure
{
	public abstract class Direction
	{
		public Position Pos;

		private string Name
		{
			get
			{
				return this.ToString();
			}
		}

		public class Up : Direction
		{
			public static new Position Pos = new Position(0, 0, -1);
		}

		public class Down : Direction
		{
			public static new Position Pos = new Position(0, 0, 1);
		}

		public class Left : Direction
		{
			public static new Position Pos = new Position(-1, 0, 0);
		}

		public class Right : Direction
		{
			public static new Position Pos = new Position(1, 0, 0);
		}

		public class UpLeft : Direction
		{
			public static new Position Pos = new Position(-1, 0, -1);
		}

		public class UpRight : Direction
		{
			public static new Position Pos = new Position(1, 0, -1);
		}

		public class DownLeft : Direction
		{
			public static new Position Pos = new Position(-1, 0, 1);
		}

		public class DownRight : Direction
		{
			public static new Position Pos = new Position(1, 0, 1);
		}

		public class FloorUp : Direction
		{
			public static new Position Pos = new Position(0, -1, 0);
		}

		public class FloorDown : Direction
		{
			public static new Position Pos = new Position(0, 1, 0);
		}
	}
}