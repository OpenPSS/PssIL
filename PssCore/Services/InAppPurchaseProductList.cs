using System;
using System.Collections;
using System.Collections.Generic;

namespace Sce.PlayStation.Core.Services
{
	/// <summary>Class representing a list of products that can be purchased with In-App Purchase.</summary>
	public class InAppPurchaseProductList : IEnumerable<InAppPurchaseProduct>, IEnumerable
	{
		
		internal InAppPurchaseProduct[] productList;
		
		/// <summary>Returns the number of the element that has the specified label (If none, then -1)</summary>
		/// <param name="label">Element label</param>
		/// <returns>Element number (If none, then -1)</returns>
		public int IndexOf(string label)
		{
			for (int i = 0; i < this.productList.Length; i++)
			{
				if (this.productList[i].Label == label)
				{
					return i;
				}
			}
			return -1;
		}

		/// <summary>Determines whether an element that has the specified label exists</summary>
		/// <param name="label">Element label</param>
		/// <returns>If element exists, then true</returns>
		public bool Contains(string label)
		{
			return this.IndexOf(label) >= 0;
		}

		/// <summary>Returns the enumerator</summary>
		/// <returns>Enumerator</returns>
		public IEnumerator<InAppPurchaseProduct> GetEnumerator()
		{
			foreach (InAppPurchaseProduct i in this.productList)
			{
				yield return i;
			}
			yield break;
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.GetEnumerator();
		}

		/// <summary>Number of elements</summary>
		/// <remarks>Returns the number of elements stored in the list.</remarks>
		public int Count
		{
			get
			{
				return this.productList.Length;
			}
		}

		/// <summary>Indexer (depending on number or label)</summary>
		/// <remarks>Obtains the elements stored in the list.</remarks>
		public InAppPurchaseProduct this[int index]
		{
			get
			{
				return this.productList[index];
			}
		}

		public InAppPurchaseProduct this[string label]
		{
			get
			{
				return this.productList[this.IndexOf(label)];
			}
		}

		internal void Resize(int count)
		{
			int productCount = (this.productList == null) ? -1 : this.productList.Length;
			if (productCount != count)
			{
				InAppPurchaseProduct[] productList = new InAppPurchaseProduct[count];
				for (int i = 0; i < count; i++)
				{
					productList[i] = ((i < productCount) ? this.productList[i] : new InAppPurchaseProduct());
				}
				this.productList = productList;
			}
		}
	}
}
