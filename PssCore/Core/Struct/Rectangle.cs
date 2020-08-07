using System;

namespace Sce.PlayStation.Core
{
	/// <summary>rectangle</summary>
	// 
	public struct Rectangle : IEquatable<Rectangle>
	{
		/// <summary>the base position of the rectangle</summary>



		public Vector2 Position
		{
			get
			{
				return new Vector2(this.X, this.Y);
			}
			set
			{
				this.X = value.X;
				this.Y = value.Y;
			}
		}

		/// <summary>the size dimensions of the rectangle</summary>



		public Vector2 Size
		{
			get
			{
				return new Vector2(this.Width, this.Height);
			}
			set
			{
				this.Width = value.X;
				this.Height = value.Y;
			}
		}

		/// <summary>constructor taking 4 floats</summary>
		/// <param name="x">x value to init with</param>
		/// <param name="y">y value to init with</param>
		/// <param name="width">width value to init with</param>
		/// <param name="height">height value to init with</param>

		public Rectangle(float x, float y, float width, float height)
		{
			this.X = x;
			this.Y = y;
			this.Width = width;
			this.Height = height;
		}

		/// <summary>constructor taking a two Vector2s</summary>
		/// <param name="position">the x, y values to init with</param>
		/// <param name="size">the width, height value to init with</param>

		public Rectangle(Vector2 position, Vector2 size)
		{
			this.X = position.X;
			this.Y = position.Y;
			this.Width = size.X;
			this.Height = size.Y;
		}

		/// <summary>constructor taking a Vector4</summary>
		/// <param name="v">the vector to init with</param>

		public Rectangle(Vector4 v)
		{
			this.X = v.X;
			this.Y = v.Y;
			this.Width = v.Z;
			this.Height = v.W;
		}

		/// <summary>rectangle inverse</summary>
		/// <returns>rectangle inverse</returns>

		public Rectangle Inverse()
		{
			Rectangle result;
			this.Inverse(out result);
			return result;
		}

		/// <summary>rectangle inverse</summary>
		/// <param name="result">rectangle inverse</param>

		public void Inverse(out Rectangle result)
		{
			result.Width = 1f / this.Width;
			result.Height = 1f / this.Height;
			result.X = -this.X / result.Width;
			result.Y = -this.Y / result.Height;
		}

		/// <summary>lerp between 2 rectangles</summary>
		/// <param name="r">second rectangle</param>
		/// <param name="f">lerp amount</param>
		/// <returns>lerp between this and r</returns>

		public Rectangle Lerp(Rectangle r, float f)
		{
			Rectangle result;
			this.Lerp(ref r, f, out result);
			return result;
		}

		/// <summary>lerp between 2 rectangles</summary>
		/// <param name="r">second rectangle</param>
		/// <param name="f">lerp amount</param>
		/// <param name="result">lerp between this and r</param>

		public void Lerp(ref Rectangle r, float f, out Rectangle result)
		{
			float num = 1f - f;
			result.X = this.X * num + r.X * f;
			result.Y = this.Y * num + r.Y * f;
			result.Width = this.Width * num + r.Width * f;
			result.Height = this.Height * num + r.Height * f;
		}

		/// <summary>return this * v (X,Y,0,1)</summary>
		/// <param name="v">vector</param>
		/// <returns>this * v (X,Y,0,1)</returns>

		public Vector2 TransformPoint(Vector2 v)
		{
			Vector2 result;
			this.TransformPoint(ref v, out result);
			return result;
		}

		/// <summary>result = this * v (X,Y,0,1)</summary>
		/// <param name="v">vector</param>
		/// <param name="result">this * v (X,Y,0,1)</param>

		public void TransformPoint(ref Vector2 v, out Vector2 result)
		{
			result.X = v.X * this.Width + this.X;
			result.Y = v.Y * this.Height + this.Y;
		}

