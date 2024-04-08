using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachineTutorial.ViewModels
{
    public class ViewModelPayment : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler? PropertyChanged;

        public void OnPropertyChange(string prop)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }

        #endregion



        #region Properties
        // Customer Information
        private double _total;

        public double Total
        {
            get { return _total; }
            set
            {
                _total = value;
                OnPropertyChange(nameof(Total));
            }
        }

        private double _inserted = 0;
        public double Inserted
        {
            get { return _inserted; }
            set
            {
                _inserted = value;
                OnPropertyChange(nameof(Inserted));
            }
        }

        private double _change = 0;
        public double Change
        {
            get { return _change; }
            set
            {
                _change = value;
                OnPropertyChange(nameof(Change));
            }
        }


        // Machine Information
        private double _bankTotal;
        public double BankTotal
        {
            get { return _bankTotal; }
            set
            {
                _bankTotal = value;
                OnPropertyChange(nameof(BankTotal));
            }
        }

        #endregion



        #region Commands
        #endregion



        #region Constructors
        public ViewModelPayment()
        {
            Total = 0;
            Inserted = 0;
            Change = 0;
            BankTotal = 0;
        }
        #endregion



        #region Methods
        public void Insert(double value)
        {
            Inserted += value;
        }

        public void GetSelectedPrice(double value)
        {
            Total = value;
        }

        public bool canBePaid()
        {
            if(Inserted >= Total)
            {
                return true;
            }

            return false;
        }

        public void Pay()
        {
            Change = Inserted - Total;
            
            BankTotal += Total;
            Total = 0;

            Inserted = 0;
        }

        public void CollectBankTotal()
        {
            Console.WriteLine($"Collected Payments: ${BankTotal}");
            BankTotal = 0;
        }

        #endregion

    }
}
