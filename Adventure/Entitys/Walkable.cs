using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Adventure.Entitys
{
	public abstract class Walkable : Entity
	{
		void Walk(Direction dir)
		{

			//Collision checks missing!

			this.Pos += dir.Pos;
		}
	}
}
