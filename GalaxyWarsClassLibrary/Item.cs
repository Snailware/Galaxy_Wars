using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxyWarsClassLibrary
{
    public class Item
    {
        protected string _name,
                         _description;

        public Item(string name, string description)
        {
            _name = name;
            _description = description;
        }
        public string Name
        {
            get { return _name; }
        }

        public string Description
        {
            get { return _description; }
        }
    }
}
