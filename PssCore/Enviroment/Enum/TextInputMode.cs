using System;

namespace Sce.PlayStation.Core.Environment
{
	/// <summary>Text input operational mode</summary>
	public enum TextInputMode : uint
	{
		/// <summary>Standard character input mode</summary>
		Normal, /* 0 */
		/// <summary>ASCII-only input mode</summary>
		BasicLatin, /* 1 */
		/// <summary>Password input mode</summary>
		Password /* 2 */
	}
}
