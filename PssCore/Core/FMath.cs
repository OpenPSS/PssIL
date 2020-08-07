using System;

namespace Sce.PlayStation.Core
{
	/// <summary>math wrapper and convenience functions</summary>
	public static class FMath
	{
		/*
		 *	Math Constants
		 */
		
		/// <summary>E</summary>
		public const float E = 2.71828175f;
		/// <summary>PI</summary>
		public const float PI = 3.14159274f;

		/// <summary>conversion ratio from degrees to radians</summary>
		public const float DegToRad = 0.0174532924f;

		/// <summary>conversion ratio from radians to degrees</summary>1
		public const float RadToDeg = 57.29578f;	
			
		/// <summary>convert from degrees to radians</summary>
		/// <param name="x">the value to convert</param>
		/// <returns>value converted from degrees to radians</returns>
		public static float Radians(float x)
		{
			return x * 0.0174532924f;
		}


		/*
		 * 	Wrapper for Math class
		 */	
		/// <summary>equivalent to (float)Math.Sin(x)</summary>
		/// <param name="x">the value to take the sin of</param>
		/// <returns>the sin of x</returns>
		public static float Sin(float x)
		{
			return (float)Math.Sin((double)x);
		}

		/// <summary>equivalent to (float)Math.Cos(x)</summary>
		/// <param name="x">the value to take the cos of</param>
		/// <returns>the cos of x</returns>
		public static float Cos(float x)
		{
			return (float)Math.Cos((double)x);
		}

		/// <summary>equivalent to (float)Math.Tan(x)</summary>
		/// <param name="x">the value to take the tan of</param>
		/// <returns>the tan of x</returns>
		public static float Tan(float x)
		{
			return (float)Math.Tan((double)x);
		}

		/// <summary>equivalent to (float)Math.Asin(x)</summary>
		/// <param name="x">the value to take the asin of</param>
		/// <returns>the asin of x</returns>
		public static float Asin(float x)
		{
			return (float)Math.Asin((double)x);
		}

		/// <summary>equivalent to (float)Math.Acos(x)</summary>
		/// <param name="x">the value to take the acos of</param>
		/// <returns>the acos of x</returns>
		public static float Acos(float x)
		{
			return (float)Math.Acos((double)x);
		}

		/// <summary>equivalent to (float)Math.Atan(x)</summary>
		/// <param name="x">the value to take the atan of</param>
		/// <returns>the atan of x</returns>
		public static float Atan(float x)
		{
			return (float)Math.Atan((double)x);
		}

		/// <summary>equivalent to (float)Math.Atan2(x,y)</summary>
		/// <param name="x">the x coordinate to take the atan2 of</param>
		/// <param name="y">the y coordinate to take the atan2 of</param>
		/// <returns>the atan2 of (x,y)</returns>
		public static float Atan2(float x, float y)
		{
			return (float)Math.Atan2((double)x, (double)y);
		}

		/// <summary>equivalent to (float)Math.Sqrt(x)</summary>
		/// <param name="x">the value to take the square root of</param>
		/// <returns>the square root of x</returns>
		public static float Sqrt(float x)
		{
			return (float)Math.Sqrt((double)x);
		}

		/// <summary>equivalent to (float)Math.Pow(x,y)</summary>
		/// <param name="x">the value to raise</param>
		/// <param name="y">the power to raise to</param>
		/// <returns>x to y power</returns>
		public static float Pow(float x, float y)
		{
			return (float)Math.Pow((double)x, (double)y);
		}

		/// <summary>equivalent to (float)Math.Exp(x)</summary>
		/// <param name="x">the value to take the exp of</param>
		/// <returns>the exp of x</returns>
		public static float Exp(float x)
		{
			return (float)Math.Exp((double)x);
		}

		/// <summary>equivalent to (float)Math.Log(x)</summary>
		/// <param name="x">the value to take the log of</param>
		/// <returns>the log of x</returns>
		public static float Log(float x)
		{
			return (float)Math.Log((double)x);
		}

		/// <summary>equivalent to (float)Math.Log10(x)</summary>
		/// <param name="x">the value to take the log 10 of</param>
		/// <returns>the log 10 of x</returns>
		public static float Log10(float x)
		{
			return (float)Math.Log10((double)x);
		}

		/// <summary>equivalent to Math.Abs(x)</summary>
		/// <param name="x">the value to take the absolute value of</param>
		/// <returns>the absolute value of x</returns>
 
		public static float Abs(float x)
		{
			return Math.Abs(x);
		}

		/// <summary>equivalent to Math.Sign(x)</summary>
		/// <param name="x">the value to take the sign of</param>
		/// <returns>the sign of x</returns>
		public static int Sign(float x)
		{
			return Math.Sign(x);
		}

