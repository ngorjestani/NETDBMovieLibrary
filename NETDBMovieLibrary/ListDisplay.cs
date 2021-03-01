using System.Collections.Generic;

namespace NETDBMovieLibrary
{
    public abstract class ListDisplay
    {
        public List<string> ListToDisplay = new List<string>();
        public abstract void CsvToList();
        public abstract void DisplayList();
    }
}