		/// <summary>return this * v (X,Y,0,0)</summary>
		/// <param name="v">vector</param>
		/// <returns>this * v (X,Y,0,0)</returns>

		public Vector2 TransformVector(Vector2 v)
		{
			Vector2 result;
			this.TransformVector(ref v, out result);
			return result;
		}

		/// <summary>result = this * v (X,Y,0,0)</summary>
		/// <param name="v">vector</param>
		/// <param name="result">this * v (X,Y,0,0)</param>

		public void TransformVector(ref Vector2 v, out Vector2 result)
		{
			result.X = v.X * this.Width;
			result.Y = v.Y * this.Height;
		}

		/// <summary>return this + r</summary>
		/// <param name="r">rectangle</param>
		/// <returns>this + r</returns>

		public Rectangle Add(Rectangle r)
		{
			Rectangle result;
			this.Add(ref r, out result);
			return result;
		}

		/// <summary>result = this + r</summary>
		/// <param name="r">rectangle</param>
		/// <param name="result">this + r</param>

		public void Add(ref Rectangle r, out Rectangle result)
		{
			result.X = this.X + r.X;
			result.Y = this.Y + r.Y;
			result.Width = this.Width + r.Width;
			result.Height = this.Height + r.Height;
		}

		/// <summary>return this - r</summary>
		/// <param name="r">rectangle</param>
		/// <returns>this - r</returns>

		public Rectangle Subtract(Rectangle r)
		{
			Rectangle result;
			this.Subtract(ref r, out result);
			return result;
		}

		/// <summary>result = this - r</summary>
		/// <param name="r">rectangle</param>
		/// <param name="result">this - r</param>

		public void Subtract(ref Rectangle r, out Rectangle result)
		{
			result.X = this.X - r.X;
			result.Y = this.Y - r.Y;
			result.Width = this.Width - r.Width;
			result.Height = this.Height - r.Height;
		}

		/// <summary>return this * r</summary>
		/// <param name="r">rectangle</param>
		/// <returns>this * r</returns>

		public Rectangle Multiply(Rectangle r)
		{
			Rectangle result;
			this.Multiply(ref r, out result);
			return result;
		}

		/// <summary>result = this * r</summary>
		/// <param name="r">rectangle</param>
		/// <param name="result">this * r</param>

		public void Multiply(ref Rectangle r, out Rectangle result)
		{
			result.X = this.Width * r.X + this.X;
			result.Y = this.Height * r.Y + this.Y;
			result.Width = this.Width * r.Width;
			result.Height = this.Height * r.Height;
		}

		/// <summary>return this * f</summary>
		/// <param name="f">scalar</param>
		/// <returns>this * f</returns>

		public Rectangle Multiply(float f)
		{
			Rectangle result;
			this.Multiply(f, out result);
			return result;
		}

		/// <summary>result = this * f</summary>
		/// <param name="f">scalar</param>
		/// <param name="result">this * f</param>

		public void Multiply(float f, out Rectangle result)
		{
			result.X = this.X * f;
			result.Y = this.Y * f;
			result.Width = this.Width * f;
			result.Height = this.Height * f;
		}

		/// <summary>return this / f</summary>
		/// <param name="f">scalar</param>
		/// <returns>this / f</returns>

		public Rectangle Divide(float f)
		{
			Rectangle result;
			this.Divide(f, out result);
			return result;
		}

		/// <summary>result = this / f</summary>
		/// <param name="f">scalar</param>
		/// <param name="result">this / f</param>

		public void Divide(float f, out Rectangle result)
		{
			float num = 1f / f;
			result.X = this.X * num;
			result.Y = this.Y * num;
			result.Width = this.Width * num;
			result.Height = this.Height * num;
		}

		/// <summary>return -this</summary>
		/// <returns>-this</returns>

		public Rectangle Negate()
		{
			Rectangle result;
			this.Negate(out result);
			return result;
		}

		/// <summary>result = -this</summary>
		/// <param name="result">-this</param>

