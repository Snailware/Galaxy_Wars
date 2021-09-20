using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxyWarsClassLibrary
{
    /// <summary>
    /// class for planets.
    /// </summary>
    public class Planet
    {
        private string _name,
                       _description;

        private int _population;

        private Alien _alien;

        private List<Weapon> _weapons;
        private List<Potion> _potions;
        private List<Item> _items;
        private List<Treasure> _treasures;
        // fields.

        /// <summary>
        /// planet obj.
        /// </summary>
        /// <param name="planetName">name of planet.</param>
        /// <param name="planetDescription">description of planet.</param>
        /// <param name="population">population of planet.</param>
        public Planet(string planetName, 
                      string planetDescription, 
                      int population,
                      Alien alien)
        {
            _name = planetName;
            _description = planetDescription;
            _population = population;

            _alien = alien;

            _weapons = new List<Weapon>();
            _potions = new List<Potion>();
            _items = new List<Item>();
            _treasures = new List<Treasure>();
        }
        // constructors.

        /// <summary>
        /// planet name.
        /// </summary>
        public string Name
        {
            get { return _name; }
        }

        /// <summary>
        /// planet description.
        /// </summary>
        public string Description
        {
            get { return _description; }
        }

        /// <summary>
        /// polulation of planet.
        /// </summary>
        public int Population
        {
            get { return _population; }
            set { _population = value; }
        }

        /// <summary>
        /// hostile alien occupying the planet.
        /// </summary>
        public Alien Alien
        {
            get { return _alien; }
            set { _alien = value; }
        }

        /// <summary>
        /// list of local weapons.
        /// </summary>
        public List<Weapon> Weapons
        {
            get { return _weapons; }
            set { _weapons = value; }
        }

        /// <summary>
        /// list of local potions.
        /// </summary>
        public List<Potion> Potions
        {
            get { return _potions; }
            set { _potions = value; }
        }

        /// <summary>
        /// list of local items.
        /// </summary>
        public List<Item> Items
        {
            get { return _items; }
            set { _items = value; }
        }

        /// <summary>
        /// list of local treasures.
        /// </summary>
        public List<Treasure> Treasures
        {
            get { return _treasures; }
            set { _treasures = value; }
        }
        // props.
        
        /// <summary>
        /// generate a semi random planet obj.
        /// </summary>
        /// <returns>random planet.</returns>
        public static Planet Generate()
        {
            Random random = new Random();
            // random nubmer generator.

            return Galaxy.Planets[random.Next(0, Galaxy.Planets.Count - 1)];
            // return a random planet from list.
        }

        /// <summary>
        /// create empty space planet obj.
        /// </summary>
        /// <returns>empty space planet obj.</returns>
        public static Planet Space()
        {
            return new Planet("Space",
                              "A welcome respite from your adventures.",
                              0,
                              new Alien("None",
                                        "None",
                                        0,
                                        0,
                                        0));
        }
        // methods.
    }
}
