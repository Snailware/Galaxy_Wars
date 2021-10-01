using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxyWarsClassLibrary
{
    public class Weapon : Item
    {
        private int _amtOfDamage;
        private string _damageType;


        /// <summary>
        /// weapon class derived from item
        /// </summary>
        /// <param name="name">name of the weapon</param>
        /// <param name="description">description of the weapon</param>
        /// <param name="damageType">damage type</param>
        /// <param name="amtOfDamage">amount of damage</param>
        /// <param name="price">price of weapon</param>
        /// <param name="quest"></param>
        public Weapon(string name, string description,int price, bool quest, string damageType, int amtOfDamage)
            : base(name, description, price, quest)
        {
            _name = name;
            _description = description;
            _price = price;
            _quest = quest;
            _damageType = damageType;
            _amtOfDamage = amtOfDamage;
        }
        /// <summary>
        /// Amount of damage
        /// </summary>
       
        public string DamageType
        {
            get { return _damageType; }
        }
        public int AmtOfDamage
        {
            get { return _amtOfDamage; }
        }
    }
}
