using System;
using System.Windows;
using System.Windows.Controls;
using RoeiJeRot.View.Wpf.Views.Windows;

namespace RoeiJeRot.View.Wpf.Views.Control
{
    /// <summary>
    ///     Interaction logic for LogoutButton.xaml
    /// </summary>
    public partial class LogoutButton : UserControl
    {
        public event EventHandler<RoutedEventArgs> Click;

        public LogoutButton()
        {
            InitializeComponent();
        }
        
        private void LogOutButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Click?.Invoke(this, e);
        }
    }
}