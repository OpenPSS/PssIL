using System;

namespace Sce.PlayStation.Core
{
	/// <summary>vector of 3 floats</summary>
	public struct Vector3 : IEquatable<Vector3>
	{
		/// <returns>a new vector consisting of the current vector's x, x, x values</returns>
		public Vector3 Xxx
		{
			get
			{
				return new Vector3(this.X, this.X, this.X);
			}
		}

		/// <returns>a new vector consisting of the current vector's y, x, x values</returns>
		public Vector3 Yxx
		{
			get
			{
				return new Vector3(this.Y, this.X, this.X);
			}
		}

		/// <returns>a new vector consisting of the current vector's z, x, x values</returns>
		public Vector3 Zxx
		{
			get
			{
				return new Vector3(this.Z, this.X, this.X);
			}
		}

		/// <returns>a new vector consisting of the current vector's x, y, x values</returns>
		public Vector3 Xyx
		{
			get
			{
				return new Vector3(this.X, this.Y, this.X);
			}
		}

		/// <returns>a new vector consisting of the current vector's y, y, x values</returns>
		public Vector3 Yyx
		{
			get
			{
				return new Vector3(this.Y, this.Y, this.X);
			}
		}

		/// <returns>a new vector consisting of the current vector's z, y, x values</returns>
		public Vector3 Zyx
		{
			get
			{
				return new Vector3(this.Z, this.Y, this.X);
			}
			set
			{
				this.Z = value.X;
				this.Y = value.Y;
				this.X = value.Z;
			}
		}

		/// <returns>a new vector consisting of the current vector's x, z, x values</returns>
		public Vector3 Xzx
		{
			get
			{
				return new Vector3(this.X, this.Z, this.X);
			}
		}

		/// <returns>a new vector consisting of the current vector's y, z, x values</returns>
		public Vector3 Yzx
		{
			get
			{
				return new Vector3(this.Y, this.Z, this.X);
			}
			set
			{
				this.Y = value.X;
				this.Z = value.Y;
				this.X = value.Z;
			}
		}

		/// <returns>a new vector consisting of the current vector's z, z, x values</returns>
		public Vector3 Zzx
		{
			get
			{
				return new Vector3(this.Z, this.Z, this.X);
			}
		}

		/// <returns>a new vector consisting of the current vector's x, x, y values</returns>
		public Vector3 Xxy
		{
			get
			{
				return new Vector3(this.X, this.X, this.Y);
			}
		}

		/// <returns>a new vector consisting of the current vector's y, x, y values</returns>
		public Vector3 Yxy
		{
			get
			{
				return new Vector3(this.Y, this.X, this.Y);
			}
		}

		/// <returns>a new vector consisting of the current vector's z, x, y values</returns>
		public Vector3 Zxy
		{
			get
			{
				return new Vector3(this.Z, this.X, this.Y);
			}
			set
			{
				this.Z = value.X;
				this.X = value.Y;
				this.Y = value.Z;
			}
		}

		/// <returns>a new vector consisting of the current vector's x, y, y values</returns>
		public Vector3 Xyy
		{
			get
			{
				return new Vector3(this.X, this.Y, this.Y);
			}
		}

		/// <returns>a new vector consisting of the current vector's y, y, y values</returns>
		public Vector3 Yyy
		{
			get
			{
				return new Vector3(this.Y, this.Y, this.Y);
			}
		}

		/// <returns>a new vector consisting of the current vector's z, y, y values</returns>
		public Vector3 Zyy
		{
			get
			{
				return new Vector3(this.Z, this.Y, this.Y);
			}
		}

		/// <returns>a new vector consisting of the current vector's x, z, y values</returns>
		public Vector3 Xzy
		{
			get
			{
				return new Vector3(this.X, this.Z, this.Y);
			}
			set
			{
				this.X = value.X;
				this.Z = value.Y;
				this.Y = value.Z;
			}
		}

		/// <returns>a new vector consisting of the current vector's y, z, y values</returns>
		public Vector3 Yzy
		{
			get
			{
				return new Vector3(this.Y, this.Z, this.Y);
			}
		}

		/// <returns>a new vector consisting of the current vector's z, z, y values</returns>
		public Vector3 Zzy
		{
			get
			{
				return new Vector3(this.Z, this.Z, this.Y);
			}
		}

		/// <returns>a new vector consisting of the current vector's x, x, z values</returns>
		public Vector3 Xxz
		{
			get
			{
				return new Vector3(this.X, this.X, this.Z);
			}
		}

		/// <returns>a new vector consisting of the current vector's y, x, z values</returns>
		public Vector3 Yxz
		{
			get
			{
				return new Vector3(this.Y, this.X, this.Z);
			}
			set
			{
				this.Y = value.X;
				this.X = value.Y;
				this.Z = value.Z;
			}
		}

		/// <returns>a new vector consisting of the current vector's z, x, z values</returns>
		public Vector3 Zxz
		{
			get
			{
				return new Vector3(this.Z, this.X, this.Z);
			}
		}

		/// <returns>a new vector consisting of the current vector's x, y, z values</returns>
		public Vector3 Xyz
		{
			get
			{
				return new Vector3(this.X, this.Y, this.Z);
			}
			set
			{
				this.X = value.X;
				this.Y = value.Y;
				this.Z = value.Z;
			}
		}

		/// <returns>a new vector consisting of the current vector's y, y, z values</returns>
		public Vector3 Yyz
		{
			get
			{
				return new Vector3(this.Y, this.Y, this.Z);
			}
		}

		/// <returns>a new vector consisting of the current vector's z, y, z values</returns>
		public Vector3 Zyz
		{
			get
			{
				return new Vector3(this.Z, this.Y, this.Z);
			}
		}

		/// <returns>a new vector consisting of the current vector's x, z, z values</returns>
		public Vector3 Xzz
		{
			get
			{
				return new Vector3(this.X, this.Z, this.Z);
			}
		}

		/// <returns>a new vector consisting of the current vector's y, z, z values</returns>
		public Vector3 Yzz
		{
			get
			{
				return new Vector3(this.Y, this.Z, this.Z);
			}
		}

		/// <returns>a new vector consisting of the current vector's z, z, z values</returns>
		public Vector3 Zzz
		{
			get
			{
				return new Vector3(this.Z, this.Z, this.Z);
			}
		}

		/// <returns>a new vector consisting of the current vector's x, x values</returns>
		public Vector2 Xx
		{
			get
			{
				return new Vector2(this.X, this.X);
			}
		}

		/// <returns>a new vector consisting of the current vector's y, x values</returns>
		public Vector2 Yx
		{
			get
			{
				return new Vector2(this.Y, this.X);
			}
			set
			{
				this.Y = value.X;
				this.X = value.Y;
			}
		}

		/// <returns>a new vector consisting of the current vector's z, x values</returns>
		public Vector2 Zx
		{
			get
			{
				return new Vector2(this.Z, this.X);
			}
			set
			{
				this.Z = value.X;
				this.X = value.Y;
			}
		}

		/// <returns>a new vector consisting of the current vector's x, y values</returns>
		public Vector2 Xy
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

		/// <returns>a new vector consisting of the current vector's y, y values</returns>
		public Vector2 Yy
		{
			get
			{
				return new Vector2(this.Y, this.Y);
			}
		}

		/// <returns>a new vector consisting of the current vector's z, y values</returns>
		public Vector2 Zy
		{
			get
			{
				return new Vector2(this.Z, this.Y);
			}
			set
			{
				this.Z = value.X;
				this.Y = value.Y;
			}
		}

		/// <returns>a new vector consisting of the current vector's x, z values</returns>
		public Vector2 Xz
		{
			get
			{
				return new Vector2(this.X, this.Z);
			}
			set
			{
				this.X = value.X;
				this.Z = value.Y;
			}
		}

		/// <returns>a new vector consisting of the current vector's y, z values</returns>
		public Vector2 Yz
		{
			get
			{
				return new Vector2(this.Y, this.Z);
			}
			set
			{
				this.Y = value.X;
				this.Z = value.Y;
			}
		}

		/// <returns>a new vector consisting of the current vector's z, z values</returns>
		public Vector2 Zz
		{
			get
			{
				return new Vector2(this.Z, this.Z);
			}
		}

		/// <summary>
		/// return a 4 element vector consisting of the current vector with the w component set to 0
		/// </summary>
		/// <returns>a 4 element vector consisting of the current vector with the w component set to 0</returns>
		public Vector4 Xyz0
		{
			get
			{
				return new Vector4(this.X, this.Y, this.Z, 0f);
			}
		}

		/// <summary>
		/// return a 4 element vector consisting of the current vector with the w component set to 1
		/// </summary>
		/// <returns>a 4 element vector consisting of the current vector with the w component set to 1</returns>
		public Vector4 Xyz1
		{
			get
			{
				return new Vector4(this.X, this.Y, this.Z, 1f);
			}
		}

		/// <summary>Red</summary>
		public float R
		{
			get
			{
				return this.X;
			}
			set
			{
				this.X = value;
			}
		}

