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
		// fields.

		/// <summary>
		/// planet obj.
		/// </summary>
		/// <param name="planetName">name of planet.</param>
		/// <param name="planetDescription">description of planet.</param>
		public Planet(string planetName, string planetDescription)
		{
			_name = planetName;
			_description = planetDescription;
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

			string primaryName = primaryNames[random.Next(0, primaryNames.Length - 1)];
			string secondaryName = secondaryNames[random.Next(0, secondaryNames.Length - 1)];
			string generatedName = $"{primaryName}-{secondaryName}";
			string description = descriptions[random.Next(0, descriptions.Length - 1)];
			return new Planet(generatedName, description);
			// create and return a random planet obj.
		}
		// methods.
	}
}