		/// <summary>equivalent to Math.Min(x,y)</summary>
		/// <param name="x">first input to min</param>
		/// <param name="y">second input to min</param>
		/// <returns>the min of x and y</returns>
		public static float Min(float x, float y)
		{
			return Math.Min(x, y);
		}

		/// <summary>equivalent to Math.Max(x,y)</summary>
		/// <param name="x">first input to max</param>
		/// <param name="y">second input to max</param>
		/// <returns>the max of x and y</returns>
		public static float Max(float x, float y)
		{
			return Math.Max(x, y);
		}

		/// <summary>equivalent to (float)Math.Floor(x)</summary>
		/// <param name="x">the value to take the floor of</param>
		/// <returns>the floor of x</returns>
		public static float Floor(float x)
		{
			return (float)Math.Floor((double)x);
		}

		/// <summary>equivalent to (float)Math.Ceiling(x)</summary>
		/// <param name="x">the value to take the ceil of</param>
		/// <returns>the ceil of x</returns>
		public static float Ceiling(float x)
		{
			return (float)Math.Ceiling((double)x);
		}

		/// <summary>equivalent to (float)Math.Round(x)</summary>
		/// <param name="x">the value to take the round of</param>
		/// <returns>the round of x</returns>
 
		public static float Round(float x)
		{
			return (float)Math.Round((double)x);
		}

		/// <summary>equivalent to (float)Math.Truncate(x)</summary>
		/// <param name="x">the value to take the trunc of</param>
		/// <returns>the trunc of x</returns>
		public static float Truncate(float x)
		{
			return (float)Math.Truncate((double)x);
		}
		
		/*
		*  Fmath specific functions.
		*/	
		
		/// <summary>clamp between two values</summary>
		/// <param name="x">the value to clamp</param>
		/// <param name="min">the min to clamp against</param>
		/// <param name="max">the max to clamp against</param>
		/// <returns>x clamped between min and max</returns>
		public static float Clamp(float x, float min, float max)
		{
			return (x <= min) ? min : ((x >= max) ? max : x);
		}

		/// <summary>repeat between two values</summary>
		/// <param name="x">the value to repeat</param>
		/// <param name="min">the min to repeat over</param>
		/// <param name="max">the max to repeat over</param>
		/// <returns>x repeated between min and max</returns>
		public static float Repeat(float x, float min, float max)
		{
			float num = max - min;
			float num2 = (num == 0f) ? 0f : ((x - min) % num);
			return min + ((num2 >= 0f) ? num2 : (num2 + num));
		}

		/// <summary>repeat shuttlewise between two values</summary>
		/// <param name="x">the value to repeat</param>
		/// <param name="min">the min to repeat over</param>
		/// <param name="max">the max to repeat over</param>
		/// <returns>x repeated shuttlewise between min and max</returns>
		public static float Mirror(float x, float min, float max)
		{
			float num = max - min;
			float num2 = (num == 0f) ? 0f : ((x - min) % (num + num));
			if (num2 < 0f)
			{
				num2 = -num2;
			}
			return min + ((num2 < num) ? num2 : (num + num - num2));
		}
		
		/// <summary>lerp between two values</summary>
		/// <param name="x1">value 1</param>
		/// <param name="x2">value 2</param>
		/// <param name="f">lerp amount</param>
		/// <returns>the result of lerping f between x1 and x2</returns>
		public static float Lerp(float x1, float x2, float f)
		{
			return (x2 - x1) * f + x1;
		}
		
		/// <summary>convert from radians to degrees</summary>
		/// <param name="x">the value to convert</param>
		/// <returns>value converted from radians to degrees</returns>
		public static float Degrees(float x)
		{
			return x * 57.29578f;
		}
		
		
		/// <summary>move one value to another value by specified amount</summary>
		/// <param name="x1">value 1</param>
		/// <param name="x2">value 2</param>
		/// <param name="amount">step amount</param>
		/// <returns>value moved to another value by specified amount</returns>
		public static float MoveTo(float x1, float x2, float amount)
		{
			return (x2 > x1) ? ((x1 + amount < x2) ? (x1 + amount) : x2) : ((x1 - amount > x2) ? (x1 - amount) : x2);
		}

		public static float Step(float edge, float x)
		{
			return (x < edge) ? 0f : 1f;
		}
		
		public static float LinearStep(float min, float max, float x)
		{
			return (x <= min) ? 0f : ((x >= max) ? 1f : ((x - min) / (max - min)));
		}
		
		public static float SmoothStep(float min, float max, float x)
		{
			float num = FMath.LinearStep(min, max, x);
			return num * num * (3f - num - num);
		}
		
		/*
		*	Obsolete function handling. 
		*/
		[Obsolete("Use Repeat()")]
		public static float Wrap(float x, float min, float max)
		{
			return FMath.Repeat(x, min, max);
		}

	}
}

