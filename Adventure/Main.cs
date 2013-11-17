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
			TCODConsole.initRoot(51, 51, "test", false, TCODRendererType.SDL);

#if !DEBUG
			TCODConsole.credits();
#endif

			//Prepare
			TCODConsole.root.clear();
			GameLoop.Game.Setup();
			Screens.Setup();

			bool run = !TCODConsole.isWindowClosed();
			while (run)
			{
				//Events
				TCODKey event_key = TCODConsole.checkForKeypress();
				TCODMouseData event_mouse = TCODMouse.getStatus();

				//Update & Draw
				GameLoop.Game.Draw();
				GameLoop.Game.Update(event_key, event_mouse);

				//Finish
				TCODConsole.flush();
				
				//Should exit?
				if (!GameLoop.Game.ShouldPause())
				{
					while (TCODConsole.checkForKeypress().KeyCode != TCODKeyCode.Space && !TCODConsole.isWindowClosed())
					{
						Sleep(0.01f);
					}
				}

				run = !TCODConsole.isWindowClosed();
				run = run && !(event_key.KeyCode == TCODKeyCode.Escape);
			}
		}


		/*while (TCODConsole.checkForKeypress().KeyCode != TCODKeyCode.Space && !TCODConsole.isWindowClosed())
				{
					Sleep(0.01f);
				}*/

		//Easteregg!
		/*
		private static String cake = 	"            ,:/+/-" + '\n' +
										"            /M/              .,-=;//;-" + '\n' +
										"       .:/= ;MH/,    ,=/+%$XH@MM#@:" + '\n' +
										"      -$##@+$###@H@MMM#######H:.    -/H#" + '\n' +
										" .,H@H@ X######@ -H#####@+-     -+H###@X" + '\n' +
										"  .,@##H;      +XM##M/,     =%@###@X;-" + '\n' +
										"X%-  :M##########$.    .:%M###@%:" + '\n' +
										"M##H,   +H@@@$/-.  ,;$M###@%,          -" + '\n' +
										"M####M=,,---,.-%%H####M$:          ,+@##" + '\n' +
										"@##################@/.         :%H##@$-" + '\n' +
										"M###############H,         ;HM##M$=" + '\n' +
										"#################.    .=$M##M$=" + '\n' +
										"################H..;XM##M$=          .:+" + '\n' +
										"M###################@%=           =+@MH%" + '\n' +
										"@################M/.          =+H#X%=" + '\n' +
										"=+M##############M,       -/X#X+;." + '\n' +
										"  .;XM##########H=    ,/X#H+:," + '\n' +
										"     .=+HM######M+/+HM@+=." + '\n' +
										"         ,:/%XM####H/." + '\n' +
										"              ,.:=-." + '\n';*/
	}
}