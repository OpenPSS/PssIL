using System;

namespace Sce.PlayStation.Core
{
	/// <summary>vector of 4 floats</summary>
	public struct Vector4 : IEquatable<Vector4>
	{
		/// <returns>a new vector consisting of the current vector's x, x, x, x values</returns>
		public Vector4 Xxxx
		{
			get
			{
				return new Vector4(this.X, this.X, this.X, this.X);
			}
		}

		/// <returns>a new vector consisting of the current vector's y, x, x, x values</returns>
		public Vector4 Yxxx
		{
			get
			{
				return new Vector4(this.Y, this.X, this.X, this.X);
			}
		}

		/// <returns>a new vector consisting of the current vector's z, x, x, x values</returns>
		public Vector4 Zxxx
		{
			get
			{
				return new Vector4(this.Z, this.X, this.X, this.X);
			}
		}

		/// <returns>a new vector consisting of the current vector's w, x, x, x values</returns>
		public Vector4 Wxxx
		{
			get
			{
				return new Vector4(this.W, this.X, this.X, this.X);
			}
		}

		/// <returns>a new vector consisting of the current vector's x, y, x, x values</returns>
		public Vector4 Xyxx
		{
			get
			{
				return new Vector4(this.X, this.Y, this.X, this.X);
			}
		}

		/// <returns>a new vector consisting of the current vector's y, y, x, x values</returns>
		public Vector4 Yyxx
		{
			get
			{
				return new Vector4(this.Y, this.Y, this.X, this.X);
			}
		}

		/// <returns>a new vector consisting of the current vector's z, y, x, x values</returns>
		public Vector4 Zyxx
		{
			get
			{
				return new Vector4(this.Z, this.Y, this.X, this.X);
			}
		}

		/// <returns>a new vector consisting of the current vector's w, y, x, x values</returns>
		public Vector4 Wyxx
		{
			get
			{
				return new Vector4(this.W, this.Y, this.X, this.X);
			}
		}

		/// <returns>a new vector consisting of the current vector's x, z, x, x values</returns>
		public Vector4 Xzxx
		{
			get
			{
				return new Vector4(this.X, this.Z, this.X, this.X);
			}
		}

		/// <returns>a new vector consisting of the current vector's y, z, x, x values</returns>
		public Vector4 Yzxx
		{
			get
			{
				return new Vector4(this.Y, this.Z, this.X, this.X);
			}
		}

		/// <returns>a new vector consisting of the current vector's z, z, x, x values</returns>
		public Vector4 Zzxx
		{
			get
			{
				return new Vector4(this.Z, this.Z, this.X, this.X);
			}
		}

		/// <returns>a new vector consisting of the current vector's w, z, x, x values</returns>
		public Vector4 Wzxx
		{
			get
			{
				return new Vector4(this.W, this.Z, this.X, this.X);
			}
		}

		/// <returns>a new vector consisting of the current vector's x, w, x, x values</returns>
		public Vector4 Xwxx
		{
			get
			{
				return new Vector4(this.X, this.W, this.X, this.X);
			}
		}

		/// <returns>a new vector consisting of the current vector's y, w, x, x values</returns>
		public Vector4 Ywxx
		{
			get
			{
				return new Vector4(this.Y, this.W, this.X, this.X);
			}
		}

		/// <returns>a new vector consisting of the current vector's z, w, x, x values</returns>
		public Vector4 Zwxx
		{
			get
			{
				return new Vector4(this.Z, this.W, this.X, this.X);
			}
		}

		/// <returns>a new vector consisting of the current vector's w, w, x, x values</returns>
		public Vector4 Wwxx
		{
			get
			{
				return new Vector4(this.W, this.W, this.X, this.X);
			}
		}

		/// <returns>a new vector consisting of the current vector's x, x, y, x values</returns>
		public Vector4 Xxyx
		{
			get
			{
				return new Vector4(this.X, this.X, this.Y, this.X);
			}
		}

		/// <returns>a new vector consisting of the current vector's y, x, y, x values</returns>
		public Vector4 Yxyx
		{
			get
			{
				return new Vector4(this.Y, this.X, this.Y, this.X);
			}
		}

		/// <returns>a new vector consisting of the current vector's z, x, y, x values</returns>
		public Vector4 Zxyx
		{
			get
			{
				return new Vector4(this.Z, this.X, this.Y, this.X);
			}
		}

		/// <returns>a new vector consisting of the current vector's w, x, y, x values</returns>
		public Vector4 Wxyx
		{
			get
			{
				return new Vector4(this.W, this.X, this.Y, this.X);
			}
		}

		/// <returns>a new vector consisting of the current vector's x, y, y, x values</returns>
		public Vector4 Xyyx
		{
			get
			{
				return new Vector4(this.X, this.Y, this.Y, this.X);
			}
		}

		/// <returns>a new vector consisting of the current vector's y, y, y, x values</returns>
		public Vector4 Yyyx
		{
			get
			{
				return new Vector4(this.Y, this.Y, this.Y, this.X);
			}
		}

		/// <returns>a new vector consisting of the current vector's z, y, y, x values</returns>
		public Vector4 Zyyx
		{
			get
			{
				return new Vector4(this.Z, this.Y, this.Y, this.X);
			}
		}

		/// <returns>a new vector consisting of the current vector's w, y, y, x values</returns>
		public Vector4 Wyyx
		{
			get
			{
				return new Vector4(this.W, this.Y, this.Y, this.X);
			}
		}

		/// <returns>a new vector consisting of the current vector's x, z, y, x values</returns>
		public Vector4 Xzyx
		{
			get
			{
				return new Vector4(this.X, this.Z, this.Y, this.X);
			}
		}

		/// <returns>a new vector consisting of the current vector's y, z, y, x values</returns>
		public Vector4 Yzyx
		{
			get
			{
				return new Vector4(this.Y, this.Z, this.Y, this.X);
			}
		}

		/// <returns>a new vector consisting of the current vector's z, z, y, x values</returns>
		public Vector4 Zzyx
		{
			get
			{
				return new Vector4(this.Z, this.Z, this.Y, this.X);
			}
		}

		/// <returns>a new vector consisting of the current vector's w, z, y, x values</returns>
		public Vector4 Wzyx
		{
			get
			{
				return new Vector4(this.W, this.Z, this.Y, this.X);
			}
			set
			{
				this.W = value.X;
				this.Z = value.Y;
				this.Y = value.Z;
				this.X = value.W;
			}
		}

		/// <returns>a new vector consisting of the current vector's x, w, y, x values</returns>
		public Vector4 Xwyx
		{
			get
			{
				return new Vector4(this.X, this.W, this.Y, this.X);
			}
		}

		/// <returns>a new vector consisting of the current vector's y, w, y, x values</returns>
		public Vector4 Ywyx
		{
			get
			{
				return new Vector4(this.Y, this.W, this.Y, this.X);
			}
		}

		/// <returns>a new vector consisting of the current vector's z, w, y, x values</returns>
		public Vector4 Zwyx
		{
			get
			{
				return new Vector4(this.Z, this.W, this.Y, this.X);
			}
			set
			{
				this.Z = value.X;
				this.W = value.Y;
				this.Y = value.Z;
				this.X = value.W;
			}
		}

		/// <returns>a new vector consisting of the current vector's w, w, y, x values</returns>
		public Vector4 Wwyx
		{
			get
			{
				return new Vector4(this.W, this.W, this.Y, this.X);
			}
		}

		/// <returns>a new vector consisting of the current vector's x, x, z, x values</returns>
		public Vector4 Xxzx
		{
			get
			{
				return new Vector4(this.X, this.X, this.Z, this.X);
			}
		}

		/// <returns>a new vector consisting of the current vector's y, x, z, x values</returns>
		public Vector4 Yxzx
		{
			get
			{
				return new Vector4(this.Y, this.X, this.Z, this.X);
			}
		}

		/// <returns>a new vector consisting of the current vector's z, x, z, x values</returns>
		public Vector4 Zxzx
		{
			get
			{
				return new Vector4(this.Z, this.X, this.Z, this.X);
			}
		}

		/// <returns>a new vector consisting of the current vector's w, x, z, x values</returns>
		public Vector4 Wxzx
		{
			get
			{
				return new Vector4(this.W, this.X, this.Z, this.X);
			}
		}

		/// <returns>a new vector consisting of the current vector's x, y, z, x values</returns>
		public Vector4 Xyzx
		{
			get
			{
				return new Vector4(this.X, this.Y, this.Z, this.X);
			}
		}

		/// <returns>a new vector consisting of the current vector's y, y, z, x values</returns>
		public Vector4 Yyzx
		{
			get
			{
				return new Vector4(this.Y, this.Y, this.Z, this.X);
			}
		}

		/// <returns>a new vector consisting of the current vector's z, y, z, x values</returns>
		public Vector4 Zyzx
		{
			get
			{
				return new Vector4(this.Z, this.Y, this.Z, this.X);
			}
		}

		/// <returns>a new vector consisting of the current vector's w, y, z, x values</returns>
		public Vector4 Wyzx
		{
			get
			{
				return new Vector4(this.W, this.Y, this.Z, this.X);
			}
			set
			{
				this.W = value.X;
				this.Y = value.Y;
				this.Z = value.Z;
				this.X = value.W;
			}
		}

		/// <returns>a new vector consisting of the current vector's x, z, z, x values</returns>
		public Vector4 Xzzx
		{
			get
			{
				return new Vector4(this.X, this.Z, this.Z, this.X);
			}
		}

		/// <returns>a new vector consisting of the current vector's y, z, z, x values</returns>
		public Vector4 Yzzx
		{
			get
			{
				return new Vector4(this.Y, this.Z, this.Z, this.X);
			}
		}

		/// <returns>a new vector consisting of the current vector's z, z, z, x values</returns>
		public Vector4 Zzzx
		{
			get
			{
				return new Vector4(this.Z, this.Z, this.Z, this.X);
			}
		}

		/// <returns>a new vector consisting of the current vector's w, z, z, x values</returns>
		public Vector4 Wzzx
		{
			get
			{
				return new Vector4(this.W, this.Z, this.Z, this.X);
			}
		}

		/// <returns>a new vector consisting of the current vector's x, w, z, x values</returns>
		public Vector4 Xwzx
		{
			get
			{
				return new Vector4(this.X, this.W, this.Z, this.X);
			}
		}

		/// <returns>a new vector consisting of the current vector's y, w, z, x values</returns>
		public Vector4 Ywzx
		{
			get
			{
				return new Vector4(this.Y, this.W, this.Z, this.X);
			}
			set
			{
				this.Y = value.X;
				this.W = value.Y;
				this.Z = value.Z;
				this.X = value.W;
			}
		}

		/// <returns>a new vector consisting of the current vector's z, w, z, x values</returns>
		public Vector4 Zwzx
		{
			get
			{
				return new Vector4(this.Z, this.W, this.Z, this.X);
			}
		}

		/// <returns>a new vector consisting of the current vector's w, w, z, x values</returns>
		public Vector4 Wwzx
		{
			get
			{
				return new Vector4(this.W, this.W, this.Z, this.X);
			}
		}

		/// <returns>a new vector consisting of the current vector's x, x, w, x values</returns>
		public Vector4 Xxwx
		{
			get
			{
				return new Vector4(this.X, this.X, this.W, this.X);
			}
		}

		/// <returns>a new vector consisting of the current vector's y, x, w, x values</returns>
		public Vector4 Yxwx
		{
			get
			{
				return new Vector4(this.Y, this.X, this.W, this.X);
			}
		}

		/// <returns>a new vector consisting of the current vector's z, x, w, x values</returns>
		public Vector4 Zxwx
		{
			get
			{
				return new Vector4(this.Z, this.X, this.W, this.X);
			}
		}

		/// <returns>a new vector consisting of the current vector's w, x, w, x values</returns>
		public Vector4 Wxwx
		{
			get
			{
				return new Vector4(this.W, this.X, this.W, this.X);
			}
		}

		/// <returns>a new vector consisting of the current vector's x, y, w, x values</returns>
		public Vector4 Xywx
		{
			get
			{
				return new Vector4(this.X, this.Y, this.W, this.X);
			}
		}

		/// <returns>a new vector consisting of the current vector's y, y, w, x values</returns>
		public Vector4 Yywx
		{
			get
			{
				return new Vector4(this.Y, this.Y, this.W, this.X);
			}
		}

		/// <returns>a new vector consisting of the current vector's z, y, w, x values</returns>
		public Vector4 Zywx
		{
			get
			{
				return new Vector4(this.Z, this.Y, this.W, this.X);
			}
			set
			{
				this.Z = value.X;
				this.Y = value.Y;
				this.W = value.Z;
				this.X = value.W;
			}
		}

		/// <returns>a new vector consisting of the current vector's w, y, w, x values</returns>
		public Vector4 Wywx
		{
			get
			{
				return new Vector4(this.W, this.Y, this.W, this.X);
			}
		}

		/// <returns>a new vector consisting of the current vector's x, z, w, x values</returns>
		public Vector4 Xzwx
		{
			get
			{
				return new Vector4(this.X, this.Z, this.W, this.X);
			}
		}

		/// <returns>a new vector consisting of the current vector's y, z, w, x values</returns>
		public Vector4 Yzwx
		{
			get
			{
				return new Vector4(this.Y, this.Z, this.W, this.X);
			}
			set
			{
				this.Y = value.X;
				this.Z = value.Y;
				this.W = value.Z;
				this.X = value.W;
			}
		}

		/// <returns>a new vector consisting of the current vector's z, z, w, x values</returns>
		public Vector4 Zzwx
		{
			get
			{
				return new Vector4(this.Z, this.Z, this.W, this.X);
			}
		}

		/// <returns>a new vector consisting of the current vector's w, z, w, x values</returns>
		public Vector4 Wzwx
		{
			get
			{
				return new Vector4(this.W, this.Z, this.W, this.X);
			}
		}

		/// <returns>a new vector consisting of the current vector's x, w, w, x values</returns>
		public Vector4 Xwwx
		{
			get
			{
				return new Vector4(this.X, this.W, this.W, this.X);
			}
		}