		/// <summary>Green</summary>
		public float G
		{
			get
			{
				return this.Y;
			}
			set
			{
				this.Y = value;
			}
		}

		/// <summary>Blue</summary>
		public float B
		{
			get
			{
				return this.Z;
			}
			set
			{
				this.Z = value;
			}
		}

		/// <summary>constructor taking three floats</summary>
		/// <param name="x">x value to initialize with</param>
		/// <param name="y">y value to initialize with</param>
		/// <param name="z">z value to initialize with</param>
		public Vector3(float x, float y, float z)
		{
			this.X = x;
			this.Y = y;
			this.Z = z;
		}

		/// <summary>constructor taking a Vector2 and a float</summary>
		/// <param name="xy">x and y values to initialize with</param>
		/// <param name="z">z value to initialize with</param>
		public Vector3(Vector2 xy, float z)
		{
			this.X = xy.X;
			this.Y = xy.Y;
			this.Z = z;
		}

		/// <summary>constructor taking one float</summary>
		/// <param name="f">f</param>
		public Vector3(float f)
		{
			this.X = f;
			this.Y = f;
			this.Z = f;
		}

		/// <summary>return the length of this vector</summary>
		/// <returns>the length of this vector</returns>
		public float Length()
		{
			return (float)Math.Sqrt((double)(this.X * this.X + this.Y * this.Y + this.Z * this.Z));
		}

		/// <summary>return the length squared of this vector</summary>
		/// <returns>the length squared of this vector</returns>
		public float LengthSquared()
		{
			return this.X * this.X + this.Y * this.Y + this.Z * this.Z;
		}

		/// <summary>get the distance between this and another vector</summary>
		/// <param name="v">the vector to get the distance to</param>
		/// <returns>the distance bwteen this and the other vector</returns>
		public float Distance(Vector3 v)
		{
			return this.Distance(ref v);
		}

		/// <summary>get the distance between this and another vector</summary>
		/// <param name="v">the vector to get the distance to</param>
		/// <returns>the distance bwteen this and the other vector</returns>
		public float Distance(ref Vector3 v)
		{
			float num = this.X - v.X;
			float num2 = this.Y - v.Y;
			float num3 = this.Z - v.Z;
			return (float)Math.Sqrt((double)(num * num + num2 * num2 + num3 * num3));
		}

		/// <summary>get the distance squared between this and another vector</summary>
		/// <param name="v">the vector to get the distance squared to</param>
		/// <returns>the distance between this and the other vector squared</returns>
		public float DistanceSquared(Vector3 v)
		{
			return this.DistanceSquared(ref v);
		}

		/// <summary>get the distance squared between this and another vector</summary>
		/// <param name="v">the vector to get the distance squared to</param>
		/// <returns>the distance between this and the other vector squared</returns>
		public float DistanceSquared(ref Vector3 v)
		{
			float num = this.X - v.X;
			float num2 = this.Y - v.Y;
			float num3 = this.Z - v.Z;
			return num * num + num2 * num2 + num3 * num3;
		}

		/// <summary>dot product of this and v</summary>
		/// <param name="v">vector to take the dot product with</param>
		/// <returns>dot product of this and v</returns>
		public float Dot(Vector3 v)
		{
			return this.X * v.X + this.Y * v.Y + this.Z * v.Z;
		}

		/// <summary>dot product of this and v</summary>
		/// <param name="v">vector to take the dot product with</param>
		/// <returns>dot product of this and v</returns>
		public float Dot(ref Vector3 v)
		{
			return this.X * v.X + this.Y * v.Y + this.Z * v.Z;
		}

		/// <summary>cross product</summary>
		/// <param name="v">vector to take the cross product with</param>
		/// <returns>cross product of this and v</returns>
		public Vector3 Cross(Vector3 v)
		{
			Vector3 result;
			this.Cross(ref v, out result);
			return result;
		}

		/// <summary>cross product</summary>
		/// <param name="v">vector to take the cross product with</param>
		/// <param name="result">cross product of this and v</param>
		public void Cross(ref Vector3 v, out Vector3 result)
		{
			result.X = this.Y * v.Z - this.Z * v.Y;
			result.Y = this.Z * v.X - this.X * v.Z;
			result.Z = this.X * v.Y - this.Y * v.X;
		}

		/// <summary>return this vector normalized</summary>
		/// <returns>this vector normalized</returns>
		public Vector3 Normalize()
		{
			Vector3 result;
			this.Normalize(out result);
			return result;
		}

		/// <summary>return this vector normalized</summary>
		/// <param name="result">this vector normalized</param>
		public void Normalize(out Vector3 result)
		{
			float num = 1f / this.Length();
			result.X = this.X * num;
			result.Y = this.Y * num;
			result.Z = this.Z * num;
		}

		/// <summary>element wise absolute value</summary>
		/// <returns>element wise absolute value of this</returns>
		public Vector3 Abs()
		{
			Vector3 result;
			this.Abs(out result);
			return result;
		}

		/// <summary>element wise absolute value</summary>
		/// <param name="result">element wise absolute value of this</param>
		public void Abs(out Vector3 result)
		{
			result.X = ((this.X >= 0f) ? this.X : (-this.X));
			result.Y = ((this.Y >= 0f) ? this.Y : (-this.Y));
			result.Z = ((this.Z >= 0f) ? this.Z : (-this.Z));
		}

		/// <summary>element wise min</summary>
		/// <param name="v">vector to compare to this</param>
		/// <returns>the min of this and v</returns>
		public Vector3 Min(Vector3 v)
		{
			Vector3 result;
			this.Min(ref v, out result);
			return result;
		}

		/// <summary>element wise min</summary>
		/// <param name="v">vector to compare to this</param>
		/// <param name="result">the min of this and v</param>
		public void Min(ref Vector3 v, out Vector3 result)
		{
			result.X = ((this.X <= v.X) ? this.X : v.X);
			result.Y = ((this.Y <= v.Y) ? this.Y : v.Y);
			result.Z = ((this.Z <= v.Z) ? this.Z : v.Z);
		}

		/// <summary>element wise min</summary>
		/// <param name="f">scalar to compare to this</param>
		/// <returns>the min of this and f</returns>
		public Vector3 Min(float f)
		{
			Vector3 result;
			this.Min(f, out result);
			return result;
		}

		/// <summary>element wise min</summary>
		/// <param name="f">scalar to compare to this</param>
		/// <param name="result">the min of this and f</param>
		public void Min(float f, out Vector3 result)
		{
			result.X = ((this.X <= f) ? this.X : f);
			result.Y = ((this.Y <= f) ? this.Y : f);
			result.Z = ((this.Z <= f) ? this.Z : f);
		}

		/// <summary>element wise max</summary>
		/// <param name="v">vector to compare to this</param>
		/// <returns>the max of this and v</returns>
		public Vector3 Max(Vector3 v)
		{
			Vector3 result;
			this.Max(ref v, out result);
			return result;
		}

		/// <summary>element wise max</summary>
		/// <param name="v">vector to compare to this</param>
		/// <param name="result">the max of this and v</param>
		public void Max(ref Vector3 v, out Vector3 result)
		{
			result.X = ((this.X >= v.X) ? this.X : v.X);
			result.Y = ((this.Y >= v.Y) ? this.Y : v.Y);
			result.Z = ((this.Z >= v.Z) ? this.Z : v.Z);
		}

		/// <summary>element wise max</summary>
		/// <param name="f">scalar to compare to this</param>
		/// <returns>the max of this and f</returns>
		public Vector3 Max(float f)
		{
			Vector3 result;
			this.Max(f, out result);
			return result;
		}

		/// <summary>element wise max</summary>
		/// <param name="f">scalar to compare to this</param>
		/// <param name="result">the max of this and f</param>
		public void Max(float f, out Vector3 result)
		{
			result.X = ((this.X >= f) ? this.X : f);
			result.Y = ((this.Y >= f) ? this.Y : f);
			result.Z = ((this.Z >= f) ? this.Z : f);
		}

		/// <summary>element wise clamp</summary>
		/// <param name="min">min values to clamp against</param>
		/// <param name="max">max values to clamp against</param>
		/// <returns>a new vector consisting of each element of this clamped between min and max</returns>
		public Vector3 Clamp(Vector3 min, Vector3 max)
		{
			Vector3 result;
			this.Clamp(ref min, ref max, out result);
			return result;
		}

		/// <summary>element wise clamp</summary>
		/// <param name="min">min values to clamp against</param>
		/// <param name="max">max values to clamp against</param>
		/// <param name="result">a new vector consisting of each element of this clamped between min and max</param>
		public void Clamp(ref Vector3 min, ref Vector3 max, out Vector3 result)
		{
			result.X = ((this.X <= min.X) ? min.X : ((this.X >= max.X) ? max.X : this.X));
			result.Y = ((this.Y <= min.Y) ? min.Y : ((this.Y >= max.Y) ? max.Y : this.Y));
			result.Z = ((this.Z <= min.Z) ? min.Z : ((this.Z >= max.Z) ? max.Z : this.Z));
		}

