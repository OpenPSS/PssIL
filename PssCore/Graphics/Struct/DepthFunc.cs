namespace Sce.PlayStation.Core.Graphics
{
	/// <summary>Structure representing the depth test function</summary>
	public struct DepthFunc
	{
		/*
		 *	Global Variables
		 */
		internal uint bits;
		
		/// <summary>Depth test function mode</summary>
		public DepthFuncMode Mode
		{
			get
			{
				return (DepthFuncMode)bits;
			}
			set
			{
				this.bits = ((uint)((int)bits & -256) | (uint)value);
			}
		}
		
		/// <summary>Depth test function write mask</summary>
		public bool WriteMask
		{
			get
			{
				return (bits & 0x100) != 0;
			}
			set
			{
				this.bits = (uint)(((int)bits & -65281) | (value ? 256 : 0));
			}
		}
		/// <summary>Creates the structure representing the depth test function</summary>
		/// <param name="mode">Depth test function mode</param>
		/// <param name="writeMask">Depth test function write mask</param>
		public DepthFunc(DepthFuncMode mode, bool writeMask)
		{
			this.bits = ((uint)mode | (uint)(writeMask ? 256 : 0));
		}
		
		/// <summary>Sets a value to the structure representing the depth test function</summary>
		/// <param name="mode">Depth test function mode</param>
		/// <param name="writeMask">Depth test function write mask</param>
		public void Set(DepthFuncMode mode, bool writeMask)
		{
			bits = ((uint)mode | (uint)(writeMask ? 256 : 0));
		}
	}
}
