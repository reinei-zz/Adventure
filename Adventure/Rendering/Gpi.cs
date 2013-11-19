using libtcod;

//GPI stands for: General Programming Interface

namespace Adventure
{
	//class Gpi
	//{
	//}

    public class Menu
    {

		public void Draw(Position playerPos)
		{
			int width = GameLoop.Console.getWidth();
			int height = GameLoop.Console.getHeight();
			string s = playerPos.ToString();

			GameLoop.Console.rect(0, height - 5, width, 4, true);

			GameLoop.Console.setForegroundColor(TCODColor.lightGrey);
			for (int x = 1; x < width - 1 ; x++)
			{
				GameLoop.Console.putChar(x, height - 5, (int)TCODSpecialCharacter.DoubleHorzLine);
			}
			for (int x = 1; x < width - 1; x++)
			{
				GameLoop.Console.putChar(x, height - 1, (int)TCODSpecialCharacter.DoubleHorzLine);
			}

			for (int y = height - 4; y < height - 1; y++)
			{
				GameLoop.Console.putChar(0, y, (int)TCODSpecialCharacter.DoubleVertLine);
			}
			for (int y = height - 4; y < height - 1; y++)
			{
				GameLoop.Console.putChar(width - 1, y, (int)TCODSpecialCharacter.DoubleVertLine);
			}

			//Corners (in order: top right, bottom Right, bottom left, top left
			GameLoop.Console.putChar(width - 1, height - 5, (int)TCODSpecialCharacter.DoubleNE);
			GameLoop.Console.putChar(width - 1, height - 1, (int)TCODSpecialCharacter.DoubleSE);
			GameLoop.Console.putChar(0, height - 1, (int)TCODSpecialCharacter.DoubleSW);
			GameLoop.Console.putChar(0, height - 5, (int)TCODSpecialCharacter.DoubleNW);

			GameLoop.Console.putChar(width - 15, height - 5, (int)TCODSpecialCharacter.DoubleTeeSouth);
			GameLoop.Console.putChar(width - 15, height - 4, (int)TCODSpecialCharacter.DoubleVertLine);
			GameLoop.Console.putChar(width - 15, height - 3, (int)TCODSpecialCharacter.DoubleTeeEast);
			for (int x = width - 14; x < width - 1; x++)
			{
				GameLoop.Console.putChar(x, height - 3, (int)TCODSpecialCharacter.DoubleHorzLine);
			}
			GameLoop.Console.putChar(width - 1, height - 3, (int)TCODSpecialCharacter.DoubleTeeWest);


			//Border finished
			GameLoop.Console.setForegroundColor(TCODColor.white);

			GameLoop.Console.print(width - s.Length - 1, height - 4, s);
		}
     }

	public class Rect
	{
		public long X, Y, W, H;

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

	struct ConsoleChar
	{
		public char Char;
		public TCODColor FCol;
		public TCODColor BCol;
		public ConsoleChar(char Char, TCODColor FCol, TCODColor BCol)
		{
			this.Char = Char;
			this.FCol = FCol;
			this.BCol = BCol;
		}
	}
}