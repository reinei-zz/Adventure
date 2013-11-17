﻿using libtcod;

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

		public override void Draw()
		{
			GameLoop.Console.setForegroundColor(TCODColor.green);
			GameLoop.Console.setBackgroundColor(TCODColor.darkGrey);
			TCODConsole.root.clear();

			Start.Draw();
		}

		public override void Update(TCODKey k, TCODMouseData m)
		{
			Start.Press(m);
		}

		public void Startup()
		{
			GameLoop.Console.print((int)(this.Width / 2) - 2, (int)(this.Height / 2), "Starting...");
		}
	}
}