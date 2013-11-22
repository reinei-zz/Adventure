using System;
using System.Reflection;

namespace Adventure
{
	internal class DamageAttr : Attribute
	{
		internal DamageAttr(bool block, bool resist)
		{
			this.Blockable = block;
			this.Resistable = resist;
		}

		public bool Blockable { get; private set; }

		public bool Resistable { get; private set; }
	}

	public static class DamageTypes
	{
		public static bool isBlockable(this DamageType d)
		{
			DamageAttr attr = GetAttr(d);
			return attr.Blockable;
		}

		public static bool isResistable(this DamageType d)
		{
			DamageAttr attr = GetAttr(d);
			return attr.Resistable;
		}

		internal static bool[] getCombinations(this DamageType d)
		{
			bool[] ret = new bool[32];
			byte i = 0;
			for (uint j = 1; j <= 2147483648; )
			{
				if (((uint)d & j) != 0)
					ret[i] = true;
				i++;
				j *= 2;
			}
			return ret;
		}

		//All checks
		public static bool isPhysical(this DamageType d)
		{
			return (d & DamageType.Physical) != 0 ? true : false;
		}

		public static bool isMagical(this DamageType d)
		{
			return (d & DamageType.Magical) != 0 ? true : false;
		}

		public static bool isItem(this DamageType d)
		{
			return (d & DamageType.Item) != 0 ? true : false;
		}

		//Attribute stuff
		private static DamageAttr GetAttr(DamageType p)
		{
			return (DamageAttr)Attribute.GetCustomAttribute(ForValue(p), typeof(DamageAttr));
		}

		private static MemberInfo ForValue(DamageType p)
		{
			return typeof(DamageType).GetField(Enum.GetName(typeof(DamageType), p));
		}
	}

	[Flags]
	public enum DamageType : uint
	{
		[DamageAttr(true, true)]
		Physical = 1,

		[DamageAttr(true, true)]
		Magical = 2,

		[DamageAttr(true, true)]
		Item = 4,

		[DamageAttr(false, true)]
		Poison = 8,

		[DamageAttr(false, true)]
		Fire = 16,

		[DamageAttr(false, false)]
		Unknown = 2147483648
	}
}