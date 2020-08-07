using System;

namespace Sce.PlayStation.Core
{
	/// <summary>a scalar normalized unsigned byte</summary>
	public struct UByteN : IEquatable<UByteN>
	{
		/// <summary>constructor taking a float to convert to normalized unsigned byte</summary>
		/// <param name="f">the float to convert</param>
		public UByteN(float f)
		{
			if (f < 0f)
			{
				f = 0f;
			}
			if (f > 1f)
			{
				f = 1f;
			}
			this.Bits = (byte)(f * 255f + 0.5f);
		}

		/// <summary>return the float value of this</summary>
		/// <returns>the float value of this</returns>
		public float ToFloat()
		{
			return (float)this.Bits * 0.003921569f;
		}

		/// <summary>equality test</summary>
		/// <param name="v">the value to compare this to</param>
		/// <returns>true if this == v, false otherwise</returns>
		public bool Equals(UByteN v)
		{
			return this.Bits == v.Bits;
		}

		/// <summary>equality test</summary>
		/// <param name="o">the object to compare this to</param>
		/// <returns>true if this == o, false otherwise</returns>
		public override bool Equals(object o)
		{
			return o is UByteN && this.Equals((UByteN)o);
		}

		/// <summary>get the string representation of float value</summary>
		/// <returns>the string representation of float value</returns>
		public override string ToString()
		{
			return this.ToFloat().ToString();
		}

		/// <summary>gets the hash code for this</summary>
		/// <returns>integer hash code</returns>
		public override int GetHashCode()
		{
			return (int)this.Bits;
		}

		/// <summary>equality operator</summary>
		/// <param name="v1">value 1</param>
		/// <param name="v2">value 2</param>
		/// <returns>true if value 1 == value 2, false otherwise</returns>
		public static bool operator ==(UByteN v1, UByteN v2)
		{
			return v1.Bits == v2.Bits;
		}

		/// <summary>not equals operator</summary>
		/// <param name="v1">value 1</param>
		/// <param name="v2">value 2</param>
		/// <returns>true if value 1 != value 2, false otherwise</returns>
		public static bool operator !=(UByteN v1, UByteN v2)
		{
			return v1.Bits != v2.Bits;
		}

		/// <summary>float casting operator</summary>
		/// <param name="v">the value to convert to float</param>
		/// <returns>the float value</returns>
		public static implicit operator float(UByteN v)
		{
			return v.ToFloat();
		}

		/// <summary>normalized unsigned byte casting operator</summary>
		/// <param name="f">the float to convert to normalized unsigned byte</param>
		/// <returns>the normalized unsigned byte value</returns>
		public static explicit operator UByteN(float f)
		{
			return new UByteN(f);
		}

		/// <summary>the byte data</summary>
		public byte Bits;
	}
}
