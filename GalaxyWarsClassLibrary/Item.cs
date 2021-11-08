using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxyWarsClassLibrary
{
    public class Item : IInventory
    {
        protected string _name,
                         _description;
        protected int _price;
        protected bool _quest;

        public Item(string name, string description, int price, bool quest)
        {
            _name = name;
            _description = description;
            _price = price;
            _quest = quest;
        }
        public string Name
        {
            get { return _name; }
        }

        public string Description
        {
            get { return _description; }
        }
        public int Price
        {
            get { return _price; }
        }
        public bool Quest
        {
            get { return _quest; }
        }
    }
}
