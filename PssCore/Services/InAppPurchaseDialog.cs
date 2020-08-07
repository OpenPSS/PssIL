using System;
using System.Runtime.CompilerServices;
using System.Security;
using Sce.PlayStation.Core.Environment;

namespace Sce.PlayStation.Core.Services
{
	/// <summary>Class representing the dialog for processing In-App billing.</summary>
	public class InAppPurchaseDialog : ICommonDialog, IDisposable
	{
		/*
		 *  Implemented by PSM Runtime.
		 */
		
		[SecurityCritical]
		[MethodImpl(4096)]
		private static extern int NewNative(int type, out int handle);
		[SecurityCritical]
		[MethodImpl(4096)]
		private static extern int ReleaseNative(int type, int handle);
		[SecurityCritical]
		[MethodImpl(4096)]
		private static extern int OpenNative(int type, int handle, ref InAppPurchaseDialog.CommandArguments cmdArg);
		[SecurityCritical]
		[MethodImpl(4096)]
		private static extern int AbortNative(int type, int handle);
		[SecurityCritical]
		[MethodImpl(4096)]
		private static extern int GetState(int type, int handle, out CommonDialogState state);
		[SecurityCritical]
		[MethodImpl(4096)]
		private static extern int GetResult(int type, int handle, out CommonDialogResult result, ref InAppPurchaseDialog.CommandResults results);
		/*
		 * Global Variables
		 */
		private const int dialogType = 257;
		private int handle;
		private bool busyStatus;
		private CommonDialogState state;
		private CommonDialogResult result;
		private InAppPurchaseCommand command;
		private string[] arguments;
		private InAppPurchaseProductList productList;
		private int infoStatus;
		private struct CommandArguments
		{
			public InAppPurchaseCommand Command;

			public int[] Arguments;
		}

		private struct CommandResults
		{
			public InAppPurchaseCommand Command;

			public int InfoStatus;

			public int Count;

			public InAppPurchaseProductData[] Results;
		}
		
		/*
		 * IL Code.
		 */
		/// <summary>Creates a dialog</summary>
		/// <remarks>A dialog class is created, and a product list is read from the metadata.</remarks>
		[SecuritySafeCritical]
		public InAppPurchaseDialog()
		{
			int errorCode = InAppPurchaseDialog.NewNative(257, out this.handle);
			if (errorCode != 0)
			{
				Error.ThrowNativeException(errorCode);
			}
			this.productList = new InAppPurchaseProductList();
			this.busyStatus = true;
			this.CheckResult();
		}

		/// <summary>Deletes a dialog</summary>
		/// <remarks>Deletes a dialog.</remarks>
		~InAppPurchaseDialog()
		{
			this.Dispose(false);
		}

		/// <summary>Frees unmanaged resources of a dialog</summary>
		/// <remarks>Frees unmanaged resources of a dialog.</remarks>
		public void Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}

		[SecuritySafeCritical]
		protected virtual void Dispose(bool disposing)
		{
			if (this.handle != 0)
			{
				InAppPurchaseDialog.ReleaseNative(257, this.handle);
			}
			this.handle = 0;
		}

		/// <summary>Opens a dialog and obtains product information from the server</summary>
		/// <param name="labels">Product label array (select all if null)</param>
		/// <remarks>Opens a dialog, connects to the server, and obtains product information for the specified product. Note that this function sends requests to the server for each product; therefore, it can take a long time to obtain a vast amount of information at one time.</remarks>
		[SecuritySafeCritical]
		public void GetProductInfo(string[] labels)
		{
			InAppPurchaseDialog.CommandArguments commandArguments;
			commandArguments.Command = InAppPurchaseCommand.GetProductInfo;
			commandArguments.Arguments = ((labels == null) ? this.AllIndices() : this.FindLabels(labels));
			int errorCode = InAppPurchaseDialog.OpenNative(257, this.handle, ref commandArguments);
			if (errorCode != 0)
			{
				Error.ThrowNativeException(errorCode);
			}
			this.command = commandArguments.Command;
			this.arguments = labels;
			this.busyStatus = true;
		}

