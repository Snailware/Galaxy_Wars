using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxyWarsClassLibrary
{
    public class Potion : Item
    {
        private int _healthEffect;
        private int _damageEffect;

        public Potion(string name, string description, int price, bool quest, int healthEffect, int damageEffect)
            : base(name, description, price, quest)
        {
            _name = name;
            _description = description;
            _quest = quest;
            _healthEffect = healthEffect;
            _damageEffect = damageEffect;
        }   
        public int HealthEffect
        {
            get { return _healthEffect; }
        }
        public int DamageEffect
        {
            get { return _damageEffect; }
        }
    }
}
