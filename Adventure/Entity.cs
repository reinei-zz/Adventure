using System;

namespace Adventure
{
	public abstract class Entity
	{
		public int Health {	get; private set; }
		
		protected float[] resistances {get; private set;}
		protected byte[] blocks {get; private set;}
		
		protected Entity(int health)
		{
			this.Health = health;
			this.resistances = new float[32];
			this.blocks = new byte[32];
		}
		
		public bool damage(int amount, DamageType d)
		{
			if (!MathHelper.blocks(amount, d, this.blocks))
			{
				amount = MathHelper.damageAfterResistance(amount, d, resistances);
				
				this.Health -= amount;
				if (this.Health <= 0)
				{
					this.Health = 0;
					return true;
				}
			}
			return false;
		}
	}
}

