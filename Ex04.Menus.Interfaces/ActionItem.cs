using System;
using System.Collections.Generic;
using Ex04.Menus.Interfaces;


namespace Ex04.Menus.Interfaces
{

    public class ActionItem : Item
    {
        private IActivity m_Activity;

        //``Constructor``//
        public ActionItem(string i_Title, MenuItem i_Parent, IActivity i_Activity)
            : base(i_Title, i_Parent)
        {
            m_Activity = i_Activity;
        }

        //``Properties``//

        public IActivity Activity
        {
            get
            {
                return m_Activity;
            }
            set
            {
                m_Activity = value;
            }
        }
       
    }
}