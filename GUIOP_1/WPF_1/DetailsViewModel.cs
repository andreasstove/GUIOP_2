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
    public class DetailsViewModel : BindableBase
    {
        private string _amount;
        public string Amount
        {
            get { return _amount; }
            set
            {
                _amount = value;
                RaisePropertyChanged("Amount");

            }
        }

        public ObservableCollection<Double> debitsModel;
        public ObservableCollection<double> DebitsModel { get { return debitsModel; } set => SetProperty(ref debitsModel, value); }
        public DetailsViewModel(Depter depter)
        {
            currentDepter = depter;
            debitsModel = depter.debits;

        }
        public DetailsViewModel()
        {

        }
        Depter currentDepter;

        
        public Depter CurrentDepter
        {
            get { return currentDepter; }
            set => SetProperty(ref currentDepter, value);
        }

        ICommand _addCommand;

        public ICommand AddCommand
        {
            get
            {
                return _addCommand ?? (_addCommand = new DelegateCommand(() =>
                {
                    currentDepter.Amount = Convert.ToDouble(Amount);

                }));
            }

        }


    }
}