		/// <returns>a new vector consisting of the current vector's y, w, w, x values</returns>
		public Vector4 Ywwx
		{
			get
			{
				return new Vector4(this.Y, this.W, this.W, this.X);
			}
		}

		/// <returns>a new vector consisting of the current vector's z, w, w, x values</returns>
		public Vector4 Zwwx
		{
			get
			{
				return new Vector4(this.Z, this.W, this.W, this.X);
			}
		}

		/// <returns>a new vector consisting of the current vector's w, w, w, x values</returns>
		public Vector4 Wwwx
		{
			get
			{
				return new Vector4(this.W, this.W, this.W, this.X);
			}
		}

		/// <returns>a new vector consisting of the current vector's x, x, x, y values</returns>
		public Vector4 Xxxy
		{
			get
			{
				return new Vector4(this.X, this.X, this.X, this.Y);
			}
		}

		/// <returns>a new vector consisting of the current vector's y, x, x, y values</returns>
		public Vector4 Yxxy
		{
			get
			{
				return new Vector4(this.Y, this.X, this.X, this.Y);
			}
		}

		/// <returns>a new vector consisting of the current vector's z, x, x, y values</returns>
		public Vector4 Zxxy
		{
			get
			{
				return new Vector4(this.Z, this.X, this.X, this.Y);
			}
		}

		/// <returns>a new vector consisting of the current vector's w, x, x, y values</returns>
		public Vector4 Wxxy
		{
			get
			{
				return new Vector4(this.W, this.X, this.X, this.Y);
			}
		}

		/// <returns>a new vector consisting of the current vector's x, y, x, y values</returns>
		public Vector4 Xyxy
		{
			get
			{
				return new Vector4(this.X, this.Y, this.X, this.Y);
			}
		}

		/// <returns>a new vector consisting of the current vector's y, y, x, y values</returns>
		public Vector4 Yyxy
		{
			get
			{
				return new Vector4(this.Y, this.Y, this.X, this.Y);
			}
		}

		/// <returns>a new vector consisting of the current vector's z, y, x, y values</returns>
		public Vector4 Zyxy
		{
			get
			{
				return new Vector4(this.Z, this.Y, this.X, this.Y);
			}
		}

		/// <returns>a new vector consisting of the current vector's w, y, x, y values</returns>
		public Vector4 Wyxy
		{
			get
			{
				return new Vector4(this.W, this.Y, this.X, this.Y);
			}
		}

		/// <returns>a new vector consisting of the current vector's x, z, x, y values</returns>
		public Vector4 Xzxy
		{
			get
			{
				return new Vector4(this.X, this.Z, this.X, this.Y);
			}
		}

		/// <returns>a new vector consisting of the current vector's y, z, x, y values</returns>
		public Vector4 Yzxy
		{
			get
			{
				return new Vector4(this.Y, this.Z, this.X, this.Y);
			}
		}

		/// <returns>a new vector consisting of the current vector's z, z, x, y values</returns>
		public Vector4 Zzxy
		{
			get
			{
				return new Vector4(this.Z, this.Z, this.X, this.Y);
			}
		}

		/// <returns>a new vector consisting of the current vector's w, z, x, y values</returns>
		public Vector4 Wzxy
		{
			get
			{
				return new Vector4(this.W, this.Z, this.X, this.Y);
			}
			set
			{
				this.W = value.X;
				this.Z = value.Y;
				this.X = value.Z;
				this.Y = value.W;
			}
		}

		/// <returns>a new vector consisting of the current vector's x, w, x, y values</returns>
		public Vector4 Xwxy
		{
			get
			{
				return new Vector4(this.X, this.W, this.X, this.Y);
			}
		}

		/// <returns>a new vector consisting of the current vector's y, w, x, y values</returns>
		public Vector4 Ywxy
		{
			get
			{
				return new Vector4(this.Y, this.W, this.X, this.Y);
			}
		}

		/// <returns>a new vector consisting of the current vector's z, w, x, y values</returns>
		public Vector4 Zwxy
		{
			get
			{
				return new Vector4(this.Z, this.W, this.X, this.Y);
			}
			set
			{
				this.Z = value.X;
				this.W = value.Y;
				this.X = value.Z;
				this.Y = value.W;
			}
		}

		/// <returns>a new vector consisting of the current vector's w, w, x, y values</returns>
		public Vector4 Wwxy
		{
			get
			{
				return new Vector4(this.W, this.W, this.X, this.Y);
			}
		}

		/// <returns>a new vector consisting of the current vector's x, x, y, y values</returns>
		public Vector4 Xxyy
		{
			get
			{
				return new Vector4(this.X, this.X, this.Y, this.Y);
			}
		}

		/// <returns>a new vector consisting of the current vector's y, x, y, y values</returns>
		public Vector4 Yxyy
		{
			get
			{
				return new Vector4(this.Y, this.X, this.Y, this.Y);
			}
		}

		/// <returns>a new vector consisting of the current vector's z, x, y, y values</returns>
		public Vector4 Zxyy
		{
			get
			{
				return new Vector4(this.Z, this.X, this.Y, this.Y);
			}
		}

		/// <returns>a new vector consisting of the current vector's w, x, y, y values</returns>
		public Vector4 Wxyy
		{
			get
			{
				return new Vector4(this.W, this.X, this.Y, this.Y);
			}
		}

		/// <returns>a new vector consisting of the current vector's x, y, y, y values</returns>
		public Vector4 Xyyy
		{
			get
			{
				return new Vector4(this.X, this.Y, this.Y, this.Y);
			}
		}

		/// <returns>a new vector consisting of the current vector's y, y, y, y values</returns>
		public Vector4 Yyyy
		{
			get
			{
				return new Vector4(this.Y, this.Y, this.Y, this.Y);
			}
		}

		/// <returns>a new vector consisting of the current vector's z, y, y, y values</returns>
		public Vector4 Zyyy
		{
			get
			{
				return new Vector4(this.Z, this.Y, this.Y, this.Y);
			}
		}

		/// <returns>a new vector consisting of the current vector's w, y, y, y values</returns>
		public Vector4 Wyyy
		{
			get
			{
				return new Vector4(this.W, this.Y, this.Y, this.Y);
			}
		}

		/// <returns>a new vector consisting of the current vector's x, z, y, y values</returns>
		public Vector4 Xzyy
		{
			get
			{
				return new Vector4(this.X, this.Z, this.Y, this.Y);
			}
		}

		/// <returns>a new vector consisting of the current vector's y, z, y, y values</returns>
		public Vector4 Yzyy
		{
			get
			{
				return new Vector4(this.Y, this.Z, this.Y, this.Y);
			}
		}

		/// <returns>a new vector consisting of the current vector's z, z, y, y values</returns>
		public Vector4 Zzyy
		{
			get
			{
				return new Vector4(this.Z, this.Z, this.Y, this.Y);
			}
		}

		/// <returns>a new vector consisting of the current vector's w, z, y, y values</returns>
		public Vector4 Wzyy
		{
			get
			{
				return new Vector4(this.W, this.Z, this.Y, this.Y);
			}
		}

		/// <returns>a new vector consisting of the current vector's x, w, y, y values</returns>
		public Vector4 Xwyy
		{
			get
			{
				return new Vector4(this.X, this.W, this.Y, this.Y);
			}
		}

		/// <returns>a new vector consisting of the current vector's y, w, y, y values</returns>
		public Vector4 Ywyy
		{
			get
			{
				return new Vector4(this.Y, this.W, this.Y, this.Y);
			}
		}

		/// <returns>a new vector consisting of the current vector's z, w, y, y values</returns>
		public Vector4 Zwyy
		{
			get
			{
				return new Vector4(this.Z, this.W, this.Y, this.Y);
			}
		}

		/// <returns>a new vector consisting of the current vector's w, w, y, y values</returns>
		public Vector4 Wwyy
		{
			get
			{
				return new Vector4(this.W, this.W, this.Y, this.Y);
			}
		}

		/// <returns>a new vector consisting of the current vector's x, x, z, y values</returns>
		public Vector4 Xxzy
		{
			get
			{
				return new Vector4(this.X, this.X, this.Z, this.Y);
			}
		}

		/// <returns>a new vector consisting of the current vector's y, x, z, y values</returns>
		public Vector4 Yxzy
		{
			get
			{
				return new Vector4(this.Y, this.X, this.Z, this.Y);
			}
		}

		/// <returns>a new vector consisting of the current vector's z, x, z, y values</returns>
		public Vector4 Zxzy
		{
			get
			{
				return new Vector4(this.Z, this.X, this.Z, this.Y);
			}
		}

		/// <returns>a new vector consisting of the current vector's w, x, z, y values</returns>
		public Vector4 Wxzy
		{
			get
			{
				return new Vector4(this.W, this.X, this.Z, this.Y);
			}
			set
			{
				this.W = value.X;
				this.X = value.Y;
				this.Z = value.Z;
				this.Y = value.W;
			}
		}

		/// <returns>a new vector consisting of the current vector's x, y, z, y values</returns>
		public Vector4 Xyzy
		{
			get
			{
				return new Vector4(this.X, this.Y, this.Z, this.Y);
			}
		}

		/// <returns>a new vector consisting of the current vector's y, y, z, y values</returns>
		public Vector4 Yyzy
		{
			get
			{
				return new Vector4(this.Y, this.Y, this.Z, this.Y);
			}
		}

		/// <returns>a new vector consisting of the current vector's z, y, z, y values</returns>
		public Vector4 Zyzy
		{
			get
			{
				return new Vector4(this.Z, this.Y, this.Z, this.Y);
			}
		}

		/// <returns>a new vector consisting of the current vector's w, y, z, y values</returns>
		public Vector4 Wyzy
		{
			get
			{
				return new Vector4(this.W, this.Y, this.Z, this.Y);
			}
		}

		/// <returns>a new vector consisting of the current vector's x, z, z, y values</returns>
		public Vector4 Xzzy
		{
			get
			{
				return new Vector4(this.X, this.Z, this.Z, this.Y);
			}
		}

		/// <returns>a new vector consisting of the current vector's y, z, z, y values</returns>
		public Vector4 Yzzy
		{
			get
			{
				return new Vector4(this.Y, this.Z, this.Z, this.Y);
			}
		}

		/// <returns>a new vector consisting of the current vector's z, z, z, y values</returns>
		public Vector4 Zzzy
		{
			get
			{
				return new Vector4(this.Z, this.Z, this.Z, this.Y);
			}
		}

		/// <returns>a new vector consisting of the current vector's w, z, z, y values</returns>
		public Vector4 Wzzy
		{
			get
			{
				return new Vector4(this.W, this.Z, this.Z, this.Y);
			}
		}

		/// <returns>a new vector consisting of the current vector's x, w, z, y values</returns>
		public Vector4 Xwzy
		{
			get
			{
				return new Vector4(this.X, this.W, this.Z, this.Y);
			}
			set
			{
				this.X = value.X;
				this.W = value.Y;
				this.Z = value.Z;
				this.Y = value.W;
			}
		}

		/// <returns>a new vector consisting of the current vector's y, w, z, y values</returns>
		public Vector4 Ywzy
		{
			get
			{
				return new Vector4(this.Y, this.W, this.Z, this.Y);
			}
		}

		/// <returns>a new vector consisting of the current vector's z, w, z, y values</returns>
		public Vector4 Zwzy
		{
			get
			{
				return new Vector4(this.Z, this.W, this.Z, this.Y);
			}
		}

		/// <returns>a new vector consisting of the current vector's w, w, z, y values</returns>
		public Vector4 Wwzy
		{
			get
			{
				return new Vector4(this.W, this.W, this.Z, this.Y);
			}
		}

		/// <returns>a new vector consisting of the current vector's x, x, w, y values</returns>
		public Vector4 Xxwy
		{
			get
			{
				return new Vector4(this.X, this.X, this.W, this.Y);
			}
		}

		/// <returns>a new vector consisting of the current vector's y, x, w, y values</returns>
		public Vector4 Yxwy
		{
			get
			{
				return new Vector4(this.Y, this.X, this.W, this.Y);
			}
		}

		/// <returns>a new vector consisting of the current vector's z, x, w, y values</returns>
		public Vector4 Zxwy
		{
			get
			{
				return new Vector4(this.Z, this.X, this.W, this.Y);
			}
			set
			{
				this.Z = value.X;
				this.X = value.Y;
				this.W = value.Z;
				this.Y = value.W;
			}
		}

		/// <returns>a new vector consisting of the current vector's w, x, w, y values</returns>
		public Vector4 Wxwy
		{
			get
			{
				return new Vector4(this.W, this.X, this.W, this.Y);
			}
		}

		/// <returns>a new vector consisting of the current vector's x, y, w, y values</returns>
		public Vector4 Xywy
		{
			get
			{
				return new Vector4(this.X, this.Y, this.W, this.Y);
			}
		}

		/// <returns>a new vector consisting of the current vector's y, y, w, y values</returns>
		public Vector4 Yywy
		{
			get
			{
				return new Vector4(this.Y, this.Y, this.W, this.Y);
			}
		}

		/// <returns>a new vector consisting of the current vector's z, y, w, y values</returns>
		public Vector4 Zywy
		{
			get
			{
				return new Vector4(this.Z, this.Y, this.W, this.Y);
			}
		}

		/// <returns>a new vector consisting of the current vector's w, y, w, y values</returns>
		public Vector4 Wywy
		{
			get
			{
				return new Vector4(this.W, this.Y, this.W, this.Y);
			}
		}

		/// <returns>a new vector consisting of the current vector's x, z, w, y values</returns>
		public Vector4 Xzwy
		{
			get
			{
				return new Vector4(this.X, this.Z, this.W, this.Y);
			}
			set
			{
				this.X = value.X;
				this.Z = value.Y;
				this.W = value.Z;
				this.Y = value.W;
			}
		}

		/// <returns>a new vector consisting of the current vector's y, z, w, y values</returns>
		public Vector4 Yzwy
		{
			get
			{
				return new Vector4(this.Y, this.Z, this.W, this.Y);
			}
		}

		/// <returns>a new vector consisting of the current vector's z, z, w, y values</returns>
		public Vector4 Zzwy
		{
			get
			{
				return new Vector4(this.Z, this.Z, this.W, this.Y);
			}
		}

