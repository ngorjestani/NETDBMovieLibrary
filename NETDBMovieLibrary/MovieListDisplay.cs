using System;
using System.Collections.Generic;
using System.IO;

namespace NETDBMovieLibrary
{
    public class MovieListDisplay : ListDisplay
    {
        private const int ID_COLUMN_SIZE = -10;
        private const int TITLE_COLUMN_SIZE = -50;
        private const int GENRE_COLUMN_SIZE = -30;
        /*private List<string> MovieList = new List<string>();*/
        private string File = "../../../MovieList/movies.csv";

        public MovieListDisplay()
        {
            CsvToList();
        }

        public override void CsvToList()
        {
            while (true)
            {
                Console.WriteLine("\nHow many movies would you like to display?");
                string userInput = Console.ReadLine();
                int userInputNumber;

                if (int.TryParse(userInput, out userInputNumber))
                {
                    StreamReader sr = new StreamReader(File);
                    for (int i = 0; i < userInputNumber; i++)
                    {
                        string movieLine = sr.ReadLine();
                        ListToDisplay.Add(movieLine);
                    }
                    
                    sr.Close();
                    break;
                }
                
                Console.WriteLine("Please enter a number");

            }
        }

        public override void DisplayList()
        {
            foreach (var movie in ListToDisplay)
            {
                string[] movieInfo = movie.Split(',');
                Console.WriteLine($"|{movieInfo[0], ID_COLUMN_SIZE} | {movieInfo[1], TITLE_COLUMN_SIZE} | {movieInfo[2], GENRE_COLUMN_SIZE}");
            }
        }
    }
}