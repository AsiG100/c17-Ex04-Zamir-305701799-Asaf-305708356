using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex04.Menus.Delegates;

namespace Ex04.Menus.Test
{
    static class Menus
    {
        public static void DelegateMenu()
        {
            MainMenu menu = new MainMenu();
            MenuItem main = menu.AddMenuItem("The main menu");
            MenuItem item1 = menu.AddMenuItem(main, "Vision and spaces");
            MenuItem item2 = menu.AddMenuItem(main, "Show Date/Time");
            ActionItem numOfSpaces = menu.AddActionItem(item1, "Count spaces", numOfSpacesInLine);
            ActionItem showVersion = menu.AddActionItem(item1, "Show version", showCorrentVersion );
            ActionItem dateToday = menu.AddActionItem(item2, "Show date", showDate);
            ActionItem timeNow = menu.AddActionItem(item2, "Show time",showTime);

            menu.Show(); //Operates the program
        }


        //``Methods``//
        private static void numOfSpacesInLine()
        {
            string userInput;
            int numOfSpaces = 0;

            Console.WriteLine("Please write a line");
            userInput = Console.ReadLine();

            for (int i = 0; i < userInput.Length; i++)
            {
                if (userInput[i] == ' ')
                {
                    numOfSpaces++;
                }
            }

            Console.WriteLine("There are {0} spaces in this line",numOfSpaces);
        }

        private static void showCorrentVersion()
        {
            Console.WriteLine("Version 15.3.4.0");
        }

        private static void showDate()
        {
            Console.WriteLine(DateTime.Now.ToShortDateString());
        }

        private static void showTime()
        {
            Console.WriteLine(DateTime.Now.ToShortTimeString());
        }
    }
}
