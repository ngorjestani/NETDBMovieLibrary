using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace NETDBMovieLibrary
{
    public class Movie
    {
        public int MovieID { get; set; }
        public string MovieTitle { get; set; }
        public List<string> MovieGenre = new List<string>();

        private string File = "../../../MovieList/movies.csv";

        private int GetNextID()
        {
            int lastID = 0;
            
            try
            {
                string lastLine = System.IO.File.ReadLines(File).Last();
                string[] lastLineSplit = lastLine.Split(',');
                lastID = Convert.ToInt32(lastLineSplit[0]);
                return lastID;
            }
            catch (DirectoryNotFoundException)
            {
                Console.WriteLine("File could not be found.");
            }

            return lastID;
        }

        public void CreateMovie()
        {
            Console.WriteLine("\nEnter movie title: ");
            MovieTitle = Console.ReadLine();

            int genreCounter = 1;
            while (true)
            {
                Console.WriteLine($"\nEnter genre {genreCounter} (Enter 0 to stop): ");
                string genre = Console.ReadLine();

                if (genre == "0")
                {
                    break;
                }
                
                MovieGenre.Add(genre);

                genreCounter++;
            }

            MovieID = GetNextID() + 1;
        }

        public void AddMovieToFile()
        {
            try
            {
                StreamWriter sw = new StreamWriter(File, true);
                sw.WriteLine(ToString());
                Console.WriteLine("Movie added successfully");
                sw.Close();
            }
            catch (DirectoryNotFoundException)
            {
                Console.WriteLine("File could not be found.");
            }
        }

        private string GenreList(List<string> genres)
        {
            return string.Join("|", genres);
        }

        public override string ToString()
        {
            string genres = GenreList(MovieGenre);
            return $"{MovieID},{MovieTitle},{genres}";
        }
    }
}