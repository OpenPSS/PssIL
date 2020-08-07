using System;

namespace Sce.PlayStation.Core
{
	/// <summary>16 bit color struct with 5 bits per channel for R, G, and B. and 1 bit for A</summary>
	// 
	public struct Rgba5551 : IEquatable<Rgba5551>
	{
		/// <summary>constructor taking ushort data</summary>
		/// <param name="bits">bits to initialize with</param>

		public Rgba5551(ushort bits)
		{
			this.Bits = bits;
		}

		/// <summary>constructor taking a 32 bit color</summary>
		/// <param name="rgba">the color to init with</param>

		public Rgba5551(Rgba rgba)
		{
			this.Bits = (ushort)(rgba.R >> 3 << 11 | rgba.G >> 3 << 6 | rgba.B >> 3 << 1 | rgba.A >> 7);
		}

		/// <summary>return the color as a 32 bit color</summary>
		/// <returns>the color as a 32 bit color</returns>

		public Rgba ToRgba()
		{
			int num = this.Bits >> 11 & 31;
			int num2 = this.Bits >> 6 & 31;
			int num3 = this.Bits >> 1 & 31;
			int num4 = (int)(this.Bits & 1);
			return new Rgba(num * 33 / 4, num2 * 33 / 4, num3 * 33 / 4, num4 * 255);
		}

		/// <summary>equality test</summary>
		/// <param name="c">the color to compare this to</param>
		/// <returns>true if this == rgba, false otherwise</returns>

		public bool Equals(Rgba5551 c)
		{
			return this.Bits == c.Bits;
		}

		/// <summary>equality test</summary>
		/// <param name="o">the object to compare this to</param>
		/// <returns>true if this == o, false otherwise</returns>

		public override bool Equals(object o)
		{
			return o is Rgba5551 && this.Equals((Rgba5551)o);
		}

		/// <summary>get the string representation of color value</summary>
		/// <returns>the string representation of color value</returns>

		public override string ToString()
		{
			return this.ToRgba().ToString();
		}

		/// <summary>gets the hash code for this</summary>
		/// <returns>integer hash code</returns>

		public override int GetHashCode()
		{
			return (int)this.Bits;
		}

		/// <summary>equality operator</summary>
		/// <param name="c1">color 1</param>
		/// <param name="c2">color 2</param>
		/// <returns>true if color 1 == color 2, false otherwise</returns>

		public static bool operator ==(Rgba5551 c1, Rgba5551 c2)
		{
			return c1.Bits == c2.Bits;
		}

		/// <summary>not equals operator</summary>
		/// <param name="c1">color 1</param>
		/// <param name="c2">color 2</param>
		/// <returns>true if c 1 != c 2, false otherwise</returns>

		public static bool operator !=(Rgba5551 c1, Rgba5551 c2)
		{
			return c1.Bits != c2.Bits;
		}

		/// <summary>color data</summary>

		public ushort Bits;
	}
}
