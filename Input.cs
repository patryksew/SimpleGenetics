using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleGenetics {
    static class Input {
        static public int NumberInt (int min, int max) {
            while (true) {
                string valueS = Console.ReadLine();
                int value;
                try {
                    value = Convert.ToInt16(valueS);
                    if (value < min || value > max)
                        throw new OverflowException();
                    return value;
                }
                catch (OverflowException) {
                    Console.WriteLine("Incorrect number, enter number between {0} and {1}", min, max);
                }
                catch (FormatException) {
                    Console.WriteLine("Use digits only");
                }
            }
        }

        static public float NumberFloat (float min, float max) {
            while (true) {
                string valueS = Console.ReadLine();
                float value;
                try {
                    value = (float)Convert.ToDouble(valueS);
                    if (value < min || value > max)
                        throw new OverflowException();
                    return value;
                }
                catch (OverflowException) {
                    Console.WriteLine("Incorrect number, enter number between {0} and {1}", min, max);
                }
                catch (FormatException) {
                    Console.WriteLine("Use digits only");
                }
            }
        }

        /// <summary>
        /// Returns true for "yes"
        /// </summary>
        /// <returns></returns>
        static public bool YesOrNo () {
            while (true) {
                Console.WriteLine("Type Y or N");
                ConsoleKeyInfo character;
                character = Console.ReadKey();
                Console.WriteLine();
                if (character.Key == ConsoleKey.Y)
                    return true;
                else if (character.Key == ConsoleKey.N)
                    return false;
                else
                    Console.Write("Wrong character: ");
            }
        }
    }
}
