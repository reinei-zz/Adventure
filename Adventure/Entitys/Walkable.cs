using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Adventure.Entitys
{
	public abstract class Walkable : Entity
	{
		public void Walk(Directions dir)
		{
			Position dest_pos = this.pos + Direction.DirectionPositions[dir];
			Tile dest_tile = GameLoop.Game.world.GetTile(dest_pos);
			if (dest_tile.Mode != TileMode.Solid)
			{
				this.pos += Direction.DirectionPositions[dir];
			}
		}
	}
}
