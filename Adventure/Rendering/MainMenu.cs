using System.Collections.Generic;
using libtcod;

namespace Adventure
{
	public class MainMenu : Screen
	{
		internal List<Button> Buttons = new List<Button>();

		public MainMenu()
			: base()
		{
			int HalfW = (int)(this.Width / 2);
			int HalfH = (int)(this.Height / 2);

			Buttons.Add(new Button("Start", HalfW, HalfH - 1, TCODColor.white, TCODColor.darkGrey, true, Startup));
			Buttons.Add(new Button("Credits", HalfW, HalfH + 1, TCODColor.white, TCODColor.darkGrey, true, null));
			Buttons.Add(new Button("Exit :(", HalfW, HalfH + 3, TCODColor.white, TCODColor.darkGrey, true, null));
		}

		public override void Draw()
		{
			GameLoop.Console.setForegroundColor(TCODColor.green);
			GameLoop.Console.setBackgroundColor(TCODColor.darkGrey);
			TCODConsole.root.clear();

			foreach (Button b in Buttons)
			{
				b.Draw();
			}
		}

		public override void Update(TCODKey k, TCODMouseData m)
		{
			foreach (Button b in Buttons)
			{
				b.Update(m);
			}
		}

		public void Startup()
		{
			GameLoop.Game.SetScreen(Screens.WorldScreen);
		}
	}
}