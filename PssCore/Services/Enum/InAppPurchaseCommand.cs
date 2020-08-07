using System;

namespace Sce.PlayStation.Core.Services
{
	/// <summary>Operation command of In-App Purchase</summary>
	public enum InAppPurchaseCommand : uint
	{
		/// <summary>None</summary>
		None, /* 0 */
		/// <summary>Obtains product information from the server</summary>
		GetProductInfo, /* 1 */
		/// <summary>Obtains ticket information from the server</summary>
		GetTicketInfo, /* 2 */
		/// <summary>Purchases a product</summary>
		Purchase, /* 3 */
		/// <summary>Consumes a ticket</summary>
		Consume /* 4 */
	}
}
