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
            SetupConsole();
            Controller.StartGame();
            StyleFrame(Controller.CallFrame(), (int)Controller.Context);
            // prep.

            while (true)
            {
                Controller.Update(Console.ReadLine());
                StyleFrame(Controller.CallFrame(), (int)Controller.Context);
            }
            // gameplay loop. game closes using exit codes via Controller.

            void SetupConsole()
            {
                const int Width = 79,
                          Height = 28;
                // console width and height, measured in characters.

                Console.Title = "Galaxy Wars";
                Console.SetWindowSize(Width, Height);
                Console.SetBufferSize(Width, Height);
                // set console title & window size for proper viewing.
            }
            // setup console window.

            void StyleFrame(List<string> frame, int context)
			{
                if (context is 0)
				{
                    string titleChars = @"_\/|`-(<,'";
                    // characters in title ascii art to be displayed in special color. 

                    for (int index = 0; index < frame.Count; index++)
                    {
                        Console.Write("   ");
                        // write whitespace buffer. 

                        foreach (char character in frame[index])
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
                    // print styled frame.
                }
                // display stylized start frame.
                else if (context is 3)
				{
                    foreach (string line in frame)
                    {
                        Console.Write("   ");
                        // write whitespace buffer.

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
                }
                // display stylized game frame.
                else
				{
                    foreach (string line in frame)
                    {
                        Console.Write("   ");
                        // write whitespace buffer.

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
                }
                // display stylized dynamic frame.
            }
            // write stylized frame to console. 
        }
    }
}

