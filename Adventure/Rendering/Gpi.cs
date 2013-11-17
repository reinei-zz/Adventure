using libtcod;

//GPI stands for: General Programming Interface

namespace Adventure
{
	//class Gpi
	//{
	//}

	public class Rect
	{
		private long X, Y, W, H;

		public Rect(long x, long y, long w, long h)
		{
			this.X = x;
			this.Y = y;
			this.W = w;
			this.H = h;
		}

		public bool Intersects(Position p)
		{
			return ((p.x >= X && p.x <= X + W) && (p.y >= Y && p.y < Y + H));
		}

		public bool Intersects(Rect r)
		{
			return ((((r.X < (this.X + this.W)) && (this.X < (r.X + r.W))) && (r.Y < (this.Y + this.H))) && (this.Y < (r.Y + r.H)));
		}

		public bool Intersects(TCODMouseData m)
		{
			return ((m.CellX >= X && m.CellX <= X + W) && (m.CellY >= Y && m.CellY < Y + H));
		}
	}
}