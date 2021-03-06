﻿using System;

namespace Sce.PlayStation.Core
{
	/// <summary>vector of 4 halfs</summary>
	public struct Half4 : IEquatable<Half4>
	{
		/// <summary>constructor taking 4 scalar floats</summary>
		/// <param name="x">x value to init with</param>
		/// <param name="y">y value to init with</param>
		/// <param name="z">z value to init with</param>
		/// <param name="w">w value to init with</param>
		public Half4(float x, float y, float z, float w)
		{
			this.X = new Half(x);
			this.Y = new Half(y);
			this.Z = new Half(z);
			this.W = new Half(w);
		}

		/// <summary>constructor taking a Vector4</summary>
		/// <param name="v">the vector to init with</param>
		public Half4(Vector4 v)
		{
			this.X = new Half(v.X);
			this.Y = new Half(v.Y);
			this.Z = new Half(v.Z);
			this.W = new Half(v.W);
		}

		/// <summary>return the vector as a Vector4</summary>
		/// <returns>the vector as a Vector4</returns>
		public Vector4 ToVector4()
		{
			return new Vector4(this.X.ToFloat(), this.Y.ToFloat(), this.Z.ToFloat(), this.W.ToFloat());
		}

		/// <summary>equality test</summary>
		/// <param name="v">the vector to compare this to</param>
		/// <returns>true if this == v, false otherwise</returns>
		public bool Equals(Half4 v)
		{
			return this.X.Equals(v.X) && this.Y.Equals(v.Y) && this.Z.Equals(v.Z) && this.W.Equals(v.W);
		}

		/// <summary>equality test</summary>
		/// <param name="o">the object to compare this to</param>
		/// <returns>true if this == o, false otherwise</returns>
		public override bool Equals(object o)
		{
			return o is Half4 && this.Equals((Half4)o);
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
			return (int)(this.X.Bits ^ this.Y.Bits ^ this.Z.Bits ^ this.W.Bits);
		}

		/// <summary>equality operator</summary>
		/// <param name="v1">vector 1</param>
		/// <param name="v2">vector 2</param>
		/// <returns>true if vector 1 == vector 2, false otherwise</returns>
		public static bool operator ==(Half4 v1, Half4 v2)
		{
			return v1.Equals(v2);
		}

		/// <summary>not equals operator</summary>
		/// <param name="v1">vector 1</param>
		/// <param name="v2">vector 2</param>
		/// <returns>true if v 1 != v 2, false otherwise</returns>
		public static bool operator !=(Half4 v1, Half4 v2)
		{
			return !v1.Equals(v2);
		}

		/// <summary>X</summary>
		public Half X;

		/// <summary>Y</summary>
		public Half Y;

		/// <summary>Z</summary>
		public Half Z;

		/// <summary>W</summary>
		public Half W;
	}
}
