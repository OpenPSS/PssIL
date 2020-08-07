using System;

namespace Sce.PlayStation.Core.Services
{
	/// <summary>Network state</summary>
	public enum NetworkState : uint
	{
		/// <summary>no connection (PSN)</summary>
		NotConnected, /* 0 */
		/// <summary>signed out (PSN)</summary>
		SignedOut, /* 1 */
		/// <summary>signed in (PSN)</summary>
		SignedIn, /* 2 */
		/// <summary>online (PSN)</summary>
		Online, /* 3 */
		/// <summary>ticket requested (PSN)</summary>
		AuthRequested, /* 4 */
		/// <summary>ticket received (PSN)</summary>
		AuthRequestReady, /* 5 */
		/// <summary>authorization failed (PSN)</summary>
		AuthRequestFailed, /* 6 */
		/// <summary>needs to connect (Network Services server)</summary>
		NetworkServerIdle, /* 7 */
		/// <summary>request has been sent (Network Services server)</summary>
		NetworkServerRequested, /* 8 */
		/// <summary>ready to make requests (Network Services server)</summary>
		NetworkServerReady, /* 9 */
		/// <summary>authorization failed (Network Services server)</summary>
		NetworkServerFailed /* 10 */
	}
}
