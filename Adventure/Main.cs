using libtcod;

namespace Adventure
{
	internal class MainClass
	{
		//dur is in seconds!
		public static void Sleep(float dur)
		{
			System.Threading.Thread.Sleep((int)(dur * 1000));
		}

		public static void Main(string[] args)
		{
			TCODConsole.setCustomFont("terminal.png", (int)TCODFontFlags.LayoutAsciiInColumn);
			TCODConsole.setKeyboardRepeat(500, 100);
			TCODConsole.initRoot(51, 51, "test", false, TCODRendererType.SDL);

#if !DEBUG
			TCODConsole.credits();
#endif

			//Prepare
			TCODConsole.root.clear();
			GameLoop.Game.Init();
			Screens.Init();
			Tiles.Init();

			//Add player
			GameLoop.Game.Player = new Entitys.Entity(new Position(9, 0, 9), 1, true);
			GameLoop.Game.world.AddEntity(GameLoop.Game.Player);
#if DEBUG
			//Add debug tiles
			for (int x = 0; x < 100; x++)
			{
				GameLoop.Game.world.SetTile(new Position(10 + x, 0, 10 + x), Tile.Stone);
			}
#endif

			while (GameLoop.Game.Run)
			{
				//Events
				TCODKey event_key = TCODConsole.checkForKeypress((int)TCODKeyStatus.KeyPressed);
				TCODMouseData event_mouse = TCODMouse.getStatus();

				//Update & Draw
				GameLoop.Game.Draw();
				GameLoop.Game.Update(event_key, event_mouse);

				//Finish
				TCODConsole.flush();

			}
		}


		/*while (TCODConsole.checkForKeypress().KeyCode != TCODKeyCode.Space && !TCODConsole.isWindowClosed())
				{
					Sleep(0.01f);
				}*/

	}
}