		public void Negate(out Rectangle result)
		{
			result.X = -this.X;
			result.Y = -this.Y;
			result.Width = -this.Width;
			result.Height = -this.Height;
		}

		/// <summary>return the rectangle as a Vector4</summary>
		/// <returns>the rectangle as a Vector4</returns>

		public Vector4 ToVector4()
		{
			Vector4 result;
			this.ToVector4(out result);
			return result;
		}

		/// <summary>return the rectangle as a Vector4</summary>
		/// <param name="result">the rectangle as a Vector4</param>

		public void ToVector4(out Vector4 result)
		{
			result.X = this.X;
			result.Y = this.Y;
			result.Z = this.Width;
			result.W = this.Height;
		}

		/// <summary>convert this rectangle to a Matrix4</summary>
		/// <returns>Matrix4 representation of this rectangle</returns>

		public Matrix4 ToMatrix4()
		{
			Matrix4 result;
			this.ToMatrix4(out result);
			return result;
		}

		/// <summary>convert this rectangle to a Matrix4</summary>
		/// <param name="result">Matrix4 representation of this rectangle</param>

		public void ToMatrix4(out Matrix4 result)
		{
			result = Matrix4.Identity;
			result.M41 = this.X;
			result.M42 = this.Y;
			result.M11 = this.Width;
			result.M22 = this.Height;
		}

		/// <summary>test if this is an identity rectangle</summary>
		/// <returns>true if this is an identity rectangle, false otherwise</returns>

		public bool IsIdentity()
		{
			return this.X == 0f && this.Y == 0f && this.Width == 1f && this.Height == 1f;
		}

		/// <summary>test if any elements of this are Infinity</summary>
		/// <returns>true if any elements of this are Infinity, false otherwise</returns>

		public bool IsInfinity()
		{
			return float.IsInfinity(this.X) || float.IsInfinity(this.Y) || float.IsInfinity(this.Width) || float.IsInfinity(this.Height);
		}

		/// <summary>test if any elements of this are NaN</summary>
		/// <returns>true if any elements of this are NaN, false otherwise</returns>

		public bool IsNaN()
		{
			return float.IsNaN(this.X) || float.IsNaN(this.Y) || float.IsNaN(this.Width) || float.IsNaN(this.Height);
		}


		public bool Equals(Rectangle r, float epsilon)
		{
			return Math.Abs(this.X - r.X) <= epsilon && Math.Abs(this.Y - r.Y) <= epsilon && Math.Abs(this.Width - r.Width) <= epsilon && Math.Abs(this.Height - r.Height) <= epsilon;
		}

		/// <summary>equality test</summary>
		/// <param name="r">the rectangle to compare this to</param>
		/// <returns>true if this == r, false otherwise</returns>

		public bool Equals(Rectangle r)
		{
			return this.X == r.X && this.Y == r.Y && this.Width == r.Width && this.Height == r.Height;
		}

		/// <summary>equality test</summary>
		/// <param name="o">the object to compare this to</param>
		/// <returns>true if this == o, false otherwise</returns>

		public override bool Equals(object o)
		{
			return o is Rectangle && this.Equals((Rectangle)o);
		}

		/// <summary>get the string representation of this rectangle</summary>
		/// <returns>the string representation of this rectangle</returns>

		public override string ToString()
		{
			return string.Format("({0:F6},{1:F6},{2:F6},{3:F6})", new object[]
			{
				this.X,
				this.Y,
				this.Width,
				this.Height
			});
		}

		/// <summary>gets the hash code for this vector</summary>
		/// <returns>integer hash code</returns>

		public override int GetHashCode()
		{
			return this.X.GetHashCode() ^ this.Y.GetHashCode() ^ this.Width.GetHashCode() ^ this.Height.GetHashCode();
		}

		/// <summary>return a rectangle representing a 2D translation/scale matrix</summary>
		/// <param name="m">matrix to form the rectangle out of</param>
		/// <returns>a rectangle representing a rectangle matrix</returns>

