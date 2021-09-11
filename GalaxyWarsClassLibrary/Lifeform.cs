using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxyWarsClassLibrary
{
	/// <summary>
	/// base class for all life to inherit from.
	/// </summary>
	public abstract class Lifeform
	{
		protected string _name;
		protected int _health;
		protected Weapon _weapon;
		protected List<Potion> _potionInventory;
		protected List<Treasure> _treasureInventory;
		protected List<Item> _itemInventory;
		// fields.

		/// <summary>
		/// name of life form.
		/// </summary>
		public string Name
		{
			get { return _name; }
		}

		/// <summary>
		/// health points of life form.
		/// </summary>
		public int Health
		{
			get { return _health; }
			set { _health = value; }
		}

		/// <summary>
		/// equipped weapon of life form. 
		/// </summary>
		public Weapon Weapon
		{
			get { return _weapon; }
			set { _weapon = value; }
		}

		/// <summary>
		/// potion inventory of life form.
		/// </summary>
		public List<Potion> PotionInventory
		{
			get { return _potionInventory; }
		}

		/// <summary>
		/// treasure inventory of life form.
		/// </summary>
		public List<Treasure> TreasureInventory
		{
			get { return _treasureInventory; }
		}

		/// <summary>
		/// item inventory of life form.
		/// </summary>
		public List<Item> ItemInventory
		{
			get { return _itemInventory; }
		}
		// props.
	}
}
