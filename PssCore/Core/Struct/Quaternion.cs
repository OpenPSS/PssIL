using System;

namespace Sce.PlayStation.Core
{
	/// <summary>quaternion</summary>
	// 
	public struct Quaternion : IEquatable<Quaternion>
	{
		/// <summary>constructor taking 4 floats</summary>
		/// <param name="x">x value to init with</param>
		/// <param name="y">y value to init with</param>
		/// <param name="z">z value to init with</param>
		/// <param name="w">w value to init with</param>

		public Quaternion(float x, float y, float z, float w)
		{
			this.X = x;
			this.Y = y;
			this.Z = z;
			this.W = w;
		}

		/// <summary>constructor taking a Vector3 and a scalar float</summary>
		/// <param name="xyz">the x, y, z values to init with</param>
		/// <param name="w">the w value to init with</param>

		public Quaternion(Vector3 xyz, float w)
		{
			this.X = xyz.X;
			this.Y = xyz.Y;
			this.Z = xyz.Z;
			this.W = w;
		}

		/// <summary>constructor taking a Vector4</summary>
		/// <param name="v">the vector to init with</param>

		public Quaternion(Vector4 v)
		{
			this.X = v.X;
			this.Y = v.Y;
			this.Z = v.Z;
			this.W = v.W;
		}

		/// <summary>return the length of this quaternion</summary>
		/// <returns>the length of this quaternion</returns>

		public float Length()
		{
			return (float)Math.Sqrt((double)(this.X * this.X + this.Y * this.Y + this.Z * this.Z + this.W * this.W));
		}

		/// <summary>return the length squared of this quaternion</summary>
		/// <returns>the length squared of this quaternion</returns>

		public float LengthSquared()
		{
			return this.X * this.X + this.Y * this.Y + this.Z * this.Z + this.W * this.W;
		}

		/// <summary>dot product</summary>
		/// <param name="q">quaternion to take the dot product with</param>
		/// <returns>dot product of this and q</returns>

		public float Dot(Quaternion q)
		{
			return this.X * q.X + this.Y * q.Y + this.Z * q.Z + this.W * q.W;
		}

		/// <summary>dot product</summary>
		/// <param name="q">quaternion to take the dot product with</param>
		/// <returns>dot product of this and q</returns>

		public float Dot(ref Quaternion q)
		{
			return this.X * q.X + this.Y * q.Y + this.Z * q.Z + this.W * q.W;
		}

		/// <summary>return a unit quaternion</summary>
		/// <returns>this as a unit quaternion</returns>

		public Quaternion Normalize()
		{
			Quaternion result;
			this.Normalize(out result);
			return result;
		}

		/// <summary>return a unit quaternion</summary>
		/// <param name="result">this as a unit quaternion</param>

		public void Normalize(out Quaternion result)
		{
			float num = 1f / this.Length();
			result.X = this.X * num;
			result.Y = this.Y * num;
			result.Z = this.Z * num;
			result.W = this.W * num;
		}

		/// <summary>quaternion conjugate</summary>
		/// <returns>quaternion conjugate</returns>

		public Quaternion Conjugate()
		{
			Quaternion result;
			this.Conjugate(out result);
			return result;
		}

		/// <summary>quaternion conjugate</summary>
		/// <param name="result">quaternion conjugate</param>

		public void Conjugate(out Quaternion result)
		{
			result.X = -this.X;
			result.Y = -this.Y;
			result.Z = -this.Z;
			result.W = this.W;
		}

		/// <summary>quaternion inverse</summary>
		/// <returns>quaternion inverse</returns>

		public Quaternion Inverse()
		{
			Quaternion result;
			this.Inverse(out result);
			return result;
		}

		/// <summary>quaternion inverse</summary>
		/// <param name="result">quaternion inverse</param>

		public void Inverse(out Quaternion result)
		{
			float num = 1f / this.LengthSquared();
			result.X = -this.X * num;
			result.Y = -this.Y * num;
			result.Z = -this.Z * num;
			result.W = this.W * num;
		}

		/// <summary>slerp between 2 quaternions</summary>
		/// <param name="q">second quaternion</param>
		/// <param name="f">slerp amount</param>
		/// <returns>slerp between this and q</returns>

		public Quaternion Slerp(Quaternion q, float f)
		{
			Quaternion result;
			this.Slerp(ref q, f, out result);
			return result;
		}

		/// <summary>slerp between 2 quaternions</summary>
		/// <param name="q">second quaternion</param>
		/// <param name="f">slerp amount</param>
		/// <param name="result">slerp between this and q</param>

		public void Slerp(ref Quaternion q, float f, out Quaternion result)
		{
			if (f <= 0f)
			{
				result = this;
			}
			else if (f >= 1f)
			{
				result = q;
			}
			else
			{
				float num = this.X * q.X + this.Y * q.Y + this.Z * q.Z + this.W * q.W;
				float num2 = 1f - f;
				float num3 = f;
				if (num < 0.998047f)
				{
					if (num < 0f)
					{
						num = -num;
						num3 = -num3;
						if (num > 1f)
						{
							num = 1f;
						}
					}
					float num4 = (float)Math.Acos((double)num);
					float num5 = (float)Math.Sin((double)num4);
					if (num5 > 5E-05f)
					{
						num2 = (float)Math.Sin((double)(num2 * num4)) / num5;
						num3 = (float)Math.Sin((double)(num3 * num4)) / num5;
					}
				}
				result.X = this.X * num2 + q.X * num3;
				result.Y = this.Y * num2 + q.Y * num3;
				result.Z = this.Z * num2 + q.Z * num3;
				result.W = this.W * num2 + q.W * num3;
			}
		}

		/// <summary>lerp between 2 quaternions</summary>
		/// <param name="q">second quaternion</param>
		/// <param name="f">lerp amount</param>
		/// <returns>lerp between this and q</returns>

		public Quaternion Lerp(Quaternion q, float f)
		{
			Quaternion result;
			this.Lerp(ref q, f, out result);
			return result;
		}

		/// <summary>lerp between 2 quaternions</summary>
		/// <param name="q">second quaternion</param>
		/// <param name="f">lerp amount</param>
		/// <param name="result">lerp between this and q</param>

		public void Lerp(ref Quaternion q, float f, out Quaternion result)
		{
			float num = 1f - f;
			result.X = this.X * num + q.X * f;
			result.Y = this.Y * num + q.Y * f;
			result.Z = this.Z * num + q.Z * f;
			result.W = this.W * num + q.W * f;
		}

		/// <summary>quaternion log</summary>
		/// <returns>quaternion log</returns>

		public Quaternion Log()
		{
			Quaternion result;
			this.Log(out result);
			return result;
		}

		/// <summary>quaternion log</summary>
		/// <param name="result">quaternion log</param>

		public void Log(out Quaternion result)
		{
			float num = (this.W < -1f) ? -1f : ((this.W > 1f) ? 1f : this.W);
			float num2 = (float)Math.Acos((double)num);
			float num3 = (float)Math.Sin((double)num2);
			float num4 = (num3 <= 0f) ? 0f : (num2 / num3);
			result.X = this.X * num4;
			result.Y = this.Y * num4;
			result.Z = this.Z * num4;
			result.W = 0f;
		}