		public static Rectangle FromMatrix4(Matrix4 m)
		{
			Rectangle result;
			Rectangle.FromMatrix4(ref m, out result);
			return result;
		}

		/// <summary>return a rectangle representing a 2D translation/scale matrix</summary>
		/// <param name="m">matrix to form the rectangle out of</param>
		/// <param name="result">a rectangle representing a rotation matrix</param>

		public static void FromMatrix4(ref Matrix4 m, out Rectangle result)
		{
			result.X = m.M41;
			result.Y = m.M42;
			result.Width = m.M11;
			result.Height = m.M22;
		}

		/// <summary>static function equivalent to Inverse()</summary>
		/// <param name="r">rectangle</param>
		/// <returns>rectangle inverse</returns>

		public static Rectangle Inverse(Rectangle r)
		{
			Rectangle result;
			r.Inverse(out result);
			return result;
		}

		/// <summary>static function equivalent to Inverse(out Rectangle)</summary>
		/// <param name="r">rectangle</param>
		/// <param name="result">rectangle inverse</param>

		public static void Inverse(ref Rectangle r, out Rectangle result)
		{
			r.Inverse(out result);
		}

		/// <summary>static function equivalent to Lerp(Rectangle, float)</summary>
		/// <param name="r1">rectangle 1</param>
		/// <param name="r2">rectangle 2</param>
		/// <param name="f">lerp amount</param>
		/// <returns>lerp between r1 and r2</returns>

		public static Rectangle Lerp(Rectangle r1, Rectangle r2, float f)
		{
			Rectangle result;
			r1.Lerp(ref r2, f, out result);
			return result;
		}

		/// <summary>static function equivalent to Lerp(ref Rectangle, float, out Rectangle)</summary>
		/// <param name="r1">rectangle 1</param>
		/// <param name="r2">rectangle 2</param>
		/// <param name="f">lerp amount</param>
		/// <param name="result">lerp between r1 and r2</param>

		public static void Lerp(ref Rectangle r1, ref Rectangle r2, float f, out Rectangle result)
		{
			r1.Lerp(ref r2, f, out result);
		}

		/// <summary>static function equivalent to TransformPoint(Vector2)</summary>
		/// <param name="r">rectangle</param>
		/// <param name="v">vector</param>
		/// <returns>r * v (X,Y,0,1)</returns>

		public static Vector2 TransformPoint(Rectangle r, Vector2 v)
		{
			Vector2 result;
			r.TransformPoint(ref v, out result);
			return result;
		}

		/// <summary>static function equivalent to TransformPoint(ref Vector2, out Vector2)</summary>
		/// <param name="r">rectangle</param>
		/// <param name="v">vector</param>
		/// <param name="result">r * v (X,Y,0,1)</param>

		public static void TransformPoint(ref Rectangle r, ref Vector2 v, out Vector2 result)
		{
			r.TransformPoint(ref v, out result);
		}

		/// <summary>static function equivalent to TransformVector(Vector2)</summary>
		/// <param name="r">rectangle</param>
		/// <param name="v">vector</param>
		/// <returns>r * v (X,Y,0,0)</returns>

		public static Vector2 TransformVector(Rectangle r, Vector2 v)
		{
			Vector2 result;
			r.TransformVector(ref v, out result);
			return result;
		}

		/// <summary>static function equivalent to TransformVector(ref Vector2, out Vector2)</summary>
		/// <param name="r">rectangle</param>
		/// <param name="v">vector</param>
		/// <param name="result">r * v (X,Y,0,0)</param>

		public static void TransformVector(ref Rectangle r, ref Vector2 v, out Vector2 result)
		{
			r.TransformVector(ref v, out result);
		}

		/// <summary>static function equivalent to Add(Rectangle)</summary>
		/// <param name="r1">rectangle 1</param>
		/// <param name="r2">rectangle 2</param>
		/// <returns>r1 + r2</returns>

