using System;

namespace Sce.PlayStation.Core
{
	/// <summary>vector of 3 normalized unsigned bytes</summary>
	public struct UByte3N : IEquatable<UByte3N>
	{
		/// <summary>constructor taking 3 scalar floats</summary>
		/// <param name="x">x value to init with</param>
		/// <param name="y">y value to init with</param>
		/// <param name="z">z value to init with</param>
		public UByte3N(float x, float y, float z)
		{
			this.X = new UByteN(x);
			this.Y = new UByteN(y);
			this.Z = new UByteN(z);
		}

		/// <summary>constructor taking a Vector3</summary>
		/// <param name="v">the vector to init with</param>
		public UByte3N(Vector3 v)
		{
			this.X = new UByteN(v.X);
			this.Y = new UByteN(v.Y);
			this.Z = new UByteN(v.Z);
		}

		/// <summary>return the vector as a Vector3</summary>
		/// <returns>the vector as a Vector3</returns>
		public Vector3 ToVector3()
		{
			return new Vector3(this.X.ToFloat(), this.Y.ToFloat(), this.Z.ToFloat());
		}

		/// <summary>equality test</summary>
		/// <param name="v">the vector to compare this to</param>
		/// <returns>true if this == v, false otherwise</returns>
		public bool Equals(UByte3N v)
		{
			return this.X.Equals(v.X) && this.Y.Equals(v.Y) && this.Z.Equals(v.Z);
		}

		/// <summary>equality test</summary>
		/// <param name="o">the object to compare this to</param>
		/// <returns>true if this == o, false otherwise</returns>
		public override bool Equals(object o)
		{
			return o is UByte3N && this.Equals((UByte3N)o);
		}

		/// <summary>get the string representation of vector value</summary>
		/// <returns>the string representation of vector value</returns>
		public override string ToString()
		{
			return string.Format("({0},{1},{2})", this.X, this.Y, this.Z);
		}

		/// <summary>gets the hash code for this</summary>
		/// <returns>integer hash code</returns>
		public override int GetHashCode()
		{
			return (int)(this.X.Bits ^ this.Y.Bits ^ this.Z.Bits);
		}

		/// <summary>equality operator</summary>
		/// <param name="v1">vector 1</param>
		/// <param name="v2">vector 2</param>
		/// <returns>true if vector 1 == vector 2, false otherwise</returns>
		public static bool operator ==(UByte3N v1, UByte3N v2)
		{
			return v1.Equals(v2);
		}

		/// <summary>not equals operator</summary>
		/// <param name="v1">vector 1</param>
		/// <param name="v2">vector 2</param>
		/// <returns>true if v 1 != v 2, false otherwise</returns>
		public static bool operator !=(UByte3N v1, UByte3N v2)
		{
			return !v1.Equals(v2);
		}

		/// <summary>X</summary>
		public UByteN X;

		/// <summary>Y</summary>
		public UByteN Y;

		/// <summary>Z</summary>
		public UByteN Z;
	}
}
