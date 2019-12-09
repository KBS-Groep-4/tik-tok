using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using RoeiJeRot.View.Wpf.ViewModels;

namespace RoeiJeRot.View.Wpf.Views.Windows
{
    /// <summary>
    /// Interaction logic for ClieMainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly WindowManager _windowManager;
        private TabViewModal tabViewModel;

        public MainWindow(WindowManager windowManager)
        {
            _windowManager = windowManager;
            InitializeComponent();
            this.headerBar.BtnCloseClick += CloseClick;
            this.headerBar.BtnMinClick += MinimizeClick;
            this.headerBar.BtnMaxClick += MaximizeRestoreClick;
            this.headerBar.LogoutClick += OnLogout;

            tabViewModel = new TabViewModal();
            ActionTabs.ItemsSource = tabViewModel.Tabs;

            LoadButtons();
        }

        private void LoadButtons()
        {
            var reservationOverViewWindow = new Button() {Content = "Reservering Overzicht",};
            reservationOverViewWindow.Click += OnReservationOverviewClick;
            pnlPageButtons.Children.Add(reservationOverViewWindow);

            var reservationWindow = new Button() { Content = "Reservering Plaatsen", };
            reservationWindow.Click += OnReservationClick;
            pnlPageButtons.Children.Add(reservationWindow);
        }

        private void OnReservationOverviewClick(object sender, RoutedEventArgs e)
        {
            if (e.Source is Button)
            {
                tabViewModel.Tabs.Add(new ActionTabItem
                {
                    Header = "Reservering Overzicht",
                    Content = InstanceCreator.Instance.CreateInstance<ReservationOverviewWindow>()
                });
            }
        }

        private void OnReservationClick(object sender, RoutedEventArgs e)
        {
            if (e.Source is Button)
            {
                tabViewModel.Tabs.Add(new ActionTabItem
                {
                    Header = "Reservering Aanmaken",
                    Content = InstanceCreator.Instance.CreateInstance<ReservationWindow>()
                });
            }
        }

        private void CloseClick(object sender, RoutedEventArgs e)
        {
            _windowManager.CurrentWindow.Close();
        }

        private void MaximizeRestoreClick(object sender, RoutedEventArgs e)
        {
            _windowManager.CurrentWindow.MaximizeWindow();
        }

        private void MinimizeClick(object sender, RoutedEventArgs e)
        {
            _windowManager.CurrentWindow.MinimizeWindow();
        }

        private void OnLogout(object sender, RoutedEventArgs e)
        {
            _windowManager.Logout();
        }

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (ActionTabs.SelectedIndex != -1)
            {
                tabViewModel.Tabs.RemoveAt(ActionTabs.SelectedIndex);
            }
        }
    }
}
