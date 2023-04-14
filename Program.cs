
using System;

namespace Hangman {
    class Program {
        static void Main(string[] args){
            Console.WriteLine("Bienvenid@ ¿estas listo para salvar al gatito?");
            string[] listwords = new string[5];
            listwords[0] = "Michisaurio";
            listwords[1] = "TitoCapotito";
            listwords[2] = "MichiOnvorguesa";
            listwords[3] = "Wiskasdesalmon";
            listwords[4] = "Cleogordita";
            
            Random randMch = new Random();
            var idx = randMch.Next(0, 4);
            string secretWord = listwords[idx];
            char[] posibble = new char[secretWord.Length];
            Console.Write("Ingresa una letra para comenzar: ");
 
            for (int p = 0; p < secretWord.Length; p++)
                posibble[p] = '*';
            
            int numErrors = 0;

            while (true)
            {
                char playerGuess = char.Parse(Console.ReadLine());
                bool correctGuess = false;
                for (int j = 0; j < secretWord.Length; j++)
                {
                    if (playerGuess == secretWord[j])
                    {
                        posibble[j] = playerGuess;
                        correctGuess = true;
                    }
                }
                if (!correctGuess)
                {
                    numErrors++;
                    DrawHangman(numErrors);
                }
                Console.WriteLine(posibble);

                if (!posibble.Contains('*'))
                {
                    Console.WriteLine("Felicidades, has ganado!");
                    break;
                }
           
            }
        }
        
        static void DrawHangman(int numErrors)
        {
            string[] hangman = new string[] {
                "  _____",
                "  |   |",
                "  |   O",
                "  |  /|\\",
                "  |  / \\",
                " _|_"
            };
            
            Console.WriteLine("\nIntento fallido " + numErrors + ":");
            for (int i = 0; i < hangman.Length && i <= numErrors; i++)
            {
                Console.WriteLine(hangman[i]);
            }
        }
    }
}
