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
		private static List<Planet> _planets;
		private static List<Weapon> _weapons;
		private static List<Potion> _potions;
		private static List<Treasure> _treasures;
		private static List<Item> _items;
		private static List<Alien> _aliens;
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
		/// Planets in current system.
		/// </summary>
		public static List<Planet> Planets
		{
			get { return _planets; }
		}

		/// <summary>
		/// all weapons in game.
		/// </summary>
		public static List<Weapon> Weapons
		{
			get { return _weapons; }
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
		/// statement describing most recent occurance.
		/// </summary>
		public static string ActionStatement
		{
			get { return _actionStatement; }
			set { _actionStatement = value; }
		}
		// props.

		/// <summary>
		/// load 5 freshly generated planets into planet list and reset player position.
		/// </summary>
		public static void DiscoverPlanets()
		{
			_planets.Clear();
			for(int index = 0; index < 5; index++)
			{
				_planets.Add(Planet.Generate());
			}
			Player.Location = 0;
		}
		// TODO move this.
		// methods.
	}
}
