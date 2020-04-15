using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace POO_Procesare_Caractere
{
    class Line
    {
        private String line;

        public Line(String line)
        {
            this.line = line;
        }

        public char[] getChars()
        {
            return this.line.ToCharArray();
        }

        public int[] countChars ()
        {
            char[] characters = this.getChars();
            int numberOfVowles = 0;
            int numberOfConsonants = 0;
            int numberOfOtherChars = 0;

            for (int i = 0; i < characters.Length; i+= 1)
            {
                Letter currentLetter = new Letter(characters[i]);

                if (currentLetter.isVowel())
                {
                    numberOfVowles += 1;
                }
                else if (currentLetter.isConsonant())
                {
                    numberOfConsonants += 1;
                }
                else
                {
                    numberOfOtherChars += 1;
                }
            }

            int[] result = new int[] { numberOfVowles, numberOfConsonants, numberOfOtherChars };

            return result;
        }
    }

    class Letter
    {
        private char letter;

        public Letter(char letter)
        {
            this.letter = letter;
        }

        public bool isVowel()
        {
            return "aeiou".IndexOf(this.letter.ToString(), StringComparison.InvariantCultureIgnoreCase) >= 0;
        }

        public bool isConsonant()
        {
            char normalizedChar = this.letter.ToString().ToLower().ToCharArray()[0];

            if (
                normalizedChar > 'a' && normalizedChar <= 'd'
                || normalizedChar > 'e' && normalizedChar < 'i'
                || normalizedChar > 'j' && normalizedChar < 'o'
                || normalizedChar >= 'p' && normalizedChar < 'u'
                || normalizedChar > 'v' && normalizedChar < 'z'
            )
            {
                return true;
            }

            return false;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("You must give the file as a command line argument");
            }
            else
            {
                string fileName = args[0];

                try
                {
                    string[] lines = File.ReadAllLines(fileName);
                    int vowels = 0;
                    int consonants = 0;
                    int otherChars = 0;

                    for (int i = 0; i < lines.Length; i += 1)
                    {
                        Console.WriteLine(lines[i]);

                        Line currentLine = new Line(lines[i]);

                        int[] counts = currentLine.countChars();

                        vowels += counts[0];
                        consonants += counts[1];
                        otherChars += counts[2];
                    }

                    Console.WriteLine();
                    Console.WriteLine($"Number of lines {lines.Length}");
                    Console.WriteLine($"Number of vowels {vowels}");
                    Console.WriteLine($"Number of consonants {consonants}");
                    Console.WriteLine($"Number of other characters {otherChars}");
                } catch (Exception)
                {
                    Console.WriteLine($"Cannot read file {args[0]}");
                }
            }

            Console.ReadKey();
        }
    }
}
    
    

    

