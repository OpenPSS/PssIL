using System;

namespace Sce.PlayStation.Core.Imaging
{
	/// <summary>Font style</summary>
	[Flags]
	public enum FontStyle : uint
	{
		/// <summary>Standard style</summary>
		Regular = 0U, /* 0 */
		/// <summary>Bold</summary>
		Bold = 1U, /* 1 */
		/// <summary>Italics</summary>
		Italic = 2U /* 2 */
	}
}