		public static Rectangle Add(Rectangle r1, Rectangle r2)
		{
			Rectangle result;
			r1.Add(ref r2, out result);
			return result;
		}

		/// <summary>static function equivalent to Add(ref Rectangle, out Rectangle)</summary>
		/// <param name="r1">rectangle 1</param>
		/// <param name="r2">rectangle 2</param>
		/// <param name="result">r1 + r2</param>

		public static void Add(ref Rectangle r1, ref Rectangle r2, out Rectangle result)
		{
			r1.Add(ref r2, out result);
		}

		/// <summary>static function equivalent to Subtract(Rectangle)</summary>
		/// <param name="r1">rectangle 1</param>
		/// <param name="r2">rectangle 2</param>
		/// <returns>r1 - r2</returns>

		public static Rectangle Subtract(Rectangle r1, Rectangle r2)
		{
			Rectangle result;
			r1.Subtract(ref r2, out result);
			return result;
		}

		/// <summary>static function equivalent to Subtract(ref Rectangle, out Rectangle)</summary>
		/// <param name="r1">rectangle 1</param>
		/// <param name="r2">rectangle 2</param>
		/// <param name="result">r1 - r2</param>

		public static void Subtract(ref Rectangle r1, ref Rectangle r2, out Rectangle result)
		{
			r1.Subtract(ref r2, out result);
		}

		/// <summary>static function equivalent to Multiply(Rectangle)</summary>
		/// <param name="r1">rectangle 1</param>
		/// <param name="r2">rectangle 2</param>
		/// <returns>r1 * r2</returns>

		public static Rectangle Multiply(Rectangle r1, Rectangle r2)
		{
			Rectangle result;
			r1.Multiply(ref r2, out result);
			return result;
		}

		/// <summary>static function equivalent to Multiply(ref Rectangle, out Rectangle)</summary>
		/// <param name="r1">rectangle 1</param>
		/// <param name="r2">rectangle 2</param>
		/// <param name="result">r1 * r2</param>

		public static void Multiply(ref Rectangle r1, ref Rectangle r2, out Rectangle result)
		{
			r1.Multiply(ref r2, out result);
		}

		/// <summary>static function equivalent to Multiply(float)</summary>
		/// <param name="r">rectangle</param>
		/// <param name="f">scalar</param>
		/// <returns>r * f</returns>

		public static Rectangle Multiply(Rectangle r, float f)
		{
			Rectangle result;
			r.Multiply(f, out result);
			return result;
		}

		/// <summary>static function equivalent to Multiply(float, out Rectangle)</summary>
		/// <param name="r">rectangle</param>
		/// <param name="f">scalar</param>
		/// <param name="result">r * f</param>

		public static void Multiply(ref Rectangle r, float f, out Rectangle result)
		{
			r.Multiply(f, out result);
		}

		/// <summary>static function equivalent to Divide(float)</summary>
		/// <param name="r">rectangle</param>
		/// <param name="f">scalar</param>
		/// <returns>r / f</returns>

		public static Rectangle Divide(Rectangle r, float f)
		{
			Rectangle result;
			r.Divide(f, out result);
			return result;
		}

		/// <summary>static function equivalent to Divide(float, out Rectangle)</summary>
		/// <param name="r">rectangle</param>
		/// <param name="f">scalar</param>
		/// <param name="result">r / f</param>

		public static void Divide(ref Rectangle r, float f, out Rectangle result)
		{
			r.Divide(f, out result);
		}

		/// <summary>static function equivalent to Negate()</summary>
		/// <param name="r">rectangle</param>
		/// <returns>-r</returns>

		public static Rectangle Negate(Rectangle r)
		{
			Rectangle result;
			r.Negate(out result);
			return result;
		}

		/// <summary>static function equivalent to Negate(out Rectangle)</summary>
		/// <param name="r">rectangle</param>
		/// <param name="result">-r</param>

