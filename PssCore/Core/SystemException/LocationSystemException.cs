using System;

namespace Sce.PlayStation.Core
{
    public class LocationSystemException : Exception
    {
		public LocationSystemException() { }
		public LocationSystemException(string message) : base(message) { }
		public LocationSystemException(string message, Exception inner) : base(message, inner) { }
	}
}
