using System;
using System.IO;

namespace Sce.PlayStation.Core.Services
{
	/// <summary>Stream reader class</summary>
	[Obsolete("Scoreboard Service of PSM was discontinued.")]
	public class NetworkStreamReader : IDisposable
	{
		internal NetworkStreamReader()
		{
			this.stream = null;
		}

		internal NetworkStreamReader(Stream stream)
		{
			this.stream = stream;
		}

		~NetworkStreamReader()
		{
			this.Dispose();
		}

		/// <summary>dispose an object</summary>
		public void Dispose()
		{
			if (this.stream != null)
			{
				this.stream.Dispose();
				this.stream = null;
			}
		}

		/// <summary>reads a stream</summary>
		/// <param name="buffer">buffer</param>
		/// <param name="offset">offset in buffer</param>
		/// <param name="count">number of bytes to read</param>
		/// <returns>number of bytes read</returns>
		public int Read(byte[] buffer, int offset, int count)
		{
			return this.stream.Read(buffer, offset, count);
		}

		/// <summary>reads to end of stream</summary>
		/// <returns>remainder of stream as a string</returns>
		public string ReadToEnd()
		{
			string result;
			using (StreamReader streamReader = new StreamReader(this.stream))
			{
				result = streamReader.ReadToEnd();
			}
			return result;
		}

		/// <summary>close stream</summary>
		public void Close()
		{
			this.stream.Close();
		}

		private Stream stream = null;
	}
}
