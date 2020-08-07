using System;

namespace Sce.PlayStation.Core
{
	/// <summary>vector of 2 normalized unsigned bytes</summary>
	// 
	public struct UByte2N : IEquatable<UByte2N>
	{
		/// <summary>constructor taking 2 scalar floats</summary>
		/// <param name="x">x value to init with</param>
		/// <param name="y">y value to init with</param>

		public UByte2N(float x, float y)
		{
			this.X = new UByteN(x);
			this.Y = new UByteN(y);
		}

		/// <summary>constructor taking a Vector2</summary>
		/// <param name="v">the vector to init with</param>

		public UByte2N(Vector2 v)
		{
			this.X = new UByteN(v.X);
			this.Y = new UByteN(v.Y);
		}

		/// <summary>return the vector as a Vector2</summary>
		/// <returns>the vector as a Vector2</returns>

		public Vector2 ToVector2()
		{
			return new Vector2(this.X.ToFloat(), this.Y.ToFloat());
		}

		/// <summary>equality test</summary>
		/// <param name="v">the vector to compare this to</param>
		/// <returns>true if this == v, false otherwise</returns>

		public bool Equals(UByte2N v)
		{
			return this.X.Equals(v.X) && this.Y.Equals(v.Y);
		}

		/// <summary>equality test</summary>
		/// <param name="o">the object to compare this to</param>
		/// <returns>true if this == o, false otherwise</returns>

		public override bool Equals(object o)
		{
			return o is UByte2N && this.Equals((UByte2N)o);
		}

		/// <summary>get the string representation of vector value</summary>
		/// <returns>the string representation of vector value</returns>

		public override string ToString()
		{
			return string.Format("({0},{1})", this.X, this.Y);
		}

		/// <summary>gets the hash code for this</summary>
		/// <returns>integer hash code</returns>

		public override int GetHashCode()
		{
			return (int)(this.X.Bits ^ this.Y.Bits);
		}

		/// <summary>equality operator</summary>
		/// <param name="v1">vector 1</param>
		/// <param name="v2">vector 2</param>
		/// <returns>true if vector 1 == vector 2, false otherwise</returns>

		public static bool operator ==(UByte2N v1, UByte2N v2)
		{
			return v1.Equals(v2);
		}

		/// <summary>not equals operator</summary>
		/// <param name="v1">vector 1</param>
		/// <param name="v2">vector 2</param>
		/// <returns>true if v 1 != v 2, false otherwise</returns>

		public static bool operator !=(UByte2N v1, UByte2N v2)
		{
			return !v1.Equals(v2);
		}

		/// <summary>X</summary>

		public UByteN X;

		/// <summary>Y</summary>

		public UByteN Y;
	}
}
