using System;

namespace Sce.PlayStation.Core
{
	/// <summary>vector of 2 floats</summary>
	public struct Vector2 : IEquatable<Vector2>
	{
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

		/// <summary>
		/// returns a 3 element vector consisting of the current vector with the z component set to 0
		/// </summary>
		/// <returns>a 3 element vector consisting of the current vector with the z component set to 0</returns>
		public Vector3 Xy0
		{
			get
			{
				return new Vector3(this.X, this.Y, 0f);
			}
		}

		/// <summary>
		/// return a 3 element vector consisting of the current vector with the z component set to 1
		/// </summary>
		/// <returns>a 3 element vector consisting of the current vector with the z component set to 1</returns>
		public Vector3 Xy1
		{
			get
			{
				return new Vector3(this.X, this.Y, 1f);
			}
		}

		/// <summary>
		/// return a 4 element vector consisting of the current vector with the z and w components set to 0 and 0
		/// </summary>
		/// <returns>a 4 element vector consisting of the current vector with the z and w components set to 0 and 0</returns>
		public Vector4 Xy00
		{
			get
			{
				return new Vector4(this.X, this.Y, 0f, 0f);
			}
		}

		/// <summary>
		/// return a 4 element vector consisting of the current vector with the z and w components set to 0 and 1
		/// </summary>
		/// <returns>a 4 element vector consisting of the current vector with the z and w components set to 0 and 1</returns>
		public Vector4 Xy01
		{
			get
			{
				return new Vector4(this.X, this.Y, 0f, 1f);
			}
		}

		/// <summary>
		/// return a 4 element vector consisting of the current vector with the z and w components set to 1 and 0
		/// </summary>
		/// <returns>a 4 element vector consisting of the current vector with the z and w components set to 1 and 0</returns>
		public Vector4 Xy10
		{
			get
			{
				return new Vector4(this.X, this.Y, 1f, 0f);
			}
		}

