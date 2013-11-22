namespace Adventure.Entitys
{
	public class Entity
	{
		//State
		public Position Pos;
		public double Health { get { return this.health; } }

		//Abilitys
		public bool CanWalk;

		//Protected
		protected double health;
		protected long fallcount;

		protected float[] Resistances { get; private set; }
		protected byte[] Blocks { get; private set; }

		public Entity(Position pos, double health, bool canwalk)
		{
			this.Pos = pos;
			this.health = health;
			this.fallcount = 0;

			this.CanWalk = canwalk;

			this.Resistances = new float[32];
			this.Blocks = new byte[32];
		}

		public bool Damage(int amount, DamageType d)
		{
			if (!MathHelper.blocks(amount, d, this.Blocks))
			{
				amount = MathHelper.damageAfterResistance(amount, d, Resistances);

				this.health -= amount;
				MathHelper.Clamp(this.health, 0, 1);
				if (this.health <= 0)
				{
					this.health = 0;
					return true;
				}
			}
			return false;
		}

		public bool Walk(Directions dir)
		{
			if (this.CanWalk)
			{
				Position dest_pos = this.Pos + Direction.DirectionPositions[dir];
				Tile dest_tile = GameLoop.Game.world.GetTile(dest_pos);
				if (Tiles.Modes[(int)dest_tile] != TileMode.Solid)
				{
					GameLoop.Game.world.MoveEntity(this, this.Pos + Direction.DirectionPositions[dir]);
					GameLoop.Game.world.Event_Noise(this.Pos, World.NoiseType.Step);
					return true;
				}
			}
			return false;
		}

		public void Event_Noise(Position pos, double amount)
		{
		}

		public void Physics_Update()
		{
			//Variables
			bool repeat;
			Position pos_below;
			Tile tile_below;

			while (true)
			{
				repeat = false;
				pos_below = this.Pos.translate(0, 1, 0);
				tile_below = GameLoop.Game.world.GetTile(pos_below);

				//Check floor
				if (Tiles.Modes[(int)tile_below] == TileMode.Solid)
				{
					if (fallcount > 0)
					{
						//Damage if too high
					}
					this.fallcount = 0;
				}
				else //Fall down
				{
					GameLoop.Game.world.MoveEntity(this, pos_below);
					this.fallcount++;
					repeat = true;
				}

				//Repeat
				if (!repeat)
				{
					break;
				}
			}			
		}

	}
}