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
                if (this.m_ParentMenuItem == null)
                {
                    Environment.Exit(0);
                }
                else
                {
                    m_ParentMenuItem.BrowseMenu();
                }
                
            }
            else
            {
                if (m_Items[userInput - 1] is MenuItem)
                {
                    ((MenuItem)m_Items[userInput - 1]).BrowseMenu();
                }
                else
                {
                    Console.Clear();
                    ((ActionItem) m_Items[userInput - 1]).InvokeActivity.Invoke();
                    Console.ReadKey();

                    this.BrowseMenu();
                }
                
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
                Console.WriteLine("====={0}=====\n",this.Title);
                for (int i = 0; i < m_Items.Count; i++)
                {
                    Console.WriteLine("{0}. {1}",i+1,m_Items[i].Title);
                }
                if (this.m_ParentMenuItem==null)
                {
                    Console.WriteLine("0. Exit");
                }
                else
                {
                    Console.WriteLine("0. Back");
                }

                Console.Write("\nChoose an item from the list: ");
                isValidInput = int.TryParse(Console.ReadLine(), out userInput);
                if (!isValidInput) //if the user doesn't enter a number
                {
                    Console.WriteLine("Please enter a number only");
                }
                else if (m_Items.Count < userInput || userInput < 0) // if the user enters a number not within the range given
                {
                    Console.WriteLine("Please Enter a number within the rangee of 0 - {0}", m_Items.Count);
                    isValidInput = false;
                }
            } while (!isValidInput);


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