		/// <summary>element wise clamp</summary>
		/// <param name="min">min value to clamp against</param>
		/// <param name="max">max value to clamp against</param>
		/// <returns>a new vector consisting of each element of this clamped between min and max</returns>
		public Vector3 Clamp(float min, float max)
		{
			Vector3 result;
			this.Clamp(min, max, out result);
			return result;
		}

		/// <summary>element wise clamp</summary>
		/// <param name="min">min value to clamp against</param>
		/// <param name="max">max value to clamp against</param>
		/// <param name="result">a new vector consisting of each element of this clamped between min and max</param>
		public void Clamp(float min, float max, out Vector3 result)
		{
			result.X = ((this.X <= min) ? min : ((this.X >= max) ? max : this.X));
			result.Y = ((this.Y <= min) ? min : ((this.Y >= max) ? max : this.Y));
			result.Z = ((this.Z <= min) ? min : ((this.Z >= max) ? max : this.Z));
		}

		/// <summary>element wise repeat</summary>
		/// <param name="min">min values to repeat over</param>
		/// <param name="max">max values to repeat over</param>
		/// <returns>a new vector consisting of each element of this repeated between min and max</returns>
		public Vector3 Repeat(Vector3 min, Vector3 max)
		{
			Vector3 result;
			this.Repeat(ref min, ref max, out result);
			return result;
		}

		/// <summary>element wise repeat</summary>
		/// <param name="min">min values to repeat over</param>
		/// <param name="max">max values to repeat over</param>
		/// <param name="result">a new vector consisting of each element of this repeated between min and max</param>
		public void Repeat(ref Vector3 min, ref Vector3 max, out Vector3 result)
		{
			result.X = FMath.Repeat(this.X, min.X, max.X);
			result.Y = FMath.Repeat(this.Y, min.Y, max.Y);
			result.Z = FMath.Repeat(this.Z, min.Z, max.Z);
		}

		/// <summary>element wise repeat</summary>
		/// <param name="min">min value to repeat over</param>
		/// <param name="max">max value to repeat over</param>
		/// <returns>a new vector consisting of each element of this repeated between min and max</returns>
		public Vector3 Repeat(float min, float max)
		{
			Vector3 result;
			this.Repeat(min, max, out result);
			return result;
		}

		/// <summary>element wise repeat</summary>
		/// <param name="min">min value to repeat over</param>
		/// <param name="max">max value to repeat over</param>
		/// <param name="result">a new vector consisting of each element of this repeated between min and max</param>
		public void Repeat(float min, float max, out Vector3 result)
		{
			result.X = FMath.Repeat(this.X, min, max);
			result.Y = FMath.Repeat(this.Y, min, max);
			result.Z = FMath.Repeat(this.Z, min, max);
		}

		/// <summary>lerp between this and the other vector</summary>
		/// <param name="v">the other vector to lerp to</param>
		/// <param name="f">lerp amount</param>
		/// <returns>a Vector3 where each element is the result of lerping f between the corresponding elements of this and other</returns>
		public Vector3 Lerp(Vector3 v, float f)
		{
			Vector3 result;
			this.Lerp(ref v, f, out result);
			return result;
		}

		/// <summary>lerp between this and the other vector</summary>
		/// <param name="v">the other vector to lerp to</param>
		/// <param name="f">lerp amount</param>
		/// <param name="result">a Vector3 where each element is the result of lerping f between the corresponding elements of this and other</param>
		public void Lerp(ref Vector3 v, float f, out Vector3 result)
		{
			float num = 1f - f;
			result.X = this.X * num + v.X * f;
			result.Y = this.Y * num + v.Y * f;
			result.Z = this.Z * num + v.Z * f;
		}

		/// <summary>slerp between this and the other vector</summary>
		/// <param name="v">the other vector to slerp to</param>
		/// <param name="f">slerp amount</param>
		/// <returns>slerp between this and v</returns>
		public Vector3 Slerp(Vector3 v, float f)
		{
			Vector3 result;
			this.Slerp(ref v, f, out result);
			return result;
		}

		/// <summary>slerp between this and the other vector</summary>
		/// <param name="v">the other vector to slerp to</param>
		/// <param name="f">slerp amount</param>
		/// <param name="result">slerp between this and v</param>
		public void Slerp(ref Vector3 v, float f, out Vector3 result)
		{
			result = Matrix4.RotationAxis(this.Cross(v), this.Angle(v) * f).TransformVector(this) * FMath.Lerp(1f, v.Length() / this.Length(), f);
		}

		/// <summary>move to target vector by specified length</summary>
		/// <param name="v">target vector</param>
		/// <param name="length">step length</param>
		/// <returns>a new vector moved to target vector by specified length</returns>
		public Vector3 MoveTo(Vector3 v, float length)
		{
			Vector3 result;
			this.MoveTo(ref v, length, out result);
			return result;
		}

		/// <summary>move to target vector by specified length</summary>
		/// <param name="v">target vector</param>
		/// <param name="length">step length</param>
		/// <param name="result">a new vector moved to target vector by specified length</param>
		public void MoveTo(ref Vector3 v, float length, out Vector3 result)
		{
			float num = this.Distance(v);
			result = ((length >= num) ? v : this.Lerp(v, length / num));
		}

		/// <summary>turn to target vector by specified angle</summary>
		/// <param name="v">target vector</param>
		/// <param name="angle">step angle</param>
		/// <returns>a new vector turned to target vector by specified angle</returns>
		public Vector3 TurnTo(Vector3 v, float angle)
		{
			Vector3 result;
			this.TurnTo(ref v, angle, out result);
			return result;
		}

		/// <summary>turn to target vector by specified angle</summary>
		/// <param name="v">target vector</param>
		/// <param name="angle">step angle</param>
		/// <param name="result">a new vector turned to target vector by specified angle</param>
		public void TurnTo(ref Vector3 v, float angle, out Vector3 result)
		{
			float num = this.Angle(v);
			result = ((angle >= num) ? v : this.Slerp(v, angle / num));
		}

		/// <summary>get the angle between this and the input vector</summary>
		/// <param name="v">the vector to get the angle to</param>
		/// <returns>the angle between this and v</returns>
		public float Angle(Vector3 v)
		{
			return this.Angle(ref v);
		}

		/// <summary>get the angle between this and the input vector</summary>
		/// <param name="v">the vector to get the angle to</param>
		/// <returns>the angle between this and v</returns>
		public float Angle(ref Vector3 v)
		{
			float num = this.Dot(v) / (this.Length() * v.Length());
			if (num < -1f)
			{
				num = -1f;
			}
			if (num > 1f)
			{
				num = 1f;
			}
			return (float)Math.Acos((double)num);
		}

		/// <summary>rotate this around the x axis by an angle</summary>
		/// <param name="angle">angle to rotate by</param>
		/// <returns>the rotated vector</returns>
		public Vector3 RotateX(float angle)
		{
			Vector3 result;
			this.RotateX(angle, out result);
			return result;
		}

		/// <summary>rotate this around the x axis by an angle</summary>
		/// <param name="angle">angle to rotate by</param>
		/// <param name="result">the rotated vector</param>
		public void RotateX(float angle, out Vector3 result)
		{
			Vector2 vector;
			Vector2.Rotation(angle, out vector);
			this.RotateX(ref vector, out result);
		}

		/// <summary>rotate this around the x axis by an angle</summary>
		/// <param name="rotation">a vector containing the cos and sin of the angle to rotate by</param>
		/// <returns>the rotated vector</returns>
		public Vector3 RotateX(Vector2 rotation)
		{
			Vector3 result;
			this.RotateX(ref rotation, out result);
			return result;
		}

		/// <summary>rotate this around the x axis by an angle</summary>
		/// <param name="rotation">a vector containing the cos and sin of the angle to rotate by</param>
		/// <param name="result">the rotated vector</param>
		public void RotateX(ref Vector2 rotation, out Vector3 result)
		{
			result.Y = rotation.X * this.Y - rotation.Y * this.Z;
			result.Z = rotation.X * this.Z + rotation.Y * this.Y;
			result.X = this.X;
		}

		/// <summary>rotate this around the y axis by an angle</summary>
		/// <param name="angle">angle to rotate by</param>
		/// <returns>the rotated vector</returns>
		public Vector3 RotateY(float angle)
		{
			Vector3 result;
			this.RotateY(angle, out result);
			return result;
		}

		/// <summary>rotate this around the y axis by an angle</summary>
		/// <param name="angle">angle to rotate by</param>
		/// <param name="result">the rotated vector</param>
		public void RotateY(float angle, out Vector3 result)
		{
			Vector2 vector;
			Vector2.Rotation(angle, out vector);
			this.RotateY(ref vector, out result);
		}

		/// <summary>rotate this around the y axis by an angle</summary>
		/// <param name="rotation">a vector containing the cos and sin of the angle to rotate by</param>
		/// <returns>the rotated vector</returns>
		public Vector3 RotateY(Vector2 rotation)
		{
			Vector3 result;
			this.RotateY(ref rotation, out result);
			return result;
		}

