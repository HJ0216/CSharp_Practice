using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using VendingMachineTutorial.Models;

namespace VendingMachineTutorial.ViewModels
{
    public class ViewModelProduct : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler? PropertyChanged;

        public void OnPropertyChange(string prop)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }

        #endregion



        #region Properties
        private VendingItemModel _vendingItemModel { get; set; }
        private const int _maxQuantity = 10;

        private long _id;

        public long Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private int _quantity;

        public int Quantity
        {
            get { return _quantity; }
            set 
            {
                _quantity = value;
                OnPropertyChange(nameof(OutOfStockMessage));
                OnPropertyChange(nameof(InventoryDisplay));
                OnPropertyChange(nameof(Quantity));
            }
        }

        public string InventoryDisplay
        {
            get
            {
                return _vendingItemModel.Name + ": " + Quantity;
            }
        }

        public VendingItemModel Information
        {
            get
            {
                return _vendingItemModel;
            }
        }

        public Visibility OutOfStockMessage
        {
            get
            {
                if(Quantity > 0)
                {
                    return Visibility.Hidden;
                }

                return Visibility.Visible;
            }
        }

        #endregion



        #region Commands
        #endregion



        #region Constructors
        public ViewModelProduct(long id, string name, double price)
        {
            _vendingItemModel = new VendingItemModel(id, name, price);
            Quantity = 0;
        }
        #endregion



        #region Methods
        public int Refill()
        {
            var refilledQuantity = _maxQuantity - Quantity;
            Quantity += refilledQuantity;

            return refilledQuantity;
        }

        public int Empty()
        {
            var remaining = Quantity;
            Quantity = 0;
            return remaining;
        }

        public bool Dispense()
        {
            if(Quantity > 0)
            {
                --Quantity;
                return true;
            }

            return false;
        }

        #endregion

    }
}
