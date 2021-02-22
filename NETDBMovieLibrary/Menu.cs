using System;
using System.Collections.Generic;

namespace NETDBMovieLibrary
{
    public class Menu
    {
        private char exitKey = 'X';
        private List<char> validChoices = new List<char> {'1', '2'};
        public bool ExitNow { get; set; }

        public Menu()
        {
            ExitNow = false;
            DisplayMenu();
        }

        public void DisplayMenu()
        {
            Console.WriteLine(@"
1) List movies
2) Add a movie to the list
X) Exit

Make Selection: 
");
        }

        public char GetUserSelection()
        {
            char userSelection = Console.ReadKey().KeyChar;
            
            while (!validChoices.Contains(userSelection) && !char.ToUpper(userSelection).Equals(exitKey))
            {
                Console.WriteLine("\nInvalid selection");
                DisplayMenu();

                userSelection = Console.ReadKey().KeyChar;
            }

            return userSelection;
        }

        public void ProcessSelection(char input)
        {
            switch (input)
            {
                case 'x': case 'X':
                    ExitNow = true;
                    Console.WriteLine("\nThanks for using movie library");
                    break;
                case '1':
                    MovieListDisplay movieList = new MovieListDisplay();
                    movieList.DisplayMovieList();
                    break;
                case '2':
                    Movie movie = new Movie();
                    movie.CreateMovie();
                    movie.AddMovieToFile();
                    break;
            }
        }
    }
}