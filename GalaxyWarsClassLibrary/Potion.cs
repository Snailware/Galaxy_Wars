using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxyWarsClassLibrary
{
    public class Potion : Item
    {
        private int _effect;

        public Potion(string name, string description, int effect)
            :base(name, description)
        {
            _name = name;
            _description = description;
            _effect = effect;
        }

        public int Effect
        {
            get { return _effect; }
        }
    }
}