		/// <summary>quaternion exp</summary>
		/// <returns>quaternion exp</returns>

		public Quaternion Exp()
		{
			Quaternion result;
			this.Exp(out result);
			return result;
		}

		/// <summary>quaternion exp</summary>
		/// <param name="result">quaternion exp</param>

		public void Exp(out Quaternion result)
		{
			float num = (float)Math.Sqrt((double)(this.X * this.X + this.Y * this.Y + this.Z * this.Z));
			float num2 = (num <= 0f) ? 0f : ((float)Math.Sin((double)num) / num);
			result.X = this.X * num2;
			result.Y = this.Y * num2;
			result.Z = this.Z * num2;
			result.W = (float)Math.Cos((double)num);
		}

		/// <summary>turn to target quaternion by specified angle</summary>
		/// <param name="q">target quaternion</param>
		/// <param name="angle">step angle</param>
		/// <returns>a new quaternion turned to target quaternion by specified angle</returns>

		public Quaternion TurnTo(Quaternion q, float angle)
		{
			Quaternion result;
			this.TurnTo(ref q, angle, out result);
			return result;
		}

		/// <summary>turn to target quaternion by specified angle</summary>
		/// <param name="q">target quaternion</param>
		/// <param name="angle">step angle</param>
		/// <param name="result">a new quaternion turned to target quaternion by specified angle</param>

		public void TurnTo(ref Quaternion q, float angle, out Quaternion result)
		{
			float num = this.Angle(q);
			result = ((angle >= num) ? q : this.Slerp(q, angle / num));
		}

		/// <summary>get the angle between this and the input quaternion</summary>
		/// <param name="q">the quaternion to get the angle to</param>
		/// <returns>the angle between this and v</returns>

		public float Angle(Quaternion q)
		{
			return this.Angle(ref q);
		}

		/// <summary>get the angle between this and the input quaternion</summary>
		/// <param name="q">the quaternion to get the angle to</param>
		/// <returns>the angle between this and q</returns>

		public float Angle(ref Quaternion q)
		{
			float num = this.Dot(ref q);
			if (num < 0f)
			{
				num = -num;
			}
			if (num > 1f)
			{
				num = 1f;
			}
			return (float)Math.Acos((double)num) * 2f;
		}

		/// <summary>return this * v</summary>
		/// <param name="v">vector</param>
		/// <returns>this * v</returns>&gt;

		public Vector4 Transform(Vector4 v)
		{
			Vector4 result;
			this.Transform(ref v, out result);
			return result;
		}

		/// <summary>result = this * v</summary>
		/// <param name="v">vector</param>
		/// <param name="result">this * v</param>

		public void Transform(ref Vector4 v, out Vector4 result)
		{
			float num = this.W * v.X + this.Y * v.Z - this.Z * v.Y;
			float num2 = this.W * v.Y - this.X * v.Z + this.Z * v.X;
			float num3 = this.W * v.Z + this.X * v.Y - this.Y * v.X;
			result.X = (this.Y * num3 - this.Z * num2) * 2f + v.X;
			result.Y = (this.Z * num - this.X * num3) * 2f + v.Y;
			result.Z = (this.X * num2 - this.Y * num) * 2f + v.Z;
			result.W = v.W;
		}

		/// <summary>return this * v</summary>
		/// <param name="v">vector</param>
		/// <returns>this * v</returns>&gt;

		public Vector3 Transform(Vector3 v)
		{
			Vector3 result;
			this.Transform(ref v, out result);
			return result;
		}

		/// <summary>result = this * v</summary>
		/// <param name="v">vector</param>
		/// <param name="result">this * v</param>

		public void Transform(ref Vector3 v, out Vector3 result)
		{
			float num = this.W * v.X + this.Y * v.Z - this.Z * v.Y;
			float num2 = this.W * v.Y - this.X * v.Z + this.Z * v.X;
			float num3 = this.W * v.Z + this.X * v.Y - this.Y * v.X;
			result.X = (this.Y * num3 - this.Z * num2) * 2f + v.X;
			result.Y = (this.Z * num - this.X * num3) * 2f + v.Y;
			result.Z = (this.X * num2 - this.Y * num) * 2f + v.Z;
		}

		/// <summary>return this * v</summary>
		/// <param name="v">vector</param>
		/// <returns>this * v</returns>&gt;

		public Vector2 Transform(Vector2 v)
		{
			Vector2 result;
			this.Transform(ref v, out result);
			return result;
		}

		/// <summary>result = this * v</summary>
		/// <param name="v">vector</param>
		/// <param name="result">this * v</param>

		public void Transform(ref Vector2 v, out Vector2 result)
		{
			float num = this.W * v.X - this.Z * v.Y;
			float num2 = this.W * v.Y + this.Z * v.X;
			float num3 = this.X * v.Y - this.Y * v.X;
			result.X = (this.Y * num3 - this.Z * num2) * 2f + v.X;
			result.Y = (this.Z * num - this.X * num3) * 2f + v.Y;
		}

		/// <summary>return this + q</summary>
		/// <param name="q">quaternion</param>
		/// <returns>this + q</returns>

		public Quaternion Add(Quaternion q)
		{
			Quaternion result;
			this.Add(ref q, out result);
			return result;
		}

		/// <summary>result = this + q</summary>
		/// <param name="q">quaternion</param>
		/// <param name="result">this + q</param>

		public void Add(ref Quaternion q, out Quaternion result)
		{
			result.X = this.X + q.X;
			result.Y = this.Y + q.Y;
			result.Z = this.Z + q.Z;
			result.W = this.W + q.W;
		}

		/// <summary>return this - q</summary>
		/// <param name="q">quaternion</param>
		/// <returns>this - q</returns>

		public Quaternion Subtract(Quaternion q)
		{
			Quaternion result;
			this.Subtract(ref q, out result);
			return result;
		}

		/// <summary>result = this - q</summary>
		/// <param name="q">quaternion</param>
		/// <param name="result">this - q</param>

		public void Subtract(ref Quaternion q, out Quaternion result)
		{
			result.X = this.X - q.X;
			result.Y = this.Y - q.Y;
			result.Z = this.Z - q.Z;
			result.W = this.W - q.W;
		}

		/// <summary>return this * q</summary>
		/// <param name="q">quaternion</param>
		/// <returns>this * q</returns>

		public Quaternion Multiply(Quaternion q)
		{
			Quaternion result;
			this.Multiply(ref q, out result);
			return result;
		}

		/// <summary>result = this * q</summary>
		/// <param name="q">quaternion</param>
		/// <param name="result">this * q</param>

		public void Multiply(ref Quaternion q, out Quaternion result)
		{
			result.X = this.W * q.X + this.X * q.W + this.Y * q.Z - this.Z * q.Y;
			result.Y = this.W * q.Y - this.X * q.Z + this.Y * q.W + this.Z * q.X;
			result.Z = this.W * q.Z + this.X * q.Y - this.Y * q.X + this.Z * q.W;
			result.W = this.W * q.W - this.X * q.X - this.Y * q.Y - this.Z * q.Z;
		}

		/// <summary>return this * f</summary>
		/// <param name="f">scalar</param>
		/// <returns>this * f</returns>

		public Quaternion Multiply(float f)
		{
			Quaternion result;
			this.Multiply(f, out result);
			return result;
		}

