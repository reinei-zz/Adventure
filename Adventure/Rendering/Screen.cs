using libtcod;

namespace Adventure
{
	//Screen Stuff
	public abstract class Screen
	{
		protected int Width, Height;

		public Screen()
		{
			this.Width = GameLoop.Console.getWidth();
			this.Height = GameLoop.Console.getHeight();
		}

		//this is ONLY supposed to hadle rendering
		public abstract void Draw();

		public abstract void Update(TCODKey k, TCODMouseData m);

		internal class Button
		{
			public delegate void Action();

			protected string Text;
			protected Rect r;
			protected TCODColor fcol;
			protected int X, Y;
			protected TCODColor bcol;
			protected TCODAlignment align;
			protected Action A;
			protected bool hover;

			public Button(string s, int x, int y, int w, int h, TCODColor fcol, TCODColor bcol, TCODAlignment align, Action a)
			{
				this.Text = s;
				r = new Rect(x, y, w, h);
				this.X = x;
				this.Y = y;
				this.fcol = fcol;
				this.bcol = bcol;
				this.align = align;
				this.A = a;
			}

			public Button(string s, int x, int y, TCODColor fcol, TCODColor bcol, TCODAlignment align, Action a)
				: this(s, x, y, s.Length, 1, fcol, bcol, align, a)
			{
			}

			public void Draw()
			{
				//Color based on mouse hover
				if (hover)
				{
					TCODColor finv = new TCODColor(-((short)fcol.Red - 255), -((short)fcol.Green - 255), -((short)fcol.Blue - 255));
					TCODColor binv = new TCODColor(-((short)bcol.Red - 255), -((short)bcol.Green - 255), -((short)bcol.Blue - 255));
					GameLoop.Console.setForegroundColor(finv);
					GameLoop.Console.setBackgroundColor(binv);
				}
				else
				{
					GameLoop.Console.setForegroundColor(fcol);
					GameLoop.Console.setBackgroundColor(bcol);
				}
				
				//Draw
				GameLoop.Console.printEx(X, Y, TCODBackgroundFlag.Set, align, Text);
			}

			public void Update(TCODMouseData m)
			{
				bool intersects = r.Intersects(m);
				hover = intersects;
				if (intersects && m.LeftButton)
				{
					A();
				}
			}
		}
	}
}