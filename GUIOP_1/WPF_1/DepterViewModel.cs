using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Commands;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Prism.Mvvm;
namespace WPF_1
{
    public class DepterViewModel : BindableBase
    {
        public DepterViewModel(Depter depter)
        {
            currentDepter = depter;
        }
        Depter currentDepter;

        public Depter CurrentDepter
        {
            get { return currentDepter; }
            set => SetProperty(ref currentDepter, value);
        }



    }
}
