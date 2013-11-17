using libtcod;

//GPI stands for: General Programming Interface

namespace Adventure
{
	//class Gpi
	//{
	//}

    public class Menu
    {
		internal static int BaseChar = 12*15 + 4;
		internal int HBorder = BaseChar + 21;
		internal int VBorder = BaseChar + 2;

		public void Draw(Position playerPos)
		{
			int width = GameLoop.Console.getWidth();
			int height = GameLoop.Console.getHeight();

			GameLoop.Console.setForegroundColor(TCODColor.lightGrey);
			for (int x = 1; x < width - 1 ; x++)
			{
				GameLoop.Console.putChar(x, height - 5, HBorder);
			}
			for (int x = 1; x < width - 1; x++)
			{
				GameLoop.Console.putChar(x, height - 1, HBorder);
			}

			for (int y = height - 4; y < height - 1; y++)
			{
				GameLoop.Console.putChar(0, y, VBorder);
			}
			for (int y = height - 4; y < height - 1; y++)
			{
				GameLoop.Console.putChar(width - 1, y, VBorder);
			}

			//Corners (in order: top right, bottom Right, bottom left, top left
			GameLoop.Console.putChar(width - 1, height - 5, BaseChar + 3);
			GameLoop.Console.putChar(width - 1, height - 1, BaseChar + 4);
			GameLoop.Console.putChar(0, height - 1, BaseChar + 16);
			GameLoop.Console.putChar(0, height - 5, BaseChar + 17);

			//Border finished
			GameLoop.Console.setForegroundColor(TCODColor.white);

			string s = playerPos.ToString();
			GameLoop.Console.print(width - s.Length - 1, height - 4, s);
		}
     }

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