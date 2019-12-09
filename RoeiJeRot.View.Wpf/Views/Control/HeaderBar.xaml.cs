﻿using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace RoeiJeRot.View.Wpf.Views.Control
{
    /// <summary>
    /// Interaction logic for HeaderBar.xaml
    /// </summary>
    public partial class HeaderBar : UserControl
    {
        public event EventHandler<RoutedEventArgs> BtnCloseClick;
        public event EventHandler<RoutedEventArgs> BtnMinClick;
        public event EventHandler<RoutedEventArgs> BtnMaxClick;
        public event EventHandler<RoutedEventArgs> LogoutClick;

        public HeaderBar()
        {
            InitializeComponent();
            logoutButton.Click += OnLogoutClick;
        }

        private void OnLogoutClick(object sender, RoutedEventArgs e)
        {
            LogoutClick?.Invoke(this, e);
        }

        private void Minimize_Click(object sender, RoutedEventArgs e)
        {
            BtnMinClick?.Invoke(this, e);
        }

        private void Maximize_Click(object sender, RoutedEventArgs e)
        {
            BtnMaxClick?.Invoke(this, e);}

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            BtnCloseClick?.Invoke(this, e);
        }
    }
}
