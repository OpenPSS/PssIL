using System;

namespace Sce.PlayStation.Core
{
	/// <summary>32 bit color struct, with 8 bits per channel</summary>
	// 
	public struct Rgba : IEquatable<Rgba>
	{
		/// <summary>constructor taking 4 integers</summary>
		/// <param name="r">red</param>
		/// <param name="g">green</param>
		/// <param name="b">blue</param>
		/// <param name="a">alpha</param>

		public Rgba(int r, int g, int b, int a)
		{
			this.R = Rgba.ToByteN(r);
			this.G = Rgba.ToByteN(g);
			this.B = Rgba.ToByteN(b);
			this.A = Rgba.ToByteN(a);
		}

		/// <summary>constructor taking a Vector4</summary>
		/// <param name="v">the vector to init with</param>

		public Rgba(Vector4 v)
		{
			this.R = Rgba.ToByteN(v.X);
			this.G = Rgba.ToByteN(v.Y);
			this.B = Rgba.ToByteN(v.Z);
			this.A = Rgba.ToByteN(v.W);
		}

		/// <summary>return the color as a Vector4</summary>
		/// <returns>the color as a Vector4</returns>

		public Vector4 ToVector4()
		{
			float num = 0.003921569f;
			return new Vector4((float)this.R * num, (float)this.G * num, (float)this.B * num, (float)this.A * num);
		}

		/// <summary>equality test</summary>
		/// <param name="c">the color to compare this to</param>
		/// <returns>true if this == c, false otherwise</returns>

		public bool Equals(Rgba c)
		{
			return ((this.R ^ c.R) | (this.G ^ c.G) | (this.B ^ c.B) | (this.A ^ c.A)) == 0;
		}

		/// <summary>equality test</summary>
		/// <param name="o">the object to compare this to</param>
		/// <returns>true if this == o, false otherwise</returns>

		public override bool Equals(object o)
		{
			return o is Rgba && this.Equals((Rgba)o);
		}

		/// <summary>get the string representation of color value</summary>
		/// <returns>the string representation of color value</returns>

		public override string ToString()
		{
			return string.Format("({0},{1},{2},{3})", new object[]
			{
				this.R,
				this.G,
				this.B,
				this.A
			});
		}

		/// <summary>gets the hash code for this</summary>
		/// <returns>integer hash code</returns>

		public override int GetHashCode()
		{
			return (int)this.R | (int)this.G << 8 | (int)this.B << 16 | (int)this.A << 24;
		}

		/// <summary>equality operator</summary>
		/// <param name="c1">color 1</param>
		/// <param name="c2">color 2</param>
		/// <returns>true if color 1 == color 2, false otherwise</returns>

		public static bool operator ==(Rgba c1, Rgba c2)
		{
			return c1.Equals(c2);
		}

		/// <summary>not equals operator</summary>
		/// <param name="c1">color 1</param>
		/// <param name="c2">color 2</param>
		/// <returns>true if c 1 != c 2, false otherwise</returns>

		public static bool operator !=(Rgba c1, Rgba c2)
		{
			return !c1.Equals(c2);
		}


		private static byte ToByteN(float f)
		{
			return Rgba.ToByteN((int)(f * 255f + 0.5f));
		}


		private static byte ToByteN(int i)
		{
			return (byte)((i < 0) ? 0 : ((i > 255) ? 255 : i));
		}


		[Obsolete("Use new Rgba4444(Rgba)")]
		public Rgba4444 ToRgba4444()
		{
			return new Rgba4444(this);
		}


		[Obsolete("Use new Rgba5551(Rgba)")]
		public Rgba5551 ToRgba5551()
		{
			return new Rgba5551(this);
		}


		[Obsolete("Use new Rgb565(Rgba)")]
		public Rgb565 ToRgb565()
		{
			return new Rgb565(this);
		}

		/// <summary>red</summary>

		public byte R;

		/// <summary>green</summary>

		public byte G;

		/// <summary>blue</summary>

		public byte B;

		/// <summary>alpha</summary>

		public byte A;
	}
}
