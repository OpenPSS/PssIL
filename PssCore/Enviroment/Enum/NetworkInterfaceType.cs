using System;

namespace Sce.PlayStation.Core.Environment
{
	/// <summary>Network interface type.</summary>
	public enum NetworkInterfaceType : uint
	{
		/// <summary>wired ethernet.</summary>
		Ethernet,
		/// <summary>wireless 80211 band.</summary>
		Wireless80211,
		/// <summary>mobile data</summary>
		MobileBroadband
	}
}
