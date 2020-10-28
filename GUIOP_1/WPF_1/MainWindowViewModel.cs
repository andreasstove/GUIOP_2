using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Commands;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
namespace WPF_1
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        ObservableCollection<Depter> depters;

        public MainWindowViewModel()
        {
            depters = new ObservableCollection<Depter>();
            currentDepter = depters[0];
        }
        Depter currentDepter = null;

        public Depter CurrentDepter
        {
            get { return currentDepter; }

            set
            {

            }
        }
        public ObservableCollection<Depter> Depters
        {
            get
            {
                return depters;
            }
        }


        #region Methods
        public void AddNewDepter()
        {
            depters.Add(new Depter());
        }
        #endregion

        #region INotifyPropertyChanged implementation
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion


    }
}
