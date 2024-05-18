using ConstructorOverriding.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructorOverriding.ViewModels
{
    public class ViewModelMain : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion


        #region Properties
        private string _data1;

        public string Data1
        {
            get { return _data1; }
            set 
            {
                _data1 = value;
                OnPropertyChanged(nameof(Data1));
            }
        }

        private string _data2;

        public string Data2
        {
            get { return _data2; }
            set
            {
                _data2 = value;
                OnPropertyChanged(nameof(Data2));
            }
        }

        private string _data3;

        public string Data3
        {
            get { return _data3; }
            set
            {
                _data3 = value;
                OnPropertyChanged(nameof(Data3));
            }
        }

        #endregion

        public ViewModelMain()
        {
            
        }

        public ViewModelMain(string data1)
        {
            Data1 = data1;
        }

        public ViewModelMain(string data1, string data2) : this(data1)
        {
            Data2 = data2;
        }

        public ViewModelMain(string data1, string data2, string data3) : this(data1, data2)
        {
            Data3 = data3;
        }


        public void OpenWindowSub1()
        {
            WindowSub1 window = new WindowSub1();
            window.DataContext = new ViewModelSub1();
            window.Show();
        }
    }
}
