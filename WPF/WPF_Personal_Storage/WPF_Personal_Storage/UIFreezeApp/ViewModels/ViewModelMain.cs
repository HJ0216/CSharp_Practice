using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UIFreezeApp.Helpers;

namespace UIFreezeApp.ViewModels
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
        private DataModel _data;

        public DataModel Data
        {
            get { return _data; }
            set 
            {
                _data = value;
                OnPropertyChanged(nameof(Data));
            }
        }

        private ObservableCollection<DataModel> _dataModels;

        public ObservableCollection<DataModel> DataModels
        {
            get { return _dataModels; }
            set { _dataModels = value; }
        }

        #endregion


        #region Commands
        public RelayCommand OpenFileCommand => null ?? new RelayCommand(OpenFileEvent);

        #endregion



        #region Constructors
        public ViewModelMain()
        {
            DataModels = new ObservableCollection<DataModel>();
        }
        #endregion



        #region Methods
        private void OpenFileEvent(object obj)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            bool? result = fileDialog.ShowDialog();

            if (result == false)
            {
                return;
            }

            if (string.IsNullOrEmpty(fileDialog.FileName))
            {
                return;
            }

            DataModels = GetDataModels(fileDialog.FileName);
            // 참조 변경으로 인한 Update
            OnPropertyChanged(nameof(DataModels));

        }

        private ObservableCollection<DataModel> GetDataModels(string fileName)
        {
            bool isFirstLine = true;
            // Column Name 데이터 제외
            
            ObservableCollection<DataModel> returnDatas = new ObservableCollection<DataModel>();

            using(var reader = new StreamReader(fileName, Encoding.UTF8))
            {
                long id = 1L;
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();

                    if (isFirstLine)
                    {
                        isFirstLine = false;
                        continue;
                    }

                    if(line != null)
                    {
                        DataModel model = GetDataModel(line);
                        model.Id = id++;
                        returnDatas.Add(model);
                    }
                }

                reader.Close();
            }

            return returnDatas;
        }

        private DataModel GetDataModel(string line)
        {
            var columns = line.Split(",");

            var model = new DataModel();
            model.CompanyName = columns[1];
            model.Location = columns[5];
            model.Sector = columns[14];
            model.NumberOfEmployees = Convert.ToInt32(columns[18]);
            model.NumberOfNewEmployees = Convert.ToInt32(columns[20]);
            model.NumberOfLeavers = Convert.ToInt32(columns[21]);

            return model;
        }

        #endregion

    }

    public class DataModel : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion



        private long _id;
        public long Id
        {
            get { return _id; }
            set
            {
                _id = value;
                OnPropertyChanged(nameof(Id));
            }
        }

        private string _companyName;
        public string CompanyName
        {
            get { return _companyName; }
            set
            {
                _companyName = value;
                OnPropertyChanged(nameof(CompanyName));
            }
        }

        private string _location;
        public string Location
        {
            get { return _location; }
            set
            {
                _location = value;
                OnPropertyChanged(nameof(Location));
            }
        }

        private string _sector;
        public string Sector
        {
            get { return _sector; }
            set
            {
                _sector = value;
                OnPropertyChanged(nameof(Sector));
            }
        }

        private int _numberOfEmployees;
        public int NumberOfEmployees
        {
            get { return _numberOfEmployees; }
            set
            {
                _numberOfEmployees = value;
                OnPropertyChanged(nameof(NumberOfEmployees));
            }
        }

        private int _numberOfNewEmployees;
        public int NumberOfNewEmployees
        {
            get { return _numberOfNewEmployees; }
            set
            {
                _numberOfNewEmployees = value;
                OnPropertyChanged(nameof(NumberOfNewEmployees));
            }
        }

        private int _numberOfLeavers;
        public int NumberOfLeavers
        {
            get { return _numberOfLeavers; }
            set
            {
                _numberOfLeavers = value;
                OnPropertyChanged(nameof(NumberOfLeavers));
            }
        }
    }

}