		/// <returns>a new vector consisting of the current vector's w, z, w, y values</returns>
		public Vector4 Wzwy
		{
			get
			{
				return new Vector4(this.W, this.Z, this.W, this.Y);
			}
		}

		/// <returns>a new vector consisting of the current vector's x, w, w, y values</returns>
		public Vector4 Xwwy
		{
			get
			{
				return new Vector4(this.X, this.W, this.W, this.Y);
			}
		}

		/// <returns>a new vector consisting of the current vector's y, w, w, y values</returns>
		public Vector4 Ywwy
		{
			get
			{
				return new Vector4(this.Y, this.W, this.W, this.Y);
			}
		}

		/// <returns>a new vector consisting of the current vector's z, w, w, y values</returns>
		public Vector4 Zwwy
		{
			get
			{
				return new Vector4(this.Z, this.W, this.W, this.Y);
			}
		}

		/// <returns>a new vector consisting of the current vector's w, w, w, y values</returns>
		public Vector4 Wwwy
		{
			get
			{
				return new Vector4(this.W, this.W, this.W, this.Y);
			}
		}

		/// <returns>a new vector consisting of the current vector's x, x, x, z values</returns>
		public Vector4 Xxxz
		{
			get
			{
				return new Vector4(this.X, this.X, this.X, this.Z);
			}
		}

		/// <returns>a new vector consisting of the current vector's y, x, x, z values</returns>
		public Vector4 Yxxz
		{
			get
			{
				return new Vector4(this.Y, this.X, this.X, this.Z);
			}
		}

		/// <returns>a new vector consisting of the current vector's z, x, x, z values</returns>
		public Vector4 Zxxz
		{
			get
			{
				return new Vector4(this.Z, this.X, this.X, this.Z);
			}
		}

		/// <returns>a new vector consisting of the current vector's w, x, x, z values</returns>
		public Vector4 Wxxz
		{
			get
			{
				return new Vector4(this.W, this.X, this.X, this.Z);
			}
		}

		/// <returns>a new vector consisting of the current vector's x, y, x, z values</returns>
		public Vector4 Xyxz
		{
			get
			{
				return new Vector4(this.X, this.Y, this.X, this.Z);
			}
		}

		/// <returns>a new vector consisting of the current vector's y, y, x, z values</returns>
		public Vector4 Yyxz
		{
			get
			{
				return new Vector4(this.Y, this.Y, this.X, this.Z);
			}
		}

		/// <returns>a new vector consisting of the current vector's z, y, x, z values</returns>
		public Vector4 Zyxz
		{
			get
			{
				return new Vector4(this.Z, this.Y, this.X, this.Z);
			}
		}

		/// <returns>a new vector consisting of the current vector's w, y, x, z values</returns>
		public Vector4 Wyxz
		{
			get
			{
				return new Vector4(this.W, this.Y, this.X, this.Z);
			}
			set
			{
				this.W = value.X;
				this.Y = value.Y;
				this.X = value.Z;
				this.Z = value.W;
			}
		}

		/// <returns>a new vector consisting of the current vector's x, z, x, z values</returns>
		public Vector4 Xzxz
		{
			get
			{
				return new Vector4(this.X, this.Z, this.X, this.Z);
			}
		}

		/// <returns>a new vector consisting of the current vector's y, z, x, z values</returns>
		public Vector4 Yzxz
		{
			get
			{
				return new Vector4(this.Y, this.Z, this.X, this.Z);
			}
		}

		/// <returns>a new vector consisting of the current vector's z, z, x, z values</returns>
		public Vector4 Zzxz
		{
			get
			{
				return new Vector4(this.Z, this.Z, this.X, this.Z);
			}
		}

		/// <returns>a new vector consisting of the current vector's w, z, x, z values</returns>
		public Vector4 Wzxz
		{
			get
			{
				return new Vector4(this.W, this.Z, this.X, this.Z);
			}
		}

		/// <returns>a new vector consisting of the current vector's x, w, x, z values</returns>
		public Vector4 Xwxz
		{
			get
			{
				return new Vector4(this.X, this.W, this.X, this.Z);
			}
		}

		/// <returns>a new vector consisting of the current vector's y, w, x, z values</returns>
		public Vector4 Ywxz
		{
			get
			{
				return new Vector4(this.Y, this.W, this.X, this.Z);
			}
			set
			{
				this.Y = value.X;
				this.W = value.Y;
				this.X = value.Z;
				this.Z = value.W;
			}
		}

		/// <returns>a new vector consisting of the current vector's z, w, x, z values</returns>
		public Vector4 Zwxz
		{
			get
			{
				return new Vector4(this.Z, this.W, this.X, this.Z);
			}
		}

		/// <returns>a new vector consisting of the current vector's w, w, x, z values</returns>
		public Vector4 Wwxz
		{
			get
			{
				return new Vector4(this.W, this.W, this.X, this.Z);
			}
		}

		/// <returns>a new vector consisting of the current vector's x, x, y, z values</returns>
		public Vector4 Xxyz
		{
			get
			{
				return new Vector4(this.X, this.X, this.Y, this.Z);
			}
		}

		/// <returns>a new vector consisting of the current vector's y, x, y, z values</returns>
		public Vector4 Yxyz
		{
			get
			{
				return new Vector4(this.Y, this.X, this.Y, this.Z);
			}
		}

		/// <returns>a new vector consisting of the current vector's z, x, y, z values</returns>
		public Vector4 Zxyz
		{
			get
			{
				return new Vector4(this.Z, this.X, this.Y, this.Z);
			}
		}

		/// <returns>a new vector consisting of the current vector's w, x, y, z values</returns>
		public Vector4 Wxyz
		{
			get
			{
				return new Vector4(this.W, this.X, this.Y, this.Z);
			}
			set
			{
				this.W = value.X;
				this.X = value.Y;
				this.Y = value.Z;
				this.Z = value.W;
			}
		}

		/// <returns>a new vector consisting of the current vector's x, y, y, z values</returns>
		public Vector4 Xyyz
		{
			get
			{
				return new Vector4(this.X, this.Y, this.Y, this.Z);
			}
		}

		/// <returns>a new vector consisting of the current vector's y, y, y, z values</returns>
		public Vector4 Yyyz
		{
			get
			{
				return new Vector4(this.Y, this.Y, this.Y, this.Z);
			}
		}

		/// <returns>a new vector consisting of the current vector's z, y, y, z values</returns>
		public Vector4 Zyyz
		{
			get
			{
				return new Vector4(this.Z, this.Y, this.Y, this.Z);
			}
		}

		/// <returns>a new vector consisting of the current vector's w, y, y, z values</returns>
		public Vector4 Wyyz
		{
			get
			{
				return new Vector4(this.W, this.Y, this.Y, this.Z);
			}
		}

		/// <returns>a new vector consisting of the current vector's x, z, y, z values</returns>
		public Vector4 Xzyz
		{
			get
			{
				return new Vector4(this.X, this.Z, this.Y, this.Z);
			}
		}

		/// <returns>a new vector consisting of the current vector's y, z, y, z values</returns>
		public Vector4 Yzyz
		{
			get
			{
				return new Vector4(this.Y, this.Z, this.Y, this.Z);
			}
		}

		/// <returns>a new vector consisting of the current vector's z, z, y, z values</returns>
		public Vector4 Zzyz
		{
			get
			{
				return new Vector4(this.Z, this.Z, this.Y, this.Z);
			}
		}

		/// <returns>a new vector consisting of the current vector's w, z, y, z values</returns>
		public Vector4 Wzyz
		{
			get
			{
				return new Vector4(this.W, this.Z, this.Y, this.Z);
			}
		}

		/// <returns>a new vector consisting of the current vector's x, w, y, z values</returns>
		public Vector4 Xwyz
		{
			get
			{
				return new Vector4(this.X, this.W, this.Y, this.Z);
			}
			set
			{
				this.X = value.X;
				this.W = value.Y;
				this.Y = value.Z;
				this.Z = value.W;
			}
		}

		/// <returns>a new vector consisting of the current vector's y, w, y, z values</returns>
		public Vector4 Ywyz
		{
			get
			{
				return new Vector4(this.Y, this.W, this.Y, this.Z);
			}
		}

		/// <returns>a new vector consisting of the current vector's z, w, y, z values</returns>
		public Vector4 Zwyz
		{
			get
			{
				return new Vector4(this.Z, this.W, this.Y, this.Z);
			}
		}

		/// <returns>a new vector consisting of the current vector's w, w, y, z values</returns>
		public Vector4 Wwyz
		{
			get
			{
				return new Vector4(this.W, this.W, this.Y, this.Z);
			}
		}

		/// <returns>a new vector consisting of the current vector's x, x, z, z values</returns>
		public Vector4 Xxzz
		{
			get
			{
				return new Vector4(this.X, this.X, this.Z, this.Z);
			}
		}

		/// <returns>a new vector consisting of the current vector's y, x, z, z values</returns>
		public Vector4 Yxzz
		{
			get
			{
				return new Vector4(this.Y, this.X, this.Z, this.Z);
			}
		}

		/// <returns>a new vector consisting of the current vector's z, x, z, z values</returns>
		public Vector4 Zxzz
		{
			get
			{
				return new Vector4(this.Z, this.X, this.Z, this.Z);
			}
		}

		/// <returns>a new vector consisting of the current vector's w, x, z, z values</returns>
		public Vector4 Wxzz
		{
			get
			{
				return new Vector4(this.W, this.X, this.Z, this.Z);
			}
		}

		/// <returns>a new vector consisting of the current vector's x, y, z, z values</returns>
		public Vector4 Xyzz
		{
			get
			{
				return new Vector4(this.X, this.Y, this.Z, this.Z);
			}
		}

		/// <returns>a new vector consisting of the current vector's y, y, z, z values</returns>
		public Vector4 Yyzz
		{
			get
			{
				return new Vector4(this.Y, this.Y, this.Z, this.Z);
			}
		}

		/// <returns>a new vector consisting of the current vector's z, y, z, z values</returns>
		public Vector4 Zyzz
		{
			get
			{
				return new Vector4(this.Z, this.Y, this.Z, this.Z);
			}
		}

		/// <returns>a new vector consisting of the current vector's w, y, z, z values</returns>
		public Vector4 Wyzz
		{
			get
			{
				return new Vector4(this.W, this.Y, this.Z, this.Z);
			}
		}

		/// <returns>a new vector consisting of the current vector's x, z, z, z values</returns>
		public Vector4 Xzzz
		{
			get
			{
				return new Vector4(this.X, this.Z, this.Z, this.Z);
			}
		}

		/// <returns>a new vector consisting of the current vector's y, z, z, z values</returns>
		public Vector4 Yzzz
		{
			get
			{
				return new Vector4(this.Y, this.Z, this.Z, this.Z);
			}
		}

		/// <returns>a new vector consisting of the current vector's z, z, z, z values</returns>
		public Vector4 Zzzz
		{
			get
			{
				return new Vector4(this.Z, this.Z, this.Z, this.Z);
			}
		}

		/// <returns>a new vector consisting of the current vector's w, z, z, z values</returns>
		public Vector4 Wzzz
		{
			get
			{
				return new Vector4(this.W, this.Z, this.Z, this.Z);
			}
		}

		/// <returns>a new vector consisting of the current vector's x, w, z, z values</returns>
		public Vector4 Xwzz
		{
			get
			{
				return new Vector4(this.X, this.W, this.Z, this.Z);
			}
		}

		/// <returns>a new vector consisting of the current vector's y, w, z, z values</returns>
		public Vector4 Ywzz
		{
			get
			{
				return new Vector4(this.Y, this.W, this.Z, this.Z);
			}
		}

		/// <returns>a new vector consisting of the current vector's z, w, z, z values</returns>
		public Vector4 Zwzz
		{
			get
			{
				return new Vector4(this.Z, this.W, this.Z, this.Z);
			}
		}

		/// <returns>a new vector consisting of the current vector's w, w, z, z values</returns>
		public Vector4 Wwzz
		{
			get
			{
				return new Vector4(this.W, this.W, this.Z, this.Z);
			}
		}

		/// <returns>a new vector consisting of the current vector's x, x, w, z values</returns>
		public Vector4 Xxwz
		{
			get
			{
				return new Vector4(this.X, this.X, this.W, this.Z);
			}
		}

		/// <returns>a new vector consisting of the current vector's y, x, w, z values</returns>
		public Vector4 Yxwz
		{
			get
			{
				return new Vector4(this.Y, this.X, this.W, this.Z);
			}
			set
			{
				this.Y = value.X;
				this.X = value.Y;
				this.W = value.Z;
				this.Z = value.W;
			}
		}

		/// <returns>a new vector consisting of the current vector's z, x, w, z values</returns>
		public Vector4 Zxwz
		{
			get
			{
				return new Vector4(this.Z, this.X, this.W, this.Z);
			}
		}

		/// <returns>a new vector consisting of the current vector's w, x, w, z values</returns>
		public Vector4 Wxwz
		{
			get
			{
				return new Vector4(this.W, this.X, this.W, this.Z);
			}
		}

		/// <returns>a new vector consisting of the current vector's x, y, w, z values</returns>
		public Vector4 Xywz
		{
			get
			{
				return new Vector4(this.X, this.Y, this.W, this.Z);
			}
			set
			{
				this.X = value.X;
				this.Y = value.Y;
				this.W = value.Z;
				this.Z = value.W;
			}
		}

		/// <returns>a new vector consisting of the current vector's y, y, w, z values</returns>
		public Vector4 Yywz
		{
			get
			{
				return new Vector4(this.Y, this.Y, this.W, this.Z);
			}
		}

		/// <returns>a new vector consisting of the current vector's z, y, w, z values</returns>
		public Vector4 Zywz
		{
			get
			{
				return new Vector4(this.Z, this.Y, this.W, this.Z);
			}
		}

		/// <returns>a new vector consisting of the current vector's w, y, w, z values</returns>
		public Vector4 Wywz
		{
			get
			{
				return new Vector4(this.W, this.Y, this.W, this.Z);
			}
		}

		/// <returns>a new vector consisting of the current vector's x, z, w, z values</returns>
		public Vector4 Xzwz
		{
			get
			{
				return new Vector4(this.X, this.Z, this.W, this.Z);
			}
		}

