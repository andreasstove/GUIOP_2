using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;
using System.Windows;
using System.Collections.ObjectModel;

namespace WPF_1
{
    public class Depter : BindableBase
    {
        string depterName;
        double amount;
        public ObservableCollection<Double> debits;
        public Depter()
        {
            debits = new ObservableCollection<double>();
        }
        public Depter(string aDepterName, double aAmount)
        {
            debits = new ObservableCollection<double>();
            depterName = aDepterName;
            Amount = aAmount;

        }
        public string DepterName
        {
            get
            {
                return depterName;
            }
            set
            {
                depterName = value;
            }
        }

        public double Amount
        {
            get
            {
                //double total = 0;
                foreach (var item in debits)
                {
                    amount += item;
                }
                return amount;

            }
            set
            {
                //amount =+ value;
                debits.Add(value);
            }
        }
    }
}
