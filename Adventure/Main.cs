using System;

namespace Adventure
{
	class MainClass
	{
		
		//dur is in seconds!
		public static void sleep(float dur)
		{
			System.Threading.Thread.Sleep((int)(dur * 1000));
		}
		
		public static void Main (string[] args)
		{
            libtcod.TCODConsole.initRoot(30, 30, "test");
            sleep(10.0f);
		}
		
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
