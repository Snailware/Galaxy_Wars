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
        protected int _armor;
        protected int _money;
        protected Weapon _weapon;
        protected List<IInventory> _inventory;
        // fields.

        /// <summary>
        /// name of life form.
        /// </summary>
        public string Name
        {
            get { return _name; }
        }

        /// <summary>
        /// health points of life form. cant go below 0.
        /// </summary>
        public int Health
        {
            get { return _health; }
            set 
            { 
                if (value >= 0)
                {
                    _health = value;
                }
                else
                {
                    _health = 0;
                }
                // dont allow health to go below 0.
            }
        }

        /// <summary>
        /// armor rating of life form.
        /// </summary>
        public int Armor
        {
            get { return _armor; }
            set { _armor = value; }
        }

        /// <summary>
        /// amount of money lifeform has.
        /// </summary>
        public int Money
        {
            get { return _money; }
            set { _money = value; }
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
        /// inventory of game objects.
        /// </summary>
        public List<IInventory> Inventory
		{
			get { return _inventory; }
            set { _inventory = value; }
		}
        // props.
    }
}
