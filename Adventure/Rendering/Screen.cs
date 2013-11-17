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
		public abstract void Draw();

		public abstract void Update(TCODKey k, TCODMouseData m);

		internal class Button
		{
			public delegate void Action();

			protected string Text;
			protected Rect r;
			protected int X, Y;
			protected Action A;

			public Button(string s, int x, int y, int w, int h, Action a)
			{
				this.Text = s;
				r = new Rect(x, y, w, h);
				this.X = x;
				this.Y = y;
				this.A = a;
			}

			public Button(string s, int x, int y, Action a)
				: this(s, x, y, s.Length, 1, a)
			{
			}

			public void Draw()
			{
				GameLoop.Console.print(X, Y, Text);
			}

			public void Press(TCODMouseData m)
			{
				if (r.Intersects(m) && m.LeftButton)
				{
					A();
				}
			}
		}
	}
}