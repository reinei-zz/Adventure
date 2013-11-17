using System;
using libtcod;

namespace Adventure
{
	//class Gui
	//{
	//}

	public class Rect
	{
		private int X, Y, W, H;

		public Rect(int x, int y, int w, int h)
		{
			this.X = x;
			this.Y = y;
			this.W = w;
			this.H = h;
		}

		public bool Intersects(TCODMouseData m)
		{
			if ((m.CellX >= X && m.CellX <= X + W) && (m.CellY >= Y && m.CellY < Y + H))
				return true;
			return false;
		}

		public bool Intersects(Rect r)
		{
			if ((this.X == r.X) && (this.Y == r.Y))
				return true;
			if ((((this.X + this.W) >= r.X) && (this.X <= r.X)) && (((this.Y + this.H) >= r.Y) && (this.Y <= r.Y)))
				return true;
			if ((((r.X + r.W) >= this.X) && (r.X <= this.X)) && (((r.Y + r.H) >= this.Y) && (r.Y <= this.Y)))
				return true;
			return false;
		}
	}
}
