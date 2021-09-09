using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI
{
	class Program
	{
		static void Main(string[] args)
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
			
			void RunStartMenuLoop()
			{
				string choice;
				// var for user input. 

				do
				{
					choice = CallStartMenu();
				} while (choice != "new game" &&
						 choice != "continue" &&
						 choice != "about" &&
						 choice != "exit");
				// call main menu and validate use input. 

				switch (choice)
				{
					case "new game":
						RunCharCreationMenuLoop();
						break;
					case "continue":
						//RunLoadCharMenuLoop();
						// TODO write this path.
						break;
					case "about":
						CallAboutMenu();
						break;
					case "exit":
						break;
				}
				// proceed according to user input.
			}
			// start menu loop & decision struct.

			void RunCharCreationMenuLoop()
			{
				bool choice;
				// var for user input. 

				do
				{
					choice = CallCharCreationMenu();
				} while (!choice);
				// call menu and validate user input. 
			}
			// char creation menu loop & decision struct.

			void CallAboutMenu()
			{
				string line1 = "Fight hostile aliens to liberate occupied planets. Save                     ",
					   line2 = "as many worlds as possible to earn a high score!",
					   line6 = "made by Adam Lancaster, Tracey Pinckney, Clarence Dews",
					   prompt = "press [ENTER] to return";
				// info to display.

				CallDynamicMenu(line1: line1,
								line2: line2,
								line6: line6,
								prompt: prompt);
				// display dynamic menu and wait for ENTER.

				RunStartMenuLoop();
				// return to start menu.
			}
			// display about menu & wait for response.

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
							Console.Write(character);
							Console.ResetColor();
						}
						else if (character == '#') 
						{
							Console.ForegroundColor = ConsoleColor.DarkYellow;
							Console.Write(character);
							Console.ResetColor();
						}
						else if (character == '^')
						{
							Console.ForegroundColor = ConsoleColor.Green;
							Console.Write(character);
							Console.ResetColor();
						}
						else
						{
							Console.Write(character);
						}
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

			string CallCharCreationMenu()
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
												   prompt: "enter PASSWORD with atleast 1 cap, 1 lowercase, & 1 special.");
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
			}
			// display character creation menu and return user input.

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

				return Console.ReadLine().ToLower();
				// get input, format as lowercase and return.
			}
			// display dynamic menu with desired info and prompt.

			StartGame();
		}
	}
}

