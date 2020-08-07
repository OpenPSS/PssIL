using System;

namespace Sce.PlayStation.Core.Services
{
	/// <summary>Class representing a product that can be purchased with In-App Purchase.</summary>
	public class InAppPurchaseProduct
	{
		/*
		 *	Global Variables
		 */
		internal InAppPurchaseProductData data;
		
		/// <summary>Product label</summary>
		public string Label
		{
			get
			{
				return this.data.Label;
			}
		}

		/// <summary>Product name</summary>
		public string Name
		{
			get
			{
				return this.data.Name;
			}
		}

		/// <summary>Product price (Obtained with GetProductInfo)</summary>
		public string Price
		{
			get
			{
				return this.data.Price;
			}
		}

		/// <summary>Ticket type</summary>
		public InAppPurchaseTicketType TicketType
		{
			get
			{
				return (InAppPurchaseTicketType)this.data.TicketType;
			}
		}

		/// <summary>Whether a ticket is valid (Obtained with GetTicketInfo)</summary>
		public bool IsTicketValid
		{
			get
			{
				return this.data.TicketIsOK;
			}
		}

		/// <summary>Remaining number of times a ticket can be consumed (Obtained with GetTicketInfo)</summary>
		public int ConsumableTicketCount
		{
			get
			{
				return this.data.TicketRemainingCount;
			}
		}
	}
}
