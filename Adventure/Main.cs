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


#if DEBUG
			bool firstrun = true;
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
				
#if DEBUG
				//Do special debug stuff here
				if (firstrun)
				{
					firstrun = false;
					GameLoop.Game.world.SetTile(new Position(110, 5, 110), new Tile(Tiles.Stone, TileMode.Solid));
				}
#endif
			}
		}


		/*while (TCODConsole.checkForKeypress().KeyCode != TCODKeyCode.Space && !TCODConsole.isWindowClosed())
				{
					Sleep(0.01f);
				}*/

	}
}