using System;
using System.Collections.Generic;

namespace Hangman {
    struct Player
    {
        public string Name;
        public int Score;

        public Player(string name, int score)
        {
            Name = name;
            Score = score;
        }
    }

    struct Word
    {
        public string Text;
        public string Hint;

        public Word(string text, string hint)
        {
            Text = text;
            Hint = hint;
        }
    }

    class Program {
        static void Main(string[] args){

            Console.WriteLine("Bienvenid@ ¿estás listo para salvar al gatito?");

            Player player1 = new Player("Jugador 1", 0);
            Player player2 = new Player("Jugador 2", 0);

            List<Word> words = new List<Word>
            {
                new Word("Michisaurio", "Animal"),
                new Word("TitoCapotito", "Nombre propio"),
                new Word("MichiOnvorguesa", "Comida"),
                new Word("Wiskasdesalmon", "Comida"),
                new Word("Cleogordita", "Nombre propio")
            };

            Random randMch = new Random();
            var idx = randMch.Next(0, words.Count);

            Word selectedWord = words[idx];
            
            char[] posibble = new char[selectedWord.Text.Length];
            Console.Write("Ingresa una letra para comenzar: ");

            for (int p = 0; p < selectedWord.Text.Length; p++)
                posibble[p] = '*';

            bool gameover = false;
            bool player1Turn = true;

            while (!gameover)
            {
                char playerGuess = char.Parse(Console.ReadLine());
                bool foundLetter = false;

                for (int j = 0; j < selectedWord.Text.Length; j++)
                {
                    if (playerGuess == selectedWord.Text[j])
                    {
                        posibble[j] = playerGuess;
                        foundLetter = true;
                    }
                }

                if (foundLetter)
                {
                    Console.WriteLine($"¡Correcto! La letra '{playerGuess}' está en la palabra.");
                }
                else
                {
                    Console.WriteLine($"¡Incorrecto! La letra '{playerGuess}' no está en la palabra.");
                    if (player1Turn)
                    {
                        player2.Score++;
                    }
                    else
                    {
                        player1.Score++;
                    }
                }

                Console.WriteLine($"Palabra: {new string(posibble)}");
                Console.WriteLine($"Pista: {selectedWord.Hint}");

                if (new string(posibble) == selectedWord.Text)
                {
                    Console.WriteLine("¡Felicidades! ¡Has salvado al gatito!");
                    if (player1Turn)
                    {
                        player1.Score++;
                    }
                    else
                    {
                        player2.Score++;
                    }
                    gameover = true;
                }
                else if (player1.Score >= 5)
                {
                    Console.WriteLine("¡El jugador 2 ha ganado!");
                    gameover = true;
                }
                else if (player2.Score >= 5)
                {
                    Console.WriteLine("¡El jugador 1 ha ganado!");
                    gameover = true;
                }
                else
                {
                    player1Turn = !player1Turn;
                    Console.WriteLine($"Turno del {(player1Turn ? "jugador 1" : "jugador 2")}");
                }
            }
        }
    }
}
