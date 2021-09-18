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
		private static Planet[,] _planets = new Planet[9, 7]; // 9 rows, 7 columns
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
		}

		/// <summary>
		/// all treasures in game.
		/// </summary>
		public static List<Treasure> Treasures
		{
			get { return _treasures; }
		}

		/// <summary>
		/// all items in game.
		/// </summary>
		public static List<Item> Items
		{
			get { return _items; }
		}

		/// <summary>
		/// aliens in current system.
		/// </summary>
		public static List<Alien> Aliens
		{
			get { return _aliens; }
		}

		/// <summary>
		/// planets in current system.
		/// </summary>
		public static Planet[,] Planets
		{
			get { return _planets; }
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
		public static void LoadNewPlanets()
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
			 *		otherwise empty Space is created. 
			*/

			for (int rowIndex = 0; rowIndex < _planets.GetUpperBound(0); rowIndex++)
			{
				for (int columnIndex = 0; columnIndex < _planets.GetUpperBound(1); columnIndex++)
				{
					if (rowIndex % 2 == 0 &&
						columnIndex % 2 == 0)
					{
						_planets[rowIndex, columnIndex] = Planet.Generate();
					}
					else
					{
						_planets[rowIndex, columnIndex] = Planet.Space();
					}
				}
			}
			// fill planet array with generated planets.
		}
		// methods.
	}
}