		/// <summary>result = this * f</summary>
		/// <param name="f">scalar</param>
		/// <param name="result">this * f</param>

		public void Multiply(float f, out Quaternion result)
		{
			result.X = this.X * f;
			result.Y = this.Y * f;
			result.Z = this.Z * f;
			result.W = this.W * f;
		}

		/// <summary>return this / f</summary>
		/// <param name="f">scalar</param>
		/// <returns>this / f</returns>

		public Quaternion Divide(float f)
		{
			Quaternion result;
			this.Divide(f, out result);
			return result;
		}

		/// <summary>result = this / f</summary>
		/// <param name="f">scalar</param>
		/// <param name="result">this / f</param>

		public void Divide(float f, out Quaternion result)
		{
			float num = 1f / f;
			result.X = this.X * num;
			result.Y = this.Y * num;
			result.Z = this.Z * num;
			result.W = this.W * num;
		}

		/// <summary>return -this</summary>
		/// <returns>-this</returns>

		public Quaternion Negate()
		{
			Quaternion result;
			this.Negate(out result);
			return result;
		}

		/// <summary>result = -this</summary>
		/// <param name="result">-this</param>

		public void Negate(out Quaternion result)
		{
			result.X = -this.X;
			result.Y = -this.Y;
			result.Z = -this.Z;
			result.W = -this.W;
		}

		/// <summary>return the quaternion as a Vector4</summary>
		/// <returns>the quaternion as a Vector4</returns>

		public Vector4 ToVector4()
		{
			Vector4 result;
			this.ToVector4(out result);
			return result;
		}

		/// <summary>return the quaternion as a Vector4</summary>
		/// <param name="result">the quaternion as a Vector4</param>

		public void ToVector4(out Vector4 result)
		{
			result.X = this.X;
			result.Y = this.Y;
			result.Z = this.Z;
			result.W = this.W;
		}

		/// <summary>convert this quaternion to a Matrix4</summary>
		/// <returns>Matrix4 representation of this quaternion</returns>

		public Matrix4 ToMatrix4()
		{
			Matrix4 result;
			this.ToMatrix4(out result);
			return result;
		}

		/// <summary>convert this quaternion to a Matrix4</summary>
		/// <param name="result">Matrix4 representation of this quaternion</param>

		public void ToMatrix4(out Matrix4 result)
		{
			float num = this.X + this.X;
			float num2 = this.Y + this.Y;
			float num3 = this.Z + this.Z;
			float num4 = this.X * num;
			float num5 = this.Y * num2;
			float num6 = this.Z * num3;
			float num7 = this.Z * num;
			float num8 = this.X * num2;
			float num9 = this.Y * num3;
			float num10 = this.W * num;
			float num11 = this.W * num2;
			float num12 = this.W * num3;
			result.M11 = 1f - num5 - num6;
			result.M12 = num8 + num12;
			result.M13 = num7 - num11;
			result.M21 = num8 - num12;
			result.M22 = 1f - num4 - num6;
			result.M23 = num9 + num10;
			result.M31 = num7 + num11;
			result.M32 = num9 - num10;
			result.M33 = 1f - num4 - num5;
			result.M14 = (result.M24 = (result.M34 = 0f));
			result.M41 = (result.M42 = (result.M43 = 0f));
			result.M44 = 1f;
		}

		/// <summary>extract the rotation axis and angle from this quaternion</summary>
		/// <param name="axis">the rotation axis</param>
		/// <param name="angle">the rotation angle</param>

		public void ToAxisAngle(out Vector3 axis, out float angle)
		{
			axis.X = this.X;
			axis.Y = this.Y;
			axis.Z = this.Z;
			angle = (float)Math.Acos((double)this.W) * 2f;
		}

		/// <summary>test if this is a unit quaternion</summary>
		/// <param name="epsilon">epsilon used in testing</param>
		/// <returns>true if this is a unit quaternion, false otherwise</returns>

		public bool IsUnit(float epsilon)
		{
			return Math.Abs(this.Length() - 1f) <= epsilon;
		}

		/// <summary>test if this is an identity quaternion</summary>
		/// <returns>true if this is an identity quaternion, false otherwise</returns>

		public bool IsIdentity()
		{
			return this.X == 0f && this.Y == 0f && this.Z == 0f && this.W == 1f;
		}

		/// <summary>test if any elements of this are Infinity</summary>
		/// <returns>true if any elements of this are Infinity, false otherwise</returns>

		public bool IsInfinity()
		{
			return float.IsInfinity(this.X) || float.IsInfinity(this.Y) || float.IsInfinity(this.Z) || float.IsInfinity(this.W);
		}

		/// <summary>test if any elements of this are NaN</summary>
		/// <returns>true if any elements of this are NaN, false otherwise</returns>

		public bool IsNaN()
		{
			return float.IsNaN(this.X) || float.IsNaN(this.Y) || float.IsNaN(this.Z) || float.IsNaN(this.W);
		}


		public bool Equals(Quaternion q, float epsilon)
		{
			return Math.Abs(this.X - q.X) <= epsilon && Math.Abs(this.Y - q.Y) <= epsilon && Math.Abs(this.Z - q.Z) <= epsilon && Math.Abs(this.W - q.W) <= epsilon;
		}

		/// <summary>equality test</summary>
		/// <param name="q">the quaternion to compare this to</param>
		/// <returns>true if this == q, false otherwise</returns>

		public bool Equals(Quaternion q)
		{
			return this.X == q.X && this.Y == q.Y && this.Z == q.Z && this.W == q.W;
		}

		/// <summary>equality test</summary>
		/// <param name="o">the object to compare this to</param>
		/// <returns>true if this == o, false otherwise</returns>

		public override bool Equals(object o)
		{
			return o is Quaternion && this.Equals((Quaternion)o);
		}

		/// <summary>get the string representation of this quaternion</summary>
		/// <returns>the string representation of this quaternion</returns>

		public override string ToString()
		{
			return string.Format("({0:F6},{1:F6},{2:F6},{3:F6})", new object[]
			{
				this.X,
				this.Y,
				this.Z,
				this.W
			});
		}

		/// <summary>gets the hash code for this vector</summary>
		/// <returns>integer hash code</returns>

		public override int GetHashCode()
		{
			return this.X.GetHashCode() ^ this.Y.GetHashCode() ^ this.Z.GetHashCode() ^ this.W.GetHashCode();
		}

		/// <summary>return a quaternion representing a rotation matrix</summary>
		/// <param name="m">matrix to form the quaternion out of</param>
		/// <returns>a quaternion representing a rotation matrix</returns>

		public static Quaternion FromMatrix4(Matrix4 m)
		{
			Quaternion result;
			Quaternion.FromMatrix4(ref m, out result);
			return result;
		}

		/// <summary>return a quaternion representing a rotation matrix</summary>
		/// <param name="m">matrix to form the quaternion out of</param>
		/// <param name="result">a quaternion representing a rotation matrix</param>

