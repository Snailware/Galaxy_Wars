using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxyWarsClassLibrary
{
	/// <summary>
	/// interface for adding objects to game inventories.
	/// </summary>
	public interface IInventory
	{
		/// <summary>
		/// name of object.
		/// </summary>
		string Name { get; }

		/// <summary>
		/// description of object.
		/// </summary>
		string Description { get; }
	}
}