		/// <summary>rotate this around the y axis by an angle</summary>
		/// <param name="rotation">a vector containing the cos and sin of the angle to rotate by</param>
		/// <param name="result">the rotated vector</param>
		public void RotateY(ref Vector2 rotation, out Vector3 result)
		{
			result.Z = rotation.X * this.Z - rotation.Y * this.X;
			result.X = rotation.X * this.X + rotation.Y * this.Z;
			result.Y = this.Y;
		}

		/// <summary>rotate this around the z axis by an angle</summary>
		/// <param name="angle">angle to rotate by</param>
		/// <returns>the rotated vector</returns>
		public Vector3 RotateZ(float angle)
		{
			Vector3 result;
			this.RotateZ(angle, out result);
			return result;
		}

		/// <summary>rotate this around the z axis by an angle</summary>
		/// <param name="angle">angle to rotate by</param>
		/// <param name="result">the rotated vector</param>
		public void RotateZ(float angle, out Vector3 result)
		{
			Vector2 vector;
			Vector2.Rotation(angle, out vector);
			this.RotateZ(ref vector, out result);
		}

		/// <summary>rotate this around the z axis by an angle</summary>
		/// <param name="rotation">a vector containing the cos and sin of the angle to rotate by</param>
		/// <returns>the rotated vector</returns>
		public Vector3 RotateZ(Vector2 rotation)
		{
			Vector3 result;
			this.RotateZ(ref rotation, out result);
			return result;
		}

		/// <summary>rotate this around the z axis by an angle</summary>
		/// <param name="rotation">a vector containing the cos and sin of the angle to rotate by</param>
		/// <param name="result">the rotated vector</param>
		public void RotateZ(ref Vector2 rotation, out Vector3 result)
		{
			result.X = rotation.X * this.X - rotation.Y * this.Y;
			result.Y = rotation.X * this.Y + rotation.Y * this.X;
			result.Z = this.Z;
		}

		/// <summary>return this vector reflected about normal </summary>
		/// <param name="normal">the vector to reflect about</param>
		/// <returns>this vector reflected about normal</returns>
		public Vector3 Reflect(Vector3 normal)
		{
			Vector3 result;
			this.Reflect(ref normal, out result);
			return result;
		}

		/// <summary>return this vector reflected about normal </summary>
		/// <param name="normal">the vector to reflect about</param>
		/// <param name="result">this vector reflected about normal</param>
		public void Reflect(ref Vector3 normal, out Vector3 result)
		{
			float num = this.Dot(normal) / normal.LengthSquared();
			Vector3 vector;
			normal.Multiply(2f * num, out vector);
			this.Subtract(ref vector, out result);
		}

		/// <summary>return a vector perpendicular to this</summary>
		/// <returns>a vector perpendicular to this</returns>
		public Vector3 Perpendicular()
		{
			Vector3 result;
			this.Perpendicular(out result);
			return result;
		}

		/// <summary>return a vector perpendicular to this</summary>
		/// <param name="result">a vector perpendicular to this</param>
		public void Perpendicular(out Vector3 result)
		{
			float num = this.X * this.X;
			float num2 = this.Y * this.Y;
			float num3 = this.Z * this.Z;
			if (num < num2)
			{
				if (num < num3)
				{
					result.X = 0f;
					result.Y = -this.Z;
					result.Z = this.Y;
				}
				else
				{
					result.Z = 0f;
					result.X = -this.Y;
					result.Y = this.X;
				}
			}
			else if (num2 < num3)
			{
				result.Y = 0f;
				result.Z = -this.X;
				result.X = this.Z;
			}
			else
			{
				result.Z = 0f;
				result.X = -this.Y;
				result.Y = this.X;
			}
		}

		/// <summary>project this vector onto the line (point,direction)</summary>
		/// <param name="point">line start point</param>
		/// <param name="direction">line direction</param>
		/// <returns>this vector projected onto the line (point,direction)</returns>
		public Vector3 ProjectOnLine(Vector3 point, Vector3 direction)
		{
			Vector3 result;
			this.ProjectOnLine(ref point, ref direction, out result);
			return result;
		}

		/// <summary>project this vector onto the line (point,direction)</summary>
		/// <param name="point">line start point</param>
		/// <param name="direction">line direction</param>
		/// <param name="result">this vector projected onto the line (point,direction)</param>
		public void ProjectOnLine(ref Vector3 point, ref Vector3 direction, out Vector3 result)
		{
			Vector3 vector;
			this.Subtract(ref point, out vector);
			float f = direction.Dot(ref vector) / direction.LengthSquared();
			direction.Multiply(f, out vector);
			point.Add(ref vector, out result);
		}

		/// <summary>return this + v</summary>
		/// <param name="v">vector</param>
		/// <returns>this + v</returns>
		public Vector3 Add(Vector3 v)
		{
			Vector3 result;
			this.Add(ref v, out result);
			return result;
		}

		/// <summary>result = this + v</summary>
		/// <param name="v">vector</param>
		/// <param name="result">this + v</param>
		public void Add(ref Vector3 v, out Vector3 result)
		{
			result.X = this.X + v.X;
			result.Y = this.Y + v.Y;
			result.Z = this.Z + v.Z;
		}

		/// <summary>return this - v</summary>
		/// <param name="v">vector</param>
		/// <returns>this - v</returns>
		public Vector3 Subtract(Vector3 v)
		{
			Vector3 result;
			this.Subtract(ref v, out result);
			return result;
		}

		/// <summary>result = this - v</summary>
		/// <param name="v">vector</param>
		/// <param name="result">this - v</param>
		public void Subtract(ref Vector3 v, out Vector3 result)
		{
			result.X = this.X - v.X;
			result.Y = this.Y - v.Y;
			result.Z = this.Z - v.Z;
		}

		/// <summary>return this * v</summary>
		/// <param name="v">vector</param>
		/// <returns>this * v</returns>
		public Vector3 Multiply(Vector3 v)
		{
			Vector3 result;
			this.Multiply(ref v, out result);
			return result;
		}

		/// <summary>result = this * v</summary>
		/// <param name="v">vector</param>
		/// <param name="result">this * v</param>
		public void Multiply(ref Vector3 v, out Vector3 result)
		{
			result.X = this.X * v.X;
			result.Y = this.Y * v.Y;
			result.Z = this.Z * v.Z;
		}

		/// <summary>return this * f</summary>
		/// <param name="f">scalar</param>
		/// <returns>this * f</returns>
		public Vector3 Multiply(float f)
		{
			Vector3 result;
			this.Multiply(f, out result);
			return result;
		}

		/// <summary>result = this * f</summary>
		/// <param name="f">scalar</param>
		/// <param name="result">this * f</param>
		public void Multiply(float f, out Vector3 result)
		{
			result.X = this.X * f;
			result.Y = this.Y * f;
			result.Z = this.Z * f;
		}

		/// <summary>return this / v</summary>
		/// <param name="v">vector</param>
		/// <returns>this / v</returns>
		public Vector3 Divide(Vector3 v)
		{
			Vector3 result;
			this.Divide(ref v, out result);
			return result;
		}

		/// <summary>result = this / v</summary>
		/// <param name="v">vector</param>
		/// <param name="result">this / v</param>
		public void Divide(ref Vector3 v, out Vector3 result)
		{
			result.X = this.X / v.X;
			result.Y = this.Y / v.Y;
			result.Z = this.Z / v.Z;
		}

		/// <summary>return this / f</summary>
		/// <param name="f">scalar</param>
		/// <returns>this / f</returns>
		public Vector3 Divide(float f)
		{
			Vector3 result;
			this.Divide(f, out result);
			return result;
		}

		/// <summary>result = this / f</summary>
		/// <param name="f">scalar</param>
		/// <param name="result">this / f</param>
		public void Divide(float f, out Vector3 result)
		{
			float num = 1f / f;
			result.X = this.X * num;
			result.Y = this.Y * num;
			result.Z = this.Z * num;
		}

		/// <summary>return -this</summary>
		/// <returns>-this</returns>
		public Vector3 Negate()
		{
			Vector3 result;
			this.Negate(out result);
			return result;
		}

		/// <summary>result = -this</summary>
		/// <param name="result">-this</param>
		public void Negate(out Vector3 result)
		{
			result.X = -this.X;
			result.Y = -this.Y;
			result.Z = -this.Z;
		}

		public bool IsUnit(float epsilon)
		{
			return Math.Abs(this.Length() - 1f) <= epsilon;
		}

		/// <summary>test if all elements of this are zero</summary>
		/// <returns>true if all elements of this are zero, false otherwise</returns>
		public bool IsZero()
		{
			return this.X == 0f && this.Y == 0f && this.Z == 0f;
		}

		/// <summary>test if all elements of this are one</summary>
		/// <returns>true if all elements of this are one, false otherwise</returns>
		public bool IsOne()
		{
			return this.X == 1f && this.Y == 1f && this.Z == 1f;
		}

