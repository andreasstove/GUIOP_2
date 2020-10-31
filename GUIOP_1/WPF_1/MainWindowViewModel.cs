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
using System.Windows.Controls;
using Microsoft.Win32;
using System.IO;
using System.Windows;
namespace WPF_1
{
    public class MainWindowViewModel : BindableBase
    {
        string filePath = "";
        private string filename = "";
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
        private string title = "hej";
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }
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

        ICommand _deleteDepterCommand;

        public ICommand DeleteDepterCommand
        {
            get
            {
                return _deleteDepterCommand ?? (_deleteDepterCommand = new DelegateCommand(() =>
                {
                    Depters.Remove(CurrentDepter);
                    CurrentDepter = null;
                }));
            }

        }


        ICommand _newDepterCommand;
        public ICommand AddNewDepterCommand
        {
            get
            {
                return _newDepterCommand ?? (_newDepterCommand = new DelegateCommand(() =>
                {
                     var newDepter = new Depter();
                     var vm = new DepterViewModel(newDepter);
                     var dlg = new AddCollecter();
                     dlg.DataContext = vm;
                     if (dlg.ShowDialog() == true)
                     {
                         Depters.Add(newDepter);
                         CurrentDepter = newDepter;
                     }
                 }));
            }
        }


        ICommand _SaveCommand;
        public ICommand SaveCommand
        {
            get
            {
                return _SaveCommand ?? (_SaveCommand = new DelegateCommand(SaveFileCommand_Execute, SaveFileCommand_CanExecute).ObservesProperty(() => Depters.Count));
            }
        }
        private void SaveFileCommand_Execute()
        {
            SaveFile();
        }
        private bool SaveFileCommand_CanExecute()
        {
            return (filename != "") && (Depters.Count > 0);
        }
        private void SaveFile()
        {
            try
            {
                Repository.SaveFile(filePath, Depters);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Unable to save file", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        ICommand _SaveAsCommand;
        public ICommand SaveAsCommand
        {
            get { return _SaveAsCommand ?? (_SaveAsCommand = new DelegateCommand(SaveAsCommand_Execute)); }
        }
        private void SaveAsCommand_Execute()
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "Depter documens|*.agn|ALL Fles|*.*";
            if(filePath == "")
            {
                dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            }
            else
            {
                dialog.InitialDirectory = Path.GetDirectoryName(filePath);
            }
            if(dialog.ShowDialog(App.Current.MainWindow) == true)
            {
                filePath = dialog.FileName;
                filename = Path.GetFileName(filePath);
                SaveFile();
                Title = filename;
            }
        }

        ICommand _OpenFileCommand;
        public ICommand OpenFileCommand
        {
            get { return _OpenFileCommand ?? (_OpenFileCommand = new DelegateCommand(OpenFileCommand_Execute)); }
        }
        private void OpenFileCommand_Execute()
        {
            var dialog = new OpenFileDialog();

            dialog.Filter = "Depter documents|*.agn|All Files|*.*";
            dialog.DefaultExt = "agn";
            if (filePath == "")
            {
                dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            }
            else
                dialog.InitialDirectory = Path.GetDirectoryName(filePath);
            if(dialog.ShowDialog(App.Current.MainWindow) == true)
            {
                filePath = dialog.FileName;
                filename = Path.GetFileName(filePath);
                try
                {
                    ObservableCollection<Depter> tempDepters;
                    Repository.ReadFile(filePath, out tempDepters);
                    Depters = tempDepters;
                    Title = filename;
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message, "Unable to open file", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        #endregion


    }
}
