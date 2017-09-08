using System;
using System.Collections.Generic;


namespace Ex04.Menus.Delegates
{
    public delegate void Action();

    public class ActionItem : Item
    {
        public event Action Activity;

        //``Constructor``//
        public ActionItem(string i_Title, MenuItem i_Parent, Action i_Method)
            : base(i_Title, i_Parent)
        {
            Activity += i_Method;
        }

        public Action InvokeActivity
        {
            get
            {
                return Activity.Invoke;
            }
        }
    }
}