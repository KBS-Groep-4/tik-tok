using System.Windows;

namespace RoeiJeRot.View.Wpf.Logic
{
    /// <summary>
    /// Wrapper over `Window`.
    /// </summary>
    public class CurrentWindow
    {
        private Window _currentWindow;
        
        /// <summary>
        /// Maximizes the current window.
        /// </summary>
        public void MaximizeWindow()
        {
            _currentWindow.WindowState = WindowState.Maximized;
        }

        /// <summary>
        /// Minimizes the current window.
        /// </summary>
        public void MinimizeWindow()
        {
            _currentWindow.WindowState = WindowState.Minimized;
        }

        /// <summary>
        /// Swaps the current window with the given window.
        /// </summary>
        public void Swap(Window window)
        {
            _currentWindow = window;
        }

        /// <summary>
        /// Closes the current window.
        /// </summary>
        public void Close()
        {
            _currentWindow?.Close();
        }

        /// <summary>
        /// Hides the previous window and shows the new window.
        /// </summary>
        public void ShowNew(Window window)
        {
            _currentWindow?.Hide();
            Swap(window);
            _currentWindow?.Show();
        }
    }
}