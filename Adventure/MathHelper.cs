using System;

namespace Adventure
{
	public class MathHelper
	{
		public static int damageAfterResistance(int amount, DamageType d, float[] resistances)
		{
			if (d.isResistable())
			{
				float resist = resistances[(int)Math.Log((uint)d,2)];
				return (int)Math.Round(amount * resist);
			}
			return amount;
		}
		
		private static Random blockRand = new Random(System.DateTime.Now.Second);
		
		//damage gets passed for later use (maybe)
		public static bool blocks(int damage, DamageType d, byte[] blockchances)
		{
			if (d.isBlockable())
			{
				return blockRand.Next(101) <= blockchances[(int)Math.Log ((uint)d, 2)];
			}
			return false;
		}
	}
}

