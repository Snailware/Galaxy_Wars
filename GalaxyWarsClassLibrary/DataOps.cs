using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxyWarsClassLibrary
{
	/// <summary>
	/// class for loading data from multiple sources. 
	/// </summary>
	public static class DataOps
	{
		/// <summary>
		/// get planets from database. if database fails, get planets from
		/// file.
		/// </summary>
		/// <returns>list of planets.</returns>
		public static List<Planet> GetPlanets()
		{
			List<Planet> planets;

			try
			{
				planets = DatabaseOps.ReadPlanets();
			}
			catch
			{
				planets = FileOps.ReadPlanets(@"..\..\..\GalaxyWarsClassLibrary\ObjectData\Planets.csv");
			}

			return planets;
		}

		/// <summary>
		/// get aliens from database. if database fails, get aliens from file.
		/// </summary>
		/// <returns>list of aliens.</returns>
		public static List<Alien> GetAliens()
		{
			List<Alien> aliens;

			try
			{
				aliens = DatabaseOps.ReadAliens();
			}
			catch
			{
				aliens = FileOps.ReadAliens(@"..\..\..\GalaxyWarsClassLibrary\ObjectData\Aliens.csv");
			}

			return aliens;
		}

		/// <summary>
		/// get weapons from database. if database fails, get weapons from
		/// file.
		/// </summary>
		/// <returns>list of weapons.</returns>
		public static List<Weapon> GetWeapons()
		{
			List<Weapon> weapons;

			try
			{
				weapons = DatabaseOps.ReadWeapons();
			}
			catch
			{
				weapons = FileOps.ReadWeapons(@"..\..\..\GalaxyWarsClassLibrary\ObjectData\Weapons.csv");
			}

			return weapons;
		}

		/// <summary>
		/// get potions from database. if database fails, get potions from
		/// file.
		/// </summary>
		/// <returns>list of potions.</returns>
		public static List<Potion> GetPotions()
		{
			List<Potion> potions;

			try
			{
				potions = DatabaseOps.ReadPotions();
			}
			catch
			{
				potions = FileOps.ReadPotions(@"..\..\..\GalaxyWarsClassLibrary\ObjectData\Potions.csv");
			}

			return potions;
		}

		/// <summary>
		/// get treasures from database. if database fails, get treasures from
		/// file.
		/// </summary>
		/// <returns></returns>
		public static List<Treasure> GetTreasures()
		{
			List<Treasure> treasures;

			try
			{
				treasures = DatabaseOps.ReadTreasures();
			}
			catch
			{
				treasures = FileOps.ReadTreasures(@"..\..\..\GalaxyWarsClassLibrary\ObjectData\Treasures.csv");
			}

			return treasures;
		}

		/// <summary>
		/// get items from database. if database fails, get items from file.
		/// </summary>
		/// <returns></returns>
		public static List<Item> GetItems()
		{
			List<Item> items;

			try
			{
				items = DatabaseOps.ReadItems();
			}
			catch
			{
				items = FileOps.ReadItems(@"..\..\..\GalaxyWarsClassLibrary\ObjectData\Items.csv");
			}

			return items;
		}
	}
}
