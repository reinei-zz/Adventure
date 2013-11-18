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

			//Collision checks missing!

			this.pos += Direction.DirectionPositions[dir];
		}
	}
}
