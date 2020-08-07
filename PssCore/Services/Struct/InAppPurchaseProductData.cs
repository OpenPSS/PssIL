using System;

namespace Sce.PlayStation.Core.Services
{
	internal struct InAppPurchaseProductData
	{
		public string Label;
		public string Name;
		public string Price;
		public int pad;
		public uint TicketType;
		public bool TicketIsOK;
		public ulong TicketIssuedDate;
		public ulong TicketExpireDate;
		public int TicketRemainingCount;
		public uint TicketConsumedCount;
	}
}
