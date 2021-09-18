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
			string[] primaryNames =
			{
				"Glaxon",
				"Bleezor",
				"Romulus",
				"Gallifrey",
				"Cybertron",
				"Krypton,",
				"Mora",
				"Kepler",
				"Arda",
				"Iotov",
				"Silon",
				"Nivion",
				"Doth",
				"Elea",
				"Halcyon",
				"Nuna",
				"Erus",
				"Talara",
				"Erd",
				"Cryon",
				"Terra",
				"Bruma"
			};
			// potential primary names.

			string[] secondaryNames =
			{
				"Alpha",
				"Beta",
				"Gamma",
				"Delta",
				"Epsilon",
				"Zeta",
				"Eta",
				"Theta",
				"Iota",
				"Kappa",
				"Lambda",
				"Mu",
				"Nu",
				"Xi",
				"Omicron",
				"Pi",
				"Rho",
				"Sigma",
				"Tau",
				"Upsilon",
				"Phi",
				"Chi",
				"Psi",
				"Omega",
				"1",
				"2",
				"3",
				"4",
				"5",
				"6",
				"7",
				"8",
				"9"
			};
			// potential secondary names. 

			string[] descriptions =
			{
				"a bustling mining planet, rich with natural resources.",
				"a bleak, sparsely inhabited world.",
				"a gas giant surrounded by strange vessels.",
				"a small space station situated near a black hole.",
				"a small brutal planet, where only the strong survive.",
				"a lush forest planet brimming with wildlife.",
				"a densely populated planet, where everything is scarce.",
				"a dry planet, where life exists without moisture.",
				"a blue ocean planet. strange vessels glide over its surface.",
				"a frozen tundra planet. blizzards rage continuously.",
				"a peaceful planet, with a highly religious population.",
				"a dark, noxious planet. deadly spores blanket its surface.",
				"an ancient planet, inhabited by a powerful humanoid species.",
				"a massive trading outpost. many species do business here.",
				"a volcanic planet. much of its surface is covered by magma.",
				"an abandoned mining colony, now home to space pirates.",
				"a tropical planet, where many species seem to vacation.",
				"a ruined, wartorn planet. civil war has raged for generations.",
				"a mystical planet, where beings with strange powers rule.",
				"an aquatic planet, research stations lie below its waves.",
				"a prison space station, for the worst of the worst.",
				"a mysterious planet, whos inhabitants have long died."
			};
			// potential descriptions.

			Random random = new Random();
			// random nubmer generator.

			string primaryName = primaryNames[random.Next(0, primaryNames.GetUpperBound(0))];
			string secondaryName = secondaryNames[random.Next(0, secondaryNames.GetUpperBound(0))];
			string generatedName = $"{primaryName}-{secondaryName}";
			string description = descriptions[random.Next(0, descriptions.GetUpperBound(0))];
			int population = random.Next(3, 999999999);
			return new Planet(planetName: generatedName, 
							  planetDescription: description,
							  population: population,
							  alien: Alien.Generate());
			// create and return a random planet obj.
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
										new List<Weapon>(),
										new List<Potion>(),
										new List<Treasure>(),
										new List<Item>()));
		}
		// methods.
	}
}
