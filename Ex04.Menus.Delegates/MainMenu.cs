using System;
using System.Collections.Generic;

namespace Ex04.Menus.Delegates
{
    public class MainMenu
    {
        private MenuItem m_MenuItem;

        //The main loop
        public void Show() 
        {
            bool isOperating = true;

            do //Loops until the user exits the menu
            {
               m_MenuItem.BrowseMenu();


            } while (isOperating);
        }

        public MenuItem MenuItem
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

        public MenuItem AddMenuItem(MenuItem i_Parent, string i_Title)
        {
            MenuItem item = new MenuItem(i_Title, i_Parent);
            i_Parent.Items.Add(item);

            return item;
        }

        public MenuItem AddMenuItem(string i_Title)
        {
            MenuItem item;

            if (m_MenuItem == null)
            {
                item = new MenuItem(i_Title);
                m_MenuItem = item;
            }
            else
            {
                throw new Exception("The menu is already initialized, please add to a specific parent");
            }

            return item;
        }

        public ActionItem AddActionItem(MenuItem i_Parent, string i_Title, Action i_Method)
        {
            ActionItem item = new ActionItem(i_Title, i_Parent, i_Method);
            i_Parent.Items.Add(item);

            return item;
        }
    }
}
