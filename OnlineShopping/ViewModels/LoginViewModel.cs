using OnlineShopping.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace OnlineShopping.ViewModels
{
    public class LoginViewModel: BaseWindowViewModel
    {
        public LoginCommand SignIn => new LoginCommand(this);
        public string Username { get; set; }

        private Visibility errorVisibility = Visibility.Hidden;
        public Visibility ErrorVisibility
        {
            get => errorVisibility;
            set
            {
                errorVisibility = value;
                OnPropertyChanged(nameof(ErrorVisibility));
            }
        }
    }
}
