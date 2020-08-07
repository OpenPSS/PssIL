using System;

namespace Sce.PlayStation.Core
{
	/// <summary>a scalar half</summary>
	// 
	public struct Half : IEquatable<Half>
	{
		/// <summary>constructor taking a float to convert to half</summary>
		/// <param name="f">the float to convert</param>

		public Half(float f)
		{
			this.Bits = Half.FloatToHalf(f);
		}

		/// <summary>return the float value of this</summary>
		/// <returns>the float value of this</returns>

		public float ToFloat()
		{
			return Half.HalfToFloat(this.Bits);
		}

		/// <summary>equality test</summary>
		/// <param name="h">the half to compare this to</param>
		/// <returns>true if this == h, false otherwise</returns>

		public bool Equals(Half h)
		{
			return this.Bits == h.Bits || ((this.Bits | h.Bits) & 32767) == 0;
		}

		/// <summary>equality test</summary>
		/// <param name="o">the object to compare this to</param>
		/// <returns>true if this == o, false otherwise</returns>

		public override bool Equals(object o)
		{
			return o is Half && this.Equals((Half)o);
		}

		/// <summary>get the string representation of float value</summary>
		/// <returns>the string representation of float value</returns>

		public override string ToString()
		{
			return Half.HalfToFloat(this.Bits).ToString();
		}

		/// <summary>gets the hash code for this</summary>
		/// <returns>integer hash code</returns>

		public override int GetHashCode()
		{
			return (int)this.Bits;
		}

		/// <summary>equality operator</summary>
		/// <param name="h1">half 1</param>
		/// <param name="h2">half 2</param>
		/// <returns>true if half 1 == half 2, false otherwise</returns>

		public static bool operator ==(Half h1, Half h2)
		{
			return h1.Equals(h2);
		}

		/// <summary>not equals operator</summary>
		/// <param name="h1">half 1</param>
		/// <param name="h2">half 2</param>
		/// <returns>true if half 1 != half 2, false otherwise</returns>

		public static bool operator !=(Half h1, Half h2)
		{
			return !h1.Equals(h2);
		}

		/// <summary>float casting operator</summary>
		/// <param name="h">the half to convert to float</param>
		/// <returns>the float value of the half</returns>

		public static implicit operator float(Half h)
		{
			return Half.HalfToFloat(h.Bits);
		}

		/// <summary>half casting operator</summary>
		/// <param name="f">the float to convert to half</param>
		/// <returns>the half value of the float</returns>

		public static explicit operator Half(float f)
		{
			return new Half(f);
		}


		private static ushort FloatToHalf(float f)
		{
			int num = BitConverter.ToInt32(BitConverter.GetBytes(f), 0);
			int num2 = num >> 31;
			int num3 = (num >> 23 & 255) - 112;
			int num4 = num & 8388607;
			if (num3 <= 0)
			{
				num3 = 0;
				num4 = 0;
			}
			if (num3 >= 31)
			{
				f = (float)((num3 < 143 || num4 == 0) ? 0 : 8388607);
				num3 = 31;
			}
			return (ushort)(num2 << 15 | num3 << 10 | num4 >> 13);
		}


		private static float HalfToFloat(ushort h)
		{
			int num = h >> 15;
			int num2 = (h >> 10 & 31) + 112;
			int num3 = (int)(h & 1023);
			if (num2 <= 112)
			{
				num2 = 0;
				num3 = 0;
			}
			if (num2 >= 143)
			{
				num2 = 255;
			}
			int num4 = num << 31 | num2 << 23 | num3 << 13;
			return BitConverter.ToSingle(BitConverter.GetBytes(num4), 0);
		}

		/// <summary>the half data</summary>

		public ushort Bits;
	}
}
