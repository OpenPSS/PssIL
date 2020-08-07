using System;

namespace Sce.PlayStation.Core.Graphics
{
	/// <summary>Structure representing the stencil test operation</summary>
	public struct StencilOp
	{
		/*
		 *	Global Variables
		 */
		
		internal uint bits;
		
		/// <summary>Creates the structure representing the stencil test operation</summary>
		/// <param name="fail">Stencil failure mode of the stencil test operation</param>
		/// <param name="zFail">Depth failure mode of the stencil test operation</param>
		/// <param name="zPass">Depth passing mode of the stencil test operation</param>
		public StencilOp(StencilOpMode fail, StencilOpMode zFail, StencilOpMode zPass)
		{
			this.bits = (uint)((uint)fail | (uint)zFail << 8 | (uint)zPass << 16);
		}

		/// <summary>Sets a value to the structure representing the stencil test operation</summary>
		/// <param name="fail">Stencil failure mode of the stencil test operation</param>
		/// <param name="zFail">Depth failure mode of the stencil test operation</param>
		/// <param name="zPass">Depth passing mode of the stencil test operation</param>
		public void Set(StencilOpMode fail, StencilOpMode zFail, StencilOpMode zPass)
		{
			this.bits = (uint)((uint)fail | (uint)zFail << 8 | (uint)zPass << 16);
		}

		/// <summary>Stencil failure mode of the stencil test operation</summary>
		public StencilOpMode Fail
		{
			get
			{
				return (StencilOpMode)this.bits;
			}
			set
			{
				this.bits = ((this.bits & 0xFFFFFF00) | (uint)value);
			}
		}

		/// <summary>Depth failure mode of the stencil test operation</summary>
		public StencilOpMode ZFail
		{
			get
			{
				return (StencilOpMode)(this.bits >> 8);
			}
			set
			{
				this.bits = ((this.bits & 0xFFFF00FF) | (uint)((uint)value << 8));
			}
		}

		/// <summary>Depth passing mode of the stencil test operation</summary>
		public StencilOpMode ZPass
		{
			get
			{
				return (StencilOpMode)(this.bits >> 16);
			}
			set
			{
				this.bits = ((this.bits & 0xFF00FFFF) | (uint)((uint)value << 16));
			}
		}

	}
}
