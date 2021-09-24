using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxyWarsClassLibrary
{
	// class for handling combat.
	public static class Combat
	{
		/// <summary>
		/// method for doing combat between player and local alien.
		/// </summary>
		/// <returns></returns>
		public static string StandardCombat()
		{
			int playerStartingHealth = Galaxy.Player.Health,
				alienStartingHealth = Galaxy.CurrentSystem[Galaxy.Player.LocationY, Galaxy.Player.LocationX].Alien.Health;

			Random random = new Random();
			// random number generator.

			Galaxy.CurrentSystem[Galaxy.Player.LocationY, Galaxy.Player.LocationX].Alien.Health -= Galaxy.Player.Weapon.Damage + random.Next(0, 3) - 
																								   Galaxy.CurrentSystem[Galaxy.Player.LocationY, Galaxy.Player.LocationX].Alien.Armor;
			// player attacks enemy. 

			string combatSummary = $"{Galaxy.CurrentSystem[Galaxy.Player.LocationY, Galaxy.Player.LocationX].Alien.Name} TAKES {alienStartingHealth - Galaxy.CurrentSystem[Galaxy.Player.LocationY, Galaxy.Player.LocationX].Alien.Health} DMG.";
			// add data to summary for player attack.

			if (Galaxy.CurrentSystem[Galaxy.Player.LocationY, Galaxy.Player.LocationX].Alien.Health > 0)
			{
				Galaxy.Player.Health -= Galaxy.CurrentSystem[Galaxy.Player.LocationY, Galaxy.Player.LocationX].Alien.Weapon.Damage + random.Next(0, 3) -
										Galaxy.Player.Armor;
				// alien attacks player.

				combatSummary = $"{combatSummary} YOU TAKE {playerStartingHealth - Galaxy.Player.Health} DMG.";
				// append info to combatSummary statement.
			}
			// if alien survives player attack, they will attack the player in return.
			// also appends alien attack data to combat summary.

			else
			{
				combatSummary = $"{combatSummary} {Galaxy.CurrentSystem[Galaxy.Player.LocationY, Galaxy.Player.LocationX].Alien.Name} DEFEATED!";
			}
			// if alien dies, alert player.

			return combatSummary;
			// return summary of combat.
		}
	}
}
