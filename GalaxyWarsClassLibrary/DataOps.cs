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
		/// source of planet data. "DB" for database, "FL" for file, "NA" for 
		/// not used yet.
		/// </summary>
		public static string PlanetSource { get; set; } = "NA";

		/// <summary>
		/// source of alien data. "DB" for database, "FL" for file, "NA" for 
		/// not used yet.
		/// </summary>
		public static string AlienSource { get; set; } = "NA";

		/// <summary>
		/// source of weapon data. "DB" for database, "FL" for file, "NA" for 
		/// not used yet.
		/// </summary>
		public static string WeaponSource { get; set; } = "NA";

		/// <summary>
		/// source of potion data. "DB" for database, "FL" for file, "NA" for 
		/// not used yet.
		/// </summary>
		public static string PotionSource { get; set; } = "NA";

		/// <summary>
		/// source of treasure data. "DB" for database, "FL" for file, "NA" for 
		/// not used yet.
		/// </summary>
		public static string TreasureSource { get; set; } = "NA";

		/// <summary>
		/// source of item data. "DB" for database, "FL" for file, "NA" for 
		/// not used yet.
		/// </summary>
		public static string ItemSource { get; set; } = "NA";

		/// <summary>
		/// source of save data. "DB" for database, "FL" for file, "NA" for 
		/// not used yet.
		/// </summary>
		public static string SaveSource { get; set; } = "NA";

		/// <summary>
		/// source of load data. "DB" for database, "FL" for file, "NA" for 
		/// not used yet.
		/// </summary>
		public static string LoadSource { get; set; } = "NA";
		// autoprops.

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
				PlanetSource = "DB";
			}
			catch
			{
				planets = FileOps.ReadPlanets(@"..\..\..\GalaxyWarsClassLibrary\ObjectData\Planets.csv");
				PlanetSource = "FL";
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
				AlienSource = "DB";
			}
			catch
			{
				aliens = FileOps.ReadAliens(@"..\..\..\GalaxyWarsClassLibrary\ObjectData\Aliens.csv");
				AlienSource = "FL";
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
				WeaponSource = "DB";
			}
			catch
			{
				weapons = FileOps.ReadWeapons(@"..\..\..\GalaxyWarsClassLibrary\ObjectData\Weapons.csv");
				WeaponSource = "FL";
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
				PotionSource = "DB";
			}
			catch
			{
				potions = FileOps.ReadPotions(@"..\..\..\GalaxyWarsClassLibrary\ObjectData\Potions.csv");
				PotionSource = "FL";
			}

			return potions;
		}

		/// <summary>
		/// get treasures from database. if database fails, get treasures from
		/// file.
		/// </summary>
		/// <returns>list of treasures.</returns>
		public static List<Treasure> GetTreasures()
		{
			List<Treasure> treasures;

			try
			{
				treasures = DatabaseOps.ReadTreasures();
				TreasureSource = "DB";
			}
			catch
			{
				treasures = FileOps.ReadTreasures(@"..\..\..\GalaxyWarsClassLibrary\ObjectData\Treasures.csv");
				TreasureSource = "FL";
			}

			return treasures;
		}

		/// <summary>
		/// get items from database. if database fails, get items from file.
		/// </summary>
		/// <returns>list of items.</returns>
		public static List<Item> GetItems()
		{
			List<Item> items;

			try
			{
				items = DatabaseOps.ReadItems();
				ItemSource = "DB";
			}
			catch
			{
				items = FileOps.ReadItems(@"..\..\..\GalaxyWarsClassLibrary\ObjectData\Items.csv");
				ItemSource = "FL";
			}

			return items;
		}

		/// <summary>
		/// save game to database. if database fails, get game from file.
		/// </summary>
		/// <returns>"success" if saved, otherwise error message. </returns>
		public static string SaveGame()
		{
			if (DatabaseOps.SaveGame() != "success")
			{
				SaveSource = "FL";
				return FileOps.SaveGame($@"..\..\..\GalaxyWarsClassLibrary\PlayerSaves\{Galaxy.Player.Name}.json");
			}
			else
			{
				SaveSource = "DB";
				return "success";
			}
		}

		/// <summary>
		/// load game from database. if database fails, get game from file.
		/// </summary>
		/// <param name="name">name of associated character.</param>
		/// <param name="password">password of associated character.</param>
		/// <returns>"success" if game is loaded, otherwise error message.</returns>
		public static string LoadGame(string name, string password)
		{
			if (DatabaseOps.AuthAndLoadGame(name, password) != "success")
			{
				LoadSource = "FL";
				return FileOps.AuthAndLoadGame(directory: $@"..\..\..\GalaxyWarsClassLibrary\PlayerSaves",
											   name: name,
											   password: password);
			}
			else
			{
				LoadSource = "DB";
				return "success";
			}
		}
		// methods.
	}
}
