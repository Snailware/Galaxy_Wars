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
                     List<IInventory> inventory)
        {
            _name = name;
            _description = description;
            _health = health;
            _armor = armor;
            _money = money;
            _inventory = inventory;
            foreach (IInventory gameObject in _inventory)
            {
                if (gameObject.GetType() == typeof(Weapon))
                {
                    _weapon = (Weapon)gameObject;
                    break;
                }
            }
            // get first weapon from inventory and set as equipped weapon.
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

            _inventory = new List<IInventory>();
            // create default lists.

            int weaponSeed = LocalRandom.Next(0, Galaxy.Weapons.Count);
            Weapon weaponCopy = new Weapon(name: Galaxy.Weapons[weaponSeed].Name,
                                           description: Galaxy.Weapons[weaponSeed].Description,
                                           price: Galaxy.Weapons[weaponSeed].Price,
                                           quest: Galaxy.Weapons[weaponSeed].Quest,
                                           damageType: Galaxy.Weapons[weaponSeed].DamageType,
                                           amtOfDamage: Galaxy.Weapons[weaponSeed].AmtOfDamage);
            _inventory.Add(weaponCopy);
            foreach (IInventory gameObject in _inventory)
            {
                if (gameObject.GetType() == typeof(Weapon))
                {
                    _weapon = (Weapon)gameObject;
                    break;
                }
            }
            // get first weapon from inventory and set as equipped weapon.
            // give alien copy of random weapon and equip it.

            int lootSeed = LocalRandom.Next(0, 4);
            switch (lootSeed)
            {
                case 0:
                    lootSeed = LocalRandom.Next(0, Galaxy.Potions.Count);
                    _inventory.Add(new Potion(name: Galaxy.Potions[lootSeed].Name,
                                                    description: Galaxy.Potions[lootSeed].Description,
                                                    price: Galaxy.Potions[lootSeed].Price,
                                                    quest: Galaxy.Potions[lootSeed].Quest,
                                                    healthEffect: Galaxy.Potions[lootSeed].HealthEffect,
                                                    damageEffect: Galaxy.Potions[lootSeed].DamageEffect));
                    break;
                    // generate a random potion and add to inventory.

                case 1:
                    lootSeed = LocalRandom.Next(0, Galaxy.Treasures.Count);
                    _inventory.Add(new Treasure(name: Galaxy.Treasures[lootSeed].Name,
                                                        description: Galaxy.Treasures[lootSeed].Description,
                                                        price: Galaxy.Treasures[lootSeed].Price,
                                                        quest: Galaxy.Treasures[lootSeed].Quest));
                    break;
                    // generate a random treasure and add to inventory.

                case 2:
                    lootSeed = LocalRandom.Next(0, Galaxy.Items.Count);
                    _inventory.Add(new Item(name: Galaxy.Items[lootSeed].Name,
                                                description: Galaxy.Items[lootSeed].Description,
                                                price: Galaxy.Items[lootSeed].Price,
                                                quest: Galaxy.Items[lootSeed].Quest));
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

        /// <summary>
        /// random number generator. placed here to initialize with seed and avoid repeating 1 value.
        /// </summary>
        private static Random LocalRandom { get; } = new Random();
        // props.

        /// <summary>
        /// generate & return a semi random alien obj.
        /// </summary>
        /// <returns>randomized alien obj.</returns>
        public static Alien Generate()
        {
            Alien baseAlien = Galaxy.Aliens[LocalRandom.Next(0, Galaxy.Aliens.Count - 1)];
            // randomly select alien to copy.

            return Alien.Copy(baseAlien);
            // create and return copy of alien.
        }

        /// <summary>
        /// create a copy of alien. 
        /// </summary>
        /// <param name="alien">alien to copy.</param>
        /// <returns>copy of alien object.</returns>
        public static Alien Copy(Alien alien)
		{
            return new Alien(name: alien.Name,
                             description: alien.Description,
                             health: alien.Health,
                             armor: alien.Armor,
                             money: alien.Money,
                             inventory: alien.Inventory);
		}
        // methods.
    }
}