		/// <summary>test if any elements of this are Infinity</summary>
		/// <returns>true if any elements of this are Infinity, false otherwise</returns>
		public bool IsInfinity()
		{
			return float.IsInfinity(this.X) || float.IsInfinity(this.Y) || float.IsInfinity(this.Z);
		}

		/// <summary>test if any elements of this are NaN</summary>
		/// <returns>true if any elements of this are NaN, false otherwise</returns>
		public bool IsNaN()
		{
			return float.IsNaN(this.X) || float.IsNaN(this.Y) || float.IsNaN(this.Z);
		}

		public bool Equals(Vector3 v, float epsilon)
		{
			return Math.Abs(this.X - v.X) <= epsilon && Math.Abs(this.Y - v.Y) <= epsilon && Math.Abs(this.Z - v.Z) <= epsilon;
		}

		/// <summary>equality test</summary>
		/// <param name="v">the vector to compare this to</param>
		/// <returns>true if this == v, false otherwise</returns>
		public bool Equals(Vector3 v)
		{
			return this.X == v.X && this.Y == v.Y && this.Z == v.Z;
		}

		/// <summary>equality test</summary>
		/// <param name="o">the object to compare this to</param>
		/// <returns>true if this == o, false otherwise</returns>
		public override bool Equals(object o)
		{
			return o is Vector3 && this.Equals((Vector3)o);
		}

		/// <summary>return the string representation of this</summary>
		/// <returns>the string representation of this</returns>
		public override string ToString()
		{
			return string.Format("({0:F6},{1:F6},{2:F6})", this.X, this.Y, this.Z);
		}

		/// <summary>gets the hash code for this vector</summary>
		/// <returns>integer hash code</returns>
		public override int GetHashCode()
		{
			return this.X.GetHashCode() ^ this.Y.GetHashCode() ^ this.Z.GetHashCode();
		}

		/// <summary>static function equivalent to Length()</summary>
		/// <param name="v">vector</param>
		/// <returns>the length of the vector</returns>
		public static float Length(Vector3 v)
		{
			return v.Length();
		}

		/// <summary>static function equivalent to Length()</summary>
		/// <param name="v">vector</param>
		/// <returns>the length of the vector</returns>
		public static float Length(ref Vector3 v)
		{
			return v.Length();
		}

		/// <summary>static function equivalent to LengthSquared()</summary>
		/// <param name="v">vector</param>
		/// <returns>the length squared of the vector</returns>
		public static float LengthSquared(Vector3 v)
		{
			return v.LengthSquared();
		}

		/// <summary>static function equivalent to LengthSquared()</summary>
		/// <param name="v">vector</param>
		/// <returns>the length squared of the vector</returns>
		public static float LengthSquared(ref Vector3 v)
		{
			return v.LengthSquared();
		}

		/// <summary>static function equivalent to Distance(Vector3)</summary>
		/// <param name="v1">vector 1</param>
		/// <param name="v2">vector 2</param>
		/// <returns>the distance bwteen v1 and v2</returns>
		public static float Distance(Vector3 v1, Vector3 v2)
		{
			return v1.Distance(ref v2);
		}

		/// <summary>static function equivalent to Distance(ref Vector3)</summary>
		/// <param name="v1">vector 1</param>
		/// <param name="v2">vector 2</param>
		/// <returns>the distance bwteen v1 and v2</returns>
		public static float Distance(ref Vector3 v1, ref Vector3 v2)
		{
			return v1.Distance(ref v2);
		}

		/// <summary>static function equivalent to DistanceSquared(Vector3)</summary>
		/// <param name="v1">vector 1</param>
		/// <param name="v2">vector 2</param>
		/// <returns>the distance between v1 and v2 squared</returns>
		public static float DistanceSquared(Vector3 v1, Vector3 v2)
		{
			return v1.DistanceSquared(ref v2);
		}

		/// <summary>static function equivalent to DistanceSquared(ref Vector3)</summary>
		/// <param name="v1">vector 1</param>
		/// <param name="v2">vector 2</param>
		/// <returns>the distance between v1 and v2 squared</returns>
		public static float DistanceSquared(ref Vector3 v1, ref Vector3 v2)
		{
			return v1.DistanceSquared(ref v2);
		}

		/// <summary>static function equivalent to Dot(Vector3)</summary>
		/// <param name="v1">vector 1</param>
		/// <param name="v2">vector 2</param>
		/// <returns>dot product of v1 and v2</returns>
		public static float Dot(Vector3 v1, Vector3 v2)
		{
			return v1.Dot(ref v2);
		}

		/// <summary>static function equivalent to Dot(ref Vector3)</summary>
		/// <param name="v1">vector 1</param>
		/// <param name="v2">vector 2</param>
		/// <returns>dot product of v1 and v2</returns>
		public static float Dot(ref Vector3 v1, ref Vector3 v2)
		{
			return v1.Dot(ref v2);
		}

		/// <summary>static function equivalent to Cross(Vector3)</summary>
		/// <param name="v1">vector 1</param>
		/// <param name="v2">vector 2</param>
		/// <returns>cross product of v1 and v2</returns>
		public static Vector3 Cross(Vector3 v1, Vector3 v2)
		{
			Vector3 result;
			v1.Cross(ref v2, out result);
			return result;
		}

		/// <summary>static function equivalent to Cross(ref Vector3, out Vector3)</summary>
		/// <param name="v1">vector 1</param>
		/// <param name="v2">vector 2</param>
		/// <param name="result">cross product of v1 and v2</param>
		public static void Cross(ref Vector3 v1, ref Vector3 v2, out Vector3 result)
		{
			v1.Cross(ref v2, out result);
		}

		/// <summary>static function equivalent to Normalize()</summary>
		/// <param name="v">vector</param>
		/// <returns>the vector normalized</returns>
		public static Vector3 Normalize(Vector3 v)
		{
			Vector3 result;
			v.Normalize(out result);
			return result;
		}

		/// <summary>static function equivalent to Normalize(out Vector3)</summary>
		/// <param name="v">vector</param>
		/// <param name="result">the vector normalized</param>
		public static void Normalize(ref Vector3 v, out Vector3 result)
		{
			v.Normalize(out result);
		}

		/// <summary>static function equivalent to Abs()</summary>
		/// <param name="v">vector</param>
		/// <returns>element wise absolute value of v</returns>
		public static Vector3 Abs(Vector3 v)
		{
			Vector3 result;
			v.Abs(out result);
			return result;
		}

		/// <summary>static function equivalent to Abs(out Vector3)</summary>
		/// <param name="v">vector</param>
		/// <param name="result">element wise absolute value of v</param>
		public static void Abs(ref Vector3 v, out Vector3 result)
		{
			v.Abs(out result);
		}

		/// <summary>static function equivalent to Min(Vector3)</summary>
		/// <param name="v1">vector 1</param>
		/// <param name="v2">vector 2</param>
		/// <returns>the min of v1 and v2</returns>
		public static Vector3 Min(Vector3 v1, Vector3 v2)
		{
			Vector3 result;
			v1.Min(ref v2, out result);
			return result;
		}

		/// <summary>static function equivalent to Min(ref Vector3, out Vector3)</summary>
		/// <param name="v1">vector 1</param>
		/// <param name="v2">vector 2</param>
		/// <param name="result">the min of v1 and v2</param>
		public static void Min(ref Vector3 v1, ref Vector3 v2, out Vector3 result)
		{
			v1.Min(ref v2, out result);
		}

		/// <summary>static function equivalent to Min(float)</summary>
		/// <param name="v">vector</param>
		/// <param name="f">scalar</param>
		/// <returns>the min of v and f</returns>
		public static Vector3 Min(Vector3 v, float f)
		{
			Vector3 result;
			v.Min(f, out result);
			return result;
		}

		/// <summary>static function equivalent to Min(float, out Vector3)</summary>
		/// <param name="v">vector</param>
		/// <param name="f">scalar</param>
		/// <param name="result">the min of v and f</param>
		public static void Min(ref Vector3 v, float f, out Vector3 result)
		{
			v.Min(f, out result);
		}

		/// <summary>static function equivalent to Max(Vector3)</summary>
		/// <param name="v1">vector 1</param>
		/// <param name="v2">vector 2</param>
		/// <returns>the max of v1 and v2</returns>
		public static Vector3 Max(Vector3 v1, Vector3 v2)
		{
			Vector3 result;
			v1.Max(ref v2, out result);
			return result;
		}

		/// <summary>static function equivalent to Max(ref Vector3, out Vector3)</summary>
		/// <param name="v1">vector 1</param>
		/// <param name="v2">vector 2</param>
		/// <param name="result">the max of v1 and v2</param>
		public static void Max(ref Vector3 v1, ref Vector3 v2, out Vector3 result)
		{
			v1.Max(ref v2, out result);
		}

