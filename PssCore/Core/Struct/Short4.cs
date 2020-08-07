using System;

namespace Sce.PlayStation.Core
{
	/// <summary>vector of 4 signed shorts</summary>
	// 
	public struct Short4 : IEquatable<Short4>
	{
		/// <summary>constructor taking 4 scalar integers</summary>
		/// <param name="x">x value to init with</param>
		/// <param name="y">y value to init with</param>
		/// <param name="z">z value to init with</param>
		/// <param name="w">w value to init with</param>

		public Short4(int x, int y, int z, int w)
		{
			this.X = (short)x;
			this.Y = (short)y;
			this.Z = (short)z;
			this.W = (short)w;
		}

		/// <summary>constructor taking a Vector4</summary>
		/// <param name="v">the vector to init with</param>

		public Short4(Vector4 v)
		{
			this.X = (short)v.X;
			this.Y = (short)v.Y;
			this.Z = (short)v.Z;
			this.W = (short)v.W;
		}

		/// <summary>return the vector as a Vector4</summary>
		/// <returns>the vector as a Vector4</returns>

		public Vector4 ToVector4()
		{
			return new Vector4((float)this.X, (float)this.Y, (float)this.Z, (float)this.W);
		}

		/// <summary>equality test</summary>
		/// <param name="v">the vector to compare this to</param>
		/// <returns>true if this == v, false otherwise</returns>

		public bool Equals(Short4 v)
		{
			return this.X == v.X && this.Y == v.Y && this.Z == v.Z && this.W == v.W;
		}

		/// <summary>equality test</summary>
		/// <param name="o">the object to compare this to</param>
		/// <returns>true if this == o, false otherwise</returns>

		public override bool Equals(object o)
		{
			return o is Short4 && this.Equals((Short4)o);
		}

		/// <summary>get the string representation of vector value</summary>
		/// <returns>the string representation of vector value</returns>

		public override string ToString()
		{
			return string.Format("({0},{1},{2},{3})", new object[]
			{
				this.X,
				this.Y,
				this.Z,
				this.W
			});
		}

		/// <summary>gets the hash code for this</summary>
		/// <returns>integer hash code</returns>

		public override int GetHashCode()
		{
			return (int)(this.X ^ this.Y ^ this.Z ^ this.W);
		}

		/// <summary>equality operator</summary>
		/// <param name="v1">vector 1</param>
		/// <param name="v2">vector 2</param>
		/// <returns>true if vector 1 == vector 2, false otherwise</returns>

		public static bool operator ==(Short4 v1, Short4 v2)
		{
			return v1.Equals(v2);
		}

		/// <summary>not equals operator</summary>
		/// <param name="v1">vector 1</param>
		/// <param name="v2">vector 2</param>
		/// <returns>true if v 1 != v 2, false otherwise</returns>

		public static bool operator !=(Short4 v1, Short4 v2)
		{
			return !v1.Equals(v2);
		}

		/// <summary>X</summary>

		public short X;

		/// <summary>Y</summary>

		public short Y;

		/// <summary>Z</summary>

		public short Z;

		/// <summary>W</summary>

		public short W;
	}
}
