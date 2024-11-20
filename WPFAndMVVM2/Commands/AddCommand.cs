using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPFAndMVVM2.Models;
using WPFAndMVVM2.ViewModels;

namespace WPFAndMVVM2.Commands
{
    public class AddCommand : ICommand
    {
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (parameter is MainViewModel mvm)
            {
                mvm.AddDefaultPerson();
            }
        }

        public event EventHandler CanExecuteChanged;
    }
}
