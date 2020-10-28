using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;
namespace WPF_1
{
    public class Depter : BindableBase
    {
        string depterName;
        string amount;
        public Depter()
        {

        }
        public Depter(string aDepterName, string aAmount)
        {
            depterName = aDepterName;
            amount = aAmount;
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

        public string Amount
        {
            get
            {
                return amount;
            }
            set
            {
                amount = value;
            }
        }
    }
}
