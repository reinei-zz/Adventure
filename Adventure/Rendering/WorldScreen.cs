using System;
using libtcod;

namespace Adventure
{
	public class WorldScreen : Screen
	{
		public WorldScreen() : base()
		{

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
				PlayerPos = PlayerPos.translate(0, -1, 0);
			}
			if (k.Character == 's')
			{
				PlayerPos = PlayerPos.translate(0, 1, 0);
			}
		}

		private Position PlayerPos = new Position(100, 100, 5);

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
					Position p = PlayerPos.translate(x, y, 0);
					Tile t = GameLoop.Game.world.GetTile(p);
					int ScreenX = halfw + x;
					int ScreenY = halfh + y;
					GameLoop.Console.print(ScreenX, ScreenY, t.Visual.ToString());
				}
			}
			GameLoop.Console.print(halfw, this.Height - 5, PlayerPos.ToString());
		}
	}
}
