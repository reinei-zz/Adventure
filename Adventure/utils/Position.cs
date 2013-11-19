using System;

namespace Adventure
{
	public struct Position
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

		public Position translate(long x, long y, long z)
		{
			return new Position(this.x + x, this.y + y, this.z + z);
		}

		public void add(long x, long y, long z)
		{
			this.x += x;
			this.y += y;
			this.z += z;
		}

		public static Position operator +(Position c1, Position c2)
		{
			return new Position(c1.x + c2.x, c1.y + c2.y, c1.z + c2.z);
		}

		public static Position operator -(Position c1, Position c2)
		{
			return new Position(c1.x - c2.x, c1.y - c2.y, c1.z - c2.z);
		}

		public static bool operator ==(Position c1, Position c2)
		{
			return (c1.x == c2.x) && (c1.y == c2.y) && (c1.z == c2.z);
		}

		public static bool operator !=(Position c1, Position c2)
		{
			return (c1.x != c2.x) || (c1.y != c2.y) || (c1.z != c2.z);
		}

		public static double Distance(Position c1, Position c2)
		{
			return Math.Sqrt(Math.Pow(c2.x - c1.x, 2) + Math.Pow(c2.y - c1.y, 2) + Math.Pow(c2.z - c1.z, 2));
		}

		public double Distance(Position c)
		{
			return Distance(this, c);
		}
	}
}