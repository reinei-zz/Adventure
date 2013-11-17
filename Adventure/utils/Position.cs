﻿namespace Adventure
{
	internal struct Position
	{
		public long x, y, z;

		public Position(long x, long y, long z)
		{
			this.x = x;
			this.y = y;
			this.z = z;
		}

		public override string ToString()
		{
			return "(" + this.x.ToString() + "," + this.y.ToString() + "," + this.z.ToString() + ")";
		}

		public Position translate(int x, int y, int z)
		{
			return new Position(this.x + x, this.y + y, this.z + z);
		}

		public static Position operator +(Position c1, Position c2)
		{
			return new Position(c1.x + c2.x, c1.y + c2.y, c1.z + c2.z);
		}

		public static Position operator -(Position c1, Position c2)
		{
			return new Position(c1.x - c2.x, c1.y - c2.y, c1.z - c2.z);
		}
	}
}