		/// <returns>a new vector consisting of the current vector's y, z, w, z values</returns>
		public Vector4 Yzwz
		{
			get
			{
				return new Vector4(this.Y, this.Z, this.W, this.Z);
			}
		}

		/// <returns>a new vector consisting of the current vector's z, z, w, z values</returns>
		public Vector4 Zzwz
		{
			get
			{
				return new Vector4(this.Z, this.Z, this.W, this.Z);
			}
		}

		/// <returns>a new vector consisting of the current vector's w, z, w, z values</returns>
		public Vector4 Wzwz
		{
			get
			{
				return new Vector4(this.W, this.Z, this.W, this.Z);
			}
		}

		/// <returns>a new vector consisting of the current vector's x, w, w, z values</returns>
		public Vector4 Xwwz
		{
			get
			{
				return new Vector4(this.X, this.W, this.W, this.Z);
			}
		}

		/// <returns>a new vector consisting of the current vector's y, w, w, z values</returns>
		public Vector4 Ywwz
		{
			get
			{
				return new Vector4(this.Y, this.W, this.W, this.Z);
			}
		}

		/// <returns>a new vector consisting of the current vector's z, w, w, z values</returns>
		public Vector4 Zwwz
		{
			get
			{
				return new Vector4(this.Z, this.W, this.W, this.Z);
			}
		}

		/// <returns>a new vector consisting of the current vector's w, w, w, z values</returns>
		public Vector4 Wwwz
		{
			get
			{
				return new Vector4(this.W, this.W, this.W, this.Z);
			}
		}

		/// <returns>a new vector consisting of the current vector's x, x, x, w values</returns>
		public Vector4 Xxxw
		{
			get
			{
				return new Vector4(this.X, this.X, this.X, this.W);
			}
		}

		/// <returns>a new vector consisting of the current vector's y, x, x, w values</returns>
		public Vector4 Yxxw
		{
			get
			{
				return new Vector4(this.Y, this.X, this.X, this.W);
			}
		}

		/// <returns>a new vector consisting of the current vector's z, x, x, w values</returns>
		public Vector4 Zxxw
		{
			get
			{
				return new Vector4(this.Z, this.X, this.X, this.W);
			}
		}

		/// <returns>a new vector consisting of the current vector's w, x, x, w values</returns>
		public Vector4 Wxxw
		{
			get
			{
				return new Vector4(this.W, this.X, this.X, this.W);
			}
		}

		/// <returns>a new vector consisting of the current vector's x, y, x, w values</returns>
		public Vector4 Xyxw
		{
			get
			{
				return new Vector4(this.X, this.Y, this.X, this.W);
			}
		}

		/// <returns>a new vector consisting of the current vector's y, y, x, w values</returns>
		public Vector4 Yyxw
		{
			get
			{
				return new Vector4(this.Y, this.Y, this.X, this.W);
			}
		}

		/// <returns>a new vector consisting of the current vector's z, y, x, w values</returns>
		public Vector4 Zyxw
		{
			get
			{
				return new Vector4(this.Z, this.Y, this.X, this.W);
			}
			set
			{
				this.Z = value.X;
				this.Y = value.Y;
				this.X = value.Z;
				this.W = value.W;
			}
		}

		/// <returns>a new vector consisting of the current vector's w, y, x, w values</returns>
		public Vector4 Wyxw
		{
			get
			{
				return new Vector4(this.W, this.Y, this.X, this.W);
			}
		}

		/// <returns>a new vector consisting of the current vector's x, z, x, w values</returns>
		public Vector4 Xzxw
		{
			get
			{
				return new Vector4(this.X, this.Z, this.X, this.W);
			}
		}

		/// <returns>a new vector consisting of the current vector's y, z, x, w values</returns>
		public Vector4 Yzxw
		{
			get
			{
				return new Vector4(this.Y, this.Z, this.X, this.W);
			}
			set
			{
				this.Y = value.X;
				this.Z = value.Y;
				this.X = value.Z;
				this.W = value.W;
			}
		}

		/// <returns>a new vector consisting of the current vector's z, z, x, w values</returns>
		public Vector4 Zzxw
		{
			get
			{
				return new Vector4(this.Z, this.Z, this.X, this.W);
			}
		}

		/// <returns>a new vector consisting of the current vector's w, z, x, w values</returns>
		public Vector4 Wzxw
		{
			get
			{
				return new Vector4(this.W, this.Z, this.X, this.W);
			}
		}

		/// <returns>a new vector consisting of the current vector's x, w, x, w values</returns>
		public Vector4 Xwxw
		{
			get
			{
				return new Vector4(this.X, this.W, this.X, this.W);
			}
		}

		/// <returns>a new vector consisting of the current vector's y, w, x, w values</returns>
		public Vector4 Ywxw
		{
			get
			{
				return new Vector4(this.Y, this.W, this.X, this.W);
			}
		}

		/// <returns>a new vector consisting of the current vector's z, w, x, w values</returns>
		public Vector4 Zwxw
		{
			get
			{
				return new Vector4(this.Z, this.W, this.X, this.W);
			}
		}

		/// <returns>a new vector consisting of the current vector's w, w, x, w values</returns>
		public Vector4 Wwxw
		{
			get
			{
				return new Vector4(this.W, this.W, this.X, this.W);
			}
		}

		/// <returns>a new vector consisting of the current vector's x, x, y, w values</returns>
		public Vector4 Xxyw
		{
			get
			{
				return new Vector4(this.X, this.X, this.Y, this.W);
			}
		}

		/// <returns>a new vector consisting of the current vector's y, x, y, w values</returns>
		public Vector4 Yxyw
		{
			get
			{
				return new Vector4(this.Y, this.X, this.Y, this.W);
			}
		}

		/// <returns>a new vector consisting of the current vector's z, x, y, w values</returns>
		public Vector4 Zxyw
		{
			get
			{
				return new Vector4(this.Z, this.X, this.Y, this.W);
			}
			set
			{
				this.Z = value.X;
				this.X = value.Y;
				this.Y = value.Z;
				this.W = value.W;
			}
		}

		/// <returns>a new vector consisting of the current vector's w, x, y, w values</returns>
		public Vector4 Wxyw
		{
			get
			{
				return new Vector4(this.W, this.X, this.Y, this.W);
			}
		}

		/// <returns>a new vector consisting of the current vector's x, y, y, w values</returns>
		public Vector4 Xyyw
		{
			get
			{
				return new Vector4(this.X, this.Y, this.Y, this.W);
			}
		}

		/// <returns>a new vector consisting of the current vector's y, y, y, w values</returns>
		public Vector4 Yyyw
		{
			get
			{
				return new Vector4(this.Y, this.Y, this.Y, this.W);
			}
		}

		/// <returns>a new vector consisting of the current vector's z, y, y, w values</returns>
		public Vector4 Zyyw
		{
			get
			{
				return new Vector4(this.Z, this.Y, this.Y, this.W);
			}
		}

		/// <returns>a new vector consisting of the current vector's w, y, y, w values</returns>
		public Vector4 Wyyw
		{
			get
			{
				return new Vector4(this.W, this.Y, this.Y, this.W);
			}
		}

		/// <returns>a new vector consisting of the current vector's x, z, y, w values</returns>
		public Vector4 Xzyw
		{
			get
			{
				return new Vector4(this.X, this.Z, this.Y, this.W);
			}
			set
			{
				this.X = value.X;
				this.Z = value.Y;
				this.Y = value.Z;
				this.W = value.W;
			}
		}

		/// <returns>a new vector consisting of the current vector's y, z, y, w values</returns>
		public Vector4 Yzyw
		{
			get
			{
				return new Vector4(this.Y, this.Z, this.Y, this.W);
			}
		}

		/// <returns>a new vector consisting of the current vector's z, z, y, w values</returns>
		public Vector4 Zzyw
		{
			get
			{
				return new Vector4(this.Z, this.Z, this.Y, this.W);
			}
		}

		/// <returns>a new vector consisting of the current vector's w, z, y, w values</returns>
		public Vector4 Wzyw
		{
			get
			{
				return new Vector4(this.W, this.Z, this.Y, this.W);
			}
		}

		/// <returns>a new vector consisting of the current vector's x, w, y, w values</returns>
		public Vector4 Xwyw
		{
			get
			{
				return new Vector4(this.X, this.W, this.Y, this.W);
			}
		}

		/// <returns>a new vector consisting of the current vector's y, w, y, w values</returns>
		public Vector4 Ywyw
		{
			get
			{
				return new Vector4(this.Y, this.W, this.Y, this.W);
			}
		}

		/// <returns>a new vector consisting of the current vector's z, w, y, w values</returns>
		public Vector4 Zwyw
		{
			get
			{
				return new Vector4(this.Z, this.W, this.Y, this.W);
			}
		}

		/// <returns>a new vector consisting of the current vector's w, w, y, w values</returns>
		public Vector4 Wwyw
		{
			get
			{
				return new Vector4(this.W, this.W, this.Y, this.W);
			}
		}

		/// <returns>a new vector consisting of the current vector's x, x, z, w values</returns>
		public Vector4 Xxzw
		{
			get
			{
				return new Vector4(this.X, this.X, this.Z, this.W);
			}
		}

		/// <returns>a new vector consisting of the current vector's y, x, z, w values</returns>
		public Vector4 Yxzw
		{
			get
			{
				return new Vector4(this.Y, this.X, this.Z, this.W);
			}
			set
			{
				this.Y = value.X;
				this.X = value.Y;
				this.Z = value.Z;
				this.W = value.W;
			}
		}

		/// <returns>a new vector consisting of the current vector's z, x, z, w values</returns>
		public Vector4 Zxzw
		{
			get
			{
				return new Vector4(this.Z, this.X, this.Z, this.W);
			}
		}

		/// <returns>a new vector consisting of the current vector's w, x, z, w values</returns>
		public Vector4 Wxzw
		{
			get
			{
				return new Vector4(this.W, this.X, this.Z, this.W);
			}
		}

		/// <returns>a new vector consisting of the current vector's x, y, z, w values</returns>
		public Vector4 Xyzw
		{
			get
			{
				return new Vector4(this.X, this.Y, this.Z, this.W);
			}
			set
			{
				this.X = value.X;
				this.Y = value.Y;
				this.Z = value.Z;
				this.W = value.W;
			}
		}

		/// <returns>a new vector consisting of the current vector's y, y, z, w values</returns>
		public Vector4 Yyzw
		{
			get
			{
				return new Vector4(this.Y, this.Y, this.Z, this.W);
			}
		}

		/// <returns>a new vector consisting of the current vector's z, y, z, w values</returns>
		public Vector4 Zyzw
		{
			get
			{
				return new Vector4(this.Z, this.Y, this.Z, this.W);
			}
		}

		/// <returns>a new vector consisting of the current vector's w, y, z, w values</returns>
		public Vector4 Wyzw
		{
			get
			{
				return new Vector4(this.W, this.Y, this.Z, this.W);
			}
		}

		/// <returns>a new vector consisting of the current vector's x, z, z, w values</returns>
		public Vector4 Xzzw
		{
			get
			{
				return new Vector4(this.X, this.Z, this.Z, this.W);
			}
		}

		/// <returns>a new vector consisting of the current vector's y, z, z, w values</returns>
		public Vector4 Yzzw
		{
			get
			{
				return new Vector4(this.Y, this.Z, this.Z, this.W);
			}
		}

		/// <returns>a new vector consisting of the current vector's z, z, z, w values</returns>
		public Vector4 Zzzw
		{
			get
			{
				return new Vector4(this.Z, this.Z, this.Z, this.W);
			}
		}

		/// <returns>a new vector consisting of the current vector's w, z, z, w values</returns>
		public Vector4 Wzzw
		{
			get
			{
				return new Vector4(this.W, this.Z, this.Z, this.W);
			}
		}

		/// <returns>a new vector consisting of the current vector's x, w, z, w values</returns>
		public Vector4 Xwzw
		{
			get
			{
				return new Vector4(this.X, this.W, this.Z, this.W);
			}
		}

		/// <returns>a new vector consisting of the current vector's y, w, z, w values</returns>
		public Vector4 Ywzw
		{
			get
			{
				return new Vector4(this.Y, this.W, this.Z, this.W);
			}
		}

		/// <returns>a new vector consisting of the current vector's z, w, z, w values</returns>
		public Vector4 Zwzw
		{
			get
			{
				return new Vector4(this.Z, this.W, this.Z, this.W);
			}
		}

		/// <returns>a new vector consisting of the current vector's w, w, z, w values</returns>
		public Vector4 Wwzw
		{
			get
			{
				return new Vector4(this.W, this.W, this.Z, this.W);
			}
		}

		/// <returns>a new vector consisting of the current vector's x, x, w, w values</returns>
		public Vector4 Xxww
		{
			get
			{
				return new Vector4(this.X, this.X, this.W, this.W);
			}
		}

		/// <returns>a new vector consisting of the current vector's y, x, w, w values</returns>
		public Vector4 Yxww
		{
			get
			{
				return new Vector4(this.Y, this.X, this.W, this.W);
			}
		}

		/// <returns>a new vector consisting of the current vector's z, x, w, w values</returns>
		public Vector4 Zxww
		{
			get
			{
				return new Vector4(this.Z, this.X, this.W, this.W);
			}
		}

		/// <returns>a new vector consisting of the current vector's w, x, w, w values</returns>
		public Vector4 Wxww
		{
			get
			{
				return new Vector4(this.W, this.X, this.W, this.W);
			}
		}

		/// <returns>a new vector consisting of the current vector's x, y, w, w values</returns>
		public Vector4 Xyww
		{
			get
			{
				return new Vector4(this.X, this.Y, this.W, this.W);
			}
		}

		/// <returns>a new vector consisting of the current vector's y, y, w, w values</returns>
		public Vector4 Yyww
		{
			get
			{
				return new Vector4(this.Y, this.Y, this.W, this.W);
			}
		}

		/// <returns>a new vector consisting of the current vector's z, y, w, w values</returns>
		public Vector4 Zyww
		{
			get
			{
				return new Vector4(this.Z, this.Y, this.W, this.W);
			}
		}

