using System;

namespace Sce.PlayStation.Core
{
	/// <summary>Shallow Cloneable interface declaration</summary>
	/// <remarks>In case of Shallow Clone of Cloneable interface, if the field(member variable) is an object, its reference will be copied, the object will be multiply-referenced</remarks>
	public interface IShallowCloneable
	{
		object ShallowClone();
	}
}

