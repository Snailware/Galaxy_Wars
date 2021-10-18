using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxyWarsClassLibrary
{
    public class Treasure : Item
    {
        


        /// <summary>
        /// weapon class derived from item
        /// </summary>
        /// <param name="name">name of the weapon</param>
        /// <param name="description">description of the weapon</param>
        /// <param name="price">price of weapon</param>
        /// <param name="quest"></param>
        public Treasure(string name, string description, int price, bool quest)
            : base(name, description, price, quest)
        {
            _name = name;
            _description = description;
            _price = price;
            _quest = quest;
        }
        /// <summary>
        /// Amount of damage
        /// </summary>
    }
}
