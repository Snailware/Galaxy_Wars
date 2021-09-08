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
				string[] aboutMenu =
				{
					@"                       .                                           ,       ", // 1
					@"        .                         ,            .              .            ",
					@" ,                .                 .                                      ",
					@"         .                 *                ,          .                   ",
					@"              ,                                                     .      ", // 5
					@"    *    This is sample text. this is sample text. this is sample          ",
					@"  .                   .       ,                 .                     .    ",
					@"      .  This is sample text. this is sample text. this is sample          ",
					@"       ,                                 ,                       .         ",
					@"         This is sample text. this is sample text. this is sample       *  ", // 10
					@"    .                    .         .                   ,             ,     ",
					@"         This is sample text. this is sample text. this is sample          ",
					@",                .                    ,                     .           .  ",
					@"                       .                                           ,       ",
					@"        .                         ,            .       *      .            ", // 15
					@" ,                .                 .                                      ",
					@"         .                 *                ,          .                   ",
					@"              ,                                                     .      ",
					@"       .                                           ,                       ",
					@"                                .                            .             ", // 20
					@"             .        ,                    .                               ",
					@"    ,                                             ,                  ,     ",
					@"+-------------------------------------------------------------------------+",
					@"|                                                                         |",
					@"|                         press [ENTER] to return                         |", // 25
					@"|                                                                         |",
					@"+-------------------------------------------------------------------------+"  // 27
				};
				// about menu array.

				string textChars = "abcdefghijklmnopqrstuvwxyz" + 
					               "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
				// characters to be highlighted as text.

				for (int index = 0; index < aboutMenu.Length; index++)
				{
					foreach (char character in aboutMenu[index])
					{
						if (textChars.Contains(character) && 
							index < 23)
						{
							Console.ForegroundColor = ConsoleColor.Green;
							Console.Write(character);
							Console.ResetColor();
						}
						// display text in special color.

						else if (character == '*')
						{
							Console.ForegroundColor = ConsoleColor.Yellow;
							Console.Write(character);
							Console.ResetColor();
						}
						// display * in special color. 

						else
						{
							Console.Write(character);
						}
						// display other text normally.
					}
					// display certain chars with styling.

					Console.WriteLine();
					// write eol.
				}
				// display about menu with styling.

				Console.ReadLine();
				// wait for input.

				RunStartMenuLoop();
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
						else 
						{
							Console.Write(character);
						}
					}
					// display title chars in special color. display others
					// normally.

					Console.WriteLine();
					// write eol.
				}
				// print start menu and with styling. 

				return Console.ReadLine().ToLower();
				// get user input and return.
			}
			// display start menu & return user input.

			bool CallCharCreationMenu()
			{


		
			}

			StartGame();
		}
	}
}

