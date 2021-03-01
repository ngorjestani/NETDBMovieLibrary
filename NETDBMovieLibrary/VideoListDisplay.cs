using System;
using System.IO;

namespace NETDBMovieLibrary
{
    public class VideoListDisplay : ListDisplay
    {
        private const int ID_COLUMN_SIZE = -10;
        private const int TITLE_COLUMN_SIZE = -50;
        private const int FORMAT_COLUMN_SIZE = -10;
        private const int LENGTH_COLUMN_SIZE = -10;
        private const int REGIONS_COLUMN_SIZE = -50;
        private string File = "../../../MovieList/videos.csv";

        public VideoListDisplay()
        {
            CsvToList();
        }

        public override void CsvToList()
        {
            StreamReader sr = new StreamReader(File);
            while (!sr.EndOfStream)
            {
                string videoLine = sr.ReadLine();
                ListToDisplay.Add(videoLine);
            }

            sr.Close();
        }

        public override void DisplayList()
        {
            foreach (var video in ListToDisplay)
            {
                string[] videoInfo = video.Split(',');
                Console.WriteLine(
                    $"|{videoInfo[0],ID_COLUMN_SIZE} | {videoInfo[1],TITLE_COLUMN_SIZE} | {videoInfo[2],FORMAT_COLUMN_SIZE} | {videoInfo[3],LENGTH_COLUMN_SIZE} | {videoInfo[4],REGIONS_COLUMN_SIZE}");
            }
        }
    }
}