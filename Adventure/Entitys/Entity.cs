namespace Adventure.Entitys
{
	public abstract class Entity
	{
		public Position Pos { get { return this.pos; } }

		public double Health { get { return this.health; } }

		protected Position pos;
		protected double health;

		protected float[] Resistances { get; private set; }

		protected byte[] Blocks { get; private set; }

		protected Entity(double health = 1)
		{
			this.health = health;
			this.Resistances = new float[32];
			this.Blocks = new byte[32];
		}

		public bool Damage(int amount, DamageType d)
		{
			if (!MathHelper.blocks(amount, d, this.Blocks))
			{
				amount = MathHelper.damageAfterResistance(amount, d, Resistances);

				this.health -= amount;
				if (this.health <= 0)
				{
					this.health = 0;
					return true;
				}
			}
			return false;
		}
	}
}