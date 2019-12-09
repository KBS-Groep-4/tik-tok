using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Security.RightsManagement;
using System.Text;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RoeiJeRot.Logic.Services;
using RoeiJeRot.View.Wpf.Views.Windows;

namespace RoeiJeRot.View.Wpf
{
    public class CurrentWindow
    {
        private Window _currentWindow;
        
        public void MaximizeWindow()
        {
            _currentWindow.WindowState = WindowState.Maximized;
        }

        public void MinimizeWindow()
        {
            _currentWindow.WindowState = WindowState.Minimized;
        }

        public void Swap(Window window)
        {
            _currentWindow = window;
        }

        public void Close()
        {
            _currentWindow?.Close();
        }

        public void ShowNew(Window window)
        {
            _currentWindow?.Hide();
            Swap(window);
            _currentWindow?.Show();
        }
    }

    public class WindowManager
    {
        private readonly IHost _host;
        public CurrentWindow CurrentWindow { get; }
        public string CurrentUserName { get; private set; }
        
        public WindowManager(IHost host)
        {
            _host = host;
            CurrentWindow = new CurrentWindow();
        }

        public void Logout()
        {
            CurrentWindow.Close();
            Login();
        }

        public void Login()
        {
            CurrentWindow.ShowNew(GetWindow<LoginWindow>());
        }
        
        public bool ShowMainWindow(string username, string password)
        {
            var authenticationService = GetService<IAuthenticationService>();
            
            if (authenticationService.AuthenticateUser(username, password))
            {
                CurrentUserName = username;
                CurrentWindow.ShowNew(GetWindow<MainWindow>());
                return true;
            }

            return false;
        }

        private Window GetWindow<T>() where T: Window
        {
            return (Window)_host.Services.GetService<T>();
        }

        private T GetService<T>()
        {
            return _host.Services.GetService<T>();
        }
    }
}
