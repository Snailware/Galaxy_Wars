using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxyWarsClassLibrary
{
    /// <summary>
    /// alien class derived from lifeform.
    /// </summary>
    public class Alien : Lifeform
    {
        private string _description;
        // fields.

        /// <summary>
        /// alien class derived from lifeform.
        /// </summary>
        /// <param name="name">name of alien.</param>
        /// <param name="description">description of alien.</param>
        /// <param name="health">health points of alien.</param>
        /// <param name="armor">armor rating of alien.</param>
        /// <param name="money">amount of money alien has.</param>
        /// <param name="weaponInventory">weapon inventory of alien.</param>
        /// <param name="potionInventory">potion inventory of alien.</param>
        /// <param name="treasureInventory">treasure inventory of alien.</param>
        /// <param name="itemInventory">item inventory of alien.</param>
        public Alien(string name,
                     string description, 
                     int health,
                     int armor,
                     int money,
                     List<Weapon> weaponInventory,
                     List<Potion> potionInventory,
                     List<Treasure> treasureInventory,
                     List<Item> itemInventory)
        {
            _name = name;
            _description = description;
            _health = health;
            _armor = armor;
            _money = money;
            _weaponInventory = weaponInventory;
            _weapon = _weaponInventory[0];
            _potionInventory = potionInventory;
            _treasureInventory = treasureInventory;
            _itemInventory = itemInventory;
        }

        /// <summary>
        /// alien class derived from lifeform.
        /// </summary>
        /// <param name="name">name of alien.</param>
        /// <param name="description">description of alien.</param>
        /// <param name="health">health points of alien.</param>
        /// <param name="armor">armor rating of alien.</param>
        /// <param name="money">amount of money alien has.</param>
        public Alien(string name,
                     string description,
                     int health,
                     int armor,
                     int money)
        {
            _name = name;
            _description = description;
            _health = health;
            _armor = armor;
            _money = money;

            _weaponInventory = new List<Weapon>();
            _potionInventory = new List<Potion>();
            _treasureInventory = new List<Treasure>();
            _itemInventory = new List<Item>();
            // create default lists.

            Random random = new Random();
            // random number generator.

            int weaponSeed = random.Next(0, Galaxy.Weapons.Count);
            _weaponInventory.Add(Galaxy.Weapons[weaponSeed]);
            _weapon = _weaponInventory[0];
            // give alien random weapon and equip it.

            int lootSeed = random.Next(0, 4);
            switch (lootSeed)
            {
                case 0:
                    lootSeed = random.Next(0, Galaxy.Potions.Count);
                    _potionInventory.Add(Galaxy.Potions[lootSeed]);
                    break;
                    // generate a random potion and add to inventory.

                case 1:
                    lootSeed = random.Next(0, Galaxy.Treasures.Count);
                    _treasureInventory.Add(Galaxy.Treasures[lootSeed]);
                    break;
                    // generate a random treasure and add to inventory.

                case 2:
                    lootSeed = random.Next(0, Galaxy.Items.Count);
                    _itemInventory.Add(Galaxy.Items[lootSeed]);
                    break;
                    // generate a random item and add to inventory.

                default:
                    break;
                    // leave all loot inventories empty.
            }
            // give alien loot. (low chance of no loot)
        }
        // constructors.

        /// <summary>
        /// description of alien.
        /// </summary>
        public string Description
        {
            get { return _description; }
        }
        // props.

        /// <summary>
        /// generate & return a semi random alien obj.
        /// </summary>
        /// <returns>randomized alien obj.</returns>
        public static Alien Generate()
        {
            Random random = new Random();
            // random number generator.

            return Galaxy.Aliens[random.Next(0, Galaxy.Aliens.Count - 1)];
            // select random alien from Galaxy.Aliens and return.
        }
        // methods.
    }
}
