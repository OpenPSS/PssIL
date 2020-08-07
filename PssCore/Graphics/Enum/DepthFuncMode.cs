using System;

namespace Sce.PlayStation.Core.Graphics
{
	/// <summary>Depth test function mode</summary>
	public enum DepthFuncMode : byte
	{
		/// <summary>Always pass</summary>
		Always,
		/// <summary>Always fail</summary>
		Never,
		/// <summary>Pass if depth value == depth buffer value</summary>
		Equal,
		/// <summary>Pass if depth value != depth buffer value</summary>
		NotEqual,
		Less,
		/// <summary>Pass if depth value &gt; depth buffer value</summary>
		Greater,
		LEqual,
		/// <summary>Pass if depth value &gt;= depth buffer value</summary>
		GEqual,
		[Obsolete("Use NotEqual")]
		NotEequal = 3
	}
}
