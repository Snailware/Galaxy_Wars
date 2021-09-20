using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxyWarsClassLibrary
{
    /// <summary>
    /// class for performing list operations.
    /// </summary>
    public static class ListOps
    {
        /// <summary>
        /// create a delimited string containing weapon names, up to desired
        /// length. if string length exceeds desired length, string will be
        /// truncated and "..." will be appended.
        /// </summary>
        /// <param name="weapons">list of weapons.</param>
        /// <param name="delimiter">character to seperate weapon names.</param>
        /// <param name="maxLength">max length of string.</param>
        /// <returns>delimited string of weapon names.</returns>
        public static string GetLimitedElements(List<Weapon> weapons, char delimiter, int maxLength)
        {
            List<string> nameList = new List<string>();
            foreach (Weapon weapon in weapons)
            {
                nameList.Add(weapon.Name);
            }
            // create and fill list with weapon names.

            return GetStrings(nameList, delimiter, maxLength);
        }

        /// <summary>
        /// create a delimited string containing potion names, up to desired
        /// length. if string length exceeds desired length, string will be
        /// truncated and "..." will be appended.
        /// </summary>
        /// <param name="potions">list of potions.</param>
        /// <param name="delimiter">character to seperate potion names</param>
        /// <param name="maxLength">max length of string.</param>
        /// <returns>delimited string of potion names.</returns>
        public static string GetLimitedElements(List<Potion> potions, char delimiter, int maxLength)
        {
            List<string> nameList = new List<string>();
            foreach (Potion potion in potions)
            {
                nameList.Add(potion.Name);
            }
            // create and fill list with potion names.

            return GetStrings(nameList, delimiter, maxLength);
        }

        /// <summary>
        /// create a delimited string containing treasure names, up to desired
        /// length. if string length exceeds desired length, string will be
        /// truncated and "..." will be appended.
        /// </summary>
        /// <param name="treasures">list of treasures.</param>
        /// <param name="delimiter">character to seperate treasure names.</param>
        /// <param name="maxLength">max length of string.</param>
        /// <returns>delimited string of treasure names.</returns>
        public static string GetLimitedElements(List<Treasure> treasures, char delimiter, int maxLength)
        {
            List<string> nameList = new List<string>();
            foreach (Treasure treasure in treasures)
            {
                nameList.Add(treasure.Name);
            }
            // create and fill list with treasure names.

            return GetStrings(nameList, delimiter, maxLength);
        }

        /// <summary>
        /// create a delimited string containing item names, up to desired
        /// length. if string length exceeds desired length, string will be
        /// truncated and "..." will be appended.
        /// </summary>
        /// <param name="items">list of items.</param>
        /// <param name="delimiter">character to seperate item names.</param>
        /// <param name="maxLength">max length of string.</param>
        /// <returns>delimited string of item names.</returns>
        public static string GetLimitedElements(List<Item> items, char delimiter, int maxLength)
        {
            List<string> nameList = new List<string>();
            foreach (Item item in items)
            {
                nameList.Add(item.Name);
            }
            // create and fill list with item names.

            return GetStrings(nameList, delimiter, maxLength);
        }

        /// <summary>
        /// create a delimited string containing names, up to desired length.
        /// if string length exceeds desired length, string will be
        /// truncated and "..." will be appended.
        /// </summary>
        /// <param name="names">lkist of object names.</param>
        /// <param name="delimiter">character to seperate object names.</param>
        /// <param name="maxLength">max length of string.</param>
        /// <returns>delimited string of names.</returns>
        private static string GetStrings(List<string> names, char delimiter, int maxLength)
        {
            string output = "";
            for (int index = 0; index < names.Count; index++)
            {
                if (output.Length + names[index].Length + 7 <= maxLength)
                {
                    output = output.Insert(-1, names[index]);
                    if (index != names.Count - 1)
                    {
                        output = output.Insert(-1, $"{delimiter} ");
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    output = output.Insert(-1, "...");
                    break;
                }
            }
            // create string according to user input.

            return output.ToUpper();
            // capitalize and return output string.
        }
    }
}
