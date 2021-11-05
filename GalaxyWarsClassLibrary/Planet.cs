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
        private List<IInventory> _inventory;
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

            _inventory = new List<IInventory>();
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
        /// local inventory of planet.
        /// </summary>
        public List<IInventory> Inventory
		{
            get { return _inventory; }
            set { _inventory = value; }
		}

        /// <summary>
        /// random number generator. placed here to initialize with seed and avoid repeating 1 value.
        /// </summary>
        private static Random LocalRandom { get; } = new Random();
        // props.
        
        /// <summary>
        /// generate a semi random planet obj.
        /// </summary>
        /// <returns>random planet.</returns>
        public static Planet Generate()
        {
            Planet basePlanet = Galaxy.Planets[LocalRandom.Next(0, Galaxy.Planets.Count - 1)];
            // randomly select planet to copy.

            Planet generatedPlanet = new Planet(planetName: basePlanet.Name,
                                                planetDescription: basePlanet.Description,
                                                population: basePlanet.Population,
                                                alien: basePlanet.Alien);
            // manually create copy of planet.

            return generatedPlanet;
            // return generated planet.
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
