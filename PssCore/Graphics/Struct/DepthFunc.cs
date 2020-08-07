using System;

namespace Sce.PlayStation.Core.Graphics
{
	/// <summary>Structure representing the depth test function</summary>
	public struct DepthFunc
	{
		/*
		 *	Global Variables
		 */
		internal uint bits;
		
		/// <summary>Creates the structure representing the depth test function</summary>
		/// <param name="mode">Depth test function mode</param>
		/// <param name="writeMask">Depth test function write mask</param>
		public DepthFunc(DepthFuncMode mode, bool writeMask)
		{
			this.bits = (uint)((uint)mode | ((!writeMask) ? 0x00 : 0xFF));
		}

		/// <summary>Sets a value to the structure representing the depth test function</summary>
		/// <param name="mode">Depth test function mode</param>
		/// <param name="writeMask">Depth test function write mask</param>
		public void Set(DepthFuncMode mode, bool writeMask)
		{
			this.bits = (uint)((uint)mode | ((!writeMask) ? 0x00 : 0xFF));
		}

		/// <summary>Depth test function mode</summary>
		public DepthFuncMode Mode
		{
			get
			{
				return (DepthFuncMode)this.bits;
			}
			set
			{
				this.bits = ((this.bits & 0xFFFFFF00) | (uint)value);
			}
		}

		/// <summary>Depth test function write mask</summary>
		public bool WriteMask
		{
			get
			{
				return (this.bits & 0) != 0U;
			}
			set
			{
				this.bits = ((this.bits & 0xFFFF00FF) | ((!value) ? 0U : 0xFF));
			}
		}

		
	}
}
