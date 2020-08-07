using System;

namespace Sce.PlayStation.Core
{
	/// <summary>16 bit color struct with 5 bits for R, 6 bits for G, and 5 bits for G</summary>
	public struct Rgb565 : IEquatable<Rgb565>
	{
		/// <summary>constructor taking ushort data</summary>
		/// <param name="bits">bits to initialize with</param>
		public Rgb565(ushort bits)
		{
			this.Bits = bits;
		}

		/// <summary>constructor taking a 32 bit color</summary>
		/// <param name="rgba">the color to init with</param>
		public Rgb565(Rgba rgba)
		{
			this.Bits = (ushort)(rgba.R >> 3 << 11 | rgba.G >> 2 << 5 | rgba.B >> 3);
		}

		/// <summary>return the color as a 32 bit color</summary>
		/// <returns>the color as a 32 bit color</returns>
		public Rgba ToRgba()
		{
			int num = this.Bits >> 11 & 31;
			int num2 = this.Bits >> 5 & 63;
			int num3 = (int)(this.Bits & 31);
			return new Rgba(num * 33 / 4, num2 * 65 / 16, num3 * 33 / 4, 255);
		}

		/// <summary>equality test</summary>
		/// <param name="c">the color to compare this to</param>
		/// <returns>true if this == rgba, false otherwise</returns>
		public bool Equals(Rgb565 c)
		{
			return this.Bits == c.Bits;
		}

		/// <summary>equality test</summary>
		/// <param name="o">the object to compare this to</param>
		/// <returns>true if this == o, false otherwise</returns>
		public override bool Equals(object o)
		{
			return o is Rgb565 && this.Equals((Rgb565)o);
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
		public static bool operator ==(Rgb565 c1, Rgb565 c2)
		{
			return c1.Bits == c2.Bits;
		}

		/// <summary>not equals operator</summary>
		/// <param name="c1">color 1</param>
		/// <param name="c2">color 2</param>
		/// <returns>true if c 1 != c 2, false otherwise</returns>
		public static bool operator !=(Rgb565 c1, Rgb565 c2)
		{
			return c1.Bits != c2.Bits;
		}

		/// <summary>color data</summary>
		public ushort Bits;
	}
}
