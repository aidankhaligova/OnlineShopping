using OnlineShopping.Helpers;
using OnlineShopping.Views;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace OnlineShopping
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            DispatcherUnhandledException += AppDispatcherUnhandledException;
        }
        private void AppDispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            Helper.Log(e.Exception);

            MessageBox.Show("Unknown exception occured", "Exception", MessageBoxButton.OK, MessageBoxImage.Error);

            e.Handled = true;
        }
    }
}
