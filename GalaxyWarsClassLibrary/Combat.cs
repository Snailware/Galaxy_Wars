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
			// get player and alien starting health for value return. 

			Random random = new Random();
			// random number generator.

			int damageTotal = Galaxy.Player.Weapon.AmtOfDamage - Galaxy.CurrentSystem[Galaxy.Player.LocationY, Galaxy.Player.LocationX].Alien.Armor;
			switch (Galaxy.Player.Weapon.DamageType)
			{
				case "Elemental":
					damageTotal += random.Next(0, 2);
					break;
				case "Projectile":
					damageTotal += random.Next(1, 3);
					break;
				case "Disintegrate":
					damageTotal += random.Next(2, 4);
					break;
				case "Rifle":
					damageTotal += random.Next(4, 6);
					break;
				case "Sword":
					damageTotal += random.Next(6, 8);
					break;
				case "Blade":
					damageTotal += random.Next(7, 10);
					break;
				case "Impale":
					damageTotal += random.Next(8, 11);
					break;
				case "Chemical":
					damageTotal += random.Next(9, 12);
					break;
				case "Fire":
					damageTotal += random.Next(10, 12);
					break;
				case "Heavyduty":
					damageTotal += random.Next(11, 14);
					break;
				case "Crystal":
					damageTotal += random.Next(12, 14);
					break;
				case "SwordSpear":
					damageTotal += random.Next(13, 15);
					break;
			}
			Galaxy.CurrentSystem[Galaxy.Player.LocationY, Galaxy.Player.LocationX].Alien.Health -= damageTotal;
			// player attacks enemy. 

			string combatSummary = $"{Galaxy.CurrentSystem[Galaxy.Player.LocationY, Galaxy.Player.LocationX].Alien.Name} TAKES {alienStartingHealth - Galaxy.CurrentSystem[Galaxy.Player.LocationY, Galaxy.Player.LocationX].Alien.Health} DMG.";
			// add data to summary for player attack.

			if (Galaxy.CurrentSystem[Galaxy.Player.LocationY, Galaxy.Player.LocationX].Alien.Health > 0)
			{
				Galaxy.Player.Health -= Galaxy.CurrentSystem[Galaxy.Player.LocationY, Galaxy.Player.LocationX].Alien.Weapon.AmtOfDamage + random.Next(0, 3) -
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
