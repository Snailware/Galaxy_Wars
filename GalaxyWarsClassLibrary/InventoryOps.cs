using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxyWarsClassLibrary
{
	/// <summary>
	/// class for performing inventory operations.
	/// </summary>
	public static class InventoryOps
	{
		/// <summary>
		/// get item objects from list.
		/// </summary>
		/// <param name="inventory">inventory to search.</param>
		/// <returns>list of items.</returns>
		public static List<Item> GetItems(List<IInventory> inventory)
		{
			List<Item> items = new List<Item>();
			foreach (IInventory gameObject in inventory)
			{
				if (gameObject.GetType() == typeof(Item))
				{
					items.Add((Item)gameObject);
				}
			}
			return items;
		}

		/// <summary>
		/// get weapon objects from list.
		/// </summary>
		/// <param name="inventory">inventory to search.</param>
		/// <returns>list of weapons.</returns>
		public static List<Weapon> GetWeapons(List<IInventory> inventory)
		{
			List<Weapon> weapons = new List<Weapon>();
			foreach (IInventory gameObject in inventory)
			{
				if (gameObject.GetType() == typeof(Weapon))
				{
					weapons.Add((Weapon)gameObject);
				}
			}
			return weapons;
		}

		/// <summary>
		/// get potion objects from list.
		/// </summary>
		/// <param name="inventory">inventory to search.</param>
		/// <returns>list of potions.</returns>
		public static List<Potion> GetPotions(List<IInventory> inventory)
		{
			List<Potion> potions = new List<Potion>();
			foreach (IInventory gameObject in inventory)
			{
				if (gameObject.GetType() == typeof(Potion))
				{
					potions.Add((Potion)gameObject);
				}
			}
			return potions;
		}

		/// <summary>
		/// get treasure objects from list.
		/// </summary>
		/// <param name="inventory">inventory to search.</param>
		/// <returns>list of treasures.</returns>
		public static List<Treasure> GetTreasures(List<IInventory> inventory)
		{
			List<Treasure> treasures = new List<Treasure>();
			foreach (IInventory gameObject in inventory)
			{
				if (gameObject.GetType() == typeof(Treasure))
				{
					treasures.Add((Treasure)gameObject);
				}
			}
			return treasures;
		}
	}
}
