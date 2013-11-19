using System;

namespace Adventure
{
	public class MathHelper
	{
		public static int damageAfterResistance(int amount, DamageType d, float[] resistances)
		{
			if (d.isResistable())
			{
				float resist = resistances[(int)Math.Log((uint)d, 2)];
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
				return blockRand.Next(101) <= blockchances[(int)Math.Log((uint)d, 2)];
			}
			return false;
		}

		public static int Clamp(int value, int min, int max)
		{
			return (value < min) ? min : (value > max) ? max : value;
		}
		public static long Clamp(long value, long min, long max)
		{
			return (value < min) ? min : (value > max) ? max : value;
		}
		public static float Clamp(float value, float min, float max)
		{
			return (value < min) ? min : (value > max) ? max : value;
		}
		public static double Clamp(double value, double min, double max)
		{
			return (value < min) ? min : (value > max) ? max : value;
		}

	}
}