		/// <summary>Opens a dialog and obtains ticket information from the server</summary>
		/// <remarks>Opens a dialog, connects to the server, and obtains ticket information for all products.</remarks>
		[SecuritySafeCritical]
		public void GetTicketInfo()
		{
			InAppPurchaseDialog.CommandArguments commandArguments;
			commandArguments.Command = InAppPurchaseCommand.GetTicketInfo;
			commandArguments.Arguments = null;
			int errorCode = InAppPurchaseDialog.OpenNative(257, this.handle, ref commandArguments);
			if (errorCode != 0)
			{
				Error.ThrowNativeException(errorCode);
			}
			this.command = commandArguments.Command;
			this.arguments = null;
			this.busyStatus = true;
		}

		/// <summary>Opens a dialog and purchases a product</summary>
		/// <param name="label">Product label</param>
		/// <remarks>Opens a dialog, connects to the server, and purchases the specified product. Note that product information and ticket information must be obtained in advance. Exceptions will occur in the following cases.
		/// <list type="bullet"><item><description>The specified product is not registered in the list</description></item><item><description>Product or ticket information is not obtained</description></item><item><description>The specified product is a normal type product and was already purchased</description></item></list><para>When dialog processing is completed and the result is OK, all ticket information is updated. If the result is Error or Aborted, the ticket information is not updated and the IsTicketInfoComplete property is false. In such cases, obtain the ticket information again with the GetTicketInfo function and check if the processing succeeded or failed.
		/// </para></remarks>
		[SecuritySafeCritical]
		public void Purchase(string label)
		{
			string[] labels = new string[]
			{
				label
			};
			InAppPurchaseDialog.CommandArguments commandArguments;
			commandArguments.Command = InAppPurchaseCommand.Purchase;
			commandArguments.Arguments = this.FindLabels(labels);
			int errorCode = InAppPurchaseDialog.OpenNative(257, this.handle, ref commandArguments);
			if (errorCode != 0)
			{
				Error.ThrowNativeException(errorCode);
			}
			this.command = commandArguments.Command;
			this.arguments = labels;
			this.busyStatus = true;
		}

		/// <summary>Opens a dialog and consumes a ticket</summary>
		/// <param name="label">Product label</param>
		/// <remarks>Opens a dialog, connects to the server, and consumes the ticket of the specified product. Note that ticket information must be obtained in advance. Exceptions will occur in the following cases.
		/// <list type="bullet"><item><description>The specified product is not registered in the list</description></item><item><description>Ticket information is not obtained</description></item><item><description>The specified product is not a consumption type product</description></item><item><description>The remaining number of times of the product is zero</description></item></list><para>When dialog processing is completed and the result is OK, all ticket information is updated. If the result is Error or Aborted, the ticket information is not updated and the IsTicketInfoComplete property is false. In such cases, obtain the ticket information again with the GetTicketInfo function and check if the processing succeeded or failed.
		/// </para></remarks>
		[SecuritySafeCritical]
		public void Consume(string label)
		{
			string[] labels = new string[]
			{
				label
			};
			InAppPurchaseDialog.CommandArguments commandArguments;
			commandArguments.Command = InAppPurchaseCommand.Consume;
			commandArguments.Arguments = this.FindLabels(labels);
			int errorCode = InAppPurchaseDialog.OpenNative(257, this.handle, ref commandArguments);
			if (errorCode != 0)
			{
				Error.ThrowNativeException(errorCode);
			}
			this.command = commandArguments.Command;
			this.arguments = labels;
			this.busyStatus = true;
		}

		/// <summary>Opens the dialog (This function is not supported)</summary>
		/// <remarks>This function is not supported. To open the dialog, use the GetProductInfo, GetTicketInfo, Purchase, and Consume functions. </remarks>
		public void Open()
		{
			throw new NotSupportedException();
		}

