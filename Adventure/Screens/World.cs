using System;
using System.Collections.Generic;
using libtcod;

namespace Adventure
{
	public class Screen_World : Screen
	{
		internal Menu m;
		internal Dictionary<char, Directions> player_directions;

		public Screen_World() : base()
		{
			m = new Menu();
			player_directions = new Dictionary<char,Directions>();

			//Player direction controls
			player_directions['w'] = Directions.Up;
			player_directions['s'] = Directions.Down;
			player_directions['a'] = Directions.Left;
			player_directions['d'] = Directions.Right;

			player_directions['q'] = Directions.UpLeft;
			player_directions['e'] = Directions.UpRight;

			player_directions['y'] = Directions.DownLeft;
			player_directions['z'] = Directions.DownLeft;
			player_directions['c'] = Directions.DownRight;
		}

		public override void Update(TCODKey k, TCODMouseData m)
		{

			//Player move
			Directions dir;
			if (player_directions.TryGetValue(k.Character, out dir))
			{
				Player.Walk(dir);
			}

		}

		private Entitys.Player Player = new Entitys.Player(new Position(100, 5, 100));

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
					Position p = Player.Pos.translate(x, 0, y);
					Tile t = GameLoop.Game.world.GetTile(p);
					int ScreenX = halfw + x;
					int ScreenY = halfh + y;
					GameLoop.Console.print(ScreenX, ScreenY, t.Visual.ToString());
				}
			}
            GameLoop.Console.setForegroundColor(TCODColor.darkerLime);
            GameLoop.Console.putChar(halfw, halfh, 2);
            GameLoop.Console.setForegroundColor(TCODColor.white);

			m.Draw(Player.Pos);
		}
	}
}
