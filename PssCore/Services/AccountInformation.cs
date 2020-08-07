using System;
using System.Runtime.CompilerServices;
using System.Security;

namespace Sce.PlayStation.Core.Services
{
	/// <summary>Static class representing account information</summary>
	public static class AccountInformation
	{
		/*
		 *  Implemented by PSM Runtime.
		 */
		
		[SecurityCritical]
		[MethodImpl(4096)]
		private static extern int GetUniqueID(byte[] id);
		
		/*
		 *	IL Code.
		 */
		
		/// <summary>Unique ID</summary>
		/// <remarks>Obtain a 16-byte number. This is a unique value per account.</remarks>
		public static byte[] UniqueID
		{
			[SecuritySafeCritical]
			get
			{
				if (AccountInformation.uniqueID == null)
				{
					AccountInformation.uniqueID = new byte[16];
					int errorCode = AccountInformation.GetUniqueID(AccountInformation.uniqueID);
					if (errorCode != 0)
					{
						Error.ThrowNativeException(errorCode);
					}
				}
				return AccountInformation.uniqueID;
			}
		}

		private static byte[] uniqueID;
	}
}
