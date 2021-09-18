using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxyWarsClassLibrary
{
	public static class FileOps
	{
		public static List<Planet> ReadPlanets(string filePath)
		{
			int lineNumber = 0;
			char[] delimiters = { ',' };
			StreamReader planetFile;
			List<Planet> results = new List<Planet>();

			planetFile = File.OpenText(filePath); 
			// open planet csv file.

			do
			{
				string roughPlanet = planetFile.ReadLine();
				// get input.

				if (lineNumber == 0)
				{
					lineNumber++;
					continue;
				}
				// skip processing first line containing headings. 

				string[] planetTokens = roughPlanet.Split(delimiters);
				// tokenize line.

				Planet planet = new Planet(planetName: planetTokens[0],
										   planetDescription: planetTokens[1],
						                   population: int.Parse(planetTokens[2]),
						                   alien: Alien.Generate());
				// create planet from tokens. int.Parse is used instead of
				// int.TryParse because all values will be controlled by devs
				// and thus can be trusted to be accurate.  

				results.Add(planet);
				// add planet to list.

				lineNumber++;
				// increment lineNumber.

			} while (!planetFile.EndOfStream);
			// read entire planet csv file, creating list of planets from 
			// contents.

			planetFile.Close();
			// close file. 

			return results;
			// return list of planets. 
		}

		public static List<Alien> ReadAliens(string filePath)
		{
			int lineNumber = 0;
			char[] delimiters = { ',' };
			StreamReader alienFile;
			List<Alien> results = new List<Alien>();

			alienFile = File.OpenText(filePath); 
			// open alien csv file.

			do
			{
				string roughAlien = alienFile.ReadLine();
				// get input.

				if (lineNumber == 0)
				{
					lineNumber++;
					continue;
				}
				// skip processing first line containing headings. 

				string[] alienTokens = roughAlien.Split(delimiters);
				// tokenize line.

				Alien alien = new Alien(name: alienTokens[0],
										description: alienTokens[1],
										health: int.Parse(alienTokens[2]),
										armor: int.Parse(alienTokens[3]),
										money: int.Parse(alienTokens[4]));
				// create alien from tokens. int.Parse is used instead of
				// int.TryParse because all values will be controlled by devs
				// and thus can be trusted to be accurate.  

				results.Add(alien);
				// add alien to list.

				lineNumber++;
				// increment lineNumber.

			} while (!alienFile.EndOfStream);
			// read entire alien csv file, creating list of aliens from 
			// contents.

			alienFile.Close();
			// close file. 

			return results;
			// return list of planets.
		}
	}
}