		public static void Negate(ref Rectangle r, out Rectangle result)
		{
			r.Negate(out result);
		}

		/// <summary>equality operator</summary>
		/// <param name="r1">first rectangle to compare</param>
		/// <param name="r2">second rectangle to compare</param>
		/// <returns>true if r1 == r2, false otherwise</returns>

		public static bool operator ==(Rectangle r1, Rectangle r2)
		{
			return r1.X == r2.X && r1.Y == r2.Y && r1.Width == r2.Width && r1.Height == r2.Height;
		}

		/// <summary>not equals operator</summary>
		/// <param name="r1">first rectangle to compare</param>
		/// <param name="r2">second rectangle to compare</param>
		/// <returns>true if r1 != r2, false otherwise</returns>

		public static bool operator !=(Rectangle r1, Rectangle r2)
		{
			return r1.X != r2.X || r1.Y != r2.Y || r1.Width != r2.Width || r1.Height != r2.Height;
		}

		/// <summary>addition operator</summary>
		/// <param name="r1">first rectangle to add</param>
		/// <param name="r2">second rectangle to add</param>
		/// <returns>r1 + r2</returns>

		public static Rectangle operator +(Rectangle r1, Rectangle r2)
		{
			Rectangle result;
			r1.Add(ref r2, out result);
			return result;
		}

		/// <summary>subtraction operator</summary>
		/// <param name="r1">value to subtract from</param>
		/// <param name="r2">value to subtract</param>
		/// <returns>r1 - r2</returns>

		public static Rectangle operator -(Rectangle r1, Rectangle r2)
		{
			Rectangle result;
			r1.Subtract(ref r2, out result);
			return result;
		}

		/// <summary>unary minus operator</summary>
		/// <param name="r">rectangle to negate</param>
		/// <returns>unary minus applied to each member of r</returns>

		public static Rectangle operator -(Rectangle r)
		{
			Rectangle result;
			r.Negate(out result);
			return result;
		}

		/// <summary>multiplication operator</summary>
		/// <param name="r1">first value to multiply</param>
		/// <param name="r2">second value to multiply</param>
		/// <returns>r1 * r2</returns>

		public static Rectangle operator *(Rectangle r1, Rectangle r2)
		{
			Rectangle result;
			r1.Multiply(ref r2, out result);
			return result;
		}

		/// <summary>multiply a rectangle by a scalar float</summary>
		/// <param name="r">rectangle to multiply</param>
		/// <param name="f">float to multiply by</param>
		/// <returns>r * f</returns>

		public static Rectangle operator *(Rectangle r, float f)
		{
			Rectangle result;
			r.Multiply(f, out result);
			return result;
		}

		/// <summary>multiply a rectangle by a scalar float</summary>
		/// <param name="f">float to multiply by</param>
		/// <param name="r">rectangle to multiply</param>
		/// <returns>f * r</returns>

		public static Rectangle operator *(float f, Rectangle r)
		{
			Rectangle result;
			r.Multiply(f, out result);
			return result;
		}

		/// <summary>division operator</summary>
		/// <param name="r">rectangle to divide</param>
		/// <param name="f">scalar float value to divide by</param>
		/// <returns>r / f</returns>

		public static Rectangle operator /(Rectangle r, float f)
		{
			Rectangle result;
			r.Divide(f, out result);
			return result;
		}

		/// <summary>X</summary>

		public float X;

		/// <summary>Y</summary>

		public float Y;

		/// <summary>Width</summary>

		public float Width;

		/// <summary>Height</summary>

		public float Height;

		/// <summary>a rectangle of all zeroes</summary>

		public static readonly Rectangle Zero = new Rectangle(0f, 0f, 0f, 0f);

		/// <summary>identity rectangle</summary>

		public static readonly Rectangle Identity = new Rectangle(0f, 0f, 1f, 1f);
	}
}