		public static void FromMatrix4(ref Matrix4 m, out Quaternion result)
		{
			float num = m.M11 + m.M22 + m.M33;
			if (num > 0f)
			{
				float num2 = (float)Math.Sqrt((double)(num + 1f)) * 0.5f;
				float num3 = 0.25f / num2;
				result.X = (m.M23 - m.M32) * num3;
				result.Y = (m.M31 - m.M13) * num3;
				result.Z = (m.M12 - m.M21) * num3;
				result.W = num2;
			}
			else if (m.M11 > m.M22 && m.M11 > m.M33)
			{
				float num4 = (float)Math.Sqrt((double)(m.M11 - m.M22 - m.M33 + 1f)) * 0.5f;
				float num3 = 0.25f / num4;
				result.X = num4;
				result.Y = (m.M21 + m.M12) * num3;
				result.Z = (m.M31 + m.M13) * num3;
				result.W = (m.M23 - m.M32) * num3;
			}
			else if (m.M22 > m.M33)
			{
				float num5 = (float)Math.Sqrt((double)(m.M22 - m.M33 - m.M11 + 1f)) * 0.5f;
				float num3 = 0.25f / num5;
				result.X = (m.M21 + m.M12) * num3;
				result.Y = num5;
				result.Z = (m.M32 + m.M23) * num3;
				result.W = (m.M31 - m.M13) * num3;
			}
			else
			{
				float num6 = (float)Math.Sqrt((double)(m.M33 - m.M11 - m.M22 + 1f)) * 0.5f;
				float num3 = 0.25f / num6;
				result.X = (m.M31 + m.M13) * num3;
				result.Y = (m.M32 + m.M23) * num3;
				result.Z = num6;
				result.W = (m.M12 - m.M21) * num3;
			}
		}

		/// <summary>return a quaternion representing a rotation about an arbitrary axis</summary>
		/// <param name="axis">the axis to rotate about</param>
		/// <param name="angle">the angle to rotate</param>
		/// <returns>a quaternion representing a rotation about an arbitrary axis</returns>

		public static Quaternion RotationAxis(Vector3 axis, float angle)
		{
			Quaternion result;
			Quaternion.RotationAxis(ref axis, angle, out result);
			return result;
		}

		/// <summary>return a quaternion representing a rotation about an arbitrary axis</summary>
		/// <param name="axis">the axis to rotate about</param>
		/// <param name="angle">the angle to rotate</param>
		/// <param name="result">a quaternion representing a rotation about an arbitrary axis</param>

		public static void RotationAxis(ref Vector3 axis, float angle, out Quaternion result)
		{
			angle *= 0.5f;
			float num = (float)Math.Sin((double)angle) / axis.Length();
			result.X = axis.X * num;
			result.Y = axis.Y * num;
			result.Z = axis.Z * num;
			result.W = (float)Math.Cos((double)angle);
		}

		/// <summary>return a quaternion representing a rotation about the x axis</summary>
		/// <param name="angle">the angle to rotate by</param>
		/// <returns>a quaternion representing a rotation about the x axis</returns>

		public static Quaternion RotationX(float angle)
		{
			Quaternion result;
			Quaternion.RotationX(angle, out result);
			return result;
		}

		/// <summary>return a quaternion representing a rotation about the x axis</summary>
		/// <param name="angle">the angle to rotate by</param>
		/// <param name="result">a quaternion representing a rotation about the x axis</param>

		public static void RotationX(float angle, out Quaternion result)
		{
			angle *= 0.5f;
			result.X = (float)Math.Sin((double)angle);
			result.Y = 0f;
			result.Z = 0f;
			result.W = (float)Math.Cos((double)angle);
		}

		/// <summary>return a quaternion representing a rotation about the y axis</summary>
		/// <param name="angle">the angle to rotate by</param>
		/// <returns>a quaternion representing a rotation about the y axis</returns>

		public static Quaternion RotationY(float angle)
		{
			Quaternion result;
			Quaternion.RotationY(angle, out result);
			return result;
		}

		/// <summary>return a quaternion representing a rotation about the y axis</summary>
		/// <param name="angle">the angle to rotate by</param>
		/// <param name="result">a quaternion representing a rotation about the y axis</param>

		public static void RotationY(float angle, out Quaternion result)
		{
			angle *= 0.5f;
			result.X = 0f;
			result.Y = (float)Math.Sin((double)angle);
			result.Z = 0f;
			result.W = (float)Math.Cos((double)angle);
		}

		/// <summary>return a quaternion representing a rotation about the z axis</summary>
		/// <param name="angle">the angle to rotate by</param>
		/// <returns>a quaternion representing a rotation about the z axis</returns>

		public static Quaternion RotationZ(float angle)
		{
			Quaternion result;
			Quaternion.RotationZ(angle, out result);
			return result;
		}

		/// <summary>return a quaternion representing a rotation about the z axis</summary>
		/// <param name="angle">the angle to rotate by</param>
		/// <param name="result">a quaternion representing a rotation about the z axis</param>

		public static void RotationZ(float angle, out Quaternion result)
		{
			angle *= 0.5f;
			result.X = 0f;
			result.Y = 0f;
			result.Z = (float)Math.Sin((double)angle);
			result.W = (float)Math.Cos((double)angle);
		}

		/// <summary>create a new quaternion from three euler angles</summary>
		/// <param name="x">x angle</param>
		/// <param name="y">y angle</param>
		/// <param name="z">z angle</param>
		/// <returns>a new quaternion from the three euler angles</returns>

		public static Quaternion RotationZyx(float x, float y, float z)
		{
			Quaternion result;
			Quaternion.RotationZyx(x, y, z, out result);
			return result;
		}

		/// <summary>create a new quaternion from three euler angles</summary>
		/// <param name="x">x angle</param>
		/// <param name="y">y angle</param>
		/// <param name="z">z angle</param>
		/// <param name="result">a new quaternion from the three euler angles</param>

		public static void RotationZyx(float x, float y, float z, out Quaternion result)
		{
			Vector3 vector;
			Vector3 vector2;
			Quaternion.RotationVector(x, y, z, out vector, out vector2);
			result.X = vector.Z * vector.Y * vector2.X - vector.X * vector2.Z * vector2.Y;
			result.Y = vector.X * vector.Z * vector2.Y + vector.Y * vector2.Z * vector2.X;
			result.Z = vector.X * vector.Y * vector2.Z - vector.Z * vector2.Y * vector2.X;
			result.W = vector.Z * vector.Y * vector.X + vector2.Z * vector2.Y * vector2.X;
		}

		/// <summary>create a new quaternion from three euler angles</summary>
		/// <param name="angles">the z, y, x euler angles used to create the quaternion</param>
		/// <returns>a new quaternion from the three euler angles</returns>

		public static Quaternion RotationZyx(Vector3 angles)
		{
			Quaternion result;
			Quaternion.RotationZyx(angles.X, angles.Y, angles.Z, out result);
			return result;
		}

		/// <summary>create a new quaternion from three euler angles</summary>
		/// <param name="angles">the z, y, x euler angles used to create the quaternion</param>
		/// <param name="result">a new quaternion from the three euler angles</param>

		public static void RotationZyx(ref Vector3 angles, out Quaternion result)
		{
			Quaternion.RotationZyx(angles.X, angles.Y, angles.Z, out result);
		}

		/// <summary>create a new quaternion from three euler angles</summary>
		/// <param name="x">x angle</param>
		/// <param name="y">y angle</param>
		/// <param name="z">z angle</param>
		/// <returns>a new quaternion from the three euler angles</returns>

