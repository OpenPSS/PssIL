using System;

namespace Sce.PlayStation.Core.Graphics
{
	/// <summary>Stencil test function mode</summary>
	public enum StencilFuncMode : byte
	{
		/// <summary>Always pass</summary>
		Always,
		/// <summary>Always fail</summary>
		Never,
		/// <summary>Pass if the reference value == stencil buffer value</summary>
		Equal,
		/// <summary>Pass if the reference value != stencil buffer value</summary>
		NotEqual,
		Less,
		/// <summary>Pass if reference value &gt; stencil buffer value</summary>
		Greater,
		LEqual,
		/// <summary>Pass if reference value &gt;= stencil buffer value</summary>
		GEqual,
		[Obsolete("Use NotEqual")]
		NotEequal = 3
	}
}
