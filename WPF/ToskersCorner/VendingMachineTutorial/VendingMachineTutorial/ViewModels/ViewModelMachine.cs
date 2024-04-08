using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using VendingMachineTutorial.Helpers;

namespace VendingMachineTutorial.ViewModels
{
    public class ViewModelMachine : INotifyPropertyChanged
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
        public ObservableCollection<ViewModelProduct> VmProducts { get; set; }

        private ViewModelPayment _vmPayment;

        public ViewModelPayment VmPayment
        {
            get { return _vmPayment; }
            set 
            {
                _vmPayment = value;
                OnPropertyChange(nameof(VmPayment));
            }
        }


        #endregion



        #region Commands
        public ICommand PurchaseCommand => null ?? new RelayCommand(PurchaseEvent);
        public ICommand InsertCoinCommand => null ?? new RelayCommand(InsertCoinEvent);
        public ICommand RefillCommand => null ?? new RelayCommand(RefillEvent);
        public ICommand EmptyCommand => null ?? new RelayCommand(EmptyEvent);
        public ICommand WithdrawCommand => null ?? new RelayCommand(CollectPaymentsEvent);


        #endregion



        #region Constructors
        public ViewModelMachine()
        {
            VmProducts = new ObservableCollection<ViewModelProduct>()
            {
                new ViewModelProduct(1, "Regular Cola", 0.50)
                , new ViewModelProduct(2, "Diet Cola", 0.50)
                , new ViewModelProduct(3, "Zero Cola", 0.75)
                , new ViewModelProduct(4, "Cherry Cola", 0.75)
            };

            VmPayment = new ViewModelPayment();
        }
        #endregion



        #region Methods
        public void PurchaseEvent(object item)
        {
            var requestedItem = item as ViewModelProduct;
            VmPayment.GetSelectedPrice(requestedItem.Information.Price);

            if (VmPayment.canBePaid())
            {
                if (requestedItem.Dispense())
                {
                    VmPayment.Pay();
                    Console.WriteLine("Enjoy Your Beverage!");
                }
            }
        }

        public void InsertCoinEvent(object value)
        {
            double insertedCoin = Convert.ToDouble(value);
            VmPayment.Insert(insertedCoin);
        }

        public void CollectPaymentsEvent(object obj)
        {
            VmPayment.CollectBankTotal();
        }

        public void RefillEvent(object obj)
        {
            foreach(ViewModelProduct item in VmProducts)
            {
                item.Refill();
            }

            Console.WriteLine("Machine has been Refilled!");
        }

        public void EmptyEvent(object obj)
        {
            foreach (ViewModelProduct item in VmProducts)
            {
                item.Empty();
            }

            Console.WriteLine("Machine has been Cleared!");
        }

        #endregion

    }
}
