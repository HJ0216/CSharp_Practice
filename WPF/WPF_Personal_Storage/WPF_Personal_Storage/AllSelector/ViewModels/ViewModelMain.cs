using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AllSelector.ViewModels
{
    class ViewModelMain : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion



        #region Properties
        private bool _isNeedAllCheckBoxUpdate;

        private bool _isAllChecked;

        public bool IsAllChecked
        {
            get { return _isAllChecked; }
            set 
            {
                _isAllChecked = value;
                OnPropertyChanged(nameof(IsAllChecked));

                ChangeAllCheckboxStatus();

            }
        }

        private bool _isOneChecked;

        public bool IsOneChecked
        {
            get { return _isOneChecked; }
            set
            {
                _isOneChecked = value;
                OnPropertyChanged(nameof(IsOneChecked));

                ChangeCheckboxStatus();
            }
        }

        private bool _isTwoChecked;

        public bool IsTwoChecked
        {
            get { return _isTwoChecked; }
            set
            {
                _isTwoChecked = value;
                OnPropertyChanged(nameof(IsTwoChecked));

                ChangeCheckboxStatus();
            }
        }

        #endregion



        #region Methods
        private void ChangeAllCheckboxStatus()
        {
            if (_isNeedAllCheckBoxUpdate)
            {
                return;
            }
            else
            {
                if (IsAllChecked)
                {
                    IsOneChecked = true;
                    IsTwoChecked = true;
                }
                else
                {
                    IsOneChecked = false;
                    IsTwoChecked = false;
                }
            }
        }

        private void ChangeCheckboxStatus()
        {
            bool allChecked = IsOneChecked && IsTwoChecked;

            if (IsAllChecked != allChecked)
            {
                _isNeedAllCheckBoxUpdate = true;
            }

            IsAllChecked = allChecked;

            _isNeedAllCheckBoxUpdate = false;
        }

        #endregion
        }
    }
