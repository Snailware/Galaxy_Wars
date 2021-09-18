using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaxyWarsClassLibrary;

namespace ConsoleUI
{
	class Program
	{
		static void Main()
		{
			void StartGame()
			{
				const int Width = 76,
						  Height = 28;
				// console width and height, measured in characters.

				Console.SetWindowSize(Width, Height);
				Console.SetBufferSize(Width, Height);
				// set console window size for proper viewing. 

				RunStartMenuLoop();
			}
			// setup console window & start game.

			void CreateNewGameState()
			{
				Galaxy.ActionStatement = "ONLY YOU CAN SAVE THE GALAXY!";
				// set intro action statement. 

				Galaxy.Weapons.Add(new Weapon("Phasers",
											  "handheld personal defense weapon", 
											  2));

				Galaxy.Weapons.Add(new Weapon("Pulse Cannons",
											  "Cannon",
											  3));

				Galaxy.Weapons.Add(new Weapon("Disruptors", 
											 "powerful weapon that destroys hulls",
											 4));

				Galaxy.Weapons.Add(new Weapon("Assault Rifles", 
											  "A rifle capable of automatic fire.",
											  5));
				//Loaded weapons
				
				
				
				Galaxy.Potions.Add(new Potion("Kryptonite",
											  "Glowing green potion that infigurates you.",
											  5));

				Galaxy.Potions.Add(new Potion("Health Potion",
											  "A bright red potion that revitalizes you.",
											  10));
				//Loaded potions
				
				
				Galaxy.Treasures.Add(new Treasure("Silver Star",
												  "A valuable star made of pure silver.",
												  100));

				Galaxy.Treasures.Add(new Treasure("Black Star",
												  "A beautiful black star made of titanium.",
												  150));

				Galaxy.Treasures.Add(new Treasure("Iron Cross",
												  "A cross made of iron.",
												  200));
				//Loaded treasures

				
				Galaxy.Items.Add(new Item("Rusty Coin",
										  "An old coin with no value."));

				Galaxy.Items.Add(new Item("Childs Doll",
										  "A doll that reminds you of home."));

				Galaxy.Items.Add(new Item("Old Ring",
										  "A simple ring tarnished by time."));

				Galaxy.Items.Add(new Item("Strange Key",
										  "A key  to an unknown lock."));
				//Loaded items

				RunCharCreationMenuLoop();
				// create new character.

				Galaxy.LoadNewPlanets();
				foreach (Planet planet in Galaxy.Planets)
				{
					Galaxy.Aliens.Add(planet.Alien);
				}
				// TODO remove this if alien master list not required.
				// load fresh planets with aliens, while also filling list.
			}
			// generate game objects for new game.
			
			void RunStartMenuLoop()
			{
				string choice;
				// var for user input. 

				do
				{
					choice = CallStartMenu().ToLower();
				} while (choice != "new game" &&
						 choice != "continue" &&
						 choice != "about" &&
						 choice != "exit");
				// call main menu and get valid use input. 

				switch (choice)
				{
					case "new game":
						CreateNewGameState();
						RunGameplayLoop();
						break;
						// create new game state, create character and start playing.

					case "continue":
						//RunLoadCharMenuLoop();
						// TODO write path to load a saved character & gamestate from storage.
						break;
						// load character & game state from storage & start playing.

					case "about":
						CallAboutMenu();
						RunStartMenuLoop();
						break;
						// display about menu then return here.

					case "exit":
						Environment.Exit(0);
						break;
						// exit program.
				}
				// proceed according to user input.
			}
			// start menu loop & decision struct.

			void RunCharCreationMenuLoop()
			{
				bool valid = false;
				// var for user input. 

				do
				{
					try
					{
						CallCharCreationSequenceMenu();
						valid = true;
					}
					catch
					{
						continue;
					}
				} while (!valid);
				// call menu and validate user input. 
			}
			// char creation menu loop.

			void RunGameplayLoop()
			{
				string[] tokenized_input;

				do
				{
					string input = CallGameplayFrame();
					// display frame & get input.

					tokenized_input = input.Split(null);
					// seperate input into array, delimited by white space.

					switch (tokenized_input[0])
					{
						case "go":
							switch (tokenized_input[1])
							{
								case "north":
									if (Galaxy.Player.Location < 4 &&
										Galaxy.Planets[Galaxy.Player.Location].Alien.Health == 0)
									{
										Galaxy.ActionStatement = "YOU GO NORTH.";
										Galaxy.Player.Location++;
									} 
									else if (Galaxy.Player.Location < 4)
									{
										Galaxy.ActionStatement = $"YOU CANT PROCEED UNTIL YOU LIBERATE {Galaxy.Planets[Galaxy.Player.Location].Name} FROM {Galaxy.Planets[Galaxy.Player.Location].Alien.Name}";
									}
									else if (Galaxy.Planets[Galaxy.Player.Location].Alien.Health == 0)
									{
										Galaxy.ActionStatement = "THERE ARE NO MORE PLANETS. GO SOUTH OR USE WARP TO TRAVEL FURTHER.";
									}
									break;
								// move character north if able. update
								// action statement accordingly.

								case "south":
									if (Galaxy.Player.Location > 0)
									{
										Galaxy.ActionStatement = "YOU GO SOUTH.";
										Galaxy.Player.Location++;
									}
									else
									{
										Galaxy.ActionStatement = "THERE ARE NO MORE PLANETS. GO NORTH OR USE WARP TO TRAVEL FURTHER.";
									}
									break;
								// move character south if able. update
								// action statement accordingly.

								case "east":
									Galaxy.ActionStatement = "THERE IS ONLY EMPTY SPACE THAT WAY.";
									break;
								// update action statement for attempted
								// eastward movement accordingly.

								case "west":
									Galaxy.ActionStatement = "THERE IS ONLY EMPTY SPACE THAT WAY.";
									break;
								// update action statement for attempted
								// westward movement accordingly.

								default:
									Galaxy.ActionStatement = "INVALID DIRECTION COMMAND.";
									break;
								// alert user to invalid direction input.
							}
							break;
						// handle GO commands.

						case "attack":
							if (Galaxy.Planets[Galaxy.Player.Location].Alien.Health > 0)
							{
								// TODO add combat call with player character & local alien.
								// TODO add increment to player score if alien is dead after combat.
							}
							else
							{
								Galaxy.ActionStatement = "ITS ALREADY DEAD. ONWARD!";
							}
							break;
						// handle ATTACK command.

						// TODO add case for WARP command.
						// TODO add case for LOOK command.
						// TODO add case for USE command.
						// TODO add case for PICKUP command.
						// TODO add case for DROP command.
						// TODO add case for HELP command.

						case "exit":
							break;
						// handle EXIT command.

						default:
							Galaxy.ActionStatement = "INVALID COMMAND.";
							break;
						// handle invalid commands.
					}
					// decision struct.

				} while (tokenized_input[0] != "exit");
			}
			// main gameplay loop & decision struct.

			void CallAboutMenu()
			{
				CallDynamicMenu(line1: "Fight hostile aliens to liberate occupied planets. Save",
								line2: "as many worlds as possible to earn a high score!",
								line6: "made by Adam Lancaster, Tracey Pinckney, Clarence Dews",
								prompt: "press [ENTER] to return");
				// display dynamic menu and wait for ENTER.
			}
			// display about menu & wait for response.

			void CallCharCreationSequenceMenu()
			{
				string charName = "",
					   charPassword = "",
					   charRace = "",
					   charClass = "";
				// character attribute vars.

				bool containsCapital = false,
					 containsLowercase = false,
					 containsSpecialChar = false;
				// valid password flags.

				charName = CallDynamicMenu(line1: $"NAME: {charName}",
										   line2: $"PASSWORD: {charPassword}",
										   line3: $"RACE: {charRace}",
										   line4: $"CLASS: {charClass}",
										   prompt: "enter NAME");
				// get name input.

				do
				{
					charPassword = CallDynamicMenu(line1: $"NAME: {charName}",
												   line2: $"PASSWORD: {charPassword}",
												   line3: $"RACE: {charRace}",
												   line4: $"CLASS: {charClass}",
												   prompt: "enter PASSWORD with 1 cap, 1 lowercase, & 1 special.");
					// get password input.

					foreach (char character in charPassword)
					{
						if (char.IsUpper(character))
						{
							containsCapital = true;
						}
						else if (char.IsLower(character))
						{
							containsLowercase = true;
						}
						else if (!char.IsLetterOrDigit(character))
						{
							containsSpecialChar = true;
						}
					}
					// check password for validity and set flags accordingly.

				} while (!containsCapital ||
						 !containsLowercase ||
						 !containsSpecialChar);
				// get validated password input.

				charRace = CallDynamicMenu(line1: $"NAME: {charName}",
										   line2: $"PASSWORD: {charPassword}",
										   line3: $"RACE: {charRace}",
										   line4: $"CLASS: {charClass}",
										   prompt: "enter RACE");
				// get race input.

				charClass = CallDynamicMenu(line1: $"NAME: {charName}",
											line2: $"PASSWORD: {charPassword}",
											line3: $"RACE: {charRace}",
											line4: $"CLASS: {charClass}",
											prompt: "enter CLASS");
				// get class input.

				Galaxy.Player = new Player(name: charName,
										   race: charRace,
										   playerClass: charClass,
										   password: charPassword,
										   health: 50,
										   location: 0,
										   score: 0,
										   weaponInventory: new List<Weapon> { Galaxy.Weapons[0] },
										   potionInventory: new List<Potion> { Galaxy.Potions[0] },
										   treasureInventory: new List<Treasure> {Galaxy.Treasures[0] },
										   itemInventory: new List<Item> { Galaxy.Items[0]});
				// create and store character object based on user input.
			}
			// display character creation menu & store created character.

			string CallStartMenu()
			{
				string[] startMenu =
				{
					@"                ___      _          .     __      __       .               ",
					@"   *   .       / __|__ _| |__ ___ ___  _  \ \    / /_ _ _ _ ___   .        ",
					@".         .   | (_ / _` | / _` \ \ / || |  \ \/\/ / _` | '_(_-<            ",
					@"        o      \___\__,_|_\__,_/_\_\\_, |   \_/\_/\__,_|_| /__/      .     ",
					@"         .              .           |__/           .                       ",
					@"          0     .                                                          ",
					@"    ,      .                 ,                ,    .             ,         ",
					@" .          \          .                         .                         ",
					@"     .       \   ,                                                         ",
					@"   .          o     .                 .                   .            .   ",
					@"          .    \                 ,             .                .          ",
					@"               #\##\#      .                              .        .       ",
					@"             #  #O##\###                .                        .         ",
					@"   .        #*#  #\##\###                       .                     ,    ",
					@"        .   ##*#  #\##\##               .                     .            ",
					@"      .      ##*#  #o##\#         .                             ,       .  ",
					@"          .     *#  #\#     .                    .             .          ,",
					@"                      \          .                         .               ",
					@"____^/\___^--____/\____O______________/\/\---/\___________---______________",
					@"   /\^   ^  ^    ^                  ^^ ^  '\ ^          ^       ---        ",
					@"       --           -            --  -      -         ---  __       ^      ",
					@"   --  __                      ___--  ^  ^                         --  __  ",
					@"+-------------------------------------------------------------------------+",
					@"|                                                                         |",
					@"|      NEW GAME            CONTINUE            ABOUT            EXIT      |",
					@"|                                                                         |",
					@"+-------------------------------------------------------------------------+"
				};
				// menu to display.

				string titleChars = @"_\/|`-(<,'";
				// characters in title ascii art to be displayed in special color. 

				for (int index = 0; index < startMenu.Length; index++)
				{
					foreach (char character in startMenu[index])
					{
						if (index < 6 && 
							titleChars.Contains(character))
						{
							Console.ForegroundColor = ConsoleColor.DarkRed;
						}
						else if (character == '#') 
						{
							Console.ForegroundColor = ConsoleColor.DarkYellow;
						}
						else if (character == '^')
						{
							Console.ForegroundColor = ConsoleColor.Magenta;
						}

						Console.Write(character);
						Console.ResetColor();
					}
					// display characters in different colors.

					Console.WriteLine();
					// write eol.
				}
				// print start menu and with styling. 

				return Console.ReadLine().ToLower();
				// get user input and return.
			}
			// display start menu & return user input.

			string CallGameplayFrame()
			{
				const int MaxLength = 30;
				const char Delimiter = ',';
				// consts.

				string pos1 = "O",
					   pos2 = "O",
					   pos3 = "O",
					   pos4 = "O",
					   pos5 = "O",
					   planetName = Galaxy.Planets[Galaxy.Player.Location].Name,
					   playerName = Galaxy.Player.Name,
					   playerClass = Galaxy.Player.PlayerClass,
					   alienName = Galaxy.Planets[Galaxy.Player.LocationX, Galaxy.Player.LocationY].Alien.Name,
					   score = Galaxy.Player.Score.ToString(),
					   planetPopulation = Galaxy.Planets[Galaxy.Player.LocationX, Galaxy.Player.LocationY].Population.ToString(),
					   playerHealth = Galaxy.Player.Health.ToString(),
					   alienHealth = Galaxy.Planets[Galaxy.Player.LocationX, Galaxy.Player.LocationY].Alien.Health.ToString(),
					   actionStatement = Galaxy.ActionStatement,
				// get state info and convert to string if needed.

				planetItems = ListOps.GetLimitedElements(items: Galaxy.Planets[Galaxy.Player.LocationX, Galaxy.Player.LocationY].Items,
														 delimiter: Delimiter,
														 maxLength: MaxLength),

				planetWeapons = ListOps.GetLimitedElements(weapons: Galaxy.Planets[Galaxy.Player.LocationX, Galaxy.Player.LocationY].Weapons,
													       delimiter: Delimiter,
													       maxLength: MaxLength),

				planetTreasures = ListOps.GetLimitedElements(treasures: Galaxy.Planets[Galaxy.Player.LocationX, Galaxy.Player.LocationY].Treasures,
															 delimiter: Delimiter,
															 maxLength: MaxLength),

				planetPotions = ListOps.GetLimitedElements(potions: Galaxy.Planets[Galaxy.Player.LocationX, Galaxy.Player.LocationY].Potions,
														   delimiter: Delimiter,
														   maxLength: MaxLength);
				// get display-ready lists.


				for (int rowIndex = 0; rowIndex < Galaxy.Planets.GetUpperBound(0); rowIndex++)
				{
					string result = "";
					// var for resulting string of symbols.

					for (int columnIndex = 0; columnIndex < Galaxy.Planets.GetUpperBound(1); columnIndex++)
					{
						if (Galaxy.Planets[rowIndex, columnIndex].Name == "Space")
						{
							result = $"{result} ";
						}
						else if (Galaxy.Planets[rowIndex, columnIndex].Alien.Health > 0)
						{
							result = $"{result}O";
						}
						else if (Galaxy.Planets[rowIndex, columnIndex].Alien.Health == 0)
						{
							result = $"{result}0";
						}
						else if (Galaxy.Player.LocationX == columnIndex && 
								 Galaxy.Player.LocationY == rowIndex)
						{
							result = $"{result}^";
						}
					}
					// create string of symbols representing object positions.

					map[rowIndex] = result;
					// insert resulting string into map array at correct position.
				}
				// fill map array with appropriate symbols.

				score = String.Format("{0, 3}", score);							//
				planetName = String.Format("{0, -30}", planetName);				//
				planetPopulation = String.Format("{0, -18}", planetPopulation);	//
				planetItems = String.Format("{0, -30}", planetItems);			//
				planetWeapons = String.Format("{0, -30}", planetWeapons);		//
				planetTreasures = String.Format("{0, -30}", planetTreasures);	//
				planetPotions = String.Format("{0, -30}", planetPotions);		//
				actionStatement = String.Format("{0, -75}", actionStatement);	//
				playerName = String.Format("{0, -75}", playerName);				//
				playerClass = String.Format("{0, -18}", playerClass);			//
				playerHealth = String.Format("{0, -14}", playerHealth);			//					
				alienHealth = String.Format("{0, 13}", alienHealth);			//
				alienName = String.Format("{0, 30}", alienName);				//
				// format strings for proper display. 

				string[] mainGameFrame =
				{
					@"                                GALAXY WARS                                ",		// 1
					$"     .                           SCORE: {score}       ,                        ",
					@"            *                          ,                      .            ",
					@"PLANET    ,              .                      .                     ALIEN",
					$"{planetName}       ,       {alienName}",											// 5
					$"{planetPopulation}    ,                            *          {alienHealth}",
					@"   .                                                      .                ",
					@"LOCAL ITEMS    ,                               .                        ,  ",
					$"{planetItems}                                       COURSE",
					$"                        *                                ,          {map[8]}",	// 10
					$"LOCAL WEAPONS    .                  .                               {map[7]}",
					$"{planetWeapons}                                       {map[6]}",
					$" ,                                       ,      .                   {map[5]}",
					$"LOCAL TREASURES          .                                 .        {map[4]}",
					$"{planetTreasures}                                      {map[3]}",					// 15
					$"          .                        .             *                  {map[2]}",
					$"LOCAL POTIONS               ,                         .             {map[1]}",
					$"{planetPotions}                                      {map[0]}",
					@".                                 *                             ,          ",
					@"               ,                             .         .                   ",		// 20
					@"---------------------------------------------------------------------------",
					$"{actionStatement}",
					@"---------------------------------------------------------------------------",
					$"{playerName}",
					$"{playerClass}  ENTER A COMMAND, OR 'HELP' FOR INFO                    ",			// 25
					$"{playerHealth}                                                             ",
					@"---------------------------------------------------------------------------"		// 27
				};
				// main gameplay frame.

				foreach (string line in mainGameFrame)
				{
					foreach (char character in line)
					{
						if (character == '*')
						{
							Console.ForegroundColor = ConsoleColor.DarkYellow;
						}
						else if (character == '^')
						{
							Console.ForegroundColor = ConsoleColor.Green;
						}
						Console.Write(character);
						Console.ResetColor();
					}
					Console.WriteLine();
				}
				// display frame with styling.

				return Console.ReadLine().ToLower();
				// get input and convert to lowercase. 
			}
			// display gameplay frame & get user input.
			
			string CallDynamicMenu(string line1 = "",
								   string line2 = "",
								   string line3 = "",
								   string line4 = "",
								   string line5 = "",
								   string line6 = "",
								   string line7 = "",
								   string prompt = "")
			{ 
				if (line1.Length > 57 || 
					line2.Length > 57 ||
					line3.Length > 57 ||
					line4.Length > 57 ||
					line5.Length > 57 ||
					line6.Length > 57 ||
					line7.Length > 57 ||
					prompt.Length > 57)
				{
					throw new Exception("an arg exceeds char limit of 57.");
				}
				// throw exception if any args exceed intended length.

				line1 = String.Format("{0, -57}", line1);
				line2 = String.Format("{0, -57}", line2);
				line3 = String.Format("{0, -57}", line3);
				line4 = String.Format("{0, -57}", line4);
				line5 = String.Format("{0, -57}", line5);
				line6 = String.Format("{0, -57}", line6);
				line7 = String.Format("{0, -57}", line7);
				prompt = String.Format("{0, -57}", prompt);
				// format all strings for appropriate viewing.

				string[] dynamicMenu =
				{
					@"                       .                                           ,       ", // 1
					@"        .                         ,            .              .            ",
					@" ,                .                 .                                      ",
					@"         .                 *                ,          .                   ",
					@"              ,                                                     .      ", // 5
					$"    *    {line1}         ",
					@"  .                   .       ,                 .                     .    ",
					$"      .  {line2}         ",
					@"       ,                                 ,                       .         ",
					$"         {line3}      *  ",													// 10
					@"    .                    .         .                   ,             ,     ",
					$"         {line4}         ",
					@",                .                    ,                     .           .  ",
					$"         {line5}         ",
					@"        .                         ,            .       *      .            ", // 15
					$" ,       {line6}   ,     ",
					@"         .                 *                ,          .                   ",
					$"         {line7}     ,   ",
					@"       .                                           ,                       ",
					@"                                .                            .             ", // 20
					@"             .        ,                    .                               ",
					@"    ,                                             ,                  ,     ",
					@"+-------------------------------------------------------------------------+",
					@"|                                                                         |",
					$"|        {prompt}        |",													// 25
					@"|                                                                         |",
					@"+-------------------------------------------------------------------------+"  // 27
				};
				// menu to display. 

				foreach (string line in dynamicMenu)
				{
					foreach (char character in line)
					{
						if (char.IsLetterOrDigit(character))
						{
							Console.ForegroundColor = ConsoleColor.Green;
						}
						else if (character == '*')
						{
							Console.ForegroundColor = ConsoleColor.DarkYellow;
						}
						// set color for character.

						Console.Write(character);
						Console.ResetColor();
						// write character and reset color for next iter.
					}
					// write styled line of menu.

					Console.WriteLine();
					// write eol.
				}
				// display dynamic menu with styling.

				return Console.ReadLine();
				// get input, format as lowercase and return.
			}
			// display dynamic menu with desired info and prompt.

			StartGame();
		}
	}
}