		/// <summary>static function equivalent to Max(float)</summary>
		/// <param name="v">vector</param>
		/// <param name="f">scalar</param>
		/// <returns>the max of v and f</returns>
		public static Vector3 Max(Vector3 v, float f)
		{
			Vector3 result;
			v.Max(f, out result);
			return result;
		}

		/// <summary>static function equivalent to Max(float, out Vector3)</summary>
		/// <param name="v">vector</param>
		/// <param name="f">scalar</param>
		/// <param name="result">the max of v and f</param>
		public static void Max(ref Vector3 v, float f, out Vector3 result)
		{
			v.Max(f, out result);
		}

		/// <summary>static function equivalent to Clamp(Vector3, Vector3)</summary>
		/// <param name="v">vector</param>
		/// <param name="min">min values to clamp against</param>
		/// <param name="max">max values to clamp against</param>
		/// <returns>a new vector consisting of each element of v clamped between min and max</returns>
		public static Vector3 Clamp(Vector3 v, Vector3 min, Vector3 max)
		{
			Vector3 result;
			v.Clamp(ref min, ref max, out result);
			return result;
		}

		/// <summary>static function equivalent to Clamp(ref Vector3, ref Vector3, out Vector3)</summary>
		/// <param name="v">vector</param>
		/// <param name="min">min values to clamp against</param>
		/// <param name="max">max values to clamp against</param>
		/// <param name="result">a new vector consisting of each element of v clamped between min and max</param>
		public static void Clamp(ref Vector3 v, ref Vector3 min, ref Vector3 max, out Vector3 result)
		{
			v.Clamp(ref min, ref max, out result);
		}

		/// <summary>static function equivalent to Clamp(float, float)</summary>
		/// <param name="v">vector</param>
		/// <param name="min">min value to clamp against</param>
		/// <param name="max">max value to clamp against</param>
		/// <returns>a new vector consisting of each element of v clamped between min and max</returns>
		public static Vector3 Clamp(Vector3 v, float min, float max)
		{
			Vector3 result;
			v.Clamp(min, max, out result);
			return result;
		}

		/// <summary>static function equivalent to Clamp(float, float, out Vector3)</summary>
		/// <param name="v">vector</param>
		/// <param name="min">min value to clamp against</param>
		/// <param name="max">max value to clamp against</param>
		/// <param name="result">a new vector consisting of each element of v clamped between min and max</param>
		public static void Clamp(ref Vector3 v, float min, float max, out Vector3 result)
		{
			v.Clamp(min, max, out result);
		}

		/// <summary>static function equivalent to Repeat(Vector3, Vector3)</summary>
		/// <param name="v">vector</param>
		/// <param name="min">min values to repeat over</param>
		/// <param name="max">max values to repeat over</param>
		/// <returns>a new vector consisting of each element of v repeated between min and max</returns>
		public static Vector3 Repeat(Vector3 v, Vector3 min, Vector3 max)
		{
			Vector3 result;
			v.Repeat(ref min, ref max, out result);
			return result;
		}

		/// <summary>static function equivalent to Repeat(ref Vector3, ref Vector3, out Vector3)</summary>
		/// <param name="v">vector</param>
		/// <param name="min">min values to repeat over</param>
		/// <param name="max">max values to repeat over</param>
		/// <param name="result">a new vector consisting of each element of v repeated between min and max</param>
		public static void Repeat(ref Vector3 v, ref Vector3 min, ref Vector3 max, out Vector3 result)
		{
			v.Repeat(ref min, ref max, out result);
		}

		/// <summary>static function equivalent to Repeat(float, float)</summary>
		/// <param name="v">vector</param>
		/// <param name="min">min value to repeat over</param>
		/// <param name="max">max value to repeat over</param>
		/// <returns>a new vector consisting of each element of v repeated between min and max</returns>
		public static Vector3 Repeat(Vector3 v, float min, float max)
		{
			Vector3 result;
			v.Repeat(min, max, out result);
			return result;
		}

		/// <summary>static function equivalent to Repeat(float, float, out Vector3)</summary>
		/// <param name="v">vector</param>
		/// <param name="min">min value to repeat over</param>
		/// <param name="max">max value to repeat over</param>
		/// <param name="result">a new vector consisting of each element of v repeated between min and max</param>
		public static void Repeat(ref Vector3 v, float min, float max, out Vector3 result)
		{
			v.Repeat(min, max, out result);
		}

		/// <summary>static function equivalent to Lerp(Vector3, float)</summary>
		/// <param name="v1">vector 1</param>
		/// <param name="v2">vector 2</param>
		/// <param name="f">lerp amount</param>
		/// <returns>a Vector3 where each element is the result of lerping f between the corresponding elements of v1 and v2</returns>
		public static Vector3 Lerp(Vector3 v1, Vector3 v2, float f)
		{
			Vector3 result;
			v1.Lerp(ref v2, f, out result);
			return result;
		}

		/// <summary>static function equivalent to Lerp(ref Vector3, float, out Vector3)</summary>
		/// <param name="v1">vector 1</param>
		/// <param name="v2">vector 2</param>
		/// <param name="f">lerp amount</param>
		/// <param name="result">a Vector3 where each element is the result of lerping f between the corresponding elements of v1 and v2</param>
		public static void Lerp(ref Vector3 v1, ref Vector3 v2, float f, out Vector3 result)
		{
			v1.Lerp(ref v2, f, out result);
		}

		/// <summary>static function equivalent to Slerp(Vector3, float)</summary>
		/// <param name="v1">vector 1</param>
		/// <param name="v2">vector 2</param>
		/// <param name="f">slerp amount</param>
		/// <returns>slerp between v1 and v2</returns>
		public static Vector3 Slerp(Vector3 v1, Vector3 v2, float f)
		{
			Vector3 result;
			v1.Slerp(ref v2, f, out result);
			return result;
		}

		/// <summary>static function equivalent to Slerp(ref Vector3, float, out Vector3)</summary>
		/// <param name="v1">vector 1</param>
		/// <param name="v2">vector 2</param>
		/// <param name="f">slerp amount</param>
		/// <param name="result">slerp between v1 and v2</param>
		public static void Slerp(ref Vector3 v1, ref Vector3 v2, float f, out Vector3 result)
		{
			v1.Slerp(ref v2, f, out result);
		}

		/// <summary>static function equivalent to MoveTo(Vector3, float)</summary>
		/// <param name="v1">vector 1</param>
		/// <param name="v2">vector 2</param>
		/// <param name="length">step length</param>
		/// <returns>a new vector moved to target vector by specified length</returns>
		public static Vector3 MoveTo(Vector3 v1, Vector3 v2, float length)
		{
			Vector3 result;
			v1.MoveTo(ref v2, length, out result);
			return result;
		}

		/// <summary>static function equivalent to MoveTo(ref Vector3, float, out Vector3)</summary>
		/// <param name="v1">vector 1</param>
		/// <param name="v2">vector 2</param>
		/// <param name="length">step length</param>
		/// <param name="result">a new vector moved to target vector by specified length</param>
		public static void MoveTo(ref Vector3 v1, ref Vector3 v2, float length, out Vector3 result)
		{
			v1.MoveTo(ref v2, length, out result);
		}

		public static Vector3 TurnTo(Vector3 v1, Vector3 v2, float angle)
		{
			Vector3 result;
			v1.TurnTo(ref v2, angle, out result);
			return result;
		}

		/// <summary>static function equivalent to TurnTo(ref Vector3, float, out Vector3)</summary>
		/// <param name="v1">vector 1</param>
		/// <param name="v2">vector 2</param>
		/// <param name="angle">step angle</param>
		/// <param name="result">a new vector turned to target vector by specified angle</param>
		public static void TurnTo(ref Vector3 v1, ref Vector3 v2, float angle, out Vector3 result)
		{
			v1.TurnTo(ref v2, angle, out result);
		}

		/// <summary>static function equivalent to Angle(Vector3)</summary>
		/// <param name="v1">vector 1</param>
		/// <param name="v2">vector 2</param>
		/// <returns>the angle between v1 and v2</returns>
		public static float Angle(Vector3 v1, Vector3 v2)
		{
			return v1.Angle(ref v2);
		}

		/// <summary>static function equivalent to Angle(ref Vector3)</summary>
		/// <param name="v1">vector 1</param>
		/// <param name="v2">vector 2</param>
		/// <returns>the angle between v1 and v2</returns>
		public static float Angle(ref Vector3 v1, ref Vector3 v2)
		{
			return v1.Angle(ref v2);
		}

		/// <summary>static function equivalent to RotateX(float)</summary>
		/// <param name="v">vector</param>
		/// <param name="angle">angle to rotate by</param>
		/// <returns>the rotated vector</returns>
		public static Vector3 RotateX(Vector3 v, float angle)
		{
			Vector3 result;
			v.RotateX(angle, out result);
			return result;
		}

		/// <summary>static function equivalent to RotateX(float, out Vector3)</summary>
		/// <param name="v">vector</param>
		/// <param name="angle">angle to rotate by</param>
		/// <param name="result">the rotated vector</param>
		public static void RotateX(ref Vector3 v, float angle, out Vector3 result)
		{
			v.RotateX(angle, out result);
		}

