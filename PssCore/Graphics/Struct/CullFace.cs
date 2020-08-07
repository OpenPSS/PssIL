using System;

namespace Sce.PlayStation.Core.Graphics
{
	/// <summary>Structure representing back-face culling</summary>
	public struct CullFace
	{
		/*
		 *	Global Variables
		 */
		internal uint bits;
		
		/// <summary>Creates the structure representing back-face culling</summary>
		/// <param name="mode">Back-face culling mode</param>
		/// <param name="direction">Front direction for back-face culling</param>
		public CullFace(CullFaceMode mode, CullFaceDirection direction)
		{
			this.bits = (uint)(mode | (CullFaceMode)((uint)direction << 8));
		}

		/// <summary>Sets the structure representing back-face culling</summary>
		/// <param name="mode">Back-face culling mode</param>
		/// <param name="direction">Front direction for back-face culling</param>
		public void Set(CullFaceMode mode, CullFaceDirection direction)
		{
			this.bits = (uint)(mode | (CullFaceMode)((uint)direction << 8));
		}

		/// <summary>Back-face culling mode</summary>
		public CullFaceMode Mode
		{
			get
			{
				return (CullFaceMode)this.bits;
			}
			set
			{
				this.bits = ((this.bits & 0xFFFFFF00) | (uint)value);
			}
		}

		/// <summary>Front direction for back-face culling</summary>
		public CullFaceDirection Direction
		{
			get
			{
				return (CullFaceDirection)(this.bits >> 8);
			}
			set
			{
				this.bits = ((this.bits & 0xFFFF00FF) | (uint)((uint)value << 8));
			}
		}

	}
}
