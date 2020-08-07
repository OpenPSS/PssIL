using System;

namespace Sce.PlayStation.Core.Graphics
{
	/// <summary>Structure representing the alpha-blending function</summary>
	public struct BlendFunc
	{
		/*
		 *	Global Variables
		 */
		
		internal uint bits;
		
		/// <summary>Creates the structure representing the alpha-blending function</summary>
		/// <param name="mode">Alpha-blending function mode</param>
		/// <param name="srcFactor">Alpha-blending function source coefficient</param>
		/// <param name="dstFactor">Alpha-blending function destination coefficient</param>
		public BlendFunc(BlendFuncMode mode, BlendFuncFactor srcFactor, BlendFuncFactor dstFactor)
		{
			this.bits = (uint)(mode | (BlendFuncMode)((uint)srcFactor << 8) | (BlendFuncMode)((uint)dstFactor << 16));
		}

		/// <summary>Sets a value to the the structure representing the alpha-blending function</summary>
		/// <param name="mode">Alpha-blending function mode</param>
		/// <param name="srcFactor">Alpha-blending function source coefficient</param>
		/// <param name="dstFactor">Alpha-blending function destination coefficient</param>
		public void Set(BlendFuncMode mode, BlendFuncFactor srcFactor, BlendFuncFactor dstFactor)
		{
			this.bits = (uint)(mode | (BlendFuncMode)((uint)srcFactor << 8) | (BlendFuncMode)((uint)dstFactor << 16));
		}

		/// <summary>Alpha-blending function mode</summary>
		public BlendFuncMode Mode
		{
			get
			{
				return (BlendFuncMode)this.bits;
			}
			set
			{
				this.bits = ((this.bits & 0xFFFFFF00) | (uint)value);
			}
		}

		/// <summary>Alpha-blending function source coefficient</summary>
		public BlendFuncFactor SrcFactor
		{
			get
			{
				return (BlendFuncFactor)(this.bits >> 8);
			}
			set
			{
				this.bits = ((this.bits & 0xFFFF00FF) | (uint)((uint)value << 8));
			}
		}

		/// <summary>Alpha-blending function destination coefficient</summary>
		public BlendFuncFactor DstFactor
		{
			get
			{
				return (BlendFuncFactor)(this.bits >> 16);
			}
			set
			{
				this.bits = ((this.bits & 0xFF00FFFF) | (uint)((uint)value << 16));
			}
		}
		

	}
}
