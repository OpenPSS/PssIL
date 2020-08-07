using System;

namespace Sce.PlayStation.Core
{
    public class InputSystemException : Exception
    {
		public InputSystemException() { }
		public InputSystemException(string message) : base(message) { }
		public InputSystemException(string message, Exception inner) : base(message, inner) { }
	}
}