		/// <returns>a new vector consisting of the current vector's w, y, w, w values</returns>
		public Vector4 Wyww
		{
			get
			{
				return new Vector4(this.W, this.Y, this.W, this.W);
			}
		}

		/// <returns>a new vector consisting of the current vector's x, z, w, w values</returns>
		public Vector4 Xzww
		{
			get
			{
				return new Vector4(this.X, this.Z, this.W, this.W);
			}
		}

		/// <returns>a new vector consisting of the current vector's y, z, w, w values</returns>
		public Vector4 Yzww
		{
			get
			{
				return new Vector4(this.Y, this.Z, this.W, this.W);
			}
		}

		/// <returns>a new vector consisting of the current vector's z, z, w, w values</returns>
		public Vector4 Zzww
		{
			get
			{
				return new Vector4(this.Z, this.Z, this.W, this.W);
			}
		}

		/// <returns>a new vector consisting of the current vector's w, z, w, w values</returns>
		public Vector4 Wzww
		{
			get
			{
				return new Vector4(this.W, this.Z, this.W, this.W);
			}
		}

		/// <returns>a new vector consisting of the current vector's x, w, w, w values</returns>
		public Vector4 Xwww
		{
			get
			{
				return new Vector4(this.X, this.W, this.W, this.W);
			}
		}

		/// <returns>a new vector consisting of the current vector's y, w, w, w values</returns>
		public Vector4 Ywww
		{
			get
			{
				return new Vector4(this.Y, this.W, this.W, this.W);
			}
		}

		/// <returns>a new vector consisting of the current vector's z, w, w, w values</returns>
		public Vector4 Zwww
		{
			get
			{
				return new Vector4(this.Z, this.W, this.W, this.W);
			}
		}

		/// <returns>a new vector consisting of the current vector's w, w, w, w values</returns>
		public Vector4 Wwww
		{
			get
			{
				return new Vector4(this.W, this.W, this.W, this.W);
			}
		}

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

