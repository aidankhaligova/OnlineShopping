using OnlineShopping.Core;
using OnlineShopping.Core.Enums;
using OnlineShopping.Core.Factories;
using OnlineShopping.Models;
using OnlineShopping.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace OnlineShopping.Views
{
    /// <summary>
    /// Interaction logic for LoadingWindow.xaml
    /// </summary>
    public partial class LoadingWindow : Window
    {
        public LoadingWindow()
        {
            InitializeComponent();
        }
        private void WindowLoaded(object sender, RoutedEventArgs e)
        {
            Task.Run(() =>
            {
                CheckServer();
            });
        }
        private void btnConfigClick(object sender, RoutedEventArgs e)
        {
            ConfigurationViewModel configurationViewModel = new ConfigurationViewModel();
            configurationViewModel.DbSettings = DbSettings.Get();

            ConfigurationWindow configWindow = new ConfigurationWindow();
            configWindow.DataContext = configurationViewModel;
            configWindow.ShowDialog();

            firstPanel.Visibility = Visibility.Visible;
            secondPanel.Visibility = Visibility.Hidden;
            Task.Run(() =>
            {
                CheckServer();
            });
        }
        private async void CheckServer()
        {
            DbSettings settings = DbSettings.Get();
            string connectionString = settings.GetConnectionString();
            Kernel.DB = DBFactory.Create(ServerType.SqlServer, connectionString);

            if (Kernel.DB == null)
            {
                Application.Current.Dispatcher.Invoke(ShowErrorPanel);
            }
            else
            {
                bool connectionSucceed = Kernel.DB.CheckServer();

                if (connectionSucceed)
                {
                    await Task.Delay(2500);
                    Application.Current.Dispatcher.Invoke(() =>
                    {
                        LoginViewModel loginViewModel = new LoginViewModel();
                        LoginWindow loginWindow = new LoginWindow();

                        loginWindow.DataContext = loginViewModel;
                        loginViewModel.Window = loginWindow;

                        Close();
                        loginWindow.ShowDialog();
                    });
                }
                else
                {
                    Application.Current.Dispatcher.Invoke(ShowErrorPanel);
                }
            }
            
            
        }
        private void ShowErrorPanel()
        {
            firstPanel.Visibility = Visibility.Hidden;
            secondPanel.Visibility = Visibility.Visible;
        }
    }
}
