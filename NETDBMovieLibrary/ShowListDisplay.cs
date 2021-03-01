using System;
using System.Collections.Generic;
using System.IO;

namespace NETDBMovieLibrary
{
    public class ShowListDisplay : ListDisplay
    {
        private const int ID_COLUMN_SIZE = -10;
        private const int TITLE_COLUMN_SIZE = -50;
        private const int SEASON_COLUMN_SIZE = -10;
        private const int EPISODE_COLUMN_SIZE = -10;
        private const int WRITERS_COLUMN_SIZE = -50;
        private string File = "../../../MovieList/shows.csv";

        public ShowListDisplay()
        {
            CsvToList();
        }

        public override void CsvToList()
        {
            StreamReader sr = new StreamReader(File);
            while (!sr.EndOfStream)
            {
                string showLine = sr.ReadLine();
                ListToDisplay.Add(showLine);
            }

            sr.Close();
        }

        public override void DisplayList()
        {
            foreach (var show in ListToDisplay)
            {
                string[] showInfo = show.Split(',');
                Console.WriteLine(
                    $"|{showInfo[0],ID_COLUMN_SIZE} | {showInfo[1],TITLE_COLUMN_SIZE} | {showInfo[2],SEASON_COLUMN_SIZE} | {showInfo[3],EPISODE_COLUMN_SIZE} | {showInfo[4],WRITERS_COLUMN_SIZE}");
            }
        }
    }
}