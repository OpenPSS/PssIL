using System;

namespace Sce.PlayStation.Core.Graphics
{
	/// <summary>Structure representing the polygon offset</summary>
	public struct PolygonOffset
	{
		/*
		 *	Global Variables
		 */
		
		/// <summary>Polygon offset scaling coefficient</summary>
		public float Factor;

		/// <summary>Polygon offset offset coefficient</summary>
		public float Units;
		
		/// <summary>Creates the structure representing the polygon offset</summary>
		/// <param name="factor">Polygon offset scaling coefficient</param>
		/// <param name="units">Polygon offset offset coefficient</param>
		public PolygonOffset(float factor, float units)
		{
			this.Factor = factor;
			this.Units = units;
		}

		/// <summary>Sets a value to the structure representing the polygon offset</summary>
		/// <param name="factor">Polygon offset scaling coefficient</param>
		/// <param name="units">Polygon offset offset coefficient</param>
		public void Set(float factor, float units)
		{
			this.Factor = factor;
			this.Units = units;
		}

	}
}
