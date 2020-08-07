using System;

namespace Sce.PlayStation.Core
{
	/// <summary>vector of 2 unsigned shorts</summary>
	public struct UByte2 : IEquatable<UByte2>
	{
		/// <summary>constructor taking 2 scalar integers</summary>
		/// <param name="x">x value to init with</param>
		/// <param name="y">y value to init with</param>
		public UByte2(int x, int y)
		{
			this.X = (byte)x;
			this.Y = (byte)y;
		}

		/// <summary>constructor taking a Vector2</summary>
		/// <param name="v">the vector to init with</param>
		public UByte2(Vector2 v)
		{
			this.X = (byte)v.X;
			this.Y = (byte)v.Y;
		}

		/// <summary>return the vector as a Vector2</summary>
		/// <returns>the vector as a Vector2</returns>
		public Vector2 ToVector2()
		{
			return new Vector2((float)this.X, (float)this.Y);
		}

		/// <summary>equality test</summary>
		/// <param name="v">the vector to compare this to</param>
		/// <returns>true if this == v, false otherwise</returns>
		public bool Equals(UByte2 v)
		{
			return this.X.Equals(v.X) && this.Y.Equals(v.Y);
		}

		/// <summary>equality test</summary>
		/// <param name="o">the object to compare this to</param>
		/// <returns>true if this == o, false otherwise</returns>
		public override bool Equals(object o)
		{
			return o is UByte2 && this.Equals((UByte2)o);
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
			return (int)(this.X ^ this.Y);
		}

		/// <summary>equality operator</summary>
		/// <param name="v1">vector 1</param>
		/// <param name="v2">vector 2</param>
		/// <returns>true if vector 1 == vector 2, false otherwise</returns>
		public static bool operator ==(UByte2 v1, UByte2 v2)
		{
			return v1.Equals(v2);
		}

		/// <summary>not equals operator</summary>
		/// <param name="v1">vector 1</param>
		/// <param name="v2">vector 2</param>
		/// <returns>true if v 1 != v 2, false otherwise</returns>
		public static bool operator !=(UByte2 v1, UByte2 v2)
		{
			return !v1.Equals(v2);
		}

		/// <summary>X</summary>
		public byte X;

		/// <summary>Y</summary>
		public byte Y;
	}
}
