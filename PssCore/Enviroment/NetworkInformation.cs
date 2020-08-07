using System;
using System.Runtime.CompilerServices;
using System.Security;

namespace Sce.PlayStation.Core.Environment
{
	/// <summary>Handles network information</summary>
	public static class NetworkInformation
	{
		/*
		 *  Implemented by PSM Runtime.
		 */
		[SecurityCritical]
		[MethodImpl(4096)]
		private static extern int GetNetworkInterfaceTypeNative();
		
		/*
		 *	IL Code
		 */
		
		/// <summary>Gets the network interface type</summary>
		/// <returns>the interface type being used right now.</returns>
		[SecuritySafeCritical]
		public static NetworkInterfaceType GetNetworkInterfaceType()
		{
			return (NetworkInterfaceType)NetworkInformation.GetNetworkInterfaceTypeNative();
		}
	}
}
