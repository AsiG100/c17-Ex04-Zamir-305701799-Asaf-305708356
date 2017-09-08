using System;
using System.Collections.Generic;
using System.Reflection;

namespace Ex04.Menus.Delegates
{
    public class MenuItem : Item
    {
        private List<Item> m_Items;

        //Connect between the menus
        public void BrowseMenu()
        {
            int userInput = getInputFromUser();
            if (userInput == 0)
            {
                m_ParentMenuItem.BrowseMenu();
            }
            else
            {
                ((MenuItem)m_Items[userInput]).BrowseMenu();
            }
        }
       

        //Displays the menu and gets the input form the user
        private int getInputFromUser()
        {
            bool isValidInput;
            int userInput;

            do
            {
                Console.Clear();

                for (int i = 1; i < m_Items.Count; i++)
                {
                    Console.WriteLine(m_Items[i]);
                }

                Console.Write("\nChoose an item from the list: ");
                isValidInput = int.TryParse(Console.ReadLine(), out userInput);
                if (!isValidInput) //if the user doesn't enter a number
                {
                    Console.WriteLine("Please enter a number only");
                }
                else if (m_Items.Count < userInput) // if the user enters a number not within the range given
                {
                    Console.WriteLine("Please Enter a number within the rangee of 0 - {0}", m_Items.Count);
                }
            } while (isValidInput);


            return userInput;
        }


        //``Constructors``//
        public MenuItem(string i_Title, MenuItem i_Parent)
            :base(i_Title,i_Parent)
        {
            m_Items = new List<Item>();
        }

        public MenuItem(string i_Title)
            : base(i_Title, null)
        {
            m_Items = new List<Item>();
        }

        //``Properties``//
        public List<Item> Items
        {
            get
            {
                return m_Items;
            }
            set
            {
                m_Items = value;
            }
        }
    }
}
