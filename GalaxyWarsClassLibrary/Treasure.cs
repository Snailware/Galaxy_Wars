using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxyWarsClassLibrary
{
    public class Treasure : Item
    {
        private int _value;

        public Treasure(string name, string description, int value)
            : base(name, description)
        {
            _name = name;
            _description = description;
            _value = value;
        }
        public int Value
        {
            get { return _value; }
        }
    }
}
