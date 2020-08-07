using System;

namespace Sce.PlayStation.Core.Environment
{
	/// <summary>handles memory usage.</summary>
	internal struct MemoryUsage
	{
		/// <summary>total memory.</summary>
		public long total;
		
		/// <summary>total memory free.</summary>
		public long free;
		
		/// <summary>total memory used.</summary>
		public long used;
		
		/// <summary>additional details</summary>
		public string details;
	}
}