		public static Quaternion RotationYxz(float x, float y, float z)
		{
			Quaternion result;
			Quaternion.RotationYxz(x, y, z, out result);
			return result;
		}

		/// <summary>create a new quaternion from three euler angles</summary>
		/// <param name="x">x angle</param>
		/// <param name="y">y angle</param>
		/// <param name="z">z angle</param>
		/// <param name="result">a new quaternion from the three euler angles</param>

		public static void RotationYxz(float x, float y, float z, out Quaternion result)
		{
			Vector3 vector;
			Vector3 vector2;
			Quaternion.RotationVector(x, y, z, out vector, out vector2);
			result.X = vector.Z * vector.Y * vector2.X + vector.X * vector2.Y * vector2.Z;
			result.Y = vector.Z * vector.X * vector2.Y - vector.Y * vector2.X * vector2.Z;
			result.Z = vector.Y * vector.X * vector2.Z - vector.Z * vector2.Y * vector2.X;
			result.W = vector.Y * vector.X * vector.Z + vector2.Y * vector2.X * vector2.Z;
		}

		/// <summary>create a new quaternion from three euler angles</summary>
		/// <param name="angles">the y, x, z euler angles used to create the quaternion</param>
		/// <returns>a new quaternion from the three euler angles</returns>

		public static Quaternion RotationYxz(Vector3 angles)
		{
			Quaternion result;
			Quaternion.RotationYxz(angles.X, angles.Y, angles.Z, out result);
			return result;
		}

		/// <summary>create a new quaternion from three euler angles</summary>
		/// <param name="angles">the y, x, z euler angles used to create the quaternion</param>
		/// <param name="result">a new quaternion from the three euler angles</param>

		public static void RotationYxz(ref Vector3 angles, out Quaternion result)
		{
			Quaternion.RotationYxz(angles.X, angles.Y, angles.Z, out result);
		}

		/// <summary>create a new quaternion from three euler angles</summary>
		/// <param name="x">x angle</param>
		/// <param name="y">y angle</param>
		/// <param name="z">z angle</param>
		/// <returns>a new quaternion from the three euler angles</returns>

		public static Quaternion RotationXzy(float x, float y, float z)
		{
			Quaternion result;
			Quaternion.RotationXzy(x, y, z, out result);
			return result;
		}

		/// <summary>create a new quaternion from three euler angles</summary>
		/// <param name="x">x angle</param>
		/// <param name="y">y angle</param>
		/// <param name="z">z angle</param>
		/// <param name="result">a new quaternion from the three euler angles</param>

		public static void RotationXzy(float x, float y, float z, out Quaternion result)
		{
			Vector3 vector;
			Vector3 vector2;
			Quaternion.RotationVector(x, y, z, out vector, out vector2);
			result.X = vector.Y * vector.Z * vector2.X - vector.X * vector2.Z * vector2.Y;
			result.Y = vector.X * vector.Z * vector2.Y - vector.Y * vector2.X * vector2.Z;
			result.Z = vector.Y * vector.X * vector2.Z + vector.Z * vector2.X * vector2.Y;
			result.W = vector.X * vector.Z * vector.Y + vector2.X * vector2.Z * vector2.Y;
		}

		/// <summary>create a new quaternion from three euler angles</summary>
		/// <param name="angles">the x, z, y euler angles used to create the quaternion</param>
		/// <returns>a new quaternion from the three euler angles</returns>

		public static Quaternion RotationXzy(Vector3 angles)
		{
			Quaternion result;
			Quaternion.RotationXzy(angles.X, angles.Y, angles.Z, out result);
			return result;
		}

		/// <summary>create a new quaternion from three euler angles</summary>
		/// <param name="angles">the x, z, y euler angles used to create the quaternion</param>
		/// <param name="result">a new quaternion from the three euler angles</param>

		public static void RotationXzy(ref Vector3 angles, out Quaternion result)
		{
			Quaternion.RotationXzy(angles.X, angles.Y, angles.Z, out result);
		}

		/// <summary>create a new quaternion from three euler angles</summary>
		/// <param name="x">x angle</param>
		/// <param name="y">y angle</param>
		/// <param name="z">z angle</param>
		/// <returns>a new quaternion from the three euler angles</returns>

		public static Quaternion RotationXyz(float x, float y, float z)
		{
			Quaternion result;
			Quaternion.RotationXyz(x, y, z, out result);
			return result;
		}

		/// <summary>create a new quaternion from three euler angles</summary>
		/// <param name="x">x angle</param>
		/// <param name="y">y angle</param>
		/// <param name="z">z angle</param>
		/// <param name="result">a new quaternion from the three euler angles</param>

		public static void RotationXyz(float x, float y, float z, out Quaternion result)
		{
			Vector3 vector;
			Vector3 vector2;
			Quaternion.RotationVector(x, y, z, out vector, out vector2);
			result.X = vector.Z * vector.Y * vector2.X + vector.X * vector2.Y * vector2.Z;
			result.Y = vector.Z * vector.X * vector2.Y - vector.Y * vector2.X * vector2.Z;
			result.Z = vector.X * vector.Y * vector2.Z + vector.Z * vector2.X * vector2.Y;
			result.W = vector.X * vector.Y * vector.Z - vector2.X * vector2.Y * vector2.Z;
		}

		/// <summary>create a new quaternion from three euler angles</summary>
		/// <param name="angles">the x, y, z euler angles used to create the quaternion</param>
		/// <returns>a new quaternion from the three euler angles</returns>

		public static Quaternion RotationXyz(Vector3 angles)
		{
			Quaternion result;
			Quaternion.RotationXyz(angles.X, angles.Y, angles.Z, out result);
			return result;
		}

		/// <summary>create a new quaternion from three euler angles</summary>
		/// <param name="angles">the x, y, z euler angles used to create the quaternion</param>
		/// <param name="result">a new quaternion from the three euler angles</param>

		public static void RotationXyz(ref Vector3 angles, out Quaternion result)
		{
			Quaternion.RotationXyz(angles.X, angles.Y, angles.Z, out result);
		}

		/// <summary>create a new quaternion from three euler angles</summary>
		/// <param name="x">x angle</param>
		/// <param name="y">y angle</param>
		/// <param name="z">z angle</param>
		/// <returns>a new quaternion from the three euler angles</returns>

		public static Quaternion RotationYzx(float x, float y, float z)
		{
			Quaternion result;
			Quaternion.RotationYzx(x, y, z, out result);
			return result;
		}

		/// <summary>create a new quaternion from three euler angles</summary>
		/// <param name="x">x angle</param>
		/// <param name="y">y angle</param>
		/// <param name="z">z angle</param>
		/// <param name="result">a new quaternion from the three euler angles</param>

		public static void RotationYzx(float x, float y, float z, out Quaternion result)
		{
			Vector3 vector;
			Vector3 vector2;
			Quaternion.RotationVector(x, y, z, out vector, out vector2);
			result.X = vector.Y * vector.Z * vector2.X + vector.X * vector2.Y * vector2.Z;
			result.Y = vector.X * vector.Z * vector2.Y + vector.Y * vector2.Z * vector2.X;
			result.Z = vector.X * vector.Y * vector2.Z - vector.Z * vector2.Y * vector2.X;
			result.W = vector.Y * vector.Z * vector.X - vector2.Y * vector2.Z * vector2.X;
		}

