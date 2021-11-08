using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxyWarsClassLibrary
{
    public class Treasure : Item, IInventory
    {
        public Treasure(string name, string description,int price, bool quest)
            : base(name, description, price, quest)
        {
            _name = name;
            _description = description;
            _price = price;
            _quest = quest;
        }
    }
}