		/// <summary>static function equivalent to RotateX(Vector2)</summary>
		/// <param name="v">vector</param>
		/// <param name="rotation">a vector containing the cos and sin of the angle to rotate by</param>
		/// <returns>the rotated vector</returns>
		public static Vector3 RotateX(Vector3 v, Vector2 rotation)
		{
			Vector3 result;
			v.RotateX(ref rotation, out result);
			return result;
		}

		/// <summary>static function equivalent to RotateX(ref Vector2, out Vector3)</summary>
		/// <param name="v">vector</param>
		/// <param name="rotation">a vector containing the cos and sin of the angle to rotate by</param>
		/// <param name="result">the rotated vector</param>
		public static void RotateX(ref Vector3 v, ref Vector2 rotation, out Vector3 result)
		{
			v.RotateX(ref rotation, out result);
		}

		/// <summary>static function equivalent to RotateY(float)</summary>
		/// <param name="v">vector</param>
		/// <param name="angle">angle to rotate by</param>
		/// <returns>the rotated vector</returns>
		public static Vector3 RotateY(Vector3 v, float angle)
		{
			Vector3 result;
			v.RotateY(angle, out result);
			return result;
		}

		/// <summary>static function equivalent to RotateY(float, out Vector3)</summary>
		/// <param name="v">vector</param>
		/// <param name="angle">angle to rotate by</param>
		/// <param name="result">the rotated vector</param>
		public static void RotateY(ref Vector3 v, float angle, out Vector3 result)
		{
			v.RotateY(angle, out result);
		}

		/// <summary>static function equivalent to RotateY(Vector2)</summary>
		/// <param name="v">vector</param>
		/// <param name="rotation">a vector containing the cos and sin of the angle to rotate by</param>
		/// <returns>the rotated vector</returns>
		public static Vector3 RotateY(Vector3 v, Vector2 rotation)
		{
			Vector3 result;
			v.RotateY(ref rotation, out result);
			return result;
		}

		/// <summary>static function equivalent to RotateY(ref Vector2, out Vector3)</summary>
		/// <param name="v">vector</param>
		/// <param name="rotation">a vector containing the cos and sin of the angle to rotate by</param>
		/// <param name="result">the rotated vector</param>
		public static void RotateY(ref Vector3 v, ref Vector2 rotation, out Vector3 result)
		{
			v.RotateY(ref rotation, out result);
		}

		/// <summary>static function equivalent to RotateZ(float)</summary>
		/// <param name="v">vector</param>
		/// <param name="angle">angle to rotate by</param>
		/// <returns>the rotated vector</returns>
		public static Vector3 RotateZ(Vector3 v, float angle)
		{
			Vector3 result;
			v.RotateZ(angle, out result);
			return result;
		}

		/// <summary>static function equivalent to RotateZ(float, out Vector3)</summary>
		/// <param name="v">vector</param>
		/// <param name="angle">angle to rotate by</param>
		/// <param name="result">the rotated vector</param>
		public static void RotateZ(ref Vector3 v, float angle, out Vector3 result)
		{
			v.RotateZ(angle, out result);
		}

		/// <summary>static function equivalent to RotateZ(Vector2)</summary>
		/// <param name="v">vector</param>
		/// <param name="rotation">a vector containing the cos and sin of the angle to rotate by</param>
		/// <returns>the rotated vector</returns>
		public static Vector3 RotateZ(Vector3 v, Vector2 rotation)
		{
			Vector3 result;
			v.RotateZ(ref rotation, out result);
			return result;
		}

		/// <summary>static function equivalent to RotateZ(ref Vector2, out Vector3)</summary>
		/// <param name="v">vector</param>
		/// <param name="rotation">a vector containing the cos and sin of the angle to rotate by</param>
		/// <param name="result">the rotated vector</param>
		public static void RotateZ(ref Vector3 v, ref Vector2 rotation, out Vector3 result)
		{
			v.RotateZ(ref rotation, out result);
		}

		/// <summary>static function equivalent to Reflect(Vector3)</summary>
		/// <param name="v">vector</param>
		/// <param name="normal">the vector to reflect about</param>
		/// <returns>the vector reflected about normal</returns>
		public static Vector3 Reflect(Vector3 v, Vector3 normal)
		{
			Vector3 result;
			v.Reflect(ref normal, out result);
			return result;
		}

		/// <summary>static function equivalent to Reflect(ref Vector3, out Vector3)</summary>
		/// <param name="v">vector</param>
		/// <param name="normal">the vector to reflect about</param>
		/// <param name="result">the vector reflected about normal</param>
		public static void Reflect(ref Vector3 v, ref Vector3 normal, out Vector3 result)
		{
			v.Reflect(ref normal, out result);
		}

		/// <summary>static function equivalent to Perpendicular()</summary>
		/// <param name="v">vector</param>
		/// <returns>a vector perpendicular to v</returns>
		public static Vector3 Perpendicular(Vector3 v)
		{
			Vector3 result;
			v.Perpendicular(out result);
			return result;
		}

		/// <summary>static function equivalent to Perpendicular(out Vector3)</summary>
		/// <param name="v">vector</param>
		/// <param name="result">a vector perpendicular to v</param>
		public static void Perpendicular(ref Vector3 v, out Vector3 result)
		{
			v.Perpendicular(out result);
		}

		/// <summary>static function equivalent to ProjectOnLine(Vector3, Vector3)</summary>
		/// <param name="v">vector</param>
		/// <param name="point">line start point</param>
		/// <param name="direction">line direction</param>
		/// <returns>the vector projected onto the line (point,direction)</returns>
		public static Vector3 ProjectOnLine(Vector3 v, Vector3 point, Vector3 direction)
		{
			Vector3 result;
			v.ProjectOnLine(ref point, ref direction, out result);
			return result;
		}

		/// <summary>static function equivalent to ProjectOnLine(ref Vector3, ref Vector3, out Vector3)</summary>
		/// <param name="v">vector</param>
		/// <param name="point">line start point</param>
		/// <param name="direction">line direction</param>
		/// <param name="result">the vector projected onto the line (point,direction)</param>
		public static void ProjectOnLine(ref Vector3 v, ref Vector3 point, ref Vector3 direction, out Vector3 result)
		{
			v.ProjectOnLine(ref point, ref direction, out result);
		}

		/// <summary>static function equivalent to Add(Vector3)</summary>
		/// <param name="v1">vector 1</param>
		/// <param name="v2">vector 2</param>
		/// <returns>v1 + v2</returns>
		public static Vector3 Add(Vector3 v1, Vector3 v2)
		{
			Vector3 result;
			v1.Add(ref v2, out result);
			return result;
		}

		/// <summary>static function equivalent to Add(ref Vector3, out Vector3)</summary>
		/// <param name="v1">vector 1</param>
		/// <param name="v2">vector 2</param>
		/// <param name="result">v1 + v2</param>
		public static void Add(ref Vector3 v1, ref Vector3 v2, out Vector3 result)
		{
			v1.Add(ref v2, out result);
		}

		/// <summary>static function equivalent to Subtract(Vector3)</summary>
		/// <param name="v1">vector 1</param>
		/// <param name="v2">vector 2</param>
		/// <returns>v1 - v2</returns>
		public static Vector3 Subtract(Vector3 v1, Vector3 v2)
		{
			Vector3 result;
			v1.Subtract(ref v2, out result);
			return result;
		}

		/// <summary>static function equivalent to Subtract(ref Vector3, out Vector3)</summary>
		/// <param name="v1">vector 1</param>
		/// <param name="v2">vector 2</param>
		/// <param name="result">v1 - v2</param>
		public static void Subtract(ref Vector3 v1, ref Vector3 v2, out Vector3 result)
		{
			v1.Subtract(ref v2, out result);
		}

		/// <summary>static function equivalent to Multiply(Vector3)</summary>
		/// <param name="v1">vector 1</param>
		/// <param name="v2">vector 2</param>
		/// <returns>v1 * v2</returns>
		public static Vector3 Multiply(Vector3 v1, Vector3 v2)
		{
			Vector3 result;
			v1.Multiply(ref v2, out result);
			return result;
		}

		/// <summary>static function equivalent to Multiply(ref Vector3, out Vector3)</summary>
		/// <param name="v1">vector 1</param>
		/// <param name="v2">vector 2</param>
		/// <param name="result">v1 * v2</param>
		public static void Multiply(ref Vector3 v1, ref Vector3 v2, out Vector3 result)
		{
			v1.Multiply(ref v2, out result);
		}

		/// <summary>static function equivalent to Multiply(float)</summary>
		/// <param name="v">vector</param>
		/// <param name="f">scalar</param>
		/// <returns>v * f</returns>
		public static Vector3 Multiply(Vector3 v, float f)
		{
			Vector3 result;
			v.Multiply(f, out result);
			return result;
		}

