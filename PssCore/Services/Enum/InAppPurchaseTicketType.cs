using System;

namespace Sce.PlayStation.Core.Services
{
	/// <summary>Ticket type of In-App Purchase</summary>
	public enum InAppPurchaseTicketType : uint
	{
		/// <summary>Normal type</summary>
		Normal, /* 0 */
		/// <summary>Consumption type</summary>
		Consumable /* 1 */
	}
}