		/// <summary>Aborts the dialog (currently unsupported)</summary>
		/// <remarks>Aborts dialog processing and closes the dialog. </remarks>
		[SecuritySafeCritical]
		public void Abort()
		{
			int errorCode = InAppPurchaseDialog.AbortNative(257, this.handle);
			if (errorCode != 0)
			{
				Error.ThrowNativeException(errorCode);
			}
		}

		/// <summary>Dialog processing state</summary>
		/// <remarks>Obtains the state of the dialog processing executed last.</remarks>
		public CommonDialogState State
		{
			get
			{
				this.CheckResult();
				return this.state;
			}
		}

		/// <summary>Dialog processing result</summary>
		/// <remarks>Obtains the result of the dialog processing executed last.</remarks>
		public CommonDialogResult Result
		{
			get
			{
				this.CheckResult();
				return this.result;
			}
		}

		/// <summary>Dialog processing command</summary>
		/// <remarks>Obtains the command of the dialog processing executed last.</remarks>
		public InAppPurchaseCommand Command
		{
			get
			{
				return this.command;
			}
		}

		/// <summary>Dialog processing argument</summary>
		/// <remarks>Obtains the argument of the dialog processing executed last.</remarks>
		public string[] Arguments
		{
			get
			{
				return this.arguments;
			}
		}

		/// <summary>Product list</summary>
		/// <remarks>Obtains a list of products that can be purchased.</remarks>
		public InAppPurchaseProductList ProductList
		{
			get
			{
				this.CheckResult();
				return this.productList;
			}
		}

		/// <summary>Whether all product information is obtained</summary>
		/// <remarks>Returns true if all product information is obtained.</remarks>
		public bool IsProductInfoComplete
		{
			get
			{
				this.CheckResult();
				return (this.infoStatus & 1) != 0;
			}
		}

		/// <summary>Whether all ticket information is obtained</summary>
		/// <remarks>Returns true if all ticket information is obtained. Returns false if ticket information is not obtained or it cannot be updated to the latest state due to an error.</remarks>
		public bool IsTicketInfoComplete
		{
			get
			{
				this.CheckResult();
				return (this.infoStatus & 2) != 0;
			}
		}

		[SecuritySafeCritical]
		internal void CheckResult()
		{
			if (this.busyStatus)
			{
				int errorCode = InAppPurchaseDialog.GetState(257, this.handle, out this.state);
				if (errorCode != 0)
				{
					Error.ThrowNativeException(errorCode);
				}
				if (this.state != CommonDialogState.Running)
				{
					InAppPurchaseDialog.CommandResults commandResults = default(InAppPurchaseDialog.CommandResults);
					errorCode = InAppPurchaseDialog.GetResult(257, this.handle, out this.result, ref commandResults);
					if (errorCode != 0)
					{
						Error.ThrowNativeException(errorCode);
					}
					if (this.result == CommonDialogResult.OK)
					{
						commandResults.Results = new InAppPurchaseProductData[commandResults.Count];
						errorCode = InAppPurchaseDialog.GetResult(257, this.handle, out this.result, ref commandResults);
						if (errorCode != 0)
						{
							Error.ThrowNativeException(errorCode);
						}
						this.productList.Resize(commandResults.Count);
						for (int i = 0; i < commandResults.Count; i++)
						{
							this.productList[i].data = commandResults.Results[i];
						}
					}
					this.infoStatus = commandResults.InfoStatus;
					this.busyStatus = false;
				}
			}
		}

		private int[] FindLabels(string[] labels)
		{
			int totalLabels = labels.Length;
			int[] allLabels = new int[totalLabels];
			for (int i = 0; i < totalLabels; i++)
			{
				allLabels[i] = this.productList.IndexOf(labels[i]);
				if (allLabels[i] < 0)
				{
					throw new ArgumentOutOfRangeException("", "Product '" + labels[i] + "' is not found\n");
				}
			}
			return allLabels;
		}

		private int[] AllIndices()
		{
			int productCount = this.productList.Count;
			int[] allProducts = new int[productCount];
			for (int i = 0; i < productCount; i++)
			{
				allProducts[i] = i;
			}
			return allProducts;
		}

	}
}