		/// <summary>create a new quaternion from three euler angles</summary>
		/// <param name="angles">the y, z, x euler angles used to create the quaternion</param>
		/// <returns>a new quaternion from the three euler angles</returns>

		public static Quaternion RotationYzx(Vector3 angles)
		{
			Quaternion result;
			Quaternion.RotationYzx(angles.X, angles.Y, angles.Z, out result);
			return result;
		}

		/// <summary>create a new quaternion from three euler angles</summary>
		/// <param name="angles">the y, z, x euler angles used to create the quaternion</param>
		/// <param name="result">a new quaternion from the three euler angles</param>

		public static void RotationYzx(ref Vector3 angles, out Quaternion result)
		{
			Quaternion.RotationYzx(angles.X, angles.Y, angles.Z, out result);
		}

		/// <summary>create a new quaternion from three euler angles</summary>
		/// <param name="x">x angle</param>
		/// <param name="y">y angle</param>
		/// <param name="z">z angle</param>
		/// <returns>a new quaternion from the three euler angles</returns>

		public static Quaternion RotationZxy(float x, float y, float z)
		{
			Quaternion result;
			Quaternion.RotationZxy(x, y, z, out result);
			return result;
		}

		/// <summary>create a new quaternion from three euler angles</summary>
		/// <param name="x">x angle</param>
		/// <param name="y">y angle</param>
		/// <param name="z">z angle</param>
		/// <param name="result">a new quaternion from the three euler angles</param>

		public static void RotationZxy(float x, float y, float z, out Quaternion result)
		{
			Vector3 vector;
			Vector3 vector2;
			Quaternion.RotationVector(x, y, z, out vector, out vector2);
			result.X = vector.Y * vector.Z * vector2.X - vector.X * vector2.Z * vector2.Y;
			result.Y = vector.Z * vector.X * vector2.Y + vector.Y * vector2.Z * vector2.X;
			result.Z = vector.Y * vector.X * vector2.Z + vector.Z * vector2.X * vector2.Y;
			result.W = vector.Z * vector.X * vector.Y - vector2.Z * vector2.X * vector2.Y;
		}

		/// <summary>create a new quaternion from three euler angles</summary>
		/// <param name="angles">the z, x, y euler angles used to create the quaternion</param>
		/// <returns>a new quaternion from the three euler angles</returns>

		public static Quaternion RotationZxy(Vector3 angles)
		{
			Quaternion result;
			Quaternion.RotationZxy(angles.X, angles.Y, angles.Z, out result);
			return result;
		}

		/// <summary>create a new quaternion from three euler angles</summary>
		/// <param name="angles">the z, x, y euler angles used to create the quaternion</param>
		/// <param name="result">a new quaternion from the three euler angles</param>

		public static void RotationZxy(ref Vector3 angles, out Quaternion result)
		{
			Quaternion.RotationZxy(angles.X, angles.Y, angles.Z, out result);
		}

		/// <summary>static function equivalent to Length()</summary>
		/// <param name="q">quaternion</param>
		/// <returns>the length of quaternion</returns>

		public static float Length(Quaternion q)
		{
			return q.Length();
		}

		/// <summary>static function equivalent to Length()</summary>
		/// <param name="q">quaternion</param>
		/// <returns>the length of quaternion</returns>

		public static float Length(ref Quaternion q)
		{
			return q.Length();
		}

		/// <summary>static function equivalent to LengthSquared()</summary>
		/// <param name="q">quaternion</param>
		/// <returns>the length squared of quaternion</returns>

		public static float LengthSquared(Quaternion q)
		{
			return q.LengthSquared();
		}

		/// <summary>static function equivalent to LengthSquared()</summary>
		/// <param name="q">quaternion</param>
		/// <returns>the length squared of quaternion</returns>

		public static float LengthSquared(ref Quaternion q)
		{
			return q.LengthSquared();
		}

		/// <summary>static function equivalent to Dot(Quaternion)</summary>
		/// <param name="q1">quaternion 1</param>
		/// <param name="q2">quaternion 2</param>
		/// <returns>dot product of q1 and q2</returns>

		public static float Dot(Quaternion q1, Quaternion q2)
		{
			return q1.Dot(q2);
		}

		/// <summary>static function equivalent to Dot(ref Quaternion)</summary>
		/// <param name="q1">quaternion 1</param>
		/// <param name="q2">quaternion 2</param>
		/// <returns>dot product of q1 and q2</returns>

		public static float Dot(ref Quaternion q1, ref Quaternion q2)
		{
			return q1.Dot(q2);
		}

		/// <summary>static function equivalent to Normalize()</summary>
		/// <param name="q">quaternion</param>
		/// <returns>q as a unit quaternion</returns>

		public static Quaternion Normalize(Quaternion q)
		{
			Quaternion result;
			q.Normalize(out result);
			return result;
		}

		/// <summary>static function equivalent to Normalize(out Quaternion)</summary>
		/// <param name="q">quaternion</param>
		/// <param name="result">q as a unit quaternion</param>

		public static void Normalize(ref Quaternion q, out Quaternion result)
		{
			q.Normalize(out result);
		}

		/// <summary>static function equivalent to Conjugate()</summary>
		/// <param name="q">quaternion</param>
		/// <returns>quaternion conjugate</returns>

		public static Quaternion Conjugate(Quaternion q)
		{
			Quaternion result;
			q.Conjugate(out result);
			return result;
		}

		/// <summary>static function equivalent to Conjugate(out Quaternion)</summary>
		/// <param name="q">quaternion</param>
		/// <param name="result">quaternion conjugate</param>

		public static void Conjugate(ref Quaternion q, out Quaternion result)
		{
			q.Conjugate(out result);
		}

		/// <summary>static function equivalent to Inverse()</summary>
		/// <param name="q">quaternion</param>
		/// <returns>quaternion inverse</returns>

		public static Quaternion Inverse(Quaternion q)
		{
			Quaternion result;
			q.Inverse(out result);
			return result;
		}

		/// <summary>static function equivalent to Inverse(out Quaternion)</summary>
		/// <param name="q">quaternion</param>
		/// <param name="result">quaternion inverse</param>

		public static void Inverse(ref Quaternion q, out Quaternion result)
		{
			q.Inverse(out result);
		}

		/// <summary>static function equivalent to Slerp(Quaternion, float)</summary>
		/// <param name="q1">quaternion 1</param>
		/// <param name="q2">quaternion 2</param>
		/// <param name="f">slerp amount</param>
		/// <returns>slerp between q1 and q2</returns>

		public static Quaternion Slerp(Quaternion q1, Quaternion q2, float f)
		{
			Quaternion result;
			q1.Slerp(ref q2, f, out result);
			return result;
		}

		/// <summary>static function equivalent to Slerp(ref Quaternion, float, out Quaternion)</summary>
		/// <param name="q1">quaternion 1</param>
		/// <param name="q2">quaternion 2</param>
		/// <param name="f">slerp amount</param>
		/// <param name="result">slerp between q1 and q2</param>

		public static void Slerp(ref Quaternion q1, ref Quaternion q2, float f, out Quaternion result)
		{
			q1.Slerp(ref q2, f, out result);
		}

