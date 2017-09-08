using System;
using System.Collections.Generic;

namespace Ex04.Menus.Delegates
{
    public class MainMenu
    {
        private Item m_MenuItem;

        //The main loop
        public void Show() 
        {
            bool isOperating = true;

            do //Loops until the user exits the menu
            {
               //s userInput = m_MenuItem.getInputFromUser();


            } while (isOperating);
        }

        public Item MenuItem
        {
            get
            {
                return m_MenuItem;
            }
            set
            {
                m_MenuItem = value;
            }
        }

        public void AddMenuItem(MenuItem i_Parent, string i_Title)
        {

                 i_Parent.Items.Add(new MenuItem(i_Title, i_Parent));

        }

        public void AddMenuItem(string i_Title)
        {
            if (m_MenuItem == null)
            {
                m_MenuItem = new MenuItem(i_Title);
            }
            else
            {
                throw new Exception("The menu is already initialized, please add to a specific parent");
            }
        }

        public void AddActionItem(MenuItem i_Parent, string i_Title, Delegate i_Method)
        {
               i_Parent.Items.Add(new ActionItem(i_Title, i_Parent));
        }
    }
}
