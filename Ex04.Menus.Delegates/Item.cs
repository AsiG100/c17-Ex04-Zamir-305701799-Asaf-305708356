using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.Delegates
{
    public abstract class Item
    {

        protected string m_Title;
        protected MenuItem m_ParentMenuItem;


        //``Constructor``//
        public Item(string i_Title, MenuItem i_Parent)
        {
            m_Title = i_Title;
            m_ParentMenuItem = i_Parent;
        }

        //``Properties``//
        public string Title
        {
            get
            {
                return m_Title;
            }
            set
            {
                m_Title = value;
            }
        }

        public MenuItem ParentMenuItem
        {
            get
            {
                return m_ParentMenuItem;
            }
            set
            {
                m_ParentMenuItem = value;
            }
        }


    }
}
