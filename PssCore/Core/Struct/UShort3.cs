using System;

namespace Sce.PlayStation.Core
{
	/// <summary>vector of 3 unsigned shorts</summary>
	// 
	public struct UShort3 : IEquatable<UShort3>
	{
		/// <summary>constructor taking 3 scalar integers</summary>
		/// <param name="x">x value to init with</param>
		/// <param name="y">y value to init with</param>
		/// <param name="z">z value to init with</param>

		public UShort3(int x, int y, int z)
		{
			this.X = (ushort)x;
			this.Y = (ushort)y;
			this.Z = (ushort)z;
		}

		/// <summary>constructor taking a Vector3</summary>
		/// <param name="v">the vector to init with</param>

		public UShort3(Vector3 v)
		{
			this.X = (ushort)v.X;
			this.Y = (ushort)v.Y;
			this.Z = (ushort)v.Z;
		}

		/// <summary>return the vector as a Vector3</summary>
		/// <returns>the vector as a Vector3</returns>

		public Vector3 ToVector3()
		{
			return new Vector3((float)this.X, (float)this.Y, (float)this.Z);
		}

		/// <summary>equality test</summary>
		/// <param name="v">the vector to compare this to</param>
		/// <returns>true if this == v, false otherwise</returns>

		public bool Equals(UShort3 v)
		{
			return this.X.Equals(v.X) && this.Y.Equals(v.Y) && this.Z.Equals(v.Z);
		}

		/// <summary>equality test</summary>
		/// <param name="o">the object to compare this to</param>
		/// <returns>true if this == o, false otherwise</returns>

		public override bool Equals(object o)
		{
			return o is UShort3 && this.Equals((UShort3)o);
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
			return (int)(this.X ^ this.Y ^ this.Z);
		}

		/// <summary>equality operator</summary>
		/// <param name="v1">vector 1</param>
		/// <param name="v2">vector 2</param>
		/// <returns>true if vector 1 == vector 2, false otherwise</returns>

		public static bool operator ==(UShort3 v1, UShort3 v2)
		{
			return v1.Equals(v2);
		}

		/// <summary>not equals operator</summary>
		/// <param name="v1">vector 1</param>
		/// <param name="v2">vector 2</param>
		/// <returns>true if v 1 != v 2, false otherwise</returns>

		public static bool operator !=(UShort3 v1, UShort3 v2)
		{
			return !v1.Equals(v2);
		}

		/// <summary>X</summary>

		public ushort X;

		/// <summary>Y</summary>

		public ushort Y;

		/// <summary>Z</summary>

		public ushort Z;
	}
}
