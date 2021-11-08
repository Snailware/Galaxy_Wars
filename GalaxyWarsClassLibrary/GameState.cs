using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxyWarsClassLibrary
{
	/// <summary>
	/// clas for saving all game info into database.
	/// </summary>
	public class GameState
	{
		public GameState(string actionStatement,
						 Player player,
						 List<Weapon> weapons,
						 List<Potion> potions,
						 List<Treasure> treasures,
						 List<Item> items,
						 List<Alien> aliens,
						 List<Planet> planets,
						 Planet[] currentSystem)
		{
			ActionStatement = actionStatement;
			Player = player;
			Weapons = weapons;
			Potions = potions;
			Treasures = treasures;
			Items = items;
			Aliens = aliens;
			Planets = planets;
			CurrentSystem = currentSystem;
		}
		// constructors.

		public string ActionStatement { get; }
		public Player Player { get; }
		public List<Weapon> Weapons { get; }
		public List<Potion> Potions { get; }
		public List<Treasure> Treasures { get; }
		public List<Item> Items { get; }
		public List<Alien> Aliens { get; }
		public List<Planet> Planets { get; }
		public Planet[] CurrentSystem { get; }
		// props.
	}
}
