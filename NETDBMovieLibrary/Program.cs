using System;

namespace NETDBMovieLibrary
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu menu = new Menu();

            while (!menu.ExitNow)
            {
                char selection = menu.GetUserSelection();
                menu.ProcessSelection(selection);
                if (!menu.ExitNow)
                {
                    menu.DisplayMenu();
                }
            }
        }
    }
}