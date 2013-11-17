using libtcod;

namespace Adventure
{
	//Screen Stuff
	public abstract class Screen
	{
		protected int Width, Height;
		public bool Pause { get; protected set; }

		public Screen()
		{
			this.Width = GameLoop.Console.getWidth();
			this.Height = GameLoop.Console.getHeight();
			this.Pause = false;
		}

		//this is ONLY supposed to hadle rendering
		public abstract void Render();

		public abstract void Handle(TCODKey k, TCODMouseData m);

		internal class Button
		{
			public delegate void Action();

			protected string Text;
			protected int X, Y, W, H;
			protected Action A;

			public Button(string s, int x, int y, int w, int h, Action a)
			{
				this.Text = s;
				this.X = x;
				this.Y = y;
				this.W = w;
				this.H = h;
				this.A = a;
			}

			public Button(string s, int x, int y, Action a)
				: this(s, x, y, s.Length, 1, a)
			{
			}

			public void Render()
			{
				TCODConsole.root.setForegroundColor(TCODColor.green);
				TCODConsole.root.setBackgroundColor(TCODColor.darkGrey);
				TCODConsole.root.clear();
				GameLoop.Console.print(X, Y, Text);
			}

			public void Press(TCODMouseData m)
			{
				if ((m.CellX >= X && m.CellX <= X + W) && (m.CellY >= Y && m.CellY < Y + H) && m.LeftButton)
				{
					A();
				}
			}
		}
	}
}