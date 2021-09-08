using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxyWarsClassLibrary
{
	/// <summary>
	/// alien class derived from lifeform.
	/// </summary>
	public class Alien : Lifeform
	{
		private string _description;
		// fields.

		/// <summary>
		/// alien class derived from lifeform.
		/// </summary>
		/// <param name="name">name of alien.</param>
		/// <param name="description">description of alien.</param>
		/// <param name="health">health points of alien.</param>
		/// <param name="location">location of alien. should refer to planets
		/// list subscript in Galaxy.</param>
		/// <param name="weapon">equipped weapon of alien.</param>
		/// <param name="potionInventory">potion inventory of alien.</param>
		/// <param name="treasureInventory">treasure inventory of alien.</param>
		/// <param name="itemInventory">item inventory of alien.</param>
		public Alien(string name,
					 string description, 
					 int health,
					 int location,
					 Weapon weapon,
					 List<Potion> potionInventory,
					 List<Treasure> treasureInventory,
					 List<Item> itemInventory)
		{
			_name = name;
			_description = description;
			_health = health;
			_location = location;
			_weapon = weapon;
			_potionInventory = potionInventory;
			_treasureInventory = treasureInventory;
			_itemInventory = itemInventory;
		}
		// constructors.

		/// <summary>
		/// description of alien.
		/// </summary>
		public string Description
		{
			get { return _description; }
		}
		// props.

		/// <summary>
		/// generate a semi random alien obj at the desired location.
		/// </summary>
		/// <param name="location">location to give generated alien.</param>
		/// <returns>randomized alien obj.</returns>
		public static Alien GenerateAt(int location)
		{
			const int MinHealth = 8,
					  MaxHealth = 13;
			// min and max health values to be generated. 

			string[] names =
			{
				"Tuvok",
				"Spock",
				"Seven",
				"Ro",
				"Odo",
				"Kira",
				"Gandalf",
				"Megatron",
				"Optimus",
				"Starscream",
				"Liono",
				"Snarf",
				"Thanos",
				"Roger",
				"Ebrietas",
				"Amygdala",
				"Artorias",
				"Sif",
				"Ornstein",
				"Havel",
				"Siegward",
				"Kalameet",
				"Manus",
				"Gwyn",
				"Solaire",
				"SHODAN"
			};
			// potential names.

			string[] descriptions =
			{
				"a humanoid officer. cold, logical, and highly intelligent.",
				"a scion to his people, his wisdom is known across the galaxy.",
				"a cyborg, more machine than person. ruthless and efficient.",
				"a humanoid freedom fighter from an occupied world.",
				"a shape shifter, capable of fantastic feats when transformed.",
				"a humanoid terrorist leader who rejects all authority but their own.",
				"a powerful humanoid ancient, whos power knows no bounds.",
				"a mechanical zealot, bent on domination at all costs.",
				"a large humanoid robot. a steadfast protecter of its kind.",
				"a cat-like humanoid. proud and strong, he will not falter.",
				"a small, furry creaure. it frequently repeats its own name.",
				"a large humanoid, driven mad and bent on destruction.",
				"a small pudgy thing, it insults you mercilessly.",
				"an ancient horror, revered by many as a God.",
				"a scorned giant with many eyes and arms, it delights in torture.",
				"a legendary humanoid warrior, known for facing impossible odds.",
				"a massive wolf-like creature. it will die before it surrenders.",
				"the humanoid captain of his lords knights, a fierce dragon slayer.",
				"a humanoid, also known as The Rock. his defenses are legendary.",
				"a plump humanoid, who values honor above all else.",
				"a giant black dragon, it has devoured countless poor souls.",
				"a twisted monster, and the father of an unstoppable abyss.",
				"The Father of Sunlight, he has sacrificed everything for power.",
				"a humble man, whose quest for sunlight drives him ever onward.",
				"an omnipotent AI, it will stop at nothing to impose its will."
			};
			// potential descriptions.

			List<Potion> potionLoot = new List<Potion>();
			List<Treasure> treasureLoot = new List<Treasure>();
			List<Item> itemLoot = new List<Item>();
			// lists for generated loot. 

			Random random = new Random();
			// random number generator.

			switch (random.Next(0,2))
			{
				case 0:
					potionLoot.Add(Galaxy.Potions[random.Next(0, Galaxy.Potions.Count - 1)]);
					break;
				case 1:
					treasureLoot.Add(Galaxy.Treasures[random.Next(0, Galaxy.Treasures.Count - 1)]);
					break;
				case 2:
					itemLoot.Add(Galaxy.Items[random.Next(0, Galaxy.Items.Count - 1)]);
					break;
			}
			// randomly add 1 piece of loot to inventory.

			return new Alien(names[random.Next(0, names.Length - 1)],
							 descriptions[random.Next(0, descriptions.Length - 1)],
							 random.Next(MinHealth, MaxHealth),
							 location,
							 Galaxy.Weapons[random.Next(0, Galaxy.Weapons.Count - 1)],
							 potionLoot,
							 treasureLoot,
							 itemLoot);
			// create new alien according to constraints and return obj.
		}
		// methods.
	}
}
