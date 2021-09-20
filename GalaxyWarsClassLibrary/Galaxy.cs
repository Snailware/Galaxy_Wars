using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxyWarsClassLibrary
{
    /// <summary>
    /// class to hold obj lists & related methods.
    /// </summary>
    public static class Galaxy
    {
        private static Player _player;
        private static List<Weapon> _weapons = new List<Weapon>();
        private static List<Potion> _potions = new List<Potion>();
        private static List<Treasure> _treasures = new List<Treasure>();
        private static List<Item> _items = new List<Item>();
        private static List<Alien> _aliens = new List<Alien>();
        private static List<Planet> _planets = new List<Planet>();
        private static Planet[,] _currentSystem = new Planet[9, 7]; // 9 rows, 7 columns
        private static string _actionStatement;
        // fields. 

        /// <summary>
        /// player character.
        /// </summary>
        public static Player Player
        {
            get { return _player; }
            set { _player = value; }
        }

        /// <summary>
        /// all weapons in game.
        /// </summary>
        public static List<Weapon> Weapons
        {
            get { return _weapons; }
            set { _weapons = value; }
        }

        /// <summary>
        /// all potions in game.
        /// </summary>
        public static List<Potion> Potions
        {
            get { return _potions; }
            set { _potions = value; }
        }

        /// <summary>
        /// all treasures in game.
        /// </summary>
        public static List<Treasure> Treasures
        {
            get { return _treasures; }
            set { _treasures = value; }
        }

        /// <summary>
        /// all items in game.
        /// </summary>
        public static List<Item> Items
        {
            get { return _items; }
            set { _items = value; }
        }

        /// <summary>
        /// aliens in current system.
        /// </summary>
        public static List<Alien> Aliens
        {
            get { return _aliens; }
            set { _aliens = value; }
        }

        /// <summary>
        /// planets in current system.
        /// </summary>
        public static List<Planet> Planets
        {
            get { return _planets; }
            set { _planets = value; }
        }

        /// <summary>
        /// currently loaded start system.
        /// </summary>
        public static Planet[,] CurrentSystem
        {
            get { return _currentSystem; }
            set { _currentSystem = value; }
        }

        /// <summary>
        /// statement describing most recent occurance.
        /// </summary>
        public static string ActionStatement
        {
            get { return _actionStatement; }
            set { _actionStatement = value; }
        }
        // props.

        /// <summary>
        /// fill planet array with new planets. 
        /// </summary>
        public static void LoadNewSystem()
        {
            /*		MAP STRUCTURE
             *		
             *		0 2 4 6
             *	
             *		O O O O		0
             * 
             *		O O O O		2
             *		       
             *		O O O O		4
             *		       
             *		O O O O		6
             *		       
             *		O O O O		8
             *		
             *		O = planet
             *		0 = liberated planet
             *		^ = player
             *		otherwise empty Space is created. 
            */

            for (int rowIndex = 0; rowIndex < _currentSystem.GetUpperBound(0); rowIndex++)
            {
                for (int columnIndex = 0; columnIndex < _currentSystem.GetUpperBound(1); columnIndex++)
                {
                    if (rowIndex % 2 == 0 &&
                        columnIndex % 2 == 0)
                    {
                        _currentSystem[rowIndex, columnIndex] = Planet.Generate();
                    }
                    else
                    {
                        _currentSystem[rowIndex, columnIndex] = Planet.Space();
                    }
                }
            }
            // fill planet array with generated planets.
        }
        // methods.
    }
}
