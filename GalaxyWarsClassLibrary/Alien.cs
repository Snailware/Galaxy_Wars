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
		/// <param name="armor">armor rating of alien.</param>
		/// <param name="money">amount of money alien has.</param>
		/// <param name="weaponInventory">weapon inventory of alien.</param>
		/// <param name="potionInventory">potion inventory of alien.</param>
		/// <param name="treasureInventory">treasure inventory of alien.</param>
		/// <param name="itemInventory">item inventory of alien.</param>
		public Alien(string name,
					 string description, 
					 int health,
					 int armor,
					 int money,
					 List<Weapon> weaponInventory,
					 List<Potion> potionInventory,
					 List<Treasure> treasureInventory,
					 List<Item> itemInventory)
		{
			_name = name;
			_description = description;
			_health = health;
			_armor = armor;
			_money = money;
			_weaponInventory = weaponInventory;
			_weapon = _weaponInventory[0];
			_potionInventory = potionInventory;
			_treasureInventory = treasureInventory;
			_itemInventory = itemInventory;
		}

		/// <summary>
		/// alien class derived from lifeform.
		/// </summary>
		/// <param name="name">name of alien.</param>
		/// <param name="description">description of alien.</param>
		/// <param name="health">health points of alien.</param>
		/// <param name="armor">armor rating of alien.</param>
		/// <param name="money">amount of money alien has.</param>
		public Alien(string name,
					 string description,
					 int health,
					 int armor,
					 int money)
		{
			_name = name;
			_description = description;
			_health = health;
			_armor = armor;
			_money = money;

			_weaponInventory = new List<Weapon>();
			_potionInventory = new List<Potion>();
			_treasureInventory = new List<Treasure>();
			_itemInventory = new List<Item>();
			// create default lists.

			Random random = new Random();
			// random number generator.

			int weaponSeed = random.Next(0, Galaxy.Weapons.Count);
			_weaponInventory.Add(Galaxy.Weapons[weaponSeed]);
			_weapon = _weaponInventory[0];
			// give alien random weapon and equip it.

			int lootSeed = random.Next(0, 4);
			switch (lootSeed)
			{
				case 0:
					lootSeed = random.Next(0, Galaxy.Potions.Count);
					_potionInventory.Add(Galaxy.Potions[lootSeed]);
					break;
					// generate a random potion and add to inventory.

				case 1:
					lootSeed = random.Next(0, Galaxy.Treasures.Count);
					_treasureInventory.Add(Galaxy.Treasures[lootSeed]);
					break;
					// generate a random treasure and add to inventory.

				case 2:
					lootSeed = random.Next(0, Galaxy.Items.Count);
					_itemInventory.Add(Galaxy.Items[lootSeed]);
					break;
					// generate a random item and add to inventory.

				default:
					break;
					// leave all loot inventories empty.
			}
			// give alien loot. (low chance of no loot)
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
		/// generate & return a semi random alien obj.
		/// </summary>
		/// <returns>randomized alien obj.</returns>
		public static Alien Generate()
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
				"a cyborg, she is more machine than person. ruthless and efficient.",
				"a humanoid freedom fighter from an occupied world.",
				"a shape shifter, capable of fantastic feats when transformed.",
				"a humanoid terrorist leader who rejects all authority but their own.",
				"a powerful humanoid ancient, whos power knows no bounds.",
				"a mechanical zealot, bent on domination at all costs.",
				"a large humanoid robot. a steadfast protecter of its kind.",
				"a cat-like humanoid. proud and strong, they will not falter.",
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
				"a giant black dragon, it has devoured countless souls.",
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

			return new Alien(name: names[random.Next(0, names.Length - 1)],
							 description: descriptions[random.Next(0, descriptions.Length - 1)],
							 health: random.Next(MinHealth, MaxHealth),
							 weaponInventory: new List<Weapon> { Galaxy.Weapons[random.Next(0, Galaxy.Weapons.Count - 1)] },
							 potionInventory: potionLoot,
							 treasureInventory: treasureLoot,
							 itemInventory: itemLoot);
			// create new alien according to constraints and return obj.
		}
		// methods.
	}
}
