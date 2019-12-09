using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

namespace RoeiJeRot.View.Wpf.Views
{
    public delegate void LoadClickedActionHandler(object o, LoadClickedActionEventArgs e);

    public class LoadClickedActionEventArgs : EventArgs
    {
        public readonly string ActionName;
        public readonly UserControl UserControl;
        public LoadClickedActionEventArgs(string actionName, UserControl page)
        {
            ActionName = actionName;
            UserControl = page;
        }
    }

    public class LoadClickedActionEvent
    {
        public static event LoadClickedActionHandler LoadClickedActioned;

        public static void OnLoadClickedAction(LoadClickedActionEventArgs e)
        {
            LoadClickedActioned?.Invoke(new object(), e);
        }
    }
}