		/// <returns>a new vector consisting of the current vector's w, x, x values</returns>
		public Vector3 Wxx
		{
			get
			{
				return new Vector3(this.W, this.X, this.X);
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

		/// <returns>a new vector consisting of the current vector's w, y, x values</returns>
		public Vector3 Wyx
		{
			get
			{
				return new Vector3(this.W, this.Y, this.X);
			}
			set
			{
				this.W = value.X;
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

		/// <returns>a new vector consisting of the current vector's w, z, x values</returns>
		public Vector3 Wzx
		{
			get
			{
				return new Vector3(this.W, this.Z, this.X);
			}
			set
			{
				this.W = value.X;
				this.Z = value.Y;
				this.X = value.Z;
			}
		}

		/// <returns>a new vector consisting of the current vector's x, w, x values</returns>
		public Vector3 Xwx
		{
			get
			{
				return new Vector3(this.X, this.W, this.X);
			}
		}

		/// <returns>a new vector consisting of the current vector's y, w, x values</returns>
		public Vector3 Ywx
		{
			get
			{
				return new Vector3(this.Y, this.W, this.X);
			}
			set
			{
				this.Y = value.X;
				this.W = value.Y;
				this.X = value.Z;
			}
		}

		/// <returns>a new vector consisting of the current vector's z, w, x values</returns>
		public Vector3 Zwx
		{
			get
			{
				return new Vector3(this.Z, this.W, this.X);
			}
			set
			{
				this.Z = value.X;
				this.W = value.Y;
				this.X = value.Z;
			}
		}

		/// <returns>a new vector consisting of the current vector's w, w, x values</returns>
		public Vector3 Wwx
		{
			get
			{
				return new Vector3(this.W, this.W, this.X);
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

		/// <returns>a new vector consisting of the current vector's w, x, y values</returns>
		public Vector3 Wxy
		{
			get
			{
				return new Vector3(this.W, this.X, this.Y);
			}
			set
			{
				this.W = value.X;
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

		/// <returns>a new vector consisting of the current vector's w, y, y values</returns>
		public Vector3 Wyy
		{
			get
			{
				return new Vector3(this.W, this.Y, this.Y);
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

		/// <returns>a new vector consisting of the current vector's w, z, y values</returns>
		public Vector3 Wzy
		{
			get
			{
				return new Vector3(this.W, this.Z, this.Y);
			}
			set
			{
				this.W = value.X;
				this.Z = value.Y;
				this.Y = value.Z;
			}
		}

		/// <returns>a new vector consisting of the current vector's x, w, y values</returns>
		public Vector3 Xwy
		{
			get
			{
				return new Vector3(this.X, this.W, this.Y);
			}
			set
			{
				this.X = value.X;
				this.W = value.Y;
				this.Y = value.Z;
			}
		}

		/// <returns>a new vector consisting of the current vector's y, w, y values</returns>
		public Vector3 Ywy
		{
			get
			{
				return new Vector3(this.Y, this.W, this.Y);
			}
		}

		/// <returns>a new vector consisting of the current vector's z, w, y values</returns>
		public Vector3 Zwy
		{
			get
			{
				return new Vector3(this.Z, this.W, this.Y);
			}
			set
			{
				this.Z = value.X;
				this.W = value.Y;
				this.Y = value.Z;
			}
		}

		/// <returns>a new vector consisting of the current vector's w, w, y values</returns>
		public Vector3 Wwy
		{
			get
			{
				return new Vector3(this.W, this.W, this.Y);
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

		/// <returns>a new vector consisting of the current vector's w, x, z values</returns>
		public Vector3 Wxz
		{
			get
			{
				return new Vector3(this.W, this.X, this.Z);
			}
			set
			{
				this.W = value.X;
				this.X = value.Y;
				this.Z = value.Z;
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

		/// <returns>a new vector consisting of the current vector's w, y, z values</returns>
		public Vector3 Wyz
		{
			get
			{
				return new Vector3(this.W, this.Y, this.Z);
			}
			set
			{
				this.W = value.X;
				this.Y = value.Y;
				this.Z = value.Z;
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

		/// <returns>a new vector consisting of the current vector's w, z, z values</returns>
		public Vector3 Wzz
		{
			get
			{
				return new Vector3(this.W, this.Z, this.Z);
			}
		}

		/// <returns>a new vector consisting of the current vector's x, w, z values</returns>
		public Vector3 Xwz
		{
			get
			{
				return new Vector3(this.X, this.W, this.Z);
			}
			set
			{
				this.X = value.X;
				this.W = value.Y;
				this.Z = value.Z;
			}
		}

		/// <returns>a new vector consisting of the current vector's y, w, z values</returns>
		public Vector3 Ywz
		{
			get
			{
				return new Vector3(this.Y, this.W, this.Z);
			}
			set
			{
				this.Y = value.X;
				this.W = value.Y;
				this.Z = value.Z;
			}
		}

		/// <returns>a new vector consisting of the current vector's z, w, z values</returns>
		public Vector3 Zwz
		{
			get
			{
				return new Vector3(this.Z, this.W, this.Z);
			}
		}

		/// <returns>a new vector consisting of the current vector's w, w, z values</returns>
		public Vector3 Wwz
		{
			get
			{
				return new Vector3(this.W, this.W, this.Z);
			}
		}

		/// <returns>a new vector consisting of the current vector's x, x, w values</returns>
		public Vector3 Xxw
		{
			get
			{
				return new Vector3(this.X, this.X, this.W);
			}
		}

		/// <returns>a new vector consisting of the current vector's y, x, w values</returns>
		public Vector3 Yxw
		{
			get
			{
				return new Vector3(this.Y, this.X, this.W);
			}
			set
			{
				this.Y = value.X;
				this.X = value.Y;
				this.W = value.Z;
			}
		}

		/// <returns>a new vector consisting of the current vector's z, x, w values</returns>
		public Vector3 Zxw
		{
			get
			{
				return new Vector3(this.Z, this.X, this.W);
			}
			set
			{
				this.Z = value.X;
				this.X = value.Y;
				this.W = value.Z;
			}
		}

		/// <returns>a new vector consisting of the current vector's w, x, w values</returns>
		public Vector3 Wxw
		{
			get
			{
				return new Vector3(this.W, this.X, this.W);
			}
		}

		/// <returns>a new vector consisting of the current vector's x, y, w values</returns>
		public Vector3 Xyw
		{
			get
			{
				return new Vector3(this.X, this.Y, this.W);
			}
			set
			{
				this.X = value.X;
				this.Y = value.Y;
				this.W = value.Z;
			}
		}

		/// <returns>a new vector consisting of the current vector's y, y, w values</returns>
		public Vector3 Yyw
		{
			get
			{
				return new Vector3(this.Y, this.Y, this.W);
			}
		}

		/// <returns>a new vector consisting of the current vector's z, y, w values</returns>
		public Vector3 Zyw
		{
			get
			{
				return new Vector3(this.Z, this.Y, this.W);
			}
			set
			{
				this.Z = value.X;
				this.Y = value.Y;
				this.W = value.Z;
			}
		}

		/// <returns>a new vector consisting of the current vector's w, y, w values</returns>
		public Vector3 Wyw
		{
			get
			{
				return new Vector3(this.W, this.Y, this.W);
			}
		}

		/// <returns>a new vector consisting of the current vector's x, z, w values</returns>
		public Vector3 Xzw
		{
			get
			{
				return new Vector3(this.X, this.Z, this.W);
			}
			set
			{
				this.X = value.X;
				this.Z = value.Y;
				this.W = value.Z;
			}
		}

		/// <returns>a new vector consisting of the current vector's y, z, w values</returns>
		public Vector3 Yzw
		{
			get
			{
				return new Vector3(this.Y, this.Z, this.W);
			}
			set
			{
				this.Y = value.X;
				this.Z = value.Y;
				this.W = value.Z;
			}
		}

		/// <returns>a new vector consisting of the current vector's z, z, w values</returns>
		public Vector3 Zzw
		{
			get
			{
				return new Vector3(this.Z, this.Z, this.W);
			}
		}

		/// <returns>a new vector consisting of the current vector's w, z, w values</returns>
		public Vector3 Wzw
		{
			get
			{
				return new Vector3(this.W, this.Z, this.W);
			}
		}

		/// <returns>a new vector consisting of the current vector's x, w, w values</returns>
		public Vector3 Xww
		{
			get
			{
				return new Vector3(this.X, this.W, this.W);
			}
		}

		/// <returns>a new vector consisting of the current vector's y, w, w values</returns>
		public Vector3 Yww
		{
			get
			{
				return new Vector3(this.Y, this.W, this.W);
			}
		}

		/// <returns>a new vector consisting of the current vector's z, w, w values</returns>
		public Vector3 Zww
		{
			get
			{
				return new Vector3(this.Z, this.W, this.W);
			}
		}

		/// <returns>a new vector consisting of the current vector's w, w, w values</returns>
		public Vector3 Www
		{
			get
			{
				return new Vector3(this.W, this.W, this.W);
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

		/// <returns>a new vector consisting of the current vector's w, x values</returns>
		public Vector2 Wx
		{
			get
			{
				return new Vector2(this.W, this.X);
			}
			set
			{
				this.W = value.X;
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

		/// <returns>a new vector consisting of the current vector's w, y values</returns>
		public Vector2 Wy
		{
			get
			{
				return new Vector2(this.W, this.Y);
			}
			set
			{
				this.W = value.X;
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

		/// <returns>a new vector consisting of the current vector's w, z values</returns>
		public Vector2 Wz
		{
			get
			{
				return new Vector2(this.W, this.Z);
			}
			set
			{
				this.W = value.X;
				this.Z = value.Y;
			}
		}

		/// <returns>a new vector consisting of the current vector's x, w values</returns>
		public Vector2 Xw
		{
			get
			{
				return new Vector2(this.X, this.W);
			}
			set
			{
				this.X = value.X;
				this.W = value.Y;
			}
		}

		/// <returns>a new vector consisting of the current vector's y, w values</returns>
		public Vector2 Yw
		{
			get
			{
				return new Vector2(this.Y, this.W);
			}
			set
			{
				this.Y = value.X;
				this.W = value.Y;
			}
		}

		/// <returns>a new vector consisting of the current vector's z, w values</returns>
		public Vector2 Zw
		{
			get
			{
				return new Vector2(this.Z, this.W);
			}
			set
			{
				this.Z = value.X;
				this.W = value.Y;
			}
		}

		/// <returns>a new vector consisting of the current vector's w, w values</returns>
		public Vector2 Ww
		{
			get
			{
				return new Vector2(this.W, this.W);
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

		/// <summary>Alpha</summary>
		public float A
		{
			get
			{
				return this.W;
			}
			set
			{
				this.W = value;
			}
		}

		/// <summary>constructor taking 4 scalar floats</summary>
		/// <param name="x">x value to init with</param>
		/// <param name="y">y value to init with</param>
		/// <param name="z">z value to init with</param>
		/// <param name="w">w value to init with</param>
		public Vector4(float x, float y, float z, float w)
		{
			this.X = x;
			this.Y = y;
			this.Z = z;
			this.W = w;
		}

		/// <summary>constructor taking a Vector3 and a scalar float</summary>
		/// <param name="xyz">xyz value to init with</param>
		/// <param name="w">w value to init with</param>
		public Vector4(Vector3 xyz, float w)
		{
			this.X = xyz.X;
			this.Y = xyz.Y;
			this.Z = xyz.Z;
			this.W = w;
		}

		/// <summary>constructor taking a Vector2 and two scalar floats</summary>
		/// <param name="xy">xy values to init with</param>
		/// <param name="z">z value to init with</param>
		/// <param name="w">w value to init with</param>
		public Vector4(Vector2 xy, float z, float w)
		{
			this.X = xy.X;
			this.Y = xy.Y;
			this.Z = z;
			this.W = w;
		}

		/// <summary>constructor taking two Vector2s</summary>
		/// <param name="xy">xy values to init with</param>
		/// <param name="zw">zw values to init with</param>
		public Vector4(Vector2 xy, Vector2 zw)
		{
			this.X = xy.X;
			this.Y = xy.Y;
			this.Z = zw.X;
			this.W = zw.Y;
		}

		/// <summary>constructor taking one float</summary>
		/// <param name="f">f</param>
		public Vector4(float f)
		{
			this.X = f;
			this.Y = f;
			this.Z = f;
			this.W = f;
		}

		/// <summary>return the length of this vector</summary>
		/// <returns>the length of this vector</returns>
		public float Length()
		{
			return (float)Math.Sqrt((double)(this.X * this.X + this.Y * this.Y + this.Z * this.Z + this.W * this.W));
		}

		/// <summary>return the length squared of this vector</summary>
		/// <returns>the length squared of this vector</returns>
		public float LengthSquared()
		{
			return this.X * this.X + this.Y * this.Y + this.Z * this.Z + this.W * this.W;
		}

		/// <summary>get the distance between this and another vector</summary>
		/// <param name="v">the vector to get the distance to</param>
		/// <returns>the distance bwteen this and the other vector</returns>
		public float Distance(Vector4 v)
		{
			return this.Distance(ref v);
		}

		/// <summary>get the distance between this and another vector</summary>
		/// <param name="v">the vector to get the distance to</param>
		/// <returns>the distance bwteen this and the other vector</returns>
		public float Distance(ref Vector4 v)
		{
			float num = this.X - v.X;
			float num2 = this.Y - v.Y;
			float num3 = this.Z - v.Z;
			float num4 = this.W - v.W;
			return (float)Math.Sqrt((double)(num * num + num2 * num2 + num3 * num3 + num4 * num4));
		}

		/// <summary>get the distance squared between this and another vector</summary>
		/// <param name="v">the vector to get the distance squared to</param>
		/// <returns>the distance between this and the other vector squared</returns>
		public float DistanceSquared(Vector4 v)
		{
			return this.DistanceSquared(ref v);
		}

		/// <summary>get the distance squared between this and another vector</summary>
		/// <param name="v">the vector to get the distance squared to</param>
		/// <returns>the distance between this and the other vector squared</returns>
		public float DistanceSquared(ref Vector4 v)
		{
			float num = this.X - v.X;
			float num2 = this.Y - v.Y;
			float num3 = this.Z - v.Z;
			float num4 = this.W - v.W;
			return num * num + num2 * num2 + num3 * num3 + num4 * num4;
		}

		/// <summary>dot product of this and v</summary>
		/// <param name="v">vector to take the dot product with</param>
		/// <returns>dot product of this and v</returns>
		public float Dot(Vector4 v)
		{
			return this.X * v.X + this.Y * v.Y + this.Z * v.Z + this.W * v.W;
		}

		/// <summary>dot product of this and v</summary>
		/// <param name="v">vector to take the dot product with</param>
		/// <returns>dot product of this and v</returns>
		public float Dot(ref Vector4 v)
		{
			return this.X * v.X + this.Y * v.Y + this.Z * v.Z + this.W * v.W;
		}

		/// <summary>return this vector normalized</summary>
		/// <returns>this vector normalized</returns>
		public Vector4 Normalize()
		{
			Vector4 result;
			this.Normalize(out result);
			return result;
		}

		/// <summary>return this vector normalized</summary>
		/// <param name="result">this vector normalized</param>
		public void Normalize(out Vector4 result)
		{
			float num = 1f / this.Length();
			result.X = this.X * num;
			result.Y = this.Y * num;
			result.Z = this.Z * num;
			result.W = this.W * num;
		}

		/// <summary>element wise absolute value</summary>
		/// <returns>element wise absolute value of this</returns>
		public Vector4 Abs()
		{
			Vector4 result;
			this.Abs(out result);
			return result;
		}

		/// <summary>element wise absolute value</summary>
		/// <param name="result">element wise absolute value of this</param>
		public void Abs(out Vector4 result)
		{
			result.X = ((this.X >= 0f) ? this.X : (-this.X));
			result.Y = ((this.Y >= 0f) ? this.Y : (-this.Y));
			result.Z = ((this.Z >= 0f) ? this.Z : (-this.Z));
			result.W = ((this.W >= 0f) ? this.W : (-this.W));
		}

		/// <summary>element wise min</summary>
		/// <param name="v">vector to compare to this</param>
		/// <returns>the min of this and v</returns>
		public Vector4 Min(Vector4 v)
		{
			Vector4 result;
			this.Min(ref v, out result);
			return result;
		}

		/// <summary>element wise min</summary>
		/// <param name="v">vector to compare to this</param>
		/// <param name="result">the min of this and v</param>
		public void Min(ref Vector4 v, out Vector4 result)
		{
			result.X = ((this.X <= v.X) ? this.X : v.X);
			result.Y = ((this.Y <= v.Y) ? this.Y : v.Y);
			result.Z = ((this.Z <= v.Z) ? this.Z : v.Z);
			result.W = ((this.W <= v.W) ? this.W : v.W);
		}

		/// <summary>element wise min</summary>
		/// <param name="f">scalar to compare to this</param>
		/// <returns>the min of this and f</returns>
		public Vector4 Min(float f)
		{
			Vector4 result;
			this.Min(f, out result);
			return result;
		}

		/// <summary>element wise min</summary>
		/// <param name="f">scalar to compare to this</param>
		/// <param name="result">the min of this and f</param>
		public void Min(float f, out Vector4 result)
		{
			result.X = ((this.X <= f) ? this.X : f);
			result.Y = ((this.Y <= f) ? this.Y : f);
			result.Z = ((this.Z <= f) ? this.Z : f);
			result.W = ((this.W <= f) ? this.W : f);
		}

		/// <summary>element wise max</summary>
		/// <param name="v">vector to compare to this</param>
		/// <returns>the max of this and v</returns>
		public Vector4 Max(Vector4 v)
		{
			Vector4 result;
			this.Max(ref v, out result);
			return result;
		}

		/// <summary>element wise max</summary>
		/// <param name="v">vector to compare to this</param>
		/// <param name="result">the max of this and v</param>
		public void Max(ref Vector4 v, out Vector4 result)
		{
			result.X = ((this.X >= v.X) ? this.X : v.X);
			result.Y = ((this.Y >= v.Y) ? this.Y : v.Y);
			result.Z = ((this.Z >= v.Z) ? this.Z : v.Z);
			result.W = ((this.W >= v.W) ? this.W : v.W);
		}

		/// <summary>element wise max</summary>
		/// <param name="f">scalar to compare to this</param>
		/// <returns>the max of this and f</returns>
		public Vector4 Max(float f)
		{
			Vector4 result;
			this.Max(f, out result);
			return result;
		}

		/// <summary>element wise max</summary>
		/// <param name="f">scalar to compare to this</param>
		/// <param name="result">the max of this and f</param>
		public void Max(float f, out Vector4 result)
		{
			result.X = ((this.X >= f) ? this.X : f);
			result.Y = ((this.Y >= f) ? this.Y : f);
			result.Z = ((this.Z >= f) ? this.Z : f);
			result.W = ((this.W >= f) ? this.W : f);
		}

		/// <summary>element wise clamp</summary>
		/// <param name="min">min values to clamp against</param>
		/// <param name="max">max values to clamp against</param>
		/// <returns>a new vector consisting of each element of this clamped between min and max</returns>
		public Vector4 Clamp(Vector4 min, Vector4 max)
		{
			Vector4 result;
			this.Clamp(ref min, ref max, out result);
			return result;
		}

		/// <summary>element wise clamp</summary>
		/// <param name="min">min values to clamp against</param>
		/// <param name="max">max values to clamp against</param>
		/// <param name="result">a new vector consisting of each element of this clamped between min and max</param>
		public void Clamp(ref Vector4 min, ref Vector4 max, out Vector4 result)
		{
			result.X = ((this.X <= min.X) ? min.X : ((this.X >= max.X) ? max.X : this.X));
			result.Y = ((this.Y <= min.Y) ? min.Y : ((this.Y >= max.Y) ? max.Y : this.Y));
			result.Z = ((this.Z <= min.Z) ? min.Z : ((this.Z >= max.Z) ? max.Z : this.Z));
			result.W = ((this.W <= min.W) ? min.W : ((this.W >= max.W) ? max.W : this.W));
		}

		/// <summary>element wise clamp</summary>
		/// <param name="min">min value to clamp against</param>
		/// <param name="max">max value to clamp against</param>
		/// <returns>a new vector consisting of each element of this clamped between min and max</returns>
		public Vector4 Clamp(float min, float max)
		{
			Vector4 result;
			this.Clamp(min, max, out result);
			return result;
		}

		/// <summary>element wise clamp</summary>
		/// <param name="min">min value to clamp against</param>
		/// <param name="max">max value to clamp against</param>
		/// <param name="result">a new vector consisting of each element of this clamped between min and max</param>
		public void Clamp(float min, float max, out Vector4 result)
		{
			result.X = ((this.X <= min) ? min : ((this.X >= max) ? max : this.X));
			result.Y = ((this.Y <= min) ? min : ((this.Y >= max) ? max : this.Y));
			result.Z = ((this.Z <= min) ? min : ((this.Z >= max) ? max : this.Z));
			result.W = ((this.W <= min) ? min : ((this.W >= max) ? max : this.W));
		}

		/// <summary>element wise repeat</summary>
		/// <param name="min">min values to repeat over</param>
		/// <param name="max">max values to repeat over</param>
		/// <returns>a new vector consisting of each element of this repeated between min and max</returns>
		public Vector4 Repeat(Vector4 min, Vector4 max)
		{
			Vector4 result;
			this.Repeat(ref min, ref max, out result);
			return result;
		}

		/// <summary>element wise repeat</summary>
		/// <param name="min">min values to repeat over</param>
		/// <param name="max">max values to repeat over</param>
		/// <param name="result">a new vector consisting of each element of this repeated between min and max</param>
		public void Repeat(ref Vector4 min, ref Vector4 max, out Vector4 result)
		{
			result.X = FMath.Repeat(this.X, min.X, max.X);
			result.Y = FMath.Repeat(this.Y, min.Y, max.Y);
			result.Z = FMath.Repeat(this.Z, min.Z, max.Z);
			result.W = FMath.Repeat(this.W, min.W, max.W);
		}

		/// <summary>element wise repeat</summary>
		/// <param name="min">min value to repeat over</param>
		/// <param name="max">max value to repeat over</param>
		/// <returns>a new vector consisting of each element of this repeated between min and max</returns>
		public Vector4 Repeat(float min, float max)
		{
			Vector4 result;
			this.Repeat(min, max, out result);
			return result;
		}

		/// <summary>element wise repeat</summary>
		/// <param name="min">min value to repeat over</param>
		/// <param name="max">max value to repeat over</param>
		/// <param name="result">a new vector consisting of each element of this repeated between min and max</param>
		public void Repeat(float min, float max, out Vector4 result)
		{
			result.X = FMath.Repeat(this.X, min, max);
			result.Y = FMath.Repeat(this.Y, min, max);
			result.Z = FMath.Repeat(this.Z, min, max);
			result.W = FMath.Repeat(this.W, min, max);
		}

		/// <summary>lerp between this and the other vector</summary>
		/// <param name="v">the other vector to lerp to</param>
		/// <param name="f">lerp amount</param>
		/// <returns>a Vector4 where each element is the result of lerping f between the corresponding elements of this and other</returns>
		public Vector4 Lerp(Vector4 v, float f)
		{
			Vector4 result;
			this.Lerp(ref v, f, out result);
			return result;
		}

		/// <summary>lerp between this and the other vector</summary>
		/// <param name="v">the other vector to lerp to</param>
		/// <param name="f">lerp amount</param>
		/// <param name="result">a Vector4 where each element is the result of lerping f between the corresponding elements of this and other</param>
		public void Lerp(ref Vector4 v, float f, out Vector4 result)
		{
			float num = 1f - f;
			result.X = this.X * num + v.X * f;
			result.Y = this.Y * num + v.Y * f;
			result.Z = this.Z * num + v.Z * f;
			result.W = this.W * num + v.W * f;
		}

		/// <summary>move to target vector by specified length</summary>
		/// <param name="v">target vector</param>
		/// <param name="length">step length</param>
		/// <returns>a new vector moved to target vector by specified length</returns>
		public Vector4 MoveTo(Vector4 v, float length)
		{
			Vector4 result;
			this.MoveTo(ref v, length, out result);
			return result;
		}

		/// <summary>move to target vector by specified length</summary>
		/// <param name="v">target vector</param>
		/// <param name="length">step length</param>
		/// <param name="result">a new vector moved to target vector by specified length</param>
		public void MoveTo(ref Vector4 v, float length, out Vector4 result)
		{
			float num = this.Distance(v);
			result = ((length >= num) ? v : this.Lerp(v, length / num));
		}

		/// <summary>return this + v</summary>
		/// <param name="v">vector</param>
		/// <returns>this + v</returns>
		public Vector4 Add(Vector4 v)
		{
			Vector4 result;
			this.Add(ref v, out result);
			return result;
		}

		/// <summary>result = this + v</summary>
		/// <param name="v">vector</param>
		/// <param name="result">this + v</param>
		public void Add(ref Vector4 v, out Vector4 result)
		{
			result.X = this.X + v.X;
			result.Y = this.Y + v.Y;
			result.Z = this.Z + v.Z;
			result.W = this.W + v.W;
		}

		/// <summary>return this - v</summary>
		/// <param name="v">vector</param>
		/// <returns>this - v</returns>
		public Vector4 Subtract(Vector4 v)
		{
			Vector4 result;
			this.Subtract(ref v, out result);
			return result;
		}

		/// <summary>result = this - v</summary>
		/// <param name="v">vector</param>
		/// <param name="result">this - v</param>
		public void Subtract(ref Vector4 v, out Vector4 result)
		{
			result.X = this.X - v.X;
			result.Y = this.Y - v.Y;
			result.Z = this.Z - v.Z;
			result.W = this.W - v.W;
		}

		/// <summary>return this * v</summary>
		/// <param name="v">vector</param>
		/// <returns>this * v</returns>
		public Vector4 Multiply(Vector4 v)
		{
			Vector4 result;
			this.Multiply(ref v, out result);
			return result;
		}

		/// <summary>result = this * v</summary>
		/// <param name="v">vector</param>
		/// <param name="result">this * v</param>
		public void Multiply(ref Vector4 v, out Vector4 result)
		{
			result.X = this.X * v.X;
			result.Y = this.Y * v.Y;
			result.Z = this.Z * v.Z;
			result.W = this.W * v.W;
		}

		/// <summary>return this * f</summary>
		/// <param name="f">scalar</param>
		/// <returns>this * f</returns>
		public Vector4 Multiply(float f)
		{
			Vector4 result;
			this.Multiply(f, out result);
			return result;
		}

		/// <summary>result = this * f</summary>
		/// <param name="f">scalar</param>
		/// <param name="result">this * f</param>
		public void Multiply(float f, out Vector4 result)
		{
			result.X = this.X * f;
			result.Y = this.Y * f;
			result.Z = this.Z * f;
			result.W = this.W * f;
		}

		/// <summary>return this / v</summary>
		/// <param name="v">vector</param>
		/// <returns>this / v</returns>
		public Vector4 Divide(Vector4 v)
		{
			Vector4 result;
			this.Divide(ref v, out result);
			return result;
		}

		/// <summary>result = this / v</summary>
		/// <param name="v">vector</param>
		/// <param name="result">this / v</param>
		public void Divide(ref Vector4 v, out Vector4 result)
		{
			result.X = this.X / v.X;
			result.Y = this.Y / v.Y;
			result.Z = this.Z / v.Z;
			result.W = this.W / v.W;
		}

		/// <summary>return this / f</summary>
		/// <param name="f">scalar</param>
		/// <returns>this / f</returns>
		public Vector4 Divide(float f)
		{
			Vector4 result;
			this.Divide(f, out result);
			return result;
		}

		/// <summary>result = this / f</summary>
		/// <param name="f">scalar</param>
		/// <param name="result">this / f</param>
		public void Divide(float f, out Vector4 result)
		{
			float num = 1f / f;
			result.X = this.X * num;
			result.Y = this.Y * num;
			result.Z = this.Z * num;
			result.W = this.W * num;
		}

		/// <summary>return -this</summary>
		/// <returns>-this</returns>
		public Vector4 Negate()
		{
			Vector4 result;
			this.Negate(out result);
			return result;
		}

		/// <summary>result = -this</summary>
		/// <param name="result">-this</param>
		public void Negate(out Vector4 result)
		{
			result.X = -this.X;
			result.Y = -this.Y;
			result.Z = -this.Z;
			result.W = -this.W;
		}

		public bool IsUnit(float epsilon)
		{
			return Math.Abs(this.Length() - 1f) <= epsilon;
		}

		/// <summary>test if all elements of this are zero</summary>
		/// <returns>true if all elements of this are zero, false otherwise</returns>
		public bool IsZero()
		{
			return this.X == 0f && this.Y == 0f && this.Z == 0f && this.W == 0f;
		}

		/// <summary>test if all elements of this are one</summary>
		/// <returns>true if all elements of this are one, false otherwise</returns>
		public bool IsOne()
		{
			return this.X == 1f && this.Y == 1f && this.Z == 1f && this.W == 1f;
		}

		/// <summary>test if any elements of this are Infinity</summary>
		/// <returns>true if any elements are Infinity, false otherwise</returns>
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

		public bool Equals(Vector4 v, float epsilon)
		{
			return Math.Abs(this.X - v.X) <= epsilon && Math.Abs(this.Y - v.Y) <= epsilon && Math.Abs(this.Z - v.Z) <= epsilon && Math.Abs(this.W - v.W) <= epsilon;
		}

		/// <summary>equality test</summary>
		/// <param name="v">the vector to compare this to</param>
		/// <returns>true if this == v, false otherwise</returns>
		public bool Equals(Vector4 v)
		{
			return this.X == v.X && this.Y == v.Y && this.Z == v.Z && this.W == v.W;
		}

		/// <summary>equality test</summary>
		/// <param name="o">the object to compare this to</param>
		/// <returns>true if this == o, false otherwise</returns>
		public override bool Equals(object o)
		{
			return o is Vector4 && this.Equals((Vector4)o);
		}

		/// <summary>get the string representation of this vector</summary>
		/// <returns>the string representation of this vector</returns>
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

		/// <summary>static function equivalent to Length()</summary>
		/// <param name="v">vector</param>
		/// <returns>the length of the vector</returns>
		public static float Length(Vector4 v)
		{
			return v.Length();
		}

		/// <summary>static function equivalent to Length()</summary>
		/// <param name="v">vector</param>
		/// <returns>the length of the vector</returns>
		public static float Length(ref Vector4 v)
		{
			return v.Length();
		}

		/// <summary>static function equivalent to LengthSquared()</summary>
		/// <param name="v">vector</param>
		/// <returns>the length squared of the vector</returns>
		public static float LengthSquared(Vector4 v)
		{
			return v.LengthSquared();
		}

		/// <summary>static function equivalent to LengthSquared()</summary>
		/// <param name="v">vector</param>
		/// <returns>the length squared of the vector</returns>
		public static float LengthSquared(ref Vector4 v)
		{
			return v.LengthSquared();
		}

		/// <summary>static function equivalent to Distance(Vector4)</summary>
		/// <param name="v1">vector 1</param>
		/// <param name="v2">vector 2</param>
		/// <returns>the distance bwteen v1 and v2</returns>
		public static float Distance(Vector4 v1, Vector4 v2)
		{
			return v1.Distance(ref v2);
		}

		/// <summary>static function equivalent to Distance(ref Vector4)</summary>
		/// <param name="v1">vector 1</param>
		/// <param name="v2">vector 2</param>
		/// <returns>the distance bwteen v1 and v2</returns>
		public static float Distance(ref Vector4 v1, ref Vector4 v2)
		{
			return v1.Distance(ref v2);
		}

		/// <summary>static function equivalent to DistanceSquared(Vector4)</summary>
		/// <param name="v1">vector 1</param>
		/// <param name="v2">vector 2</param>
		/// <returns>the distance between v1 and v2 squared</returns>
		public static float DistanceSquared(Vector4 v1, Vector4 v2)
		{
			return v1.DistanceSquared(ref v2);
		}

		/// <summary>static function equivalent to DistanceSquared(ref Vector4)</summary>
		/// <param name="v1">vector 1</param>
		/// <param name="v2">vector 2</param>
		/// <returns>the distance between v1 and v2 squared</returns>
		public static float DistanceSquared(ref Vector4 v1, ref Vector4 v2)
		{
			return v1.DistanceSquared(ref v2);
		}

		/// <summary>static function equivalent to Dot(Vector4)</summary>
		/// <param name="v1">vector 1</param>
		/// <param name="v2">vector 2</param>
		/// <returns>dot product of v1 and v2</returns>
		public static float Dot(Vector4 v1, Vector4 v2)
		{
			return v1.Dot(ref v2);
		}

		/// <summary>static function equivalent to Dot(ref Vector4)</summary>
		/// <param name="v1">vector 1</param>
		/// <param name="v2">vector 2</param>
		/// <returns>dot product of v1 and v2</returns>
		public static float Dot(ref Vector4 v1, ref Vector4 v2)
		{
			return v1.Dot(ref v2);
		}

		/// <summary>static function equivalent to Normalize()</summary>
		/// <param name="v">vector</param>
		/// <returns>the vector normalized</returns>
		public static Vector4 Normalize(Vector4 v)
		{
			Vector4 result;
			v.Normalize(out result);
			return result;
		}

		/// <summary>static function equivalent to Normalize(out Vector4)</summary>
		/// <param name="v">vector</param>
		/// <param name="result">the vector normalized</param>
		public static void Normalize(ref Vector4 v, out Vector4 result)
		{
			v.Normalize(out result);
		}

		/// <summary>static function equivalent to Abs()</summary>
		/// <param name="v">vector</param>
		/// <returns>element wise absolute value of v</returns>
		public static Vector4 Abs(Vector4 v)
		{
			Vector4 result;
			v.Abs(out result);
			return result;
		}

		/// <summary>static function equivalent to Abs(out Vector4)</summary>
		/// <param name="v">vector</param>
		/// <param name="result">element wise absolute value of v</param>
		public static void Abs(ref Vector4 v, out Vector4 result)
		{
			v.Abs(out result);
		}

		/// <summary>static function equivalent to Min(Vector4)</summary>
		/// <param name="v1">vector 1</param>
		/// <param name="v2">vector 2</param>
		/// <returns>the min of v1 and v2</returns>
		public static Vector4 Min(Vector4 v1, Vector4 v2)
		{
			Vector4 result;
			v1.Min(ref v2, out result);
			return result;
		}

		/// <summary>static function equivalent to Min(ref Vector4, out Vector4)</summary>
		/// <param name="v1">vector 1</param>
		/// <param name="v2">vector 2</param>
		/// <param name="result">the min of v1 and v2</param>
		public static void Min(ref Vector4 v1, ref Vector4 v2, out Vector4 result)
		{
			v1.Min(ref v2, out result);
		}

		/// <summary>static function equivalent to Min(float)</summary>
		/// <param name="v">vector</param>
		/// <param name="f">scalar</param>
		/// <returns>the min of v and f</returns>
		public static Vector4 Min(Vector4 v, float f)
		{
			Vector4 result;
			v.Min(f, out result);
			return result;
		}

		/// <summary>static function equivalent to Min(float, out Vector4)</summary>
		/// <param name="v">vector</param>
		/// <param name="f">scalar</param>
		/// <param name="result">the min of v and f</param>
		public static void Min(ref Vector4 v, float f, out Vector4 result)
		{
			v.Min(f, out result);
		}

		/// <summary>static function equivalent to Max(Vector4)</summary>
		/// <param name="v1">vector 1</param>
		/// <param name="v2">vector 2</param>
		/// <returns>the max of v1 and v2</returns>
		public static Vector4 Max(Vector4 v1, Vector4 v2)
		{
			Vector4 result;
			v1.Max(ref v2, out result);
			return result;
		}

		/// <summary>static function equivalent to Max(ref Vector4, out Vector4)</summary>
		/// <param name="v1">vector 1</param>
		/// <param name="v2">vector 2</param>
		/// <param name="result">the max of v1 and v2</param>
		public static void Max(ref Vector4 v1, ref Vector4 v2, out Vector4 result)
		{
			v1.Max(ref v2, out result);
		}

		/// <summary>static function equivalent to Max(float)</summary>
		/// <param name="v">vector</param>
		/// <param name="f">scalar</param>
		/// <returns>the max of v and f</returns>
		public static Vector4 Max(Vector4 v, float f)
		{
			Vector4 result;
			v.Max(f, out result);
			return result;
		}

		/// <summary>static function equivalent to Max(float, out Vector4)</summary>
		/// <param name="v">vector</param>
		/// <param name="f">scalar</param>
		/// <param name="result">the max of v and f</param>
		public static void Max(ref Vector4 v, float f, out Vector4 result)
		{
			v.Max(f, out result);
		}

		/// <summary>static function equivalent to Clamp(Vector4, Vector4)</summary>
		/// <param name="v">vector</param>
		/// <param name="min">min values to clamp against</param>
		/// <param name="max">max values to clamp against</param>
		/// <returns>a new vector consisting of each element of v clamped between min and max</returns>
		public static Vector4 Clamp(Vector4 v, Vector4 min, Vector4 max)
		{
			Vector4 result;
			v.Clamp(ref min, ref max, out result);
			return result;
		}

		/// <summary>static function equivalent to Clamp(ref Vector4, ref Vector4, out Vector4)</summary>
		/// <param name="v">vector</param>
		/// <param name="min">min values to clamp against</param>
		/// <param name="max">max values to clamp against</param>
		/// <param name="result">a new vector consisting of each element of v clamped between min and max</param>
		public static void Clamp(ref Vector4 v, ref Vector4 min, ref Vector4 max, out Vector4 result)
		{
			v.Clamp(ref min, ref max, out result);
		}

		/// <summary>static function equivalent to Clamp(float, float)</summary>
		/// <param name="v">vector</param>
		/// <param name="min">min value to clamp against</param>
		/// <param name="max">max value to clamp against</param>
		/// <returns>a new vector consisting of each element of v clamped between min and max</returns>
		public static Vector4 Clamp(Vector4 v, float min, float max)
		{
			Vector4 result;
			v.Clamp(min, max, out result);
			return result;
		}

		/// <summary>static function equivalent to Clamp(float, float, out Vector4)</summary>
		/// <param name="v">vector</param>
		/// <param name="min">min value to clamp against</param>
		/// <param name="max">max value to clamp against</param>
		/// <param name="result">a new vector consisting of each element of v clamped between min and max</param>
		public static void Clamp(ref Vector4 v, float min, float max, out Vector4 result)
		{
			v.Clamp(min, max, out result);
		}

		/// <summary>static function equivalent to Repeat(Vector4, Vector4)</summary>
		/// <param name="v">vector</param>
		/// <param name="min">min values to repeat over</param>
		/// <param name="max">max values to repeat over</param>
		/// <returns>a new vector consisting of each element of v repeated between min and max</returns>
		public static Vector4 Repeat(Vector4 v, Vector4 min, Vector4 max)
		{
			Vector4 result;
			v.Repeat(ref min, ref max, out result);
			return result;
		}

		/// <summary>static function equivalent to Repeat(ref Vector4, ref Vector4, out Vector4)</summary>
		/// <param name="v">vector</param>
		/// <param name="min">min values to repeat over</param>
		/// <param name="max">max values to repeat over</param>
		/// <param name="result">a new vector consisting of each element of v repeated between min and max</param>
		public static void Repeat(ref Vector4 v, ref Vector4 min, ref Vector4 max, out Vector4 result)
		{
			v.Repeat(ref min, ref max, out result);
		}

		/// <summary>static function equivalent to Repeat(float, float)</summary>
		/// <param name="v">vector</param>
		/// <param name="min">min value to repeat over</param>
		/// <param name="max">max value to repeat over</param>
		/// <returns>a new vector consisting of each element of v repeated between min and max</returns>
		public static Vector4 Repeat(Vector4 v, float min, float max)
		{
			Vector4 result;
			v.Repeat(min, max, out result);
			return result;
		}

		/// <summary>static function equivalent to Repeat(float, float, out Vector4)</summary>
		/// <param name="v">vector</param>
		/// <param name="min">min value to repeat over</param>
		/// <param name="max">max value to repeat over</param>
		/// <param name="result">a new vector consisting of each element of v repeated between min and max</param>
		public static void Repeat(ref Vector4 v, float min, float max, out Vector4 result)
		{
			v.Repeat(min, max, out result);
		}

		/// <summary>static function equivalent to Lerp(Vector4, float)</summary>
		/// <param name="v1">vector 1</param>
		/// <param name="v2">vector 2</param>
		/// <param name="f">lerp amount</param>
		/// <returns>a Vector4 where each element is the result of lerping f between the corresponding elements of v1 and v2</returns>
		public static Vector4 Lerp(Vector4 v1, Vector4 v2, float f)
		{
			Vector4 result;
			v1.Lerp(ref v2, f, out result);
			return result;
		}

		/// <summary>static function equivalent to Lerp(ref Vector4, float, out Vector4)</summary>
		/// <param name="v1">vector 1</param>
		/// <param name="v2">vector 2</param>
		/// <param name="f">lerp amount</param>
		/// <param name="result">a Vector4 where each element is the result of lerping f between the corresponding elements of v1 and v2</param>
		public static void Lerp(ref Vector4 v1, ref Vector4 v2, float f, out Vector4 result)
		{
			v1.Lerp(ref v2, f, out result);
		}

		/// <summary>static function equivalent to MoveTo(Vector4, float)</summary>
		/// <param name="v1">vector 1</param>
		/// <param name="v2">vector 2</param>
		/// <param name="length">step length</param>
		/// <returns>a new vector moved to target vector by specified length</returns>
		public static Vector4 MoveTo(Vector4 v1, Vector4 v2, float length)
		{
			Vector4 result;
			v1.MoveTo(ref v2, length, out result);
			return result;
		}

		/// <summary>static function equivalent to MoveTo(ref Vector4, float, out Vector4)</summary>
		/// <param name="v1">vector 1</param>
		/// <param name="v2">vector 2</param>
		/// <param name="length">step length</param>
		/// <param name="result">a new vector moved to target vector by specified length</param>
		public static void MoveTo(ref Vector4 v1, ref Vector4 v2, float length, out Vector4 result)
		{
			v1.MoveTo(ref v2, length, out result);
		}

		/// <summary>static function equivalent to Add(Vector4)</summary>
		/// <param name="v1">vector 1</param>
		/// <param name="v2">vector 2</param>
		/// <returns>v1 + v2</returns>
		public static Vector4 Add(Vector4 v1, Vector4 v2)
		{
			Vector4 result;
			v1.Add(ref v2, out result);
			return result;
		}

		/// <summary>static function equivalent to Add(ref Vector4, out Vector4)</summary>
		/// <param name="v1">vector 1</param>
		/// <param name="v2">vector 2</param>
		/// <param name="result">v1 + v2</param>
		public static void Add(ref Vector4 v1, ref Vector4 v2, out Vector4 result)
		{
			v1.Add(ref v2, out result);
		}

		/// <summary>static function equivalent to Subtract(Vector4)</summary>
		/// <param name="v1">vector 1</param>
		/// <param name="v2">vector 2</param>
		/// <returns>v1 - v2</returns>
		public static Vector4 Subtract(Vector4 v1, Vector4 v2)
		{
			Vector4 result;
			v1.Subtract(ref v2, out result);
			return result;
		}

		/// <summary>static function equivalent to Subtract(ref Vector4, out Vector4)</summary>
		/// <param name="v1">vector 1</param>
		/// <param name="v2">vector 2</param>
		/// <param name="result">v1 - v2</param>
		public static void Subtract(ref Vector4 v1, ref Vector4 v2, out Vector4 result)
		{
			v1.Subtract(ref v2, out result);
		}

		/// <summary>static function equivalent to Multiply(Vector4)</summary>
		/// <param name="v1">vector 1</param>
		/// <param name="v2">vector 2</param>
		/// <returns>v1 * v2</returns>
		public static Vector4 Multiply(Vector4 v1, Vector4 v2)
		{
			Vector4 result;
			v1.Multiply(ref v2, out result);
			return result;
		}

		/// <summary>static function equivalent to Multiply(ref Vector4, out Vector4)</summary>
		/// <param name="v1">vector 1</param>
		/// <param name="v2">vector 2</param>
		/// <param name="result">v1 * v2</param>
		public static void Multiply(ref Vector4 v1, ref Vector4 v2, out Vector4 result)
		{
			v1.Multiply(ref v2, out result);
		}

		/// <summary>static function equivalent to Multiply(float)</summary>
		/// <param name="v">vector</param>
		/// <param name="f">scalar</param>
		/// <returns>v * f</returns>
		public static Vector4 Multiply(Vector4 v, float f)
		{
			Vector4 result;
			v.Multiply(f, out result);
			return result;
		}

		/// <summary>static function equivalent to Multiply(float, out Vector4)</summary>
		/// <param name="v">vector</param>
		/// <param name="f">scalar</param>
		/// <param name="result">v * f</param>
		public static void Multiply(ref Vector4 v, float f, out Vector4 result)
		{
			v.Multiply(f, out result);
		}

		/// <summary>static function equivalent to Divide(Vector4)</summary>
		/// <param name="v1">vector 1</param>
		/// <param name="v2">vector 2</param>
		/// <returns>v1 / v2</returns>
		public static Vector4 Divide(Vector4 v1, Vector4 v2)
		{
			Vector4 result;
			v1.Divide(ref v2, out result);
			return result;
		}

		/// <summary>static function equivalent to Divide(ref Vector4, out Vector4)</summary>
		/// <param name="v1">vector 1</param>
		/// <param name="v2">vector 2</param>
		/// <param name="result">v1 / v2</param>
		public static void Divide(ref Vector4 v1, ref Vector4 v2, out Vector4 result)
		{
			v1.Divide(ref v2, out result);
		}

		/// <summary>static function equivalent to Divide(float)</summary>
		/// <param name="v">vector</param>
		/// <param name="f">scalar</param>
		/// <returns>v / f</returns>
		public static Vector4 Divide(Vector4 v, float f)
		{
			Vector4 result;
			v.Divide(f, out result);
			return result;
		}

		/// <summary>static function equivalent to Divide(float, out Vector4)</summary>
		/// <param name="v">vector</param>
		/// <param name="f">scalar</param>
		/// <param name="result">v / f</param>
		public static void Divide(ref Vector4 v, float f, out Vector4 result)
		{
			v.Divide(f, out result);
		}

		/// <summary>static function equivalent to Negate()</summary>
		/// <param name="v">vector</param>
		/// <returns>-v</returns>
		public static Vector4 Negate(Vector4 v)
		{
			Vector4 result;
			v.Negate(out result);
			return result;
		}

		/// <summary>static function equivalent to Negate(out Vector4)</summary>
		/// <param name="v">vector</param>
		/// <param name="result">-v</param>
		public static void Negate(ref Vector4 v, out Vector4 result)
		{
			v.Negate(out result);
		}

		/// <summary>equality operator</summary>
		/// <param name="v1">vector 1</param>
		/// <param name="v2">vector 2</param>
		/// <returns>true if vector 1 == vector 2, false otherwise</returns>
		public static bool operator ==(Vector4 v1, Vector4 v2)
		{
			return v1.X == v2.X && v1.Y == v2.Y && v1.Z == v2.Z && v1.W == v2.W;
		}

		/// <summary>not equals operator</summary>
		/// <param name="v1">vector 1</param>
		/// <param name="v2">vector 2</param>
		/// <returns>true if vector 1 != vector 2, false otherwise</returns>
		public static bool operator !=(Vector4 v1, Vector4 v2)
		{
			return v1.X != v2.X || v1.Y != v2.Y || v1.Z != v2.Z || v1.W != v2.W;
		}

		/// <summary>vector addition operator</summary>
		/// <param name="v1">vector 1</param>
		/// <param name="v2">vector 2</param>
		/// <returns>vector 1 + vector 2</returns>
		public static Vector4 operator +(Vector4 v1, Vector4 v2)
		{
			Vector4 result;
			v1.Add(ref v2, out result);
			return result;
		}

		/// <summary>adds a scalar float to each element of a vector</summary>
		/// <param name="v">the vector to add</param>
		/// <param name="f">the scalar float to add each element of the vector</param>
		/// <returns>a new vector with f added to each element of v</returns>
		public static Vector4 operator +(Vector4 v, float f)
		{
			return new Vector4(v.X + f, v.Y + f, v.Z + f, v.W + f);
		}

		/// <summary>adds a scalar float to each element of a vector</summary>
		/// <param name="f">the scalar float to add each element of the vector</param>
		/// <param name="v">the vector to add</param>
		/// <returns>a new vector with f added to each element of v</returns>
		public static Vector4 operator +(float f, Vector4 v)
		{
			return new Vector4(f + v.X, f + v.Y, f + v.Z, f + v.W);
		}

		/// <summary>vector subtraction operator</summary>
		/// <param name="v1">vector 1</param>
		/// <param name="v2">vector 2</param>
		/// <returns>vector 1 - vector 2</returns>
		public static Vector4 operator -(Vector4 v1, Vector4 v2)
		{
			Vector4 result;
			v1.Subtract(ref v2, out result);
			return result;
		}

		/// <summary>subtract a scalar float from each element of a vector</summary>
		/// <param name="v">the vector to subtract from</param>
		/// <param name="f">the scalar float to subtract from each element of the vector</param>
		/// <returns>a new vector with f subtracted from each element of v</returns>
		public static Vector4 operator -(Vector4 v, float f)
		{
			return new Vector4(v.X - f, v.Y - f, v.Z - f, v.W - f);
		}

		/// <summary>creates a new vector consisting of {f, f, f, f}, and then subtracts v from it</summary>
		/// <param name="f">the scalar that we subtract v from</param>
		/// <param name="v">the vector to subtract</param>
		/// <returns>a new vector consisting of v subtracted from the vector {f, f, f, f}</returns>
		public static Vector4 operator -(float f, Vector4 v)
		{
			return new Vector4(f - v.X, f - v.Y, f - v.Z, f - v.W);
		}

		/// <summary>unary minus operator</summary>
		/// <param name="v">vector to negate</param>
		/// <returns>unary minus applied to each member of v</returns>
		public static Vector4 operator -(Vector4 v)
		{
			Vector4 result;
			v.Negate(out result);
			return result;
		}

		/// <summary>multiplication operator</summary>
		/// <param name="v1">vector 1</param>
		/// <param name="v2">vector 2</param>
		/// <returns>vector 1 * vector 2</returns>
		public static Vector4 operator *(Vector4 v1, Vector4 v2)
		{
			Vector4 result;
			v1.Multiply(ref v2, out result);
			return result;
		}

		/// <summary>multiply each element of vector by scalar float</summary>
		/// <param name="v">the vector to multiply</param>
		/// <param name="f">the scalar to multiply each element of the vector by</param>
		/// <returns>a new vector consisting of each element of vector multiplied by f</returns>
		public static Vector4 operator *(Vector4 v, float f)
		{
			Vector4 result;
			v.Multiply(f, out result);
			return result;
		}

		/// <summary>multiply each element of vector by scalar float</summary>
		/// <param name="f">the scalar to multiply each element of the vector by</param>
		/// <param name="v">the vector to multiply</param>
		/// <returns>a new vector consisting of each element of vector multiplied by f</returns>
		public static Vector4 operator *(float f, Vector4 v)
		{
			Vector4 result;
			v.Multiply(f, out result);
			return result;
		}

		/// <summary>division operator</summary>
		/// <param name="v1">vector 1</param>
		/// <param name="v2">vector 2</param>
		/// <returns>vector 1 / vector 2</returns>
		public static Vector4 operator /(Vector4 v1, Vector4 v2)
		{
			Vector4 result;
			v1.Divide(ref v2, out result);
			return result;
		}

		/// <summary>divide each element of a vector by a scalar float</summary>
		/// <param name="v">the vector to divide by scalar</param>
		/// <param name="f">the scalar to divide by</param>
		/// <returns>a new Vector4 consisting of each element of v divided by f</returns>
		public static Vector4 operator /(Vector4 v, float f)
		{
			Vector4 result;
			v.Divide(f, out result);
			return result;
		}

		/// <summary>create a new vector consisting of {f, f, f, f} and divide it by vec</summary>
		/// <param name="f">the scalar to divide by vector</param>
		/// <param name="v">the vector to divide by</param>
		/// <returns>a new vector {f, f, f, f} divided by v</returns>
		public static Vector4 operator /(float f, Vector4 v)
		{
			return new Vector4(f / v.X, f / v.Y, f / v.Z, f / v.W);
		}

		/// <summary>X</summary>
		public float X;

		/// <summary>Y</summary>
		public float Y;

		/// <summary>Z</summary>
		public float Z;

		/// <summary>W</summary>
		public float W;

		/// <summary>return a new vector of all zeros</summary>
		/// <returns>a new vector of all zeros</returns>
		public static readonly Vector4 Zero = new Vector4(0f, 0f, 0f, 0f);

		/// <summary>return a new vector of all ones</summary>
		/// <returns>a new vector of all ones</returns>
		public static readonly Vector4 One = new Vector4(1f, 1f, 1f, 1f);

		/// <summary>return a new vector of all zeros with only the x value set to one</summary>
		/// <returns>a new vector of all zeros with only the x value set to one</returns>
		public static readonly Vector4 UnitX = new Vector4(1f, 0f, 0f, 0f);

		/// <summary>return a new vector of all zeros with only the y value set to one</summary>
		/// <returns>a new vector of all zeros with only the y value set to one</returns>
		public static readonly Vector4 UnitY = new Vector4(0f, 1f, 0f, 0f);

		/// <summary>return a new vector of all zeros with only the z value set to one</summary>
		/// <returns>a new vector of all zeros with only the z value set to one</returns>
		public static readonly Vector4 UnitZ = new Vector4(0f, 0f, 1f, 0f);

		/// <summary>return a new vector of all zeros with only the w value set to one</summary>
		/// <returns>a new vector of all zeros with only the w value set to one</returns>
		public static readonly Vector4 UnitW = new Vector4(0f, 0f, 0f, 1f);
	}
}