		/// <summary>static function equivalent to Multiply(float, out Vector3)</summary>
		/// <param name="v">vector</param>
		/// <param name="f">scalar</param>
		/// <param name="result">v * f</param>
		public static void Multiply(ref Vector3 v, float f, out Vector3 result)
		{
			v.Multiply(f, out result);
		}

		/// <summary>static function equivalent to Divide(Vector3)</summary>
		/// <param name="v1">vector 1</param>
		/// <param name="v2">vector 2</param>
		/// <returns>v1 / v2</returns>
		public static Vector3 Divide(Vector3 v1, Vector3 v2)
		{
			Vector3 result;
			v1.Divide(ref v2, out result);
			return result;
		}

		/// <summary>static function equivalent to Divide(ref Vector3, out Vector3)</summary>
		/// <param name="v1">vector 1</param>
		/// <param name="v2">vector 2</param>
		/// <param name="result">v1 / v2</param>
		public static void Divide(ref Vector3 v1, ref Vector3 v2, out Vector3 result)
		{
			v1.Divide(ref v2, out result);
		}

		/// <summary>static function equivalent to Divide(float)</summary>
		/// <param name="v">vector</param>
		/// <param name="f">scalar</param>
		/// <returns>v / f</returns>
		public static Vector3 Divide(Vector3 v, float f)
		{
			Vector3 result;
			v.Divide(f, out result);
			return result;
		}

		/// <summary>static function equivalent to Divide(float, out Vector3)</summary>
		/// <param name="v">vector</param>
		/// <param name="f">scalar</param>
		/// <param name="result">v / f</param>
		public static void Divide(ref Vector3 v, float f, out Vector3 result)
		{
			v.Divide(f, out result);
		}

		/// <summary>static function equivalent to Negate()</summary>
		/// <param name="v">vector</param>
		/// <returns>-v</returns>
		public static Vector3 Negate(Vector3 v)
		{
			Vector3 result;
			v.Negate(out result);
			return result;
		}

		/// <summary>static function equivalent to Negate(out Vector3)</summary>
		/// <param name="v">vector</param>
		/// <param name="result">-v</param>
		public static void Negate(ref Vector3 v, out Vector3 result)
		{
			v.Negate(out result);
		}

		/// <summary>equality operator</summary>
		/// <param name="v1">vector 1</param>
		/// <param name="v2">vector 2</param>
		/// <returns>true if vector 1 == vector 2, false otherwise</returns>
		public static bool operator ==(Vector3 v1, Vector3 v2)
		{
			return v1.X == v2.X && v1.Y == v2.Y && v1.Z == v2.Z;
		}

		/// <summary>not equals operator</summary>
		/// <param name="v1">vector 1</param>
		/// <param name="v2">vector 2</param>
		/// <returns>true if vector 1 != vector 2, false otherwise</returns>
		public static bool operator !=(Vector3 v1, Vector3 v2)
		{
			return v1.X != v2.X || v1.Y != v2.Y || v1.Z != v2.Z;
		}

		/// <summary>vector addition operator</summary>
		/// <param name="v1">vector 1</param>
		/// <param name="v2">vector 2</param>
		/// <returns>vector 1 + vector 2</returns>
		public static Vector3 operator +(Vector3 v1, Vector3 v2)
		{
			Vector3 result;
			v1.Add(ref v2, out result);
			return result;
		}

		/// <summary>adds a scalar float to each element of a vector</summary>
		/// <param name="v">the vector to add</param>
		/// <param name="f">the scalar float to add each element of the vector</param>
		/// <returns>a new vector with f added to each element of v</returns>
		public static Vector3 operator +(Vector3 v, float f)
		{
			return new Vector3(v.X + f, v.Y + f, v.Z + f);
		}

		/// <summary>adds a scalar float to each element of a vector</summary>
		/// <param name="f">the scalar float to add each element of the vector</param>
		/// <param name="v">the vector to add</param>
		/// <returns>a new vector with f added to each element of v</returns>
		public static Vector3 operator +(float f, Vector3 v)
		{
			return new Vector3(f + v.X, f + v.Y, f + v.Z);
		}

		/// <summary>vector subtraction operator</summary>
		/// <param name="v1">vector 1</param>
		/// <param name="v2">vector 2</param>
		/// <returns>vector 1 - vector 2</returns>
		public static Vector3 operator -(Vector3 v1, Vector3 v2)
		{
			Vector3 result;
			v1.Subtract(ref v2, out result);
			return result;
		}

		/// <summary>subtract a scalar float from each element of a vector</summary>
		/// <param name="v">the vector to subtract from</param>
		/// <param name="f">the scalar float to subtract from each element of the vector</param>
		/// <returns>a new vector with f subtracted from each element of v</returns>
		public static Vector3 operator -(Vector3 v, float f)
		{
			return new Vector3(v.X - f, v.Y - f, v.Z - f);
		}

		/// <summary>creates a new vector consisting of {f, f, f}, and then subtracts v from it</summary>
		/// <param name="f">the scalar that we subtract v from</param>
		/// <param name="v">the vector to subtract</param>
		/// <returns>a new vector consisting of v subtracted from the vector {f, f, f}</returns>
		public static Vector3 operator -(float f, Vector3 v)
		{
			return new Vector3(f - v.X, f - v.Y, f - v.Z);
		}

		/// <summary>unary minus operator</summary>
		/// <param name="v">the vector to negate</param>
		/// <returns>unary minus applied to each member of v</returns>
		public static Vector3 operator -(Vector3 v)
		{
			Vector3 result;
			v.Negate(out result);
			return result;
		}

		/// <summary>multiplication operator</summary>
		/// <param name="v1">vector 1</param>
		/// <param name="v2">vector 2</param>
		/// <returns>vector 1 * vector 2</returns>
		public static Vector3 operator *(Vector3 v1, Vector3 v2)
		{
			Vector3 result;
			v1.Multiply(ref v2, out result);
			return result;
		}

		/// <summary>multiply each element of vector by scalar float</summary>
		/// <param name="v">the vector to multiply</param>
		/// <param name="f">the scalar to multiply each element of the vector by</param>
		/// <returns>a new vector consisting of each element of vector multiplied by f</returns>
		public static Vector3 operator *(Vector3 v, float f)
		{
			Vector3 result;
			v.Multiply(f, out result);
			return result;
		}

		/// <summary>multiply each element of vector by scalar float</summary>
		/// <param name="f">the scalar to multiply each element of the vector by</param>
		/// <param name="v">the vector to multiply</param>
		/// <returns>a new vector consisting of each element of vector multiplied by f</returns>
		public static Vector3 operator *(float f, Vector3 v)
		{
			Vector3 result;
			v.Multiply(f, out result);
			return result;
		}

		/// <summary>division operator</summary>
		/// <param name="v1">vector 1</param>
		/// <param name="v2">vector 2</param>
		/// <returns>vector 1 / vector 2</returns>
		public static Vector3 operator /(Vector3 v1, Vector3 v2)
		{
			Vector3 result;
			v1.Divide(ref v2, out result);
			return result;
		}

		/// <summary>divide each element of a vector by a scalar float</summary>
		/// <param name="v">the vector to divide by scalar</param>
		/// <param name="f">the scalar to divide by</param>
		/// <returns>a new Vector3 consisting of each element of v divided by f</returns>
		public static Vector3 operator /(Vector3 v, float f)
		{
			Vector3 result;
			v.Divide(f, out result);
			return result;
		}

		/// <summary>create a new vector consisting of {f, f, f} and divide it by vec</summary>
		/// <param name="f">the scalar to divide by vector</param>
		/// <param name="v">the vector to divide by</param>
		/// <returns>a new vector {f, f, f} divided by v</returns>
		public static Vector3 operator /(float f, Vector3 v)
		{
			return new Vector3(f / v.X, f / v.Y, f / v.Z);
		}

		/// <summary>X</summary>
		public float X;

		/// <summary>Y</summary>
		public float Y;

		/// <summary>Z</summary>
		public float Z;

		/// <summary>return a vector of all zeros</summary>
		/// <returns>a vector of all zeros</returns>
		public static readonly Vector3 Zero = new Vector3(0f, 0f, 0f);

		/// <summary>return a vector of all ones</summary>
		/// <returns>a vector of all ones</returns>
		public static readonly Vector3 One = new Vector3(1f, 1f, 1f);

		/// <summary>return a Vector3 with the x component set to one, and all others set to zero</summary>
		/// <returns>a Vector3 with the x component set to one, and all others set to zero</returns>
		public static readonly Vector3 UnitX = new Vector3(1f, 0f, 0f);

		/// <summary>return a Vector3 with the y component set to one, and all others set to zero</summary>
		/// <returns>a Vector3 with the y component set to one, and all others set to zero</returns>
		public static readonly Vector3 UnitY = new Vector3(0f, 1f, 0f);

		/// <summary>return a Vector3 with the z component set to one, and all others set to zero</summary>
		/// <returns>a Vector3 with the z component set to one, and all others set to zero</returns>
		public static readonly Vector3 UnitZ = new Vector3(0f, 0f, 1f);
	}
}