		/// <summary>
		/// return a 4 element vector consisting of the current vector with the z and w components set to 1 and 1
		/// </summary>
		/// <returns>a 4 element vector consisting of the current vector with the z and w components set to 1 and 1</returns>
		public Vector4 Xy11
		{
			get
			{
				return new Vector4(this.X, this.Y, 1f, 1f);
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

		/// <summary>constructor taking two floats</summary>
		/// <param name="x">x</param>
		/// <param name="y">y</param>
		public Vector2(float x, float y)
		{
			this.X = x;
			this.Y = y;
		}

		/// <summary>constructor taking one float</summary>
		/// <param name="f">f</param>
		public Vector2(float f)
		{
			this.X = f;
			this.Y = f;
		}

		/// <summary>return the length of this vector</summary>
		/// <returns>the length of this vector</returns>
		public float Length()
		{
			return (float)Math.Sqrt((double)(this.X * this.X + this.Y * this.Y));
		}

		/// <summary>return the length squared of this vector</summary>
		/// <returns>the length squared of this vector</returns>
		public float LengthSquared()
		{
			return this.X * this.X + this.Y * this.Y;
		}

		/// <summary>get the distance between this and another vector</summary>
		/// <param name="v">the vector to get the distance to</param>
		/// <returns>the distance bwteen this and the other vector</returns>
		public float Distance(Vector2 v)
		{
			return this.Distance(ref v);
		}

		/// <summary>get the distance between this and another vector</summary>
		/// <param name="v">the vector to get the distance to</param>
		/// <returns>the distance bwteen this and the other vector</returns>
		public float Distance(ref Vector2 v)
		{
			float num = this.X - v.X;
			float num2 = this.Y - v.Y;
			return (float)Math.Sqrt((double)(num * num + num2 * num2));
		}

		/// <summary>get the distance squared between this and another vector</summary>
		/// <param name="v">the vector to get the distance squared to</param>
		/// <returns>the distance between this and the other vector squared</returns>
		public float DistanceSquared(Vector2 v)
		{
			return this.DistanceSquared(ref v);
		}

		/// <summary>get the distance squared between this and another vector</summary>
		/// <param name="v">the vector to get the distance squared to</param>
		/// <returns>the distance between this and the other vector squared</returns>
		public float DistanceSquared(ref Vector2 v)
		{
			float num = this.X - v.X;
			float num2 = this.Y - v.Y;
			return num * num + num2 * num2;
		}

		/// <summary>dot product of this and v</summary>
		/// <param name="v">vector to take the dot product with</param>
		/// <returns>dot product of this and v</returns>
		public float Dot(Vector2 v)
		{
			return this.X * v.X + this.Y * v.Y;
		}

		/// <summary>dot product of this and v</summary>
		/// <param name="v">vector to take the dot product with</param>
		/// <returns>dot product of this and v</returns>
		public float Dot(ref Vector2 v)
		{
			return this.X * v.X + this.Y * v.Y;
		}

		/// <summary>return the determinant of the 2x2 matrix formed by this and v</summary>
		/// <param name="v">vector used to form the 2x2 matrix to take the determinant of</param>
		/// <returns>the determinant of the 2x2 matrix formed by this and v</returns>
		public float Determinant(Vector2 v)
		{
			return this.X * v.Y - this.Y * v.X;
		}

		/// <summary>return the determinant of the 2x2 matrix formed by this and v</summary>
		/// <param name="v">vector used to form the 2x2 matrix to take the determinant of</param>
		/// <returns>the determinant of the 2x2 matrix formed by this and v</returns>
		public float Determinant(ref Vector2 v)
		{
			return this.X * v.Y - this.Y * v.X;
		}

		/// <summary>return this vector normalized</summary>
		/// <returns>this vector normalized</returns>
		public Vector2 Normalize()
		{
			Vector2 result;
			this.Normalize(out result);
			return result;
		}

		/// <summary>return this vector normalized</summary>
		/// <param name="result">this vector normalized</param>
		public void Normalize(out Vector2 result)
		{
			float num = 1f / this.Length();
			result.X = this.X * num;
			result.Y = this.Y * num;
		}

		/// <summary>element wise absolute value</summary>
		/// <returns>element wise absolute value of this</returns>
		public Vector2 Abs()
		{
			Vector2 result;
			this.Abs(out result);
			return result;
		}

		/// <summary>element wise absolute value</summary>
		/// <param name="result">element wise absolute value of this</param>
		public void Abs(out Vector2 result)
		{
			result.X = ((this.X >= 0f) ? this.X : (-this.X));
			result.Y = ((this.Y >= 0f) ? this.Y : (-this.Y));
		}

		/// <summary>element wise min</summary>
		/// <param name="v">vector to compare to this</param>
		/// <returns>the min of this and v</returns>
		public Vector2 Min(Vector2 v)
		{
			Vector2 result;
			this.Min(ref v, out result);
			return result;
		}

		/// <summary>element wise min</summary>
		/// <param name="v">vector to compare to this</param>
		/// <param name="result">the min of this and v</param>
		public void Min(ref Vector2 v, out Vector2 result)
		{
			result.X = ((this.X <= v.X) ? this.X : v.X);
			result.Y = ((this.Y <= v.Y) ? this.Y : v.Y);
		}

		/// <summary>element wise min</summary>
		/// <param name="f">scalar to compare to this</param>
		/// <returns>the min of this and f</returns>
		public Vector2 Min(float f)
		{
			Vector2 result;
			this.Min(f, out result);
			return result;
		}

		/// <summary>element wise min</summary>
		/// <param name="f">scalar to compare to this</param>
		/// <param name="result">the min of this and f</param>
		public void Min(float f, out Vector2 result)
		{
			result.X = ((this.X <= f) ? this.X : f);
			result.Y = ((this.Y <= f) ? this.Y : f);
		}

		/// <summary>element wise max</summary>
		/// <param name="v">vector to compare to this</param>
		/// <returns>the max of this and v</returns>
		public Vector2 Max(Vector2 v)
		{
			Vector2 result;
			this.Max(ref v, out result);
			return result;
		}

		/// <summary>element wise max</summary>
		/// <param name="v">vector to compare to this</param>
		/// <param name="result">the max of this and v</param>
		public void Max(ref Vector2 v, out Vector2 result)
		{
			result.X = ((this.X >= v.X) ? this.X : v.X);
			result.Y = ((this.Y >= v.Y) ? this.Y : v.Y);
		}

		/// <summary>element wise max</summary>
		/// <param name="f">scalar to compare to this</param>
		/// <returns>the max of this and f</returns>
		public Vector2 Max(float f)
		{
			Vector2 result;
			this.Max(f, out result);
			return result;
		}

		/// <summary>element wise max</summary>
		/// <param name="f">scalar to compare to this</param>
		/// <param name="result">the max of this and f</param>
		public void Max(float f, out Vector2 result)
		{
			result.X = ((this.X >= f) ? this.X : f);
			result.Y = ((this.Y >= f) ? this.Y : f);
		}

		/// <summary>element wise clamp</summary>
		/// <param name="min">min values to clamp against</param>
		/// <param name="max">max values to clamp against</param>
		/// <returns>a new vector consisting of each element of this clamped between min and max</returns>
		public Vector2 Clamp(Vector2 min, Vector2 max)
		{
			Vector2 result;
			this.Clamp(ref min, ref max, out result);
			return result;
		}

		/// <summary>element wise clamp</summary>
		/// <param name="min">min values to clamp against</param>
		/// <param name="max">max values to clamp against</param>
		/// <param name="result">a new vector consisting of each element of this clamped between min and max</param>
		public void Clamp(ref Vector2 min, ref Vector2 max, out Vector2 result)
		{
			result.X = ((this.X <= min.X) ? min.X : ((this.X >= max.X) ? max.X : this.X));
			result.Y = ((this.Y <= min.Y) ? min.Y : ((this.Y >= max.Y) ? max.Y : this.Y));
		}

		/// <summary>element wise clamp</summary>
		/// <param name="min">min value to clamp against</param>
		/// <param name="max">max value to clamp against</param>
		/// <returns>a new vector consisting of each element of this clamped between min and max</returns>
		public Vector2 Clamp(float min, float max)
		{
			Vector2 result;
			this.Clamp(min, max, out result);
			return result;
		}

		/// <summary>element wise clamp</summary>
		/// <param name="min">min value to clamp against</param>
		/// <param name="max">max value to clamp against</param>
		/// <param name="result">a new vector consisting of each element of this clamped between min and max</param>
		public void Clamp(float min, float max, out Vector2 result)
		{
			result.X = ((this.X <= min) ? min : ((this.X >= max) ? max : this.X));
			result.Y = ((this.Y <= min) ? min : ((this.Y >= max) ? max : this.Y));
		}

		/// <summary>element wise repeat</summary>
		/// <param name="min">min values to repeat over</param>
		/// <param name="max">max values to repeat over</param>
		/// <returns>a new vector consisting of each element of this repeated between min and max</returns>
		public Vector2 Repeat(Vector2 min, Vector2 max)
		{
			Vector2 result;
			this.Repeat(ref min, ref max, out result);
			return result;
		}

		/// <summary>element wise repeat</summary>
		/// <param name="min">min values to repeat over</param>
		/// <param name="max">max values to repeat over</param>
		/// <param name="result">a new vector consisting of each element of this repeated between min and max</param>
		public void Repeat(ref Vector2 min, ref Vector2 max, out Vector2 result)
		{
			result.X = FMath.Repeat(this.X, min.X, max.X);
			result.Y = FMath.Repeat(this.Y, min.Y, max.Y);
		}

		/// <summary>element wise repeat</summary>
		/// <param name="min">min value to repeat over</param>
		/// <param name="max">max value to repeat over</param>
		/// <returns>a new vector consisting of each element of this repeated between min and max</returns>
		public Vector2 Repeat(float min, float max)
		{
			Vector2 result;
			this.Repeat(min, max, out result);
			return result;
		}

		/// <summary>element wise repeat</summary>
		/// <param name="min">min value to repeat over</param>
		/// <param name="max">max value to repeat over</param>
		/// <param name="result">a new vector consisting of each element of this repeated between min and max</param>
		public void Repeat(float min, float max, out Vector2 result)
		{
			result.X = FMath.Repeat(this.X, min, max);
			result.Y = FMath.Repeat(this.Y, min, max);
		}

		/// <summary>lerp between this and the other vector</summary>
		/// <param name="v">the other vector to lerp to</param>
		/// <param name="f">lerp amount</param>
		/// <returns>a Vector2 where each element is the result of lerping f between the corresponding elements of this and other</returns>
		public Vector2 Lerp(Vector2 v, float f)
		{
			Vector2 result;
			this.Lerp(ref v, f, out result);
			return result;
		}

		/// <summary>lerp between this and the other vector</summary>
		/// <param name="v">the other vector to lerp to</param>
		/// <param name="f">lerp amount</param>
		/// <param name="result">a Vector2 where each element is the result of lerping f between the corresponding elements of this and other</param>
		public void Lerp(ref Vector2 v, float f, out Vector2 result)
		{
			float num = 1f - f;
			result.X = this.X * num + v.X * f;
			result.Y = this.Y * num + v.Y * f;
		}

		/// <summary>slerp between this and the other vector</summary>
		/// <param name="v">the other vector to slerp to</param>
		/// <param name="f">slerp amount</param>
		/// <returns>slerp between this and v</returns>
		public Vector2 Slerp(Vector2 v, float f)
		{
			Vector2 result;
			this.Slerp(ref v, f, out result);
			return result;
		}

		/// <summary>slerp between this and the other vector</summary>
		/// <param name="v">the other vector to slerp to</param>
		/// <param name="f">slerp amount</param>
		/// <param name="result">slerp between this and v</param>
		public void Slerp(ref Vector2 v, float f, out Vector2 result)
		{
			result = this.Rotate(this.Angle(v) * f) * FMath.Lerp(1f, v.Length() / this.Length(), f);
		}

		/// <summary>move to target vector by specified length</summary>
		/// <param name="v">target vector</param>
		/// <param name="length">step length</param>
		/// <returns>a new vector moved to target vector by specified length</returns>
		public Vector2 MoveTo(Vector2 v, float length)
		{
			Vector2 result;
			this.MoveTo(ref v, length, out result);
			return result;
		}

		/// <summary>move to target vector by specified angle</summary>
		/// <param name="v">target vector</param>
		/// <param name="length">step length</param>
		/// <param name="result">a new vector moved to target vector by specified length</param>
		public void MoveTo(ref Vector2 v, float length, out Vector2 result)
		{
			float num = this.Distance(v);
			result = ((length >= num) ? v : this.Lerp(v, length / num));
		}

		/// <summary>turn to target vector by specified angle</summary>
		/// <param name="v">target vector</param>
		/// <param name="angle">step angle</param>
		/// <returns>a new vector turned to target vector by specified angle</returns>
		public Vector2 TurnTo(Vector2 v, float angle)
		{
			Vector2 result;
			this.TurnTo(ref v, angle, out result);
			return result;
		}

		/// <summary>turn to target vector by specified angle</summary>
		/// <param name="v">target vector</param>
		/// <param name="angle">step angle</param>
		/// <param name="result">a new vector turned to target vector by specified angle</param>
		public void TurnTo(ref Vector2 v, float angle, out Vector2 result)
		{
			float num = this.Angle(v);
			if (num < 0f)
			{
				num = -num;
			}
			result = ((angle >= num) ? v : this.Slerp(v, angle / num));
		}

		/// <summary>return the angle between this and v</summary>
		/// <param name="v">vector to get the angle with</param>
		/// <returns>the angle between this and v</returns>
		public float Angle(Vector2 v)
		{
			return this.Angle(ref v);
		}

		/// <summary>return the angle between this and v</summary>
		/// <param name="v">vector to get the angle with</param>
		/// <returns>the angle between this and v</returns>
		public float Angle(ref Vector2 v)
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
			float num2 = (float)Math.Acos((double)num);
			return (this.X * v.Y - this.Y * v.X >= 0f) ? num2 : (-num2);
		}

		/// <summary>return this vector rotated by angle</summary>
		/// <param name="angle">angle to rotate by</param>
		/// <returns>this vector rotated by angle</returns>
		public Vector2 Rotate(float angle)
		{
			Vector2 result;
			this.Rotate(angle, out result);
			return result;
		}

		/// <summary>return this vector rotated by angle</summary>
		/// <param name="angle">angle to rotate by</param>
		/// <param name="result">this vector rotated by angle</param>
		public void Rotate(float angle, out Vector2 result)
		{
			Vector2 vector;
			Vector2.Rotation(angle, out vector);
			this.Rotate(ref vector, out result);
		}

		/// <summary>return this vector rotated by angle</summary>
		/// <param name="rotation">a vector containing the cos and sin of the angle to rotate by</param>
		/// <returns>this vector rotated by angle</returns>
		public Vector2 Rotate(Vector2 rotation)
		{
			Vector2 result;
			this.Rotate(ref rotation, out result);
			return result;
		}

		/// <summary>return this vector rotated by angle</summary>
		/// <param name="rotation">a vector containing the cos and sin of the angle to rotate by</param>
		/// <param name="result">this vector rotated by angle</param>
		public void Rotate(ref Vector2 rotation, out Vector2 result)
		{
			result.X = rotation.X * this.X - rotation.Y * this.Y;
			result.Y = rotation.X * this.Y + rotation.Y * this.X;
		}

		/// <summary>return this vector reflected about normal </summary>
		/// <param name="normal">the vector to reflect about</param>
		/// <returns>this vector reflected about normal</returns>
		public Vector2 Reflect(Vector2 normal)
		{
			Vector2 result;
			this.Reflect(ref normal, out result);
			return result;
		}

		/// <summary>return this vector reflected about normal </summary>
		/// <param name="normal">the vector to reflect about</param>
		/// <param name="result">this vector reflected about normal</param>
		public void Reflect(ref Vector2 normal, out Vector2 result)
		{
			float num = this.Dot(normal) / normal.LengthSquared();
			Vector2 vector;
			normal.Multiply(2f * num, out vector);
			this.Subtract(ref vector, out result);
		}

		/// <summary>return a vector perpendicular to this</summary>
		/// <returns>a vector perpendicular to this</returns>
		public Vector2 Perpendicular()
		{
			Vector2 result;
			this.Perpendicular(out result);
			return result;
		}

		/// <summary>return this rotated by +pi/2</summary>
		/// <param name="result">return this rotated by +pi/2 (this is different from Vector3.Perpendicular)</param>
		public void Perpendicular(out Vector2 result)
		{
			result.X = -this.Y;
			result.Y = this.X;
		}

		/// <summary>project this onto the line (point,direction)</summary>
		/// <param name="point">point of the line to project onto</param>
		/// <param name="direction">direction of the line to project onto</param>
		/// <returns>projection of this onto the line (point,direction)</returns>
		public Vector2 ProjectOnLine(Vector2 point, Vector2 direction)
		{
			Vector2 result;
			this.ProjectOnLine(ref point, ref direction, out result);
			return result;
		}

		/// <summary>project this onto the line (point,direction)</summary>
		/// <param name="point">point of the line to project onto</param>
		/// <param name="direction">direction of the line to project onto</param>
		/// <param name="result">projection of this onto the line (point,direction)</param>
		public void ProjectOnLine(ref Vector2 point, ref Vector2 direction, out Vector2 result)
		{
			Vector2 vector;
			this.Subtract(ref point, out vector);
			float f = direction.Dot(ref vector) / direction.LengthSquared();
			direction.Multiply(f, out vector);
			point.Add(ref vector, out result);
		}

		/// <summary>return this + v</summary>
		/// <param name="v">vector</param>
		/// <returns>this + v</returns>
		public Vector2 Add(Vector2 v)
		{
			Vector2 result;
			this.Add(ref v, out result);
			return result;
		}

		/// <summary>result = this + v</summary>
		/// <param name="v">vector</param>
		/// <param name="result">this + v</param>
		public void Add(ref Vector2 v, out Vector2 result)
		{
			result.X = this.X + v.X;
			result.Y = this.Y + v.Y;
		}

		/// <summary>return this - v</summary>
		/// <param name="v">vector</param>
		/// <returns>this - v</returns>
		public Vector2 Subtract(Vector2 v)
		{
			Vector2 result;
			this.Subtract(ref v, out result);
			return result;
		}

		/// <summary>result = this - v</summary>
		/// <param name="v">vector</param>
		/// <param name="result">this - v</param>
		public void Subtract(ref Vector2 v, out Vector2 result)
		{
			result.X = this.X - v.X;
			result.Y = this.Y - v.Y;
		}

		/// <summary>return this * v</summary>
		/// <param name="v">vector</param>
		/// <returns>this * v</returns>
		public Vector2 Multiply(Vector2 v)
		{
			Vector2 result;
			this.Multiply(ref v, out result);
			return result;
		}

		/// <summary>result = this * v</summary>
		/// <param name="v">vector</param>
		/// <param name="result">this * v</param>
		public void Multiply(ref Vector2 v, out Vector2 result)
		{
			result.X = this.X * v.X;
			result.Y = this.Y * v.Y;
		}

		/// <summary>return this * f</summary>
		/// <param name="f">scalar</param>
		/// <returns>this * f</returns>
		public Vector2 Multiply(float f)
		{
			Vector2 result;
			this.Multiply(f, out result);
			return result;
		}

		/// <summary>result = this * f</summary>
		/// <param name="f">scalar</param>
		/// <param name="result">this * f</param>
		public void Multiply(float f, out Vector2 result)
		{
			result.X = this.X * f;
			result.Y = this.Y * f;
		}

		/// <summary>return this / v</summary>
		/// <param name="v">vector</param>
		/// <returns>this / v</returns>
		public Vector2 Divide(Vector2 v)
		{
			Vector2 result;
			this.Divide(ref v, out result);
			return result;
		}

		/// <summary>result = this / v</summary>
		/// <param name="v">vector</param>
		/// <param name="result">this / v</param>
		public void Divide(ref Vector2 v, out Vector2 result)
		{
			result.X = this.X / v.X;
			result.Y = this.Y / v.Y;
		}

		/// <summary>return this / f</summary>
		/// <param name="f">scalar</param>
		/// <returns>this / f</returns>
		public Vector2 Divide(float f)
		{
			Vector2 result;
			this.Divide(f, out result);
			return result;
		}

		/// <summary>result = this / f</summary>
		/// <param name="f">scalar</param>
		/// <param name="result">this / f</param>
		public void Divide(float f, out Vector2 result)
		{
			float num = 1f / f;
			result.X = this.X * num;
			result.Y = this.Y * num;
		}

		/// <summary>return -this</summary>
		/// <returns>-this</returns>
		public Vector2 Negate()
		{
			Vector2 result;
			this.Negate(out result);
			return result;
		}

		/// <summary>result = -this</summary>
		/// <param name="result">-this</param>
		public void Negate(out Vector2 result)
		{
			result.X = -this.X;
			result.Y = -this.Y;
		}

		public bool IsUnit(float epsilon)
		{
			return Math.Abs(this.Length() - 1f) <= epsilon;
		}

		/// <summary>test if all elements of this are zero</summary>
		/// <returns>true if all elements of this are zero, false otherwise</returns>
		public bool IsZero()
		{
			return this.X == 0f && this.Y == 0f;
		}

		/// <summary>test if all elements of this are one</summary>
		/// <returns>true if all elements of this are one, false otherwise</returns>
		public bool IsOne()
		{
			return this.X == 1f && this.Y == 1f;
		}

		/// <summary>test if any elements of this are Infinity</summary>
		/// <returns>true if any elements of this are Infinity, false otherwise</returns>
		public bool IsInfinity()
		{
			return float.IsInfinity(this.X) || float.IsInfinity(this.Y);
		}

		/// <summary>test if any of the elements of this are NaN</summary>
		/// <returns>true is any elements of this are NaN, false otherwise</returns>
		public bool IsNaN()
		{
			return float.IsNaN(this.X) || float.IsNaN(this.Y);
		}

		public bool Equals(Vector2 v, float epsilon)
		{
			return Math.Abs(this.X - v.X) <= epsilon && Math.Abs(this.Y - v.Y) <= epsilon;
		}

		/// <summary>equality test</summary>
		/// <param name="v">the vector to compare this to</param>
		/// <returns>true if this == v, false otherwise</returns>
		public bool Equals(Vector2 v)
		{
			return this.X == v.X && this.Y == v.Y;
		}

		/// <summary>equality test</summary>
		/// <param name="o">the object to compare this to</param>
		/// <returns>true if this == o, false otherwise</returns>
		public override bool Equals(object o)
		{
			return o is Vector2 && this.Equals((Vector2)o);
		}

		/// <summary>convert vector to string</summary>
		/// <returns>string representation of the vector</returns>
		public override string ToString()
		{
			return string.Format("({0:F6},{1:F6})", this.X, this.Y);
		}

		/// <summary>gets the hash code for this vector</summary>
		/// <returns>integer hash code</returns>
		public override int GetHashCode()
		{
			return this.X.GetHashCode() ^ this.Y.GetHashCode();
		}

		/// <summary>return a new vector that breaks a rotation angle into its x and y components</summary>
		/// <param name="angle">the rotation angle</param>
		/// <returns>a new vector that breaks a rotation angle into its x and y components</returns>
		public static Vector2 Rotation(float angle)
		{
			Vector2 result;
			Vector2.Rotation(angle, out result);
			return result;
		}

		/// <summary>return a new vector that breaks a rotation angle into its x and y components</summary>
		/// <param name="angle">the rotation angle</param>
		/// <param name="result">a new vector that breaks a rotation angle into its x and y components</param>
		public static void Rotation(float angle, out Vector2 result)
		{
			result.X = (float)Math.Cos((double)angle);
			result.Y = (float)Math.Sin((double)angle);
		}

		/// <summary>static function equivalent to Length()</summary>
		/// <param name="v">vector</param>
		/// <returns>the length of the vector</returns>
		public static float Length(Vector2 v)
		{
			return v.Length();
		}

		/// <summary>static function equivalent to Length()</summary>
		/// <param name="v">vector</param>
		/// <returns>the length of the vector</returns>
		public static float Length(ref Vector2 v)
		{
			return v.Length();
		}

		/// <summary>static function equivalent to LengthSquared()</summary>
		/// <param name="v">vector</param>
		/// <returns>the length squared of the vector</returns>
		public static float LengthSquared(Vector2 v)
		{
			return v.LengthSquared();
		}

		/// <summary>static function equivalent to LengthSquared()</summary>
		/// <param name="v">vector</param>
		/// <returns>the length squared of the vector</returns>
		public static float LengthSquared(ref Vector2 v)
		{
			return v.LengthSquared();
		}

		/// <summary>static function equivalent to Distance(Vector2)</summary>
		/// <param name="v1">vector 1</param>
		/// <param name="v2">vector 2</param>
		/// <returns>the distance bwteen v1 and v2</returns>
		public static float Distance(Vector2 v1, Vector2 v2)
		{
			return v1.Distance(ref v2);
		}

		/// <summary>static function equivalent to Distance(ref Vector2)</summary>
		/// <param name="v1">vector 1</param>
		/// <param name="v2">vector 2</param>
		/// <returns>the distance bwteen v1 and v2</returns>
		public static float Distance(ref Vector2 v1, ref Vector2 v2)
		{
			return v1.Distance(ref v2);
		}

		/// <summary>static function equivalent to DistanceSquared(Vector2)</summary>
		/// <param name="v1">vector 1</param>
		/// <param name="v2">vector 2</param>
		/// <returns>the distance between v1 and v2 squared</returns>
		public static float DistanceSquared(Vector2 v1, Vector2 v2)
		{
			return v1.DistanceSquared(ref v2);
		}

		/// <summary>static function equivalent to DistanceSquared(ref Vector2)</summary>
		/// <param name="v1">vector 1</param>
		/// <param name="v2">vector 2</param>
		/// <returns>the distance between v1 and v2 squared</returns>
		public static float DistanceSquared(ref Vector2 v1, ref Vector2 v2)
		{
			return v1.DistanceSquared(ref v2);
		}

		/// <summary>static function equivalent to Dot(Vector2)</summary>
		/// <param name="v1">vector 1</param>
		/// <param name="v2">vector 2</param>
		/// <returns>dot product of v1 and v2</returns>
		public static float Dot(Vector2 v1, Vector2 v2)
		{
			return v1.Dot(ref v2);
		}

		/// <summary>static function equivalent to Dot(ref Vector2)</summary>
		/// <param name="v1">vector 1</param>
		/// <param name="v2">vector 2</param>
		/// <returns>dot product of v1 and v2</returns>
		public static float Dot(ref Vector2 v1, ref Vector2 v2)
		{
			return v1.Dot(ref v2);
		}

		/// <summary>static function equivalent to Determinant(Vector2 v)</summary>
		/// <param name="v1">vector 1</param>
		/// <param name="v2">vector 2</param>
		/// <returns>the determinant of the 2x2 matrix formed by v1 and v2</returns>
		public static float Determinant(Vector2 v1, Vector2 v2)
		{
			return v1.Determinant(ref v2);
		}

		/// <summary>static function equivalent to Determinant(ref Vector2 v)</summary>
		/// <param name="v1">vector 1</param>
		/// <param name="v2">vector 2</param>
		/// <returns>the determinant of the 2x2 matrix formed by v1 and v2</returns>
		public static float Determinant(ref Vector2 v1, ref Vector2 v2)
		{
			return v1.Determinant(ref v2);
		}

		/// <summary>static function equivalent to Normalize()</summary>
		/// <param name="v">vector</param>
		/// <returns>the vector normalized</returns>
		public static Vector2 Normalize(Vector2 v)
		{
			Vector2 result;
			v.Normalize(out result);
			return result;
		}

		/// <summary>static function equivalent to Normalize(out Vector2)</summary>
		/// <param name="v">vector</param>
		/// <param name="result">the vector normalized</param>
		public static void Normalize(ref Vector2 v, out Vector2 result)
		{
			v.Normalize(out result);
		}

		/// <summary>static function equivalent to Abs()</summary>
		/// <param name="v">vector</param>
		/// <returns>element wise absolute value of v</returns>
		public static Vector2 Abs(Vector2 v)
		{
			Vector2 result;
			v.Abs(out result);
			return result;
		}

		/// <summary>static function equivalent to Abs(out Vector2)</summary>
		/// <param name="v">vector</param>
		/// <param name="result">element wise absolute value of v</param>
		public static void Abs(ref Vector2 v, out Vector2 result)
		{
			v.Abs(out result);
		}

		/// <summary>static function equivalent to Min(Vector2)</summary>
		/// <param name="v1">vector 1</param>
		/// <param name="v2">vector 2</param>
		/// <returns>the min of v1 and v2</returns>
		public static Vector2 Min(Vector2 v1, Vector2 v2)
		{
			Vector2 result;
			v1.Min(ref v2, out result);
			return result;
		}

		/// <summary>static function equivalent to Min(ref Vector2, out Vector2)</summary>
		/// <param name="v1">vector 1</param>
		/// <param name="v2">vector 2</param>
		/// <param name="result">the min of v1 and v2</param>
		public static void Min(ref Vector2 v1, ref Vector2 v2, out Vector2 result)
		{
			v1.Min(ref v2, out result);
		}

		/// <summary>static function equivalent to Min(float)</summary>
		/// <param name="v">vector</param>
		/// <param name="f">scalar</param>
		/// <returns>the min of v and f</returns>
		public static Vector2 Min(Vector2 v, float f)
		{
			Vector2 result;
			v.Min(f, out result);
			return result;
		}

		/// <summary>static function equivalent to Min(float, out Vector2)</summary>
		/// <param name="v">vector</param>
		/// <param name="f">scalar</param>
		/// <param name="result">the min of v and f</param>
		public static void Min(ref Vector2 v, float f, out Vector2 result)
		{
			v.Min(f, out result);
		}

		/// <summary>static function equivalent to Max(Vector2)</summary>
		/// <param name="v1">vector 1</param>
		/// <param name="v2">vector 2</param>
		/// <returns>the max of v1 and v2</returns>
		public static Vector2 Max(Vector2 v1, Vector2 v2)
		{
			Vector2 result;
			v1.Max(ref v2, out result);
			return result;
		}

		/// <summary>static function equivalent to Max(ref Vector2, out Vector2)</summary>
		/// <param name="v1">vector 1</param>
		/// <param name="v2">vector 2</param>
		/// <param name="result">the max of v1 and v2</param>
		public static void Max(ref Vector2 v1, ref Vector2 v2, out Vector2 result)
		{
			v1.Max(ref v2, out result);
		}

		/// <summary>static function equivalent to Max(float)</summary>
		/// <param name="v">vector</param>
		/// <param name="f">scalar</param>
		/// <returns>the max of v and f</returns>
		public static Vector2 Max(Vector2 v, float f)
		{
			Vector2 result;
			v.Max(f, out result);
			return result;
		}

		/// <summary>static function equivalent to Max(float, out Vector2)</summary>
		/// <param name="v">vector</param>
		/// <param name="f">scalar</param>
		/// <param name="result">the max of v and f</param>
		public static void Max(ref Vector2 v, float f, out Vector2 result)
		{
			v.Max(f, out result);
		}

		/// <summary>static function equivalent to Clamp(Vector2, Vector2)</summary>
		/// <param name="v">vector</param>
		/// <param name="min">min values to clamp against</param>
		/// <param name="max">max values to clamp against</param>
		/// <returns>a new vector consisting of each element of v clamped between min and max</returns>
		public static Vector2 Clamp(Vector2 v, Vector2 min, Vector2 max)
		{
			Vector2 result;
			v.Clamp(ref min, ref max, out result);
			return result;
		}

		/// <summary>static function equivalent to Clamp(ref Vector2, ref Vector2, out Vector2)</summary>
		/// <param name="v">vector</param>
		/// <param name="min">min values to clamp against</param>
		/// <param name="max">max values to clamp against</param>
		/// <param name="result">a new vector consisting of each element of v clamped between min and max</param>
		public static void Clamp(ref Vector2 v, ref Vector2 min, ref Vector2 max, out Vector2 result)
		{
			v.Clamp(ref min, ref max, out result);
		}

		/// <summary>static function equivalent to Clamp(float, float)</summary>
		/// <param name="v">vector</param>
		/// <param name="min">min value to clamp against</param>
		/// <param name="max">max value to clamp against</param>
		/// <returns>a new vector consisting of each element of v clamped between min and max</returns>
		public static Vector2 Clamp(Vector2 v, float min, float max)
		{
			Vector2 result;
			v.Clamp(min, max, out result);
			return result;
		}

		/// <summary>static function equivalent to Clamp(float, float, out Vector2)</summary>
		/// <param name="v">vector</param>
		/// <param name="min">min value to clamp against</param>
		/// <param name="max">max value to clamp against</param>
		/// <param name="result">a new vector consisting of each element of v clamped between min and max</param>
		public static void Clamp(ref Vector2 v, float min, float max, out Vector2 result)
		{
			v.Clamp(min, max, out result);
		}

		/// <summary>static function equivalent to Repeat(Vector2, Vector2)</summary>
		/// <param name="v">vector</param>
		/// <param name="min">min values to repeat over</param>
		/// <param name="max">max values to repeat over</param>
		/// <returns>a new vector consisting of each element of v repeated between min and max</returns>
		public static Vector2 Repeat(Vector2 v, Vector2 min, Vector2 max)
		{
			Vector2 result;
			v.Repeat(ref min, ref max, out result);
			return result;
		}

		/// <summary>static function equivalent to Repeat(ref Vector2, ref Vector2, out Vector2)</summary>
		/// <param name="v">vector</param>
		/// <param name="min">min values to repeat over</param>
		/// <param name="max">max values to repeat over</param>
		/// <param name="result">a new vector consisting of each element of v repeated between min and max</param>
		public static void Repeat(ref Vector2 v, ref Vector2 min, ref Vector2 max, out Vector2 result)
		{
			v.Repeat(ref min, ref max, out result);
		}

		/// <summary>static function equivalent to Repeat(float, float)</summary>
		/// <param name="v">vector</param>
		/// <param name="min">min value to repeat over</param>
		/// <param name="max">max value to repeat over</param>
		/// <returns>a new vector consisting of each element of v repeated between min and max</returns>
		public static Vector2 Repeat(Vector2 v, float min, float max)
		{
			Vector2 result;
			v.Repeat(min, max, out result);
			return result;
		}

		/// <summary>static function equivalent to Repeat(float, float, out Vector2)</summary>
		/// <param name="v">vector</param>
		/// <param name="min">min value to repeat over</param>
		/// <param name="max">max value to repeat over</param>
		/// <param name="result">a new vector consisting of each element of v repeated between min and max</param>
		public static void Repeat(ref Vector2 v, float min, float max, out Vector2 result)
		{
			v.Repeat(min, max, out result);
		}

		/// <summary>static function equivalent to Lerp(Vector2, float)</summary>
		/// <param name="v1">vector 1</param>
		/// <param name="v2">vector 2</param>
		/// <param name="f">lerp amount</param>
		/// <returns>a Vector2 where each element is the result of lerping f between the corresponding elements of v1 and v2</returns>
		public static Vector2 Lerp(Vector2 v1, Vector2 v2, float f)
		{
			Vector2 result;
			v1.Lerp(ref v2, f, out result);
			return result;
		}

		/// <summary>static function equivalent to Lerp(ref Vector2, float, out Vector2)</summary>
		/// <param name="v1">vector 1</param>
		/// <param name="v2">vector 2</param>
		/// <param name="f">lerp amount</param>
		/// <param name="result">a Vector2 where each element is the result of lerping f between the corresponding elements of v1 and v2</param>
		public static void Lerp(ref Vector2 v1, ref Vector2 v2, float f, out Vector2 result)
		{
			v1.Lerp(ref v2, f, out result);
		}

		/// <summary>static function equivalent to Slerp(Vector2, float)</summary>
		/// <param name="v1">vector 1</param>
		/// <param name="v2">vector 2</param>
		/// <param name="f">slerp amount</param>
		/// <returns>slerp between v1 and v2</returns>
		public static Vector2 Slerp(Vector2 v1, Vector2 v2, float f)
		{
			Vector2 result;
			v1.Slerp(ref v2, f, out result);
			return result;
		}

		/// <summary>static function equivalent to Slerp(ref Vector2, float, out Vector2)</summary>
		/// <param name="v1">vector 1</param>
		/// <param name="v2">vector 2</param>
		/// <param name="f">slerp amount</param>
		/// <param name="result">slerp between v1 and v2</param>
		public static void Slerp(ref Vector2 v1, ref Vector2 v2, float f, out Vector2 result)
		{
			v1.Slerp(ref v2, f, out result);
		}

		/// <summary>static function equivalent to MoveTo(Vector2, float)</summary>
		/// <param name="v1">vector 1</param>
		/// <param name="v2">vector 2</param>
		/// <param name="length">step length</param>
		/// <returns>a new vector moved to target vector by specified length</returns>
		public static Vector2 MoveTo(Vector2 v1, Vector2 v2, float length)
		{
			Vector2 result;
			v1.MoveTo(ref v2, length, out result);
			return result;
		}

		/// <summary>static function equivalent to MoveTo(ref Vector2, float, out Vector2)</summary>
		/// <param name="v1">vector 1</param>
		/// <param name="v2">vector 2</param>
		/// <param name="length">step length</param>
		/// <param name="result">a new vector moved to target vector by specified length</param>
		public static void MoveTo(ref Vector2 v1, ref Vector2 v2, float length, out Vector2 result)
		{
			v1.MoveTo(ref v2, length, out result);
		}

		/// <summary>static function equivalent to TurnTo(Vector2, float)</summary>
		/// <param name="v1">vector 1</param>
		/// <param name="v2">vector 2</param>
		/// <param name="angle">step angle</param>
		/// <returns>a new vector turned to target vector by specified angle</returns>
		public static Vector2 TurnTo(Vector2 v1, Vector2 v2, float angle)
		{
			Vector2 result;
			v1.TurnTo(ref v2, angle, out result);
			return result;
		}

		/// <summary>static function equivalent to TurnTo(ref Vector2, float, out Vector2)</summary>
		/// <param name="v1">vector 1</param>
		/// <param name="v2">vector 2</param>
		/// <param name="angle">step angle</param>
		/// <param name="result">a new vector turned to target vector by specified angle</param>
		public static void TurnTo(ref Vector2 v1, ref Vector2 v2, float angle, out Vector2 result)
		{
			v1.TurnTo(ref v2, angle, out result);
		}

		/// <summary>static function equivalent to Angle(Vector2)</summary>
		/// <param name="v1">vector 1</param>
		/// <param name="v2">vector 2</param>
		/// <returns>the angle between v1 and v2</returns>
		public static float Angle(Vector2 v1, Vector2 v2)
		{
			return v1.Angle(ref v2);
		}

		/// <summary>static function equivalent to Angle(ref Vector2)</summary>
		/// <param name="v1">vector 1</param>
		/// <param name="v2">vector 2</param>
		/// <returns>the angle between v1 and v2</returns>
		public static float Angle(ref Vector2 v1, ref Vector2 v2)
		{
			return v1.Angle(ref v2);
		}

		/// <summary>static function equivalent to Rotate(float)</summary>
		/// <param name="v">vector</param>
		/// <param name="angle">angle to rotate by</param>
		/// <returns>the vector rotated by angle</returns>
		public static Vector2 Rotate(Vector2 v, float angle)
		{
			Vector2 result;
			v.Rotate(angle, out result);
			return result;
		}

		/// <summary>static function equivalent to Rotate(float, out Vector2)</summary>
		/// <param name="v">vector</param>
		/// <param name="angle">angle to rotate by</param>
		/// <param name="result">the vector rotated by angle</param>
		public static void Rotate(ref Vector2 v, float angle, out Vector2 result)
		{
			v.Rotate(angle, out result);
		}

		/// <summary>static function equivalent to Rotate(Vector2)</summary>
		/// <param name="v">vector</param>
		/// <param name="rotation">a vector containing the cos and sin of the angle to rotate by</param>
		/// <returns>the vector rotated by angle</returns>
		public static Vector2 Rotate(Vector2 v, Vector2 rotation)
		{
			Vector2 result;
			v.Rotate(ref rotation, out result);
			return result;
		}

		/// <summary>static function equivalent to Rotate(ref Vector2, out Vector2)</summary>
		/// <param name="v">vector</param>
		/// <param name="rotation">a vector containing the cos and sin of the angle to rotate by</param>
		/// <param name="result">the vector rotated by angle</param>
		public static void Rotate(ref Vector2 v, ref Vector2 rotation, out Vector2 result)
		{
			v.Rotate(ref rotation, out result);
		}

		/// <summary>static function equivalent to Reflect(Vector2)</summary>
		/// <param name="v">vector</param>
		/// <param name="normal">the vector to reflect about</param>
		/// <returns>the vector reflected about normal</returns>
		public static Vector2 Reflect(Vector2 v, Vector2 normal)
		{
			Vector2 result;
			v.Reflect(ref normal, out result);
			return result;
		}

		/// <summary>static function equivalent to Reflect(ref Vector2, out Vector2)</summary>
		/// <param name="v">vector</param>
		/// <param name="normal">the vector to reflect about</param>
		/// <param name="result">the vector reflected about normal</param>
		public static void Reflect(ref Vector2 v, ref Vector2 normal, out Vector2 result)
		{
			v.Reflect(ref normal, out result);
		}

		/// <summary>static function equivalent to Perpendicular()</summary>
		/// <param name="v">vector</param>
		/// <returns>a vector perpendicular to v</returns>
		public static Vector2 Perpendicular(Vector2 v)
		{
			Vector2 result;
			v.Perpendicular(out result);
			return result;
		}

		/// <summary>static function equivalent to Perpendicular(out Vector2)</summary>
		/// <param name="v">vector</param>
		/// <param name="result">a vector perpendicular to v</param>
		public static void Perpendicular(ref Vector2 v, out Vector2 result)
		{
			v.Perpendicular(out result);
		}

		/// <summary>static function equivalent to ProjectOnLine(Vector2, Vector2)</summary>
		/// <param name="v">vector</param>
		/// <param name="point">point of the line to project onto</param>
		/// <param name="direction">direction of the line to project onto</param>
		/// <returns>projection of v onto the line (point,direction)</returns>
		public static Vector2 ProjectOnLine(Vector2 v, Vector2 point, Vector2 direction)
		{
			Vector2 result;
			v.ProjectOnLine(ref point, ref direction, out result);
			return result;
		}

		/// <summary>static function equivalent to ProjectOnLine(ref Vector2, ref Vector2, out Vector2)</summary>
		/// <param name="v">vector</param>
		/// <param name="point">point of the line to project onto</param>
		/// <param name="direction">direction of the line to project onto</param>
		/// <param name="result">projection of v onto the line (point,direction)</param>
		public static void ProjectOnLine(ref Vector2 v, ref Vector2 point, ref Vector2 direction, out Vector2 result)
		{
			v.ProjectOnLine(ref point, ref direction, out result);
		}

		/// <summary>static function equivalent to Add(Vector2)</summary>
		/// <param name="v1">vector 1</param>
		/// <param name="v2">vector 2</param>
		/// <returns>v1 + v2</returns>
		public static Vector2 Add(Vector2 v1, Vector2 v2)
		{
			Vector2 result;
			v1.Add(ref v2, out result);
			return result;
		}

		/// <summary>static function equivalent to Add(ref Vector2, out Vector2)</summary>
		/// <param name="v1">vector 1</param>
		/// <param name="v2">vector 2</param>
		/// <param name="result">v1 + v2</param>
		public static void Add(ref Vector2 v1, ref Vector2 v2, out Vector2 result)
		{
			v1.Add(ref v2, out result);
		}

		/// <summary>static function equivalent to Subtract(Vector2)</summary>
		/// <param name="v1">vector 1</param>
		/// <param name="v2">vector 2</param>
		/// <returns>v1 - v2</returns>
		public static Vector2 Subtract(Vector2 v1, Vector2 v2)
		{
			Vector2 result;
			v1.Subtract(ref v2, out result);
			return result;
		}

		/// <summary>static function equivalent to Subtract(ref Vector2, out Vector2)</summary>
		/// <param name="v1">vector 1</param>
		/// <param name="v2">vector 2</param>
		/// <param name="result">v1 - v2</param>
		public static void Subtract(ref Vector2 v1, ref Vector2 v2, out Vector2 result)
		{
			v1.Subtract(ref v2, out result);
		}

		/// <summary>static function equivalent to Multiply(Vector2)</summary>
		/// <param name="v1">vector 1</param>
		/// <param name="v2">vector 2</param>
		/// <returns>v1 * v2</returns>
		public static Vector2 Multiply(Vector2 v1, Vector2 v2)
		{
			Vector2 result;
			v1.Multiply(ref v2, out result);
			return result;
		}

		/// <summary>static function equivalent to Multiply(ref Vector2, out Vector2)</summary>
		/// <param name="v1">vector 1</param>
		/// <param name="v2">vector 2</param>
		/// <param name="result">v1 * v2</param>
		public static void Multiply(ref Vector2 v1, ref Vector2 v2, out Vector2 result)
		{
			v1.Multiply(ref v2, out result);
		}

		/// <summary>static function equivalent to Multiply(float)</summary>
		/// <param name="v">vector</param>
		/// <param name="f">scalar</param>
		/// <returns>v * f</returns>
		public static Vector2 Multiply(Vector2 v, float f)
		{
			Vector2 result;
			v.Multiply(f, out result);
			return result;
		}

		/// <summary>static function equivalent to Multiply(float, out Vector2)</summary>
		/// <param name="v">vector</param>
		/// <param name="f">scalar</param>
		/// <param name="result">v * f</param>
		public static void Multiply(ref Vector2 v, float f, out Vector2 result)
		{
			v.Multiply(f, out result);
		}

		/// <summary>static function equivalent to Divide(Vector2)</summary>
		/// <param name="v1">vector 1</param>
		/// <param name="v2">vector 2</param>
		/// <returns>v1 / v2</returns>
		public static Vector2 Divide(Vector2 v1, Vector2 v2)
		{
			Vector2 result;
			v1.Divide(ref v2, out result);
			return result;
		}

		/// <summary>static function equivalent to Divide(ref Vector2, out Vector2)</summary>
		/// <param name="v1">vector 1</param>
		/// <param name="v2">vector 2</param>
		/// <param name="result">v1 / v2</param>
		public static void Divide(ref Vector2 v1, ref Vector2 v2, out Vector2 result)
		{
			v1.Divide(ref v2, out result);
		}

		/// <summary>static function equivalent to Divide(float)</summary>
		/// <param name="v">vector</param>
		/// <param name="f">scalar</param>
		/// <returns>v / f</returns>
		public static Vector2 Divide(Vector2 v, float f)
		{
			Vector2 result;
			v.Divide(f, out result);
			return result;
		}

		/// <summary>static function equivalent to Divide(float, out Vector2)</summary>
		/// <param name="v">vector</param>
		/// <param name="f">scalar</param>
		/// <param name="result">v / f</param>
		public static void Divide(ref Vector2 v, float f, out Vector2 result)
		{
			v.Divide(f, out result);
		}

		/// <summary>static function equivalent to Negate()</summary>
		/// <param name="v">vector</param>
		/// <returns>-v</returns>
		public static Vector2 Negate(Vector2 v)
		{
			Vector2 result;
			v.Negate(out result);
			return result;
		}

		/// <summary>static function equivalent to Negate(out Vector2)</summary>
		/// <param name="v">vector</param>
		/// <param name="result">-v</param>
		public static void Negate(ref Vector2 v, out Vector2 result)
		{
			v.Negate(out result);
		}

		/// <summary>equality operator</summary>
		/// <param name="v1">vector 1</param>
		/// <param name="v2">vector 2</param>
		/// <returns>true if vector 1 == vector 2, false otherwise</returns>
		public static bool operator ==(Vector2 v1, Vector2 v2)
		{
			return v1.X == v2.X && v1.Y == v2.Y;
		}

		/// <summary>not equals operator</summary>
		/// <param name="v1">vector 1</param>
		/// <param name="v2">vector 2</param>
		/// <returns>true if vector 1 != vector 2, false otherwise</returns>
		public static bool operator !=(Vector2 v1, Vector2 v2)
		{
			return v1.X != v2.X || v1.Y != v2.Y;
		}

		/// <summary>vector addition operator</summary>
		/// <param name="v1">vector 1</param>
		/// <param name="v2">vector 2</param>
		/// <returns>vector 1 + vector 2</returns>
		public static Vector2 operator +(Vector2 v1, Vector2 v2)
		{
			return new Vector2(v1.X + v2.X, v1.Y + v2.Y);
		}

		/// <summary>adds a scalar float to each element of a vector</summary>
		/// <param name="v">the vector to add</param>
		/// <param name="f">the scalar float to add each element of the vector</param>
		/// <returns>a new vector with f added to each element of v</returns>
		public static Vector2 operator +(Vector2 v, float f)
		{
			return new Vector2(v.X + f, v.Y + f);
		}

		/// <summary>adds a scalar float to each element of a vector</summary>
		/// <param name="f">the scalar float to add each element of the vector</param>
		/// <param name="v">the vector to add</param>
		/// <returns>a new vector with f added to each element of v</returns>
		public static Vector2 operator +(float f, Vector2 v)
		{
			return new Vector2(f + v.X, f + v.Y);
		}

		/// <summary>vector subtraction operator</summary>
		/// <param name="v1">vector 1</param>
		/// <param name="v2">vector 2</param>
		/// <returns>vector 1 - vector 2</returns>
		public static Vector2 operator -(Vector2 v1, Vector2 v2)
		{
			return new Vector2(v1.X - v2.X, v1.Y - v2.Y);
		}

		/// <summary>subtract a scalar float from each element of a vector</summary>
		/// <param name="v">the vector to subtract from</param>
		/// <param name="f">the scalar float to subtract from each element of the vector</param>
		/// <returns>a new vector with f subtracted from each element of v</returns>
		public static Vector2 operator -(Vector2 v, float f)
		{
			return new Vector2(v.X - f, v.Y - f);
		}

		/// <summary>creates a new vector consisting of {f, f}, and then subtracts v from it</summary>
		/// <param name="f">the scalar that we subtract v from</param>
		/// <param name="v">the vector to subtract</param>
		/// <returns>a new vector consisting of v subtracted from the vector {f, f}</returns>
		public static Vector2 operator -(float f, Vector2 v)
		{
			return new Vector2(f - v.X, f - v.Y);
		}

		/// <summary>unary minus operator</summary>
		/// <param name="v">the vector to negate</param>
		/// <returns>unary minus applied to each member of v</returns>
		public static Vector2 operator -(Vector2 v)
		{
			return new Vector2(-v.X, -v.Y);
		}

		/// <summary>multiplication operator</summary>
		/// <param name="v1">vector 1</param>
		/// <param name="v2">vector 2</param>
		/// <returns>vector 1 * vector 2</returns>
		public static Vector2 operator *(Vector2 v1, Vector2 v2)
		{
			return new Vector2(v1.X * v2.X, v1.Y * v2.Y);
		}

		/// <summary>multiply each element of vector by scalar float</summary>
		/// <param name="v">the vector to multiply</param>
		/// <param name="f">the scalar to multiply each element of the vector by</param>
		/// <returns>a new vector consisting of each element of vector multiplied by f</returns>
		public static Vector2 operator *(Vector2 v, float f)
		{
			return new Vector2(v.X * f, v.Y * f);
		}

		/// <summary>multiply each element of vector by scalar float</summary>
		/// <param name="f">the scalar to multiply each element of the vector by</param>
		/// <param name="v">the vector to multiply</param>
		/// <returns>a new vector consisting of each element of vector multiplied by f</returns>
		public static Vector2 operator *(float f, Vector2 v)
		{
			return new Vector2(f * v.X, f * v.Y);
		}

		/// <summary>division operator</summary>
		/// <param name="v1">vector 1</param>
		/// <param name="v2">vector 2</param>
		/// <returns>vector 1 / vector 2</returns>
		public static Vector2 operator /(Vector2 v1, Vector2 v2)
		{
			return new Vector2(v1.X / v2.X, v1.Y / v2.Y);
		}

		/// <summary>divide each element of a vector by a scalar float</summary>
		/// <param name="v">the vector to divide by scalar</param>
		/// <param name="f">the scalar to divide by</param>
		/// <returns>a new Vector2 consisting of each element of v divided by f</returns>
		public static Vector2 operator /(Vector2 v, float f)
		{
			float num = 1f / f;
			return new Vector2(v.X * num, v.Y * num);
		}

		/// <summary>create a new vector consisting of {f, f} and divide it by vec</summary>
		/// <param name="f">the scalar to divide by vector</param>
		/// <param name="v">the vector to divide by</param>
		/// <returns>a new vector {f, f} divided by v</returns>
		public static Vector2 operator /(float f, Vector2 v)
		{
			return new Vector2(f / v.X, f / v.Y);
		}

		/// <summary>x</summary>
		public float X;

		/// <summary>y</summary>
		public float Y;

		/// <summary>return a new vector with x and y set to 0 and 0</summary>
		/// <returns>a new vector with x and y set to 0 and 0</returns>
		public static readonly Vector2 Zero = new Vector2(0f, 0f);

		/// <summary>return a new vector with x and y set to 1 and 1</summary>
		/// <returns>a new vector with x and y set to 1 and 1</returns>
		public static readonly Vector2 One = new Vector2(1f, 1f);

		/// <summary>return a new vector with x and y set to 1 and 0</summary>
		/// <returns>a new vector with x and y set to 1 and 0</returns>
		public static readonly Vector2 UnitX = new Vector2(1f, 0f);

		/// <summary>return a new vector with x and y set to 0 and 1</summary>
		/// <returns>a new vector with x and y set to 0 and 1</returns>
		public static readonly Vector2 UnitY = new Vector2(0f, 1f);
	}
}
