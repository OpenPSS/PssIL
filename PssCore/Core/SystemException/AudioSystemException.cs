using System;

namespace Sce.PlayStation.Core
{
	public class AudioSystemException : Exception 
	{
		public AudioSystemException() { }
		public AudioSystemException(string message) : base(message) { }
		public AudioSystemException(string message, Exception inner) : base(message, inner) { }
	}
}

