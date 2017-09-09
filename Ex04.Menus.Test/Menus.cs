using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex04.Menus.Interfaces;


namespace Ex04.Menus.Test
{
    class Menus : IActivity
    {
        //``Menus``//
        public static void DelegateMenu()
        {
            Ex04.Menus.Delegates.MainMenu menu = new Ex04.Menus.Delegates.MainMenu();
            Ex04.Menus.Delegates.MenuItem main = menu.AddMenuItem("The main menu");
            Ex04.Menus.Delegates.MenuItem item1 = menu.AddMenuItem(main, "Vision and spaces");
            Ex04.Menus.Delegates.MenuItem item2 = menu.AddMenuItem(main, "Show Date/Time");
            Ex04.Menus.Delegates.ActionItem numOfSpaces = menu.AddActionItem(item1, "Count spaces", numOfSpacesInLine);
            Ex04.Menus.Delegates.ActionItem showVersion = menu.AddActionItem(item1, "Show version", showCorrentVersion );
            Ex04.Menus.Delegates.ActionItem dateToday = menu.AddActionItem(item2, "Show date", showDate);
            Ex04.Menus.Delegates.ActionItem timeNow = menu.AddActionItem(item2, "Show time",showTime);

            menu.Show(); //Operates the program
        }

        public static void InterfaceMenu()
        {
            Ex04.Menus.Interfaces.MainMenu menu = new Ex04.Menus.Interfaces.MainMenu();
            Ex04.Menus.Interfaces.MenuItem main = menu.AddMenuItem("The main menu");
            Ex04.Menus.Interfaces.MenuItem item1 = menu.AddMenuItem(main, "Vision and spaces");
            Ex04.Menus.Interfaces.MenuItem item2 = menu.AddMenuItem(main, "Show Date/Time");
            Menus actionPerformer = new Menus();
            Ex04.Menus.Interfaces.ActionItem numOfSpaces = menu.AddActionItem(item1, "Count spaces", actionPerformer);
            Ex04.Menus.Interfaces.ActionItem showVersion = menu.AddActionItem(item1, "Show version", actionPerformer);
            Ex04.Menus.Interfaces.ActionItem dateToday = menu.AddActionItem(item2, "Show date", actionPerformer);
            Ex04.Menus.Interfaces.ActionItem timeNow = menu.AddActionItem(item2, "Show time", actionPerformer);

            menu.Show();
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

        public void StartActivity(ActionItem i_Item)
        {
            if (i_Item.Title == "Count spaces")
            {
                numOfSpacesInLine();
            }
            else if (i_Item.Title == "Show version")
            {
                showCorrentVersion();
            }
            else if (i_Item.Title == "Show date")
            {
                showDate();
            }
            else if (i_Item.Title == "Show time")
            {
                showTime();
            }
        }
    }
}
