using System;
using System.Collections.Generic;

namespace Sce.PlayStation.Core.Graphics
{
	/// <summary>Class representing shader program creation options</summary>
	public class ShaderProgramOption
	{
		/*
		 *	Global Variables
		 */
		
		/// <summary>Constant value overwritten at the time of the compile</summary>
		/// <remarks>Used for rewriting a variable to a constant at the time of the compile.  "uniform int" can be rewritten as "static const int" and "uniform bool" can be rewritten as "static const bool". The declaration of each variable must be completed on one line. Once a variable has been rewritten to a constant, that value cannot be changed.</remarks>
		public Dictionary<string, int> ConstantValues;
		
		/// <summary>Creates a class representing shader program creation options</summary>
		public ShaderProgramOption()
		{
			this.ConstantValues = new Dictionary<string, int>();
		}
	}
}
