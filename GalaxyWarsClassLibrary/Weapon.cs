using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxyWarsClassLibrary
{
    public class Weapon : Item
    {
        private int _damage;
        
    
        /// <summary>
        /// weapon class derived from item
        /// </summary>
        /// <param name="name">name of the weapon</param>
        /// <param name="description">description of the weapon</param>
        /// <param name="damage">amount of damage</param>
        public Weapon(string name, string description, int damage)
            : base(name, description)
        {
            _name = name;
            _description = description;
            _damage = damage;  
        }
        /// <summary>
        /// Amount of damage
        /// </summary>
        public int Damage
        {
            get { return _damage; }
        }
    }
}
