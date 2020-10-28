﻿using System;
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
using System.Windows.Controls;

namespace WPF_1
{
    public class MainWindowViewModel : BindableBase
    {
        public ObservableCollection<Depter> depters;
         
        public MainWindowViewModel()
        {
            depters = new ObservableCollection<Depter>
            {
                new Depter("Thomas", 100),
                new Depter("Andreas", 30)
            };
            CurrentDepter = null;

        }


        #region Properties

        Depter currentDepter = null;
        public Depter CurrentDepter
        {
            get { return currentDepter; }

            set
            {
                SetProperty(ref currentDepter, value);
            }
        }
        public ObservableCollection<Depter> Depters
        {
            get
            {
                return depters;
            }
            set
            {
                SetProperty(ref depters, value);
            }
            
        }
 

        int currentIndex = -1;
        public int CurrentIndex
        {
            get { return currentIndex; }
            set => SetProperty(ref currentIndex, value: value);
        }
        #endregion


        #region Methods
        public void AddNewDepter()
        {
            var newDepter = new Depter();
            depters.Add(newDepter);
            currentDepter = newDepter;

        }

   
        #endregion

        #region INotifyPropertyChanged implementation
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        #region ICommand 

        ICommand _newDepterCommand;
        public ICommand AddNewDepterCommand
        {
            get
            {
                return _newDepterCommand ?? (_newDepterCommand = new DelegateCommand(() =>
                 {
                     var newDepter = new Depter("Lasse", 22);

                     
                     CurrentIndex = Depters.Count - 1;
                     var vm = new DepterViewModel(newDepter);
                     var win = new AddCollecter
                     {
                         DataContext = vm
                     };
                     Depters.Add(newDepter);
                 }));
                
            }
        }
            

        #endregion


    }
}
