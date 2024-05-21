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
        private bool _isAllChecked;
        private bool _isOneChecked;
        private bool _isTwoChecked;
        private bool _isThreeChecked;
        private bool _isFourChecked;
        private bool _ignoreCheckAll;

        public event PropertyChangedEventHandler PropertyChanged;

        public bool IsAllChecked
        {
            get => _isAllChecked;
            set
            {
                if (_isAllChecked != value)
                {
                    _isAllChecked = value;
                    OnPropertyChanged(nameof(IsAllChecked));
                    if (!_ignoreCheckAll)
                    {
                        _ignoreCheckAll = true;
                        IsOneChecked = value;
                        IsTwoChecked = value;
                        IsThreeChecked = value;
                        IsFourChecked = value;
                        _ignoreCheckAll = false;
                    }
                }
            }
        }

        public bool IsOneChecked
        {
            get => _isOneChecked;
            set
            {
                if (_isOneChecked != value)
                {
                    _isOneChecked = value;
                    OnPropertyChanged(nameof(IsOneChecked));
                    UpdateIsAllChecked();
                }
            }
        }

        public bool IsTwoChecked
        {
            get => _isTwoChecked;
            set
            {
                if (_isTwoChecked != value)
                {
                    _isTwoChecked = value;
                    OnPropertyChanged(nameof(IsTwoChecked));
                    UpdateIsAllChecked();
                }
            }
        }

        public bool IsThreeChecked
        {
            get => _isThreeChecked;
            set
            {
                if (_isThreeChecked != value)
                {
                    _isThreeChecked = value;
                    OnPropertyChanged(nameof(IsThreeChecked));
                    UpdateIsAllChecked();
                }
            }
        }

        public bool IsFourChecked
        {
            get => _isFourChecked;
            set
            {
                if (_isFourChecked != value)
                {
                    _isFourChecked = value;
                    OnPropertyChanged(nameof(IsFourChecked));
                    UpdateIsAllChecked();
                }
            }
        }

        private void UpdateIsAllChecked()
        {
            if (!_ignoreCheckAll)
            {
                _ignoreCheckAll = true;
                IsAllChecked = _isOneChecked && _isTwoChecked && _isThreeChecked && _isFourChecked;
                _ignoreCheckAll = false;
            }
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    /*    {
            #region INotifyPropertyChanged
            public event PropertyChangedEventHandler? PropertyChanged;

            protected virtual void OnPropertyChanged(string propertyName)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }

            #endregion



            #region Properties
            private bool _isAllChecked;

            public bool IsAllChecked
            {
                get { return _isAllChecked; }
                set 
                {
                    _isAllChecked = value;
                    OnPropertyChanged(nameof(IsAllChecked));

                    ChangeCheckboxFromAll();

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

                    ChangeCheckboxFromEach();
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

                    ChangeCheckboxFromEach();
                }
            }

            #endregion



            #region Methods
            private void ChangeCheckboxFromAll()
            {
                bool alreadyCheckedAll = IsOneChecked && IsTwoChecked;

                if (IsAllChecked == alreadyCheckedAll)
                {
                    return;
                }
                else
                {
                    IsOneChecked = IsAllChecked;
                    IsTwoChecked = IsAllChecked;
                }

            }

            private void ChangeCheckboxFromEach()
            {
                bool alreadyCheckedAll = IsOneChecked && IsTwoChecked;

                if (IsAllChecked == alreadyCheckedAll)
                {
                    return;
                }
                else
                {
                    IsAllChecked = alreadyCheckedAll;
                }

            }
            #endregion
        }*/
}
