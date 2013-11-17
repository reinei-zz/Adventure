using System;
using libtcod;

namespace Adventure
{
	public class Screen_World : Screen
	{
		internal Menu m;

		public Screen_World() : base()
		{
			m = new Menu();
		}

		public override void Update(TCODKey k, TCODMouseData m)
		{
			if (k.Character == 'd')
			{
				PlayerPos = PlayerPos.translate(1, 0, 0);
			}
			if (k.Character == 'a')
			{
				PlayerPos = PlayerPos.translate(-1, 0, 0);
			}
			if (k.Character == 'w')
			{
				PlayerPos = PlayerPos.translate(0, 0, -1);
			}
			if (k.Character == 's')
			{
				PlayerPos = PlayerPos.translate(0, 0, 1);
			}
		}

		private Position PlayerPos = new Position(100, 5, 100);

		public override void Draw()
		{
			//Get PlayerPosition
			

			//create constans that are usefull
			int halfw = (this.Width - 1) / 2;
			int halfh = (this.Height - 1) / 2;

			//Render. Currently Render full screen. We will need space for a menu later.
			for (int x = -halfw; x <= halfw; x++)
			{
				for (int y = -halfh; y <= halfh - 5; y++)
				{
					Position p = PlayerPos.translate(x, 0, y);
					Tile t = GameLoop.Game.world.GetTile(p);
					int ScreenX = halfw + x;
					int ScreenY = halfh + y;
					GameLoop.Console.print(ScreenX, ScreenY, t.Visual.ToString());
				}
			}
            GameLoop.Console.setForegroundColor(TCODColor.darkerLime);
            GameLoop.Console.putChar(halfw, halfh, 2);
            GameLoop.Console.setForegroundColor(TCODColor.white);

			m.Draw(PlayerPos);
		}
	}
}
