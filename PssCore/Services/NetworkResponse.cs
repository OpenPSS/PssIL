using System;
using System.IO;
using System.Text;

namespace Sce.PlayStation.Core.Services
{
	/// <summary>Network response class</summary>
	[Obsolete("Scoreboard Service of PSM was discontinued.")]
	public class NetworkResponse : IDisposable
	{
		internal NetworkResponse(string response)
		{
			this.response = response;
		}

		~NetworkResponse()
		{
			this.Dispose();
		}

		/// <summary>disposes class</summary>
		public void Dispose()
		{
			if (this.response != null)
			{
				this.response = null;
			}
		}

		/// <summary>Creates a stream reader</summary>
		/// <returns>stream reader</returns>
		public NetworkStreamReader GetStreamReader()
		{
			byte[] responseBytes = Encoding.Default.GetBytes(this.response);
			MemoryStream ms = new MemoryStream();
			ms.Write(responseBytes, 0, responseBytes.Length);
			ms.Position = 0L;
			return new NetworkStreamReader(ms);
		}

		internal string response = null;
	}
}