		/// <summary>static function equivalent to Lerp(Quaternion, float)</summary>
		/// <param name="q1">quaternion 1</param>
		/// <param name="q2">quaternion 2</param>
		/// <param name="f">lerp amount</param>
		/// <returns>lerp between q1 and q2</returns>

		public static Quaternion Lerp(Quaternion q1, Quaternion q2, float f)
		{
			Quaternion result;
			q1.Lerp(ref q2, f, out result);
			return result;
		}

		/// <summary>static function equivalent to Lerp(ref Quaternion, float, out Quaternion)</summary>
		/// <param name="q1">quaternion 1</param>
		/// <param name="q2">quaternion 2</param>
		/// <param name="f">lerp amount</param>
		/// <param name="result">lerp between q1 and q2</param>

		public static void Lerp(ref Quaternion q1, ref Quaternion q2, float f, out Quaternion result)
		{
			q1.Lerp(ref q2, f, out result);
		}

		/// <summary>static function equivalent to Log()</summary>
		/// <param name="q">quaternion</param>
		/// <returns>quaternion log</returns>

		public static Quaternion Log(Quaternion q)
		{
			Quaternion result;
			q.Log(out result);
			return result;
		}

		/// <summary>static function equivalent to Log(out Quaternion)</summary>
		/// <param name="q">quaternion</param>
		/// <param name="result">quaternion log</param>

		public static void Log(ref Quaternion q, out Quaternion result)
		{
			q.Log(out result);
		}

		/// <summary>static function equivalent to Exp()</summary>
		/// <param name="q">quaternion</param>
		/// <returns>quaternion exp</returns>

		public static Quaternion Exp(Quaternion q)
		{
			Quaternion result;
			q.Exp(out result);
			return result;
		}

		/// <summary>static function equivalent to Exp(out Quaternion)</summary>
		/// <param name="q">quaternion</param>
		/// <param name="result">quaternion exp</param>

		public static void Exp(ref Quaternion q, out Quaternion result)
		{
			q.Exp(out result);
		}

		/// <summary>static function equivalent to TurnTo(Quaternion, float)</summary>
		/// <param name="q1">quaternion 1</param>
		/// <param name="q2">quaternion 2</param>
		/// <param name="angle">step angle</param>
		/// <returns>a new quaternion turned to target quaternion by specified angle</returns>

		public static Quaternion TurnTo(Quaternion q1, Quaternion q2, float angle)
		{
			Quaternion result;
			q1.TurnTo(ref q2, angle, out result);
			return result;
		}

		/// <summary>static function equivalent to TurnTo(ref Quaternion, float, out Quaternion)</summary>
		/// <param name="q1">quaternion 1</param>
		/// <param name="q2">quaternion 2</param>
		/// <param name="angle">step angle</param>
		/// <param name="result">a new quaternion turned to target quaternion by specified angle</param>

		public static void TurnTo(ref Quaternion q1, ref Quaternion q2, float angle, out Quaternion result)
		{
			q1.TurnTo(ref q2, angle, out result);
		}

		/// <summary>static function equivalent to Angle(Quaternion)</summary>
		/// <param name="q1">quaternion 1</param>
		/// <param name="q2">quaternion 2</param>
		/// <returns>the angle between q1 and q2</returns>

		public static float Angle(Quaternion q1, Quaternion q2)
		{
			return q1.Angle(ref q2);
		}

		/// <summary>static function equivalent to Angle(ref Quaternion)</summary>
		/// <param name="q1">quaternion 1</param>
		/// <param name="q2">quaternion 2</param>
		/// <returns>the angle between q1 and q2</returns>

		public static float Angle(ref Quaternion q1, ref Quaternion q2)
		{
			return q1.Angle(ref q2);
		}

		/// <summary>static function equivalent to Transform(Vector4)</summary>
		/// <param name="q">quaternion</param>
		/// <param name="v">vector</param>
		/// <returns>q * v</returns>

		public static Vector4 Transform(Quaternion q, Vector4 v)
		{
			Vector4 result;
			q.Transform(ref v, out result);
			return result;
		}

		/// <summary>static function equivalent to Transform(ref Vector4, out Vector4)</summary>
		/// <param name="q">quaternion</param>
		/// <param name="v">vector</param>
		/// <param name="result">q * v</param>

		public static void Transform(ref Quaternion q, ref Vector4 v, out Vector4 result)
		{
			q.Transform(ref v, out result);
		}

		/// <summary>static function equivalent to Transform(Vector3)</summary>
		/// <param name="q">quaternion</param>
		/// <param name="v">vector</param>
		/// <returns>q * v</returns>

		public static Vector3 Transform(Quaternion q, Vector3 v)
		{
			Vector3 result;
			q.Transform(ref v, out result);
			return result;
		}

		/// <summary>static function equivalent to Transform(ref Vector3, out Vector3)</summary>
		/// <param name="q">quaternion</param>
		/// <param name="v">vector</param>
		/// <param name="result">q * v</param>

		public static void Transform(ref Quaternion q, ref Vector3 v, out Vector3 result)
		{
			q.Transform(ref v, out result);
		}

		/// <summary>static function equivalent to Transform(Vector2)</summary>
		/// <param name="q">quaternion</param>
		/// <param name="v">vector</param>
		/// <returns>q * v</returns>

		public static Vector2 Transform(Quaternion q, Vector2 v)
		{
			Vector2 result;
			q.Transform(ref v, out result);
			return result;
		}

		/// <summary>static function equivalent to Transform(ref Vector2, out Vector2)</summary>
		/// <param name="q">quaternion</param>
		/// <param name="v">vector</param>
		/// <param name="result">q * v</param>

		public static void Transform(ref Quaternion q, ref Vector2 v, out Vector2 result)
		{
			q.Transform(ref v, out result);
		}

		/// <summary>static function equivalent to Add(Quaternion)</summary>
		/// <param name="q1">quaternion 1</param>
		/// <param name="q2">quaternion 2</param>
		/// <returns>q1 + q2</returns>

		public static Quaternion Add(Quaternion q1, Quaternion q2)
		{
			Quaternion result;
			q1.Add(ref q2, out result);
			return result;
		}

		/// <summary>static function equivalent to Add(ref Quaternion, out Quaternion)</summary>
		/// <param name="q1">quaternion 1</param>
		/// <param name="q2">quaternion 2</param>
		/// <param name="result">q1 + q2</param>

		public static void Add(ref Quaternion q1, ref Quaternion q2, out Quaternion result)
		{
			q1.Add(ref q2, out result);
		}

		/// <summary>static function equivalent to Subtract(Quaternion)</summary>
		/// <param name="q1">quaternion 1</param>
		/// <param name="q2">quaternion 2</param>
		/// <returns>q1 - q2</returns>

		public static Quaternion Subtract(Quaternion q1, Quaternion q2)
		{
			Quaternion result;
			q1.Subtract(ref q2, out result);
			return result;
		}

		/// <summary>static function equivalent to Subtract(ref Quaternion, out Quaternion)</summary>
		/// <param name="q1">quaternion 1</param>
		/// <param name="q2">quaternion 2</param>
		/// <param name="result">q1 - q2</param>

		public static void Subtract(ref Quaternion q1, ref Quaternion q2, out Quaternion result)
		{
			q1.Subtract(ref q2, out result);
		}

