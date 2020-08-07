using System;
using System.Runtime.CompilerServices;
using System.Security;

namespace Sce.PlayStation.Core.Environment
{
	/// <summary>Class to receive system parameters</summary>
	public static class SystemParameters
	{
		
		/*
		 *  Implemented by PSM Runtime.
		 */
		
		[SecurityCritical]
		[MethodImpl(4096)]
		private static extern int GetInt(SystemParameters.ParameterKey key, out int value);
		[SecurityCritical]
		[MethodImpl(4096)]
		private static extern int GetFloat(SystemParameters.ParameterKey key, out float value);
		[SecurityCritical]
		[MethodImpl(4096)]
		private static extern int GetString(SystemParameters.ParameterKey key, out string value);
		
		private enum ParameterKey : uint
		{
			Language, /* 0 */
			GamePadButtonMeaning, /* 1 */
			YesNoLayout, /* 2 */
			DisplayDpiX, /* 3 */
			DisplayDpiY /* 4 */
		}
		
		/// <summary>System language settings</summary>
		/// <remarks>The possible values for this property are as follows.
		/// \li ja-JP : Japanese  \li en-US : English (US)  \li en-GB : English (UK)  \li fr-FR : French \li es-ES : Spanish  \li de-DE : German  \li it-IT : Italian  \li nl-NL : Dutch \li pt-PT : Portuguese  \li pt-BR : Portuguese (Brazil)  \li ru-RU : Russian  \li ko-KR : Korean  \li zh-Hant : Chinese (traditional)  \li zh-Hans : Chinese (simplified)  \li fi_FI : Finnish  \li sv-SE : Swedish  \li da-DK : Danish  \li nb-NO : Norwegian  \li pl-PL : Polish  
		/// To support new languages in the future, this range may expand and unknown values for applications may return. Even if this property is an unknown value for applications, describe them so that they will operate correctly.</remarks>
		public static string Language
		{
			[SecuritySafeCritical]
			get
			{
				string language;
				int errorCode = SystemParameters.GetString(SystemParameters.ParameterKey.Language, out language);
				if (errorCode != 0)
				{
					Error.ThrowNativeException(errorCode);
				}
				return language;
			}
		}

		/// <summary>Meanings of the circle and cross buttons</summary>
		/// <remarks>The meanings of the circle and cross buttons differ by region. The meanings of the circle and cross buttons set to the system can be obtained by this property.</remarks>
		public static GamePadButtonMeaning GamePadButtonMeaning
		{
			[SecuritySafeCritical]
			get
			{
				int buttonMeaning;
				int errorCode = SystemParameters.GetInt(SystemParameters.ParameterKey.GamePadButtonMeaning, out buttonMeaning);
				if (errorCode != 0)
				{
					Error.ThrowNativeException(errorCode);
				}
				return (GamePadButtonMeaning)buttonMeaning;
			}
		}

		/// <summary>Yes and No positions of the message dialog</summary>
		/// <remarks>Depending on the operational platform, positions of buttons meaning Yes and No differ. The natural layout of the operational platform can be obtained by this property.</remarks>
		public static YesNoLayout YesNoLayout
		{
			[SecuritySafeCritical]
			get
			{
				int yesNoLayout;
				int errorCode = SystemParameters.GetInt(SystemParameters.ParameterKey.YesNoLayout, out yesNoLayout);
				if (errorCode != 0)
				{
					Error.ThrowNativeException(errorCode);
				}
				return (YesNoLayout)yesNoLayout;
			}
		}

		/// <summary>Number of dots per inch of the display (X axis direction)</summary>
		public static float DisplayDpiX
		{
			[SecuritySafeCritical]
			get
			{
				float dpiX;
				int errorCode = SystemParameters.GetFloat(SystemParameters.ParameterKey.DisplayDpiX, out dpiX);
				if (errorCode != 0)
				{
					Error.ThrowNativeException(errorCode);
				}
				return dpiX;
			}
		}

		/// <summary>Number of dots per inch of the display (Y axis direction)</summary>
		public static float DisplayDpiY
		{
			[SecuritySafeCritical]
			get
			{
				float dpiY;
				int errorCode = SystemParameters.GetFloat(SystemParameters.ParameterKey.DisplayDpiY, out dpiY);
				if (errorCode != 0)
				{
					Error.ThrowNativeException(errorCode);
				}
				return dpiY;
			}
		}
	}
}
