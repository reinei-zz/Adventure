using System.Collections.Generic;
using libtcod;

namespace Adventure
{
	public class Screen_Menu : Screen
	{
		internal List<Button> Buttons = new List<Button>();

		public Screen_Menu()
			: base()
		{
			int HalfW = (int)(this.Width / 2);
			int HalfH = (int)(this.Height / 2);

			Buttons.Add(new Button("Start", HalfW, HalfH - 1, TCODColor.white, TCODColor.darkGrey, true, Start));
			Buttons.Add(new Button("Credits", HalfW, HalfH + 1, TCODColor.white, TCODColor.darkGrey, true, Credits));
			Buttons.Add(new Button("Exit :(", HalfW, HalfH + 3, TCODColor.red, TCODColor.darkGrey, true, Exit));
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

		private void Start()
		{
			GameLoop.Game.SetScreen(Screens.World);
		}

		private void Credits()
		{
			GameLoop.Game.SetScreen(Screens.Credits);
		}

		private void Exit()
		{
			GameLoop.Game.Exit();
		}
	}
}