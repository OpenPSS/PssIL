using System;

namespace Sce.PlayStation.Core
{
	/// <summary>16 bit color struct with 4 bits per channel</summary>
	public struct Rgba4444 : IEquatable<Rgba4444>
	{
		/// <summary>constructor taking ushort data</summary>
		/// <param name="bits">bits to initialize with</param>
		public Rgba4444(ushort bits)
		{
			this.Bits = bits;
		}

		/// <summary>constructor taking a 32 bit color</summary>
		/// <param name="rgba">the color to init with</param>
		public Rgba4444(Rgba rgba)
		{
			this.Bits = (ushort)(rgba.R >> 4 << 12 | rgba.G >> 4 << 8 | rgba.B >> 4 << 4 | rgba.A >> 4);
		}

		/// <summary>return the color as a 32 bit color</summary>
		/// <returns>the color as a 32 bit color</returns>
		public Rgba ToRgba()
		{
			int num = this.Bits >> 12 & 15;
			int num2 = this.Bits >> 8 & 15;
			int num3 = this.Bits >> 4 & 15;
			int num4 = (int)(this.Bits & 15);
			return new Rgba(num * 17, num2 * 17, num3 * 17, num4 * 17);
		}

		/// <summary>equality test</summary>
		/// <param name="c">the color to compare this to</param>
		/// <returns>true if this == rgba, false otherwise</returns>
		public bool Equals(Rgba4444 c)
		{
			return this.Bits == c.Bits;
		}

		/// <summary>equality test</summary>
		/// <param name="o">the object to compare this to</param>
		/// <returns>true if this == o, false otherwise</returns>
		public override bool Equals(object o)
		{
			return o is Rgba4444 && this.Equals((Rgba4444)o);
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
		public static bool operator ==(Rgba4444 c1, Rgba4444 c2)
		{
			return c1.Bits == c2.Bits;
		}

		/// <summary>not equals operator</summary>
		/// <param name="c1">color 1</param>
		/// <param name="c2">color 2</param>
		/// <returns>true if c 1 != c 2, false otherwise</returns>
		public static bool operator !=(Rgba4444 c1, Rgba4444 c2)
		{
			return c1.Bits != c2.Bits;
		}

		/// <summary>color data</summary>
		public ushort Bits;
	}
}
