using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GalaxyWarsClassLibrary
{
    /// <summary>
    /// class for perfroming operations on files.
    /// </summary>
    public static class FileOps
    {
        /// <summary>
        /// Read planets csv file and create planets based on data.
        /// </summary>
        /// <param name="filePath">path to csv file.</param>
        /// <returns>list of planet objects.</returns>
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

        /// <summary>
        /// Read aliens csv file and create aliens based on data.
        /// </summary>
        /// <param name="filePath">path to csv file.</param>
        /// <returns>list of alien objects.</returns>
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
            // return list of aliens.
        }

        /// <summary>
        /// Read weapons csv file and create weapons based on data.
        /// </summary>
        /// <param name="filePath">path to csv file.</param>
        /// <returns>list of weapon objects.</returns>
        public static List<Weapon> ReadWeapons(string filePath)
        {
            int lineNumber = 0;
            char[] delimiters = { ',' };
            StreamReader weaponFile;
            List<Weapon> results = new List<Weapon>();

            weaponFile = File.OpenText(filePath);
            // open weapon csv file.

            do
            {
                string roughWeapon = weaponFile.ReadLine();
                // get input.

                if (lineNumber == 0)
                {
                    lineNumber++;
                    continue;
                }
                // skip processing first line containing headings. 

                string[] weaponTokens = roughWeapon.Split(delimiters);
                // tokenize line.

                Weapon weapon = new Weapon(name: weaponTokens[0],
                                          description: weaponTokens[1],
                                          price: int.Parse(weaponTokens[2]),
                                          quest: bool.Parse(weaponTokens[3]),
                                          damageType: weaponTokens[4],
                                          amtOfDamage: int.Parse(weaponTokens[5]));
                // create weapon from tokens. int.Parse is used instead of
                // int.TryParse because all values will be controlled by devs
                // and thus can be trusted to be accurate.  

                results.Add(weapon);
                // add weapon to list.

                lineNumber++;
                // increment lineNumber.

            } while (!weaponFile.EndOfStream);
            // read entire weapon csv file, creating list of weapons from 
            // contents.

            weaponFile.Close();
            // close file. 

            return results;
            // return list of weapons.
        }

        /// <summary>
        /// Read potions csv file and create potions based on data.
        /// </summary>
        /// <param name="filePath">path to csv file.</param>
        /// <returns>list of potion objects.</returns>
        public static List<Potion> ReadPotions(string filePath)
        {
            int lineNumber = 0;
            char[] delimiters = { ',' };
            StreamReader potionFile;
            List<Potion> results = new List<Potion>();

            potionFile = File.OpenText(filePath);
            // open potion csv file.

            do
            {
                string roughPotion = potionFile.ReadLine();
                // get input.

                if (lineNumber == 0)
                {
                    lineNumber++;
                    continue;
                }
                // skip processing first line containing headings. 

                string[] potionTokens = roughPotion.Split(delimiters);
                // tokenize line.

                Potion potion = new Potion(name: potionTokens[0],
                                          description: potionTokens[1],
                                          price: int.Parse(potionTokens[2]),
                                          quest: bool.Parse(potionTokens[3]),
                                          healthEffect: int.Parse(potionTokens[4]),
                                          damageEffect: int.Parse(potionTokens[5]));
                // create potion from tokens. int.Parse is used instead of
                // int.TryParse because all values will be controlled by devs
                // and thus can be trusted to be accurate.  

                results.Add(potion);
                // add potion to list.

                lineNumber++;
                // increment lineNumber.

            } while (!potionFile.EndOfStream);
            // read entire potion csv file, creating list of potions from 
            // contents.

            potionFile.Close();
            // close file. 

            return results;
            // return list of potions.
        }

        /// <summary>
        /// Read treasures csv file and create treasures based on data.
        /// </summary>
        /// <param name="filePath">path to csv file.</param>
        /// <returns>list of treasure objects.</returns>
        public static List<Treasure> ReadTreasures(string filePath)
        {
            int lineNumber = 0;
            char[] delimiters = { ',' };
            StreamReader treasureFile;
            List<Treasure> results = new List<Treasure>();

            treasureFile = File.OpenText(filePath);
            // open treasure csv file.

            do
            {
                string roughTreasure = treasureFile.ReadLine();
                // get input.

                if (lineNumber == 0)
                {
                    lineNumber++;
                    continue;
                }
                // skip processing first line containing headings. 

                string[] treasureTokens = roughTreasure.Split(delimiters);
                // tokenize line.

                Treasure treasure = new Treasure(name: treasureTokens[0],
                                                 description: treasureTokens[1],
                                                 price: int.Parse(treasureTokens[2]),
                                                 quest: bool.Parse(treasureTokens[3]));
                // create treasure from tokens. int.Parse is used instead of
                // int.TryParse because all values will be controlled by devs
                // and thus can be trusted to be accurate.  

                results.Add(treasure);
                // add treasure to list.

                lineNumber++;
                // increment lineNumber.

            } while (!treasureFile.EndOfStream);
            // read entire treasure csv file, creating list of treasures from 
            // contents.

            treasureFile.Close();
            // close file. 

            return results;
            // return list of treasures.
        }

        /// <summary>
        /// Read items csv file and create items based on data.
        /// </summary>
        /// <param name="filePath">path to csv file.</param>
        /// <returns>list of item objects.</returns>
        public static List<Item> ReadItems(string filePath)
        {
            int lineNumber = 0;
            char[] delimiters = { ',' };
            StreamReader itemFile;
            List<Item> results = new List<Item>();

            itemFile = File.OpenText(filePath);
            // open item csv file.

            do
            {
                string roughItem = itemFile.ReadLine();
                // get input.

                if (lineNumber == 0)
                {
                    lineNumber++;
                    continue;
                }
                // skip processing first line containing headings. 

                string[] itemTokens = roughItem.Split(delimiters);
                // tokenize line.

                Item item = new Item(name: itemTokens[0],
                                     description: itemTokens[1],
                                     price: int.Parse(itemTokens[2]),
                                     quest: bool.Parse(itemTokens[3]));
                // create item from tokens. int.Parse is used instead of
                // int.TryParse because all values will be controlled by devs
                // and thus can be trusted to be accurate.  

                results.Add(item);
                // add item to list.

                lineNumber++;
                // increment lineNumber.

            } while (!itemFile.EndOfStream);
            // read entire item csv file, creating list of items from 
            // contents.

            itemFile.Close();
            // close file. 

            return results;
            // return list of items.
        }

        /// <summary>
        /// save current character data to file.
        /// </summary>
        /// <param name="filePath">path to character file.</param>
        /// <returns>save status message.</returns>
        public static string SaveGame(string filePath)
        {
            string status;

            try
            {
                GameState gameState = new GameState(actionStatement: Galaxy.ActionStatement,
                                                    player: Galaxy.Player,
                                                    weapons: Galaxy.Weapons,
                                                    potions: Galaxy.Potions,
                                                    treasures: Galaxy.Treasures,
                                                    items: Galaxy.Items,
                                                    aliens: Galaxy.Aliens,
                                                    planets: Galaxy.Planets,
                                                    currentSystem: ArrayOps.FlattenArray(Galaxy.CurrentSystem));
                // create gamestate based on galaxy.

                string gameJson = JsonSerializer.Serialize(gameState);
                // convert game data to json.

                File.WriteAllText(filePath, gameJson);
                // create new file, write json game data then close.

                status = "success";
                // set status for success.
            } 
            catch (Exception ex)
            {
                status = ex.Message;
                // set status for failure adding excpetion message.
            }

            return status;
            // return save status. 
        }

        /// <summary>
        /// load current character data from file.
        /// </summary>
        /// <param name="filePath">path to character file.</param>
        /// <returns>load status message.</returns>
        public static string LoadGame(string filePath)
        {
            string status;

            try
            {
                string gameJson = File.ReadAllText(filePath);
                // open file, read all json text, then close.
                    
                GameState gameState = JsonSerializer.Deserialize<GameState>(gameJson);
                // parse state from json. 

                Galaxy.ActionStatement = gameState.ActionStatement;
                Galaxy.Player = gameState.Player;
                Galaxy.Weapons = gameState.Weapons;
                Galaxy.Potions = gameState.Potions;
                Galaxy.Treasures = gameState.Treasures;
                Galaxy.Items = gameState.Items;
                Galaxy.Aliens = gameState.Aliens;
                Galaxy.Planets = gameState.Planets;
                Galaxy.CurrentSystem = ArrayOps.ExpandArray(gameState.CurrentSystem);
                // load data to game. 

                status = "success";
                // set status for success.
            }
            catch (Exception ex)
            {
                status = ex.Message;
                // set status for failure adding excpetion message.
            }

            return status;
            // return load status.
        }

        /// <summary>
        ///  search directory for save file matching credentials.
        /// </summary>
        /// <param name="directory">directory to search for save files.</param>
        /// <param name="name">name of charater.</param>
        /// <param name="password">password of character.</param>
        /// <returns>file path of authorized file, or error message.</returns>
        public static string AuthAndLoadGame(string directory, string name, string password)
        {
            string output = "NO SAVE MATCHING CREDENTIALS.";

            try
            {
                string[] saveFiles = Directory.GetFiles(directory);

                foreach (string file in saveFiles)
                {
                    string gameJson = File.ReadAllText(file);
                    // open file, read all json text, then close.

                    GameState gameState = JsonSerializer.Deserialize<GameState>(gameJson);
                    // parse character from json.

                    if (name == gameState.Player.Name &&
                        password == gameState.Player.Password)
                    {
                        output = "success";
                        LoadGame(file);
                        break;
                    }
                    // if match is found, set file path and stop search.
                }
                // find character save file with matching creds.}
            } 
            catch (Exception ex)
            {
                output = ex.Message;
            }

            return output;
            // return results.
        }

        /// <summary>
        /// get database connection string from file.
        /// </summary>
        /// <param name="filePath">path to connection string file.</param>
        /// <returns>connection string.</returns>
        public static string GetConnectionString(string filePath)
        {
            string ConnectionString = File.ReadAllText(filePath);
            // read all text from file.

            return ConnectionString.Trim();
            // remove whitespace and return connection string.
        }
    }
}
