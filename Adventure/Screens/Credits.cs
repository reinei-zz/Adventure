using System.Collections.Generic;
using libtcod;

namespace Adventure
{
	public class Screen_Credits : Screen
	{
		internal List<Button> Buttons = new List<Button>();

		public Screen_Credits()
			: base()
		{
			int HalfW = (int)(this.Width / 2);
			int HalfH = (int)(this.Height / 2);

			Buttons.Add(new Button("Back", HalfW, Height - 3, TCODColor.grey, TCODColor.black, true, Back));
		}

		public override void Draw()
		{
			GameLoop.Console.setForegroundColor(TCODColor.crimson);
			GameLoop.Console.setBackgroundColor(TCODColor.black);
			TCODConsole.root.clear();

			string cake =
				"            ,:/+/-" + '\n' +
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
				"              ,.:=-." + "\n\n\n\n\n\n" +
				"             It's not a lie!";
			GameLoop.Console.print(6, 10, cake);

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

		public void Back()
		{
			GameLoop.Game.SetScreen(Screens.Menu);
		}
	}
}