using OnlineShopping.Core;
using OnlineShopping.Core.Domains.Entities;
using OnlineShopping.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace OnlineShopping.Commands
{
    public class LoginCommand : BaseCommand
    {
        private readonly LoginViewModel viewModel;
        public LoginCommand(LoginViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public override void Execute(object parameter)
        {
            User user = Kernel.DB.UserRepository.Get(viewModel.Username);

            if (user != null)
            {
                PasswordBox passwordBox = (PasswordBox)parameter;
                string password = passwordBox.Password;
                string passwordHash = SecurityHelper.ComputeSha256Hash(password);

                if (user.Password == passwordHash)
                {
                    Kernel.CurrentUser = user;
                    MainWindow mainWindow = new MainWindow();
                    MainViewModel mainViewModel = new MainViewModel();

                    mainViewModel.Window = mainWindow;
                    mainWindow.DataContext = mainViewModel;
                    mainWindow.Show();
                    viewModel.Window.Close();
                }
                else
                {
                    viewModel.ErrorVisibility = Visibility.Visible;
                }
            }
            else
            {
                viewModel.ErrorVisibility = Visibility.Visible;
            }
        }
    }
}
