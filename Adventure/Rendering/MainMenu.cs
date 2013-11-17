using libtcod;

namespace Adventure
{
	public class MainMenu : Screen
	{
		internal Button Start;

		public MainMenu()
			: base()
		{
			int HalfW = (int)(this.Width / 2);
			int HalfH = (int)(this.Height / 2);
			Start = new Button("start", HalfW - 2, HalfH + 1, Startup);
			this.Pause = true;
		}

		public override void Render()
		{
			//GameLoop.console.print(0, 0, "hello world!");
			Start.Render();
		}

		public override void Handle(TCODKey k, TCODMouseData m)
		{
			Start.Press(m);
		}

		public void Startup()
		{
			GameLoop.Console.print((int)(this.Width / 2) - 2, (int)(this.Height / 2), "Starting...");
		}
	}
}