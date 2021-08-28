using OnlineShopping.Core;
using OnlineShopping.Core.Domains.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace OnlineShopping.Commands
{
    public abstract class BaseCommand : ICommand
    {
        protected IUnitOfWork DB => Kernel.DB;

        public event EventHandler CanExecuteChanged;
        public virtual bool CanExecute(object parameter)
        {
            return true;
        }

        public abstract void Execute(object parameter);
    }
}
