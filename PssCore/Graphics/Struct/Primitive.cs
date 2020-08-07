using System;

namespace Sce.PlayStation.Core.Graphics
{
	/// <summary>Structure representing the primitive</summary>
	public struct Primitive
	{
		/*
		 *	Global Variables
		 */
		
		/// <summary>Primitive rendering mode</summary>
		public DrawMode Mode;

		/// <summary>Starting vertex of the primitive</summary>
		public ushort First;

		/// <summary>Number of vertices in the primitive</summary>
		public ushort Count;

		/// <summary>User data</summary>
		public ushort UserData;
		
		/// <summary>Creates the structure representing the primitive</summary>
		/// <param name="mode">Primitive rendering mode</param>
		/// <param name="first">Starting vertex of the primitive</param>
		/// <param name="count">Number of vertices in the primitive</param>
		/// <param name="userData">User data</param>
		public Primitive(DrawMode mode, int first, int count, int userData)
		{
			this.Mode = mode;
			this.First = (ushort)first;
			this.Count = (ushort)count;
			this.UserData = (ushort)userData;
		}

		/// <summary>Sets the structure representing the primitive</summary>
		/// <param name="mode">Primitive rendering mode</param>
		/// <param name="first">Starting vertex of the primitive</param>
		/// <param name="count">Number of vertices in the primitive</param>
		/// <param name="userData">User data</param>
		public void Set(DrawMode mode, int first, int count, int userData)
		{
			this.Mode = mode;
			this.First = (ushort)first;
			this.Count = (ushort)count;
			this.UserData = (ushort)userData;
		}

		
	}
}
