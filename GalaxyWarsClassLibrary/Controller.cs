using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxyWarsClassLibrary
{
	/// <summary>
	/// main controller for game. 
	/// </summary>
	public static class Controller
	{
		/// <summary>
		/// game context. context name == menu name. 
		/// </summary>
		public enum GameContext
		{
			Start,
			About,
			Help,
			Game,
			Debug,
			CreateCharName,
			CreateCharPassword,
			CreateCharRace,
			CreateCharClass,
			LoadCharName,
			LoadCharPassword
		}

		/// <summary>
		/// set context for starting game. 
		/// </summary>
		public static void StartGame()
		{
			Context = GameContext.Start;
		}

		/// <summary>
		/// update game state according to user input and context.
		/// </summary>
		/// <param name="input"></param>
		public static void Update(string input)
		{
			string userInput = input;
			// input stored to be processed.

			if (Context is GameContext.Start ||
				Context is GameContext.Game)
			{
				userInput = userInput.ToLower();
			}
			// format input to lowercase depending on context.

			string[] inputTokens = userInput.Split(null);
			// tokenize input string.

			if (inputTokens.Length is 0)
			{
				inputTokens = new string[] { "" };
			}
			// if array is empty, store new array with 1 blank entry.

			switch (Context)
			{
				#region start menu decision struct.
				case GameContext.Start:
					switch (inputTokens[0])
					{
						case "new":
							CreateNewGameState();
							Context = GameContext.CreateCharName;
							break;
						// go to new char name creation.

						case "load":
							CreateNewGameState();
							Context = GameContext.LoadCharName;
							break;
						// go to load char name input.

						case "help":
							Context = GameContext.Help;
							break;
						// go to help menu.

						case "about":
							Context = GameContext.About;
							break;
						// display about menu then return here.

						case "exit":
							Environment.Exit(0);
							break;
						// exit program.

						default:
							break;
					}
					break;
				#endregion

				#region about menu decision struct.
				case GameContext.About:
					if (string.IsNullOrWhiteSpace(inputTokens[0]))
					{
						Context = GameContext.Start;
					}
					break;
				#endregion

				#region help menu decision struct.
				case GameContext.Help:
					if (string.IsNullOrWhiteSpace(inputTokens[0]))
					{
						Context = GameContext.Start;
					}
					break;
				#endregion

				#region game menu decision struct.
				case GameContext.Game:
					switch (inputTokens[0])
					{
						#region 'go' decision struct.
						case "go":
							switch (inputTokens[1])
							{
								case "north":
									if (Galaxy.Player.LocationY < Galaxy.CurrentSystem.GetUpperBound(0) &&
										Galaxy.CurrentSystem[Galaxy.Player.LocationY, Galaxy.Player.LocationX].Alien.Health == 0)
									{
										Galaxy.ActionStatement = "YOU GO NORTH.";
										Galaxy.Player.LocationY++;
									}
									else if (Galaxy.Player.LocationY < Galaxy.CurrentSystem.GetUpperBound(0) &&
											 Galaxy.CurrentSystem[Galaxy.Player.LocationY, Galaxy.Player.LocationX].Alien.Health != 0)
									{
										Galaxy.ActionStatement = $"{Galaxy.CurrentSystem[Galaxy.Player.LocationY, Galaxy.Player.LocationX].Alien.Name} BLOCKS YOUR PATH.";
									}
									else
									{
										Galaxy.ActionStatement = "NO MORE PLANETS. GO SOUTH OR USE WARP TO TRAVEL FURTHER.";
									}
									break;
								// move character north if able. update
								// action statement accordingly.

								case "south":
									if (Galaxy.Player.LocationY > Galaxy.CurrentSystem.GetLowerBound(0) &&
										Galaxy.CurrentSystem[Galaxy.Player.LocationY, Galaxy.Player.LocationX].Alien.Health == 0)
									{
										Galaxy.ActionStatement = "YOU GO SOUTH.";
										Galaxy.Player.LocationY--;
									}
									else if (Galaxy.Player.LocationY < Galaxy.CurrentSystem.GetUpperBound(0) &&
											 Galaxy.CurrentSystem[Galaxy.Player.LocationY, Galaxy.Player.LocationX].Alien.Health != 0)
									{
										Galaxy.ActionStatement = $"{Galaxy.CurrentSystem[Galaxy.Player.LocationY, Galaxy.Player.LocationX].Alien.Name} BLOCKS YOUR PATH.";
									}
									else
									{
										Galaxy.ActionStatement = "NO MORE PLANETS. GO NORTH OR USE WARP TO TRAVEL FURTHER.";
									}
									break;
								// move character south if able. update
								// action statement accordingly.

								case "east":
									if (Galaxy.Player.LocationX < Galaxy.CurrentSystem.GetUpperBound(1) &&
										Galaxy.CurrentSystem[Galaxy.Player.LocationY, Galaxy.Player.LocationX].Alien.Health == 0)
									{
										Galaxy.ActionStatement = "YOU GO EAST.";
										Galaxy.Player.LocationX++;
									}
									else if (Galaxy.Player.LocationY < Galaxy.CurrentSystem.GetUpperBound(0) &&
											 Galaxy.CurrentSystem[Galaxy.Player.LocationY, Galaxy.Player.LocationX].Alien.Health != 0)
									{
										Galaxy.ActionStatement = $"{Galaxy.CurrentSystem[Galaxy.Player.LocationY, Galaxy.Player.LocationX].Alien.Name} BLOCKS YOUR PATH.";
									}
									else
									{
										Galaxy.ActionStatement = "NO MORE PLANETS. GO WEST OR USE WARP TO TRAVEL FURTHER.";
									}
									break;
								// move character east if able. update
								// action statement accordingly.

								case "west":
									if (Galaxy.Player.LocationX > Galaxy.CurrentSystem.GetLowerBound(1) &&
										Galaxy.CurrentSystem[Galaxy.Player.LocationY, Galaxy.Player.LocationX].Alien.Health == 0)
									{
										Galaxy.ActionStatement = "YOU GO WEST.";
										Galaxy.Player.LocationX--;
									}
									else if (Galaxy.Player.LocationY < Galaxy.CurrentSystem.GetUpperBound(0) &&
											 Galaxy.CurrentSystem[Galaxy.Player.LocationY, Galaxy.Player.LocationX].Alien.Health != 0)
									{
										Galaxy.ActionStatement = $"{Galaxy.CurrentSystem[Galaxy.Player.LocationY, Galaxy.Player.LocationX].Alien.Name} BLOCKS YOUR PATH.";
									}
									else
									{
										Galaxy.ActionStatement = "NO MORE PLANETS. GO EAST OR USE WARP TO TRAVEL FURTHER.";
									}
									break;
								// move character west if able. update
								// action statement accordingly.

								default:
									Galaxy.ActionStatement = "INVALID DIRECTION COMMAND.";
									break;
								// alert user to invalid direction input.
							}
							break;
						#endregion

						#region 'attack' decision struct.
						case "attack":
							if (Galaxy.CurrentSystem[Galaxy.Player.LocationY, Galaxy.Player.LocationX].Alien.Health > 0)
							{
								Galaxy.ActionStatement = Combat.StandardCombat();
								// perform combat.

								if (Galaxy.CurrentSystem[Galaxy.Player.LocationY, Galaxy.Player.LocationX].Alien.Health == 0)
								{
									Galaxy.Player.Score++;
									// increment score if player defeats alien.

									foreach (IInventory gameObject in Galaxy.CurrentSystem[Galaxy.Player.LocationY, Galaxy.Player.LocationX].Alien.Inventory)
									{
										Galaxy.CurrentSystem[Galaxy.Player.LocationY, Galaxy.Player.LocationX].Inventory.Add(gameObject);
									}
									// copy alien inv contents to planet inv.

									Galaxy.CurrentSystem[Galaxy.Player.LocationY, Galaxy.Player.LocationX].Alien.Inventory.Clear();
									// clear alien inv.

									Galaxy.CurrentSystem[Galaxy.Player.LocationY, Galaxy.Player.LocationX].Alien.Weapon = new Weapon(name: "none",
																																	 description: "unarmed",
																																	 price: 0,
																																	 quest: false,
																																	 damageType: "none",
																																	 amtOfDamage: 0);
									// set weapon for dead alien.

								}
								// transfer alien inventory to planet and increment score if alien dies during combat.
							}
							else
							{
								Galaxy.ActionStatement = "ITS ALREADY DEAD. ONWARD!";
							}
							break;
						#endregion

						#region 'warp' decision struct.
						case "warp":
							Treasure warpDrive = null;
							foreach (Treasure treasure in Galaxy.Treasures)
							{
								if (treasure.Name is "Warp Drive")
								{
									warpDrive = treasure;
									break;
								}
							}
							// get warp drive data from treasure list.

							if (Galaxy.Player.Inventory.Contains(warpDrive))
							{
								Galaxy.Player.Inventory.Remove(warpDrive); // TODO double ccheck this
								Galaxy.ActionStatement = "YOU WARPED TO A NEW SYSTEM!";
								Galaxy.LoadNewSystem();
							}
							// if found, warp player to new system and update action statement.
							else
							{
								Galaxy.ActionStatement = "NO WARP DRIVE IN INVENTORY.";
							}
							// if not found, alert user.

							break;
						#endregion

						// TODO add case for LOOK command.
						// TODO add case for USE command.
						// TODO add case for PICKUP command.
						// TODO add case for DROP command.

						#region 'save' case.
						case "save":
							Galaxy.ActionStatement = DataOps.SaveGame();
							break;
						#endregion

						#region 'debug' case.
						case "debug":
							Context = GameContext.Debug;
							break;
						#endregion

						#region 'help' case.
						case "help":
							Context = GameContext.Help;
							break;
						#endregion

						#region 'exit' case.
						case "exit":
							Context = GameContext.Start;
							break;
						#endregion

						#region default case.
						default:
							Galaxy.ActionStatement = "INVALID COMMAND.";
							break;
						#endregion
					}

					break;
				#endregion

				#region debug menu decision struct.
				case GameContext.Debug:
					if (string.IsNullOrWhiteSpace(inputTokens[0]))
					{
						Context = GameContext.Game;
					}
					break;
				#endregion

				#region character creation name entry decision struct.
				case GameContext.CreateCharName:
					if (!string.IsNullOrWhiteSpace(inputTokens[0]))
					{
						Galaxy.Player = new Player(inputTokens[0]);
						Context = GameContext.CreateCharPassword;
					}
					break;
				#endregion

				#region character creation password entry decision struct.
				case GameContext.CreateCharPassword:
					bool containsCapital = false,
						 containsLowercase = false,
						 containsSpecialChar = false;
					// valid password flags.

					foreach (char character in inputTokens[0])
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

					if (containsCapital && containsLowercase && containsSpecialChar)
					{
						Galaxy.Player.Password = inputTokens[0];
						Context = GameContext.CreateCharRace;
					}
					// assign valid password to new player & change context.

					break;
				#endregion

				#region character creation race entry decision struct.
				case GameContext.CreateCharRace:
					if (!string.IsNullOrWhiteSpace(inputTokens[0]))
					{
						Galaxy.Player.Race = inputTokens[0];
						Context = GameContext.CreateCharClass;
					}
					// assign race to new player & change context.
					break;
				#endregion

				#region character creation class entry decision struct.
				case GameContext.CreateCharClass:
					if (!string.IsNullOrWhiteSpace(inputTokens[0]))
					{
						Galaxy.Player.PlayerClass = inputTokens[0];
						Context = GameContext.Game;
					}
					// assign class to new player & change context.
					break;
				#endregion

				#region load character name entry decision struct.
				case GameContext.LoadCharName:
					if (!string.IsNullOrWhiteSpace(inputTokens[0]))
					{
						Galaxy.Player = new Player(inputTokens[0]);
						Context = GameContext.LoadCharPassword;
					}
					// store info temporarily in galaxy player obj & change
					// context.
					else if (inputTokens[0].ToLower() is "exit")
					{
						Context = GameContext.Start;
					}
					// exit to previous menu.
					break;
				#endregion

				#region load character password entry decision struct.
				case GameContext.LoadCharPassword:
					if (!string.IsNullOrWhiteSpace(inputTokens[0]))
					{
						Galaxy.Player.Password = inputTokens[0];
						// store password temporarily.
						
						if (DataOps.LoadGame(Galaxy.Player.Name, Galaxy.Player.Password) is "success")
						{
							Context = GameContext.Game;
						}
					}
					// store info temporarily in galaxy player obj & change 
					// context if creds match.
					else if (inputTokens[0].ToLower() is "exit")
					{
						Context = GameContext.Start;
					}
					// exit to previous menu.
					break;
				#endregion

				#region default case.
				default:
					break;
				#endregion
			}
			// game decision struct.
		}

		/// <summary>
		/// call frame for current context and game state.
		/// </summary>
		/// <returns>frame as list of strings. each list entry represents a
		/// line of frame. 
		/// </returns>
		public static List<string> CallFrame()
		{
			List<string> frame = null;
			// list for generated frame. 

			switch (Context)
			{
				#region start menu.
				case GameContext.Start:
					frame = new List<string>
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
						@"|      NEW           LOAD          HELP          ABOUT          EXIT      |",
						@"|                                                                         |",
						@"+-------------------------------------------------------------------------+"
					};
					break;
				#endregion

				#region about menu.
				case GameContext.About:
					frame = CallDynamicFrame(line1: "Fight hostile aliens to liberate occupied planets. Save",
											 line2: "as many worlds as possible to earn a high score!",
											 line6: "made by Adam Lancaster & Tracey Pinckney.",
											 prompt: "press [ENTER] to return");
					break;
				#endregion

				#region help menu.
				case GameContext.Help:
					frame = CallDynamicFrame(line1: "NAVIGATION: 'go <north/east/south/west>'",
											 line2: "INSPECT OBJECT: 'look <object name>'",
											 line3: "USE/PICKUP/DROP OBJECT: '<use/pickup/drop> <object name>'",
											 line4: "ATTACK: 'attack'",
											 line5: "WARP (if player has warp drive): 'warp'",
											 line7: "SAVE: 'save'          EXIT: 'exit'          HELP: 'help'",
											 prompt: "press [ENTER] to return");
					break;
				#endregion

				#region game menu.
				case GameContext.Game:
					const int MaxLength = 30;
					const char Delimiter = ',';
					// consts.

					string[] map = new string[9];
					// map array for course visualization.

					string planetName = Galaxy.CurrentSystem[Galaxy.Player.LocationY, Galaxy.Player.LocationX].Name,
						   playerName = Galaxy.Player.Name,
						   playerClass = Galaxy.Player.PlayerClass,
						   alienName = Galaxy.CurrentSystem[Galaxy.Player.LocationY, Galaxy.Player.LocationX].Alien.Name,
						   score = Galaxy.Player.Score.ToString(),
						   planetPopulation = Galaxy.CurrentSystem[Galaxy.Player.LocationY, Galaxy.Player.LocationX].Population.ToString(),
						   playerHealth = Galaxy.Player.Health.ToString(),
						   alienHealth = Galaxy.CurrentSystem[Galaxy.Player.LocationY, Galaxy.Player.LocationX].Alien.Health.ToString(),
						   actionStatement = Galaxy.ActionStatement,
						   planetItems = ListOps.GetLimitedElements(InventoryOps.GetItems(Galaxy.CurrentSystem[Galaxy.Player.LocationY, Galaxy.Player.LocationX].Inventory),
																	Delimiter,
																	MaxLength),
						   planetWeapons = ListOps.GetLimitedElements(InventoryOps.GetWeapons(Galaxy.CurrentSystem[Galaxy.Player.LocationY, Galaxy.Player.LocationX].Inventory),
																	  Delimiter,
																	  MaxLength),
						   planetTreasures = ListOps.GetLimitedElements(InventoryOps.GetTreasures(Galaxy.CurrentSystem[Galaxy.Player.LocationY, Galaxy.Player.LocationX].Inventory),
																		Delimiter,
																		MaxLength),
						   planetPotions = ListOps.GetLimitedElements(InventoryOps.GetPotions(Galaxy.CurrentSystem[Galaxy.Player.LocationY, Galaxy.Player.LocationX].Inventory),
																	  Delimiter,
																	  MaxLength);
					// get state info and convert to formatted strings if needed.

					for (int rowIndex = 0; rowIndex < Galaxy.CurrentSystem.GetLength(0); rowIndex++)
					{
						string result = "";
						// var for resulting string of symbols.

						for (int columnIndex = 0; columnIndex < Galaxy.CurrentSystem.GetLength(1); columnIndex++)
						{

							if (Galaxy.Player.LocationX == columnIndex &&
									 Galaxy.Player.LocationY == rowIndex)
							{
								result = $"{result}^";
							}
							else if (Galaxy.CurrentSystem[rowIndex, columnIndex].Name == "Space")
							{
								result = $"{result} ";
							}
							else if (Galaxy.CurrentSystem[rowIndex, columnIndex].Alien.Health > 0)
							{
								result = $"{result}O";
							}
							else if (Galaxy.CurrentSystem[rowIndex, columnIndex].Alien.Health == 0)
							{
								result = $"{result}0";
							}
							// display appropriate character based on object locations.
						}
						// create string of symbols representing object positions.

						map[rowIndex] = result;
						// insert resulting string into map array at correct position.
					}
					// fill map array with appropriate symbols.

					score = string.Format("{0, 3}", score);
					planetName = string.Format("{0, -30}", planetName);
					planetPopulation = string.Format("{0, -18}", planetPopulation);
					planetItems = string.Format("{0, -30}", planetItems);
					planetWeapons = string.Format("{0, -30}", planetWeapons);
					planetTreasures = string.Format("{0, -30}", planetTreasures);
					planetPotions = string.Format("{0, -30}", planetPotions);
					actionStatement = string.Format("{0, -75}", actionStatement);
					playerName = string.Format("{0, -75}", playerName);
					playerClass = string.Format("{0, -18}", playerClass);
					playerHealth = string.Format("{0, -14}", playerHealth);
					alienHealth = string.Format("{0, 13}", alienHealth);
					alienName = string.Format("{0, 30}", alienName);
					// format strings for proper display. 

					frame = new List<string>
					{
						@"                                GALAXY WARS                                ",		// 1
						$"     .                           SCORE: {score}       ,                        ",
						@"            *                          ,                      .            ",
						@"PLANET    ,              .                      .                     ALIEN",
						$"{planetName}       ,       {alienName}",											// 5
						$"{planetPopulation}    ,                            *          {alienHealth}",
						@"   .                                                      .                ",
						@"LOCAL ITEMS    ,                               .                        ,  ",
						$"{planetItems}                                        MAP",
						$"                        *                                ,          {map[8]}",	// 10
						$"LOCAL WEAPONS    .                  .                               {map[7]}",
						$"{planetWeapons}                                      {map[6]}",
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

					break;
				#endregion

				#region debug menu.
				case GameContext.Debug:
					frame = CallDynamicFrame(line1: $"Planet Source: {DataOps.PlanetSource}",
											 line2: $"Alien Source: {DataOps.AlienSource}",
											 line3: $"Weapon Source: {DataOps.WeaponSource}",
											 line4: $"Potion Source: {DataOps.PotionSource}",
											 line5: $"Treasure Source: {DataOps.TreasureSource}",
											 line6: $"Item Source: {DataOps.ItemSource}",
											 line7: $"Save Source: {DataOps.SaveSource}   Load Source: {DataOps.LoadSource}",
											 prompt: "press [ENTER] to return.");
					break;
				#endregion

				#region character creation name entry menu.
				case GameContext.CreateCharName:
					frame = CallDynamicFrame(line1: "NAME:",
											 line2: "PASSWORD:",
											 line3: "RACE:",
											 line4: "CLASS:",
											 prompt: "enter NAME");
					break;
				#endregion

				#region character creation password entry menu.
				case GameContext.CreateCharPassword:
					frame = CallDynamicFrame(line1: $"NAME: {Galaxy.Player.Name}",
											 line2: "PASSWORD:",
											 line3: "RACE:",
											 line4: "CLASS:",
											 prompt: "enter PASSWORD with 1 cap, 1 lowercase, & 1 special.");
					break;
				#endregion

				#region character creation race entry menu.
				case GameContext.CreateCharRace:
					frame = CallDynamicFrame(line1: $"NAME: {Galaxy.Player.Name}",
											 line2: $"PASSWORD: {Galaxy.Player.Password}",
											 line3: "RACE:",
											 line4: "CLASS:",
											 prompt: "enter RACE");
					break;
				#endregion

				#region character creation class entry menu.
				case GameContext.CreateCharClass:
					frame = CallDynamicFrame(line1: $"NAME: {Galaxy.Player.Name}",
											 line2: $"PASSWORD: {Galaxy.Player.Password}",
											 line3: $"RACE: {Galaxy.Player.Race}",
											 line4: "CLASS:",
											 prompt: "enter CLASS");
					break;
				#endregion

				#region load character name entry menu.
				case GameContext.LoadCharName:
					frame = CallDynamicFrame(line1: "NAME:",
											 line2: "PASSWORD:",
											 prompt: "ENTER NAME OR EXIT");
					break;
				#endregion

				#region load character password entry menu.
				case GameContext.LoadCharPassword:
					frame = CallDynamicFrame(line1: $"NAME: {Galaxy.Player.Name}",
											 line2: "PASSWORD:",
											 prompt: "ENTER PASSWORD OR EXIT");
					break;
				#endregion

				#region default case.
				default:
					break;
				#endregion
			}
			// frame style decision struct.

			return frame;
			// return generated frame. 

		}

		/// <summary>
		/// create dynamic frame.
		/// </summary>
		/// <param name="line1">1st line of frame.</param>
		/// <param name="line2">2nd line of frame.</param>
		/// <param name="line3">3rd line of frame.</param>
		/// <param name="line4">4th line of frame.</param>
		/// <param name="line5">5th line of frame.</param>
		/// <param name="line6">6th line of frame.</param>
		/// <param name="line7">7th line of frame.</param>
		/// <param name="prompt">prompt at bottom of frame.</param>
		/// <returns>constructed menu based on args.</returns>
		private static List<string> CallDynamicFrame(string line1 = "",
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
				throw new ArgumentException("lines cannot exceed 57 characters in length.");
			}
			// throw exception if any args exceed intended length.

			line1 = string.Format("{0, -57}", line1);
			line2 = string.Format("{0, -57}", line2);
			line3 = string.Format("{0, -57}", line3);
			line4 = string.Format("{0, -57}", line4);
			line5 = string.Format("{0, -57}", line5);
			line6 = string.Format("{0, -57}", line6);
			line7 = string.Format("{0, -57}", line7);
			prompt = string.Format("{0, -57}", prompt);
			// format all strings for appropriate viewing.

			List<string> dynamicMenu = new List<string>
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

			return dynamicMenu;
			// return generated menu.


		}

		/// <summary>
		/// create objects for new game.
		/// </summary>
		private static void CreateNewGameState()
		{
			Galaxy.ActionStatement = "ONLY YOU CAN SAVE THE GALAXY!";
			// set intro action statement. 

			Galaxy.Treasures = DataOps.GetTreasures();
			Galaxy.Items = DataOps.GetItems();
			Galaxy.Potions = DataOps.GetPotions();
			Galaxy.Weapons = DataOps.GetWeapons();
			Galaxy.Aliens = DataOps.GetAliens();
			Galaxy.Planets = DataOps.GetPlanets();
			// load object data.

			Galaxy.LoadNewSystem();
			// load new system.
		}
		// methods.

		/// <summary>
		/// current context of game.
		/// </summary>
		public static GameContext Context { get; set; }
		// autoprops.
	}
}
