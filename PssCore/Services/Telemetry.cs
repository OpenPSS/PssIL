using System;

namespace Sce.PlayStation.Core.Services
{
	/*
	 *	PSM's Spying tools, feel free to comment it out
	 */
	
	
	/// <summary>for creating telemetry requests</summary>
	internal static class Telemetry
	{
		internal static string ConstructAuthJson(string tokenData)
		{
			string b64t = string.Format("\"{0}\": \"b64({1})\"", "t", tokenData);
			string u = string.Format("\"{0}\": {{{1}}}", "u", b64t);
			string b = string.Format("\"{0}\": {{{1}}}", "b", u);
			return string.Format("{{{0}, {1}}}", Telemetry.ConstructHeader(), b);
		}

		internal static string ConstructHeader()
		{
			string dateTimeStr = DateTime.UtcNow.ToString("o");
			return string.Format("\"{0}\": {{\"{1}\": \"{2}\"}}", "h", "t", dateTimeStr);
		}
	}
}
