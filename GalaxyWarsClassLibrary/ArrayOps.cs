using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxyWarsClassLibrary
{
	/// <summary>
	/// class for performing operations on arrays. 
	/// </summary>
	public static class ArrayOps
	{
		/// <summary>
		/// take 2D array and convert to 1D array.
		/// </summary>
		/// <param name="planetArray2D">2D array to be flattened.</param>
		/// <returns>1D array.</returns>
		public static Planet[] FlattenArray(Planet[,] planetArray2D)
		{
			List<Planet> flattenedList = new List<Planet>();
			// list to hold planets.

			for (int row = 0; row < planetArray2D.GetUpperBound(0); row++)
			{
				for (int column = 0; column < planetArray2D.GetUpperBound(1); column++)
				{
					flattenedList.Add(planetArray2D[row, column]);
				}
			}
			// iter over rows and columns, adding planets to list. 

			return flattenedList.ToArray();
			// convert list to array and return result. 
		}

		/// <summary>
		/// take 1D array and convert to 2D array.
		/// </summary>
		/// <param name="planetArray">1D array to be expanded.</param>
		/// <returns>2D array.</returns>
		public static Planet[,] ExpandArray(Planet[] planetArray)
		{
			Planet[,] expandedArray = new Planet[9, 7];
			// array to hold expanded output. 

			List<Planet> planetList = planetArray.ToList<Planet>();
			// convert input array to list. 

			for (int row = 0; row < expandedArray.GetUpperBound(0); row++)
			{
				for (int column = 0; column < expandedArray.GetUpperBound(1); column++)
				{
					expandedArray[row, column] = planetList[0];
					planetList.RemoveAt(0);
				}
			}
			// iter over rows and columns, adding planets to 2D array.

			return expandedArray;
			// return filled 2D array.
		}
	}
}
