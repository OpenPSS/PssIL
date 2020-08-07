using System;

namespace Sce.PlayStation.Core.Graphics
{
	/// <summary>Structure representing the stencil test function</summary>
	public struct StencilFunc
	{
		/*
		 *	Global Variables
		 */
		
		internal uint bits;
		
		/// <summary>Creates the structure representing the stencil test function</summary>
		/// <param name="mode">Stencil test function mode</param>
		/// <param name="reference">Reference value (0-255) of the stencil test function</param>
		/// <param name="readMask">Read mask (0-255) of the stencil test function</param>
		/// <param name="writeMask">Write mask (0-255) of the stencil test function</param>
		public StencilFunc(StencilFuncMode mode, int reference, int readMask, int writeMask)
		{
			this.bits = (uint)((int)mode | (int)((byte)reference) << 8 | (int)((byte)readMask) << 16 | (int)((byte)writeMask) << 24);
		}

		/// <summary>Sets a value to the structure representing the stencil test function</summary>
		/// <param name="mode">Stencil test function mode</param>
		/// <param name="reference">Reference value (0-255) of the stencil test function</param>
		/// <param name="readMask">Read mask (0-255) of the stencil test function</param>
		/// <param name="writeMask">Write mask (0-255) of the stencil test function</param>
		public void Set(StencilFuncMode mode, int reference, int readMask, int writeMask)
		{
			this.bits = (uint)((int)mode | (int)((byte)reference) << 8 | (int)((byte)readMask) << 16 | (int)((byte)writeMask) << 24);
		}

		/// <summary>Stencil test function mode</summary>
		public StencilFuncMode Mode
		{
			get
			{
				return (StencilFuncMode)this.bits;
			}
			set
			{
				this.bits = ((this.bits & 0xFFFFFF00) | (uint)value);
			}
		}

		/// <summary>Reference value (0-255) of the stencil test function</summary>
		public int Reference
		{
			get
			{
				return (int)((byte)(this.bits >> 8));
			}
			set
			{
				this.bits = ((this.bits & 0xFFFF00FF) | (uint)((uint)((byte)value) << 8));
			}
		}

		/// <summary>Read mask (0-255) of the stencil test function</summary>
		public int ReadMask
		{
			get
			{
				return (int)((byte)(this.bits >> 16));
			}
			set
			{
				this.bits = ((this.bits & 0xFF00FFFF) | (uint)((uint)((byte)value) << 16));
			}
		}

		/// <summary>Write mask (0-255) of the stencil test function</summary>
		public int WriteMask
		{
			get
			{
				return (int)((byte)(this.bits >> 24));
			}
			set
			{
				this.bits = ((this.bits & 0x00FFFFFF) | (uint)((uint)((byte)value) << 24));
			}
		}

	}
}