		/// <summary>static function equivalent to Multiply(Quaternion)</summary>
		/// <param name="q1">quaternion 1</param>
		/// <param name="q2">quaternion 2</param>
		/// <returns>q1 * q2</returns>

		public static Quaternion Multiply(Quaternion q1, Quaternion q2)
		{
			Quaternion result;
			q1.Multiply(ref q2, out result);
			return result;
		}

		/// <summary>static function equivalent to Multiply(ref Quaternion, out Quaternion)</summary>
		/// <param name="q1">quaternion 1</param>
		/// <param name="q2">quaternion 2</param>
		/// <param name="result">q1 * q2</param>

		public static void Multiply(ref Quaternion q1, ref Quaternion q2, out Quaternion result)
		{
			q1.Multiply(ref q2, out result);
		}

		/// <summary>static function equivalent to Multiply(float)</summary>
		/// <param name="q">quaternion</param>
		/// <param name="f">scalar</param>
		/// <returns>q * f</returns>

		public static Quaternion Multiply(Quaternion q, float f)
		{
			Quaternion result;
			q.Multiply(f, out result);
			return result;
		}

		/// <summary>static function equivalent to Multiply(float, out Quaternion)</summary>
		/// <param name="q">quaternion</param>
		/// <param name="f">scalar</param>
		/// <param name="result">q * f</param>

		public static void Multiply(ref Quaternion q, float f, out Quaternion result)
		{
			q.Multiply(f, out result);
		}

		/// <summary>static function equivalent to Divide(float)</summary>
		/// <param name="q">quaternion</param>
		/// <param name="f">scalar</param>
		/// <returns>q / f</returns>

		public static Quaternion Divide(Quaternion q, float f)
		{
			Quaternion result;
			q.Divide(f, out result);
			return result;
		}

		/// <summary>static function equivalent to Divide(float, out Quaternion)</summary>
		/// <param name="q">quaternion</param>
		/// <param name="f">scalar</param>
		/// <param name="result">q / f</param>

		public static void Divide(ref Quaternion q, float f, out Quaternion result)
		{
			q.Divide(f, out result);
		}

		/// <summary>static function equivalent to Negate()</summary>
		/// <param name="q">quaternion</param>
		/// <returns>-q</returns>

		public static Quaternion Negate(Quaternion q)
		{
			Quaternion result;
			q.Negate(out result);
			return result;
		}

		/// <summary>static function equivalent to Negate(out Quaternion)</summary>
		/// <param name="q">quaternion</param>
		/// <param name="result">-q</param>

		public static void Negate(ref Quaternion q, out Quaternion result)
		{
			q.Negate(out result);
		}

		/// <summary>equality operator</summary>
		/// <param name="q1">first quaternion to compare</param>
		/// <param name="q2">second quaternion to compare</param>
		/// <returns>true if q1 == q2, false otherwise</returns>

		public static bool operator ==(Quaternion q1, Quaternion q2)
		{
			return q1.X == q2.X && q1.Y == q2.Y && q1.Z == q2.Z && q1.W == q2.W;
		}

		/// <summary>not equals operator</summary>
		/// <param name="q1">first quaternion to compare</param>
		/// <param name="q2">second quaternion to compare</param>
		/// <returns>true if q1 != q2, false otherwise</returns>

		public static bool operator !=(Quaternion q1, Quaternion q2)
		{
			return q1.X != q2.X || q1.Y != q2.Y || q1.Z != q2.Z || q1.W != q2.W;
		}

		/// <summary>addition operator</summary>
		/// <param name="q1">first quaternion to add</param>
		/// <param name="q2">second quaternion to add</param>
		/// <returns>q1 + q2</returns>

		public static Quaternion operator +(Quaternion q1, Quaternion q2)
		{
			Quaternion result;
			q1.Add(ref q2, out result);
			return result;
		}

		/// <summary>subtraction operator</summary>
		/// <param name="q1">value to subtract from</param>
		/// <param name="q2">value to subtract</param>
		/// <returns>q1 - q2</returns>

		public static Quaternion operator -(Quaternion q1, Quaternion q2)
		{
			Quaternion result;
			q1.Subtract(ref q2, out result);
			return result;
		}

		/// <summary>unary minus operator</summary>
		/// <param name="q">quaternion to negate</param>
		/// <returns>unary minus applied to each member of q</returns>

		public static Quaternion operator -(Quaternion q)
		{
			Quaternion result;
			q.Negate(out result);
			return result;
		}

		/// <summary>multiplication operator</summary>
		/// <param name="q1">first value to multiply</param>
		/// <param name="q2">second value to multiply</param>
		/// <returns>q1 * q2</returns>

		public static Quaternion operator *(Quaternion q1, Quaternion q2)
		{
			Quaternion result;
			q1.Multiply(ref q2, out result);
			return result;
		}

		/// <summary>multiply a quaternion by a scalar float</summary>
		/// <param name="q">quaternion to multiply</param>
		/// <param name="f">float to multiply by</param>
		/// <returns>q * f</returns>

		public static Quaternion operator *(Quaternion q, float f)
		{
			Quaternion result;
			q.Multiply(f, out result);
			return result;
		}

		/// <summary>multiply a quaternion by a scalar float</summary>
		/// <param name="f">float to multiply by</param>
		/// <param name="q">quaternion to multiply</param>
		/// <returns>f * q</returns>

		public static Quaternion operator *(float f, Quaternion q)
		{
			Quaternion result;
			q.Multiply(f, out result);
			return result;
		}

		/// <summary>division operator</summary>
		/// <param name="q">quaternion to divide</param>
		/// <param name="f">scalar float value to divide by</param>
		/// <returns>q / f</returns>

		public static Quaternion operator /(Quaternion q, float f)
		{
			Quaternion result;
			q.Divide(f, out result);
			return result;
		}


		private static void RotationVector(float x, float y, float z, out Vector3 c, out Vector3 s)
		{
			x *= 0.5f;
			y *= 0.5f;
			z *= 0.5f;
			c.X = (float)Math.Cos((double)x);
			c.Y = (float)Math.Cos((double)y);
			c.Z = (float)Math.Cos((double)z);
			s.X = (float)Math.Sin((double)x);
			s.Y = (float)Math.Sin((double)y);
			s.Z = (float)Math.Sin((double)z);
		}


		[Obsolete]
		public static Vector3 operator *(Quaternion q, Vector3 v)
		{
			float num = q.Y * v.Z - q.Z * v.Y + q.W * v.X;
			float num2 = q.Z * v.X - q.X * v.Z + q.W * v.Y;
			float num3 = q.X * v.Y - q.Y * v.X + q.W * v.Z;
			float x = (q.Y * num3 - q.Z * num2) * 2f + v.X;
			float y = (q.Z * num - q.X * num3) * 2f + v.Y;
			float z = (q.X * num2 - q.Y * num) * 2f + v.Z;
			return new Vector3(x, y, z);
		}

		/// <summary>X</summary>

		public float X;

		/// <summary>Y</summary>

		public float Y;

		/// <summary>Z</summary>

		public float Z;

		/// <summary>W</summary>

		public float W;

		/// <summary>identity quaternion</summary>

		public static readonly Quaternion Identity = new Quaternion(0f, 0f, 0f, 1f);
	}
}
