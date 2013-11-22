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
			GameLoop.Game.Player.Physics_Update();
			//Player move
			Directions dir;
			if (player_directions.TryGetValue(k.Character, out dir))
			{
				GameLoop.Game.Player.Walk(dir);
			}

		}

		public override void Draw()
		{

			//create constans that are usefull
			int halfw = (this.Width - 1) / 2;
			int halfh = (this.Height - 1) / 2;

			//Render the current Layer
			for (int x = -halfw; x <= halfw; x++)
			{
				for (int y = -halfh; y <= halfh - 5; y++)
				{
					Position p = GameLoop.Game.Player.Pos.translate(x, 0, y);
					Tile t = GameLoop.Game.world.GetTile(p);
					int ScreenX = halfw + x;
					int ScreenY = halfh + y;
					ConsoleChar c = Tiles.Visuals[(int)t];
					GameLoop.Console.putCharEx(ScreenX, ScreenY, c.Char, c.FCol, c.BCol);
				}
			}

			//Layer below this one.
			for (int x = -halfw; x <= halfw; x++)
			{
				for (int y = -halfh; y <= halfh - 5; y++)
				{
					int ScreenX = halfw + x;
					int ScreenY = halfh + y;
					
					Position p = GameLoop.Game.Player.Pos.translate(x, 0, y);
					
					if (Tiles.TFlags[(int)GameLoop.Game.world.GetTile(p)] == TileFlags.transparent)
					{
						p = p.translate(0, -1, 0);
						Tile t = GameLoop.Game.world.GetTile(p);
						ConsoleChar c = Tiles.BelowVisuals[(int)t];
						c.FCol = TCODColor.darkGrey.Multiply(c.FCol);
						c.BCol = TCODColor.darkGrey.Multiply(c.BCol);
						GameLoop.Console.putCharEx(ScreenX, ScreenY, c.Char, c.FCol, c.BCol);
					}
				}
			}

            GameLoop.Console.setForegroundColor(TCODColor.darkerLime);
            GameLoop.Console.putChar(halfw, halfh, 2);
            GameLoop.Console.setForegroundColor(TCODColor.white);

			m.Draw(GameLoop.Game.Player.Pos);
		}
	}
}
