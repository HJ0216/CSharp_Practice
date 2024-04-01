using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHomeApp.ViewModels
{
    public class ViewModelAddButton
    {
        #region Properties
        private string _title = string.Empty;

        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        #endregion



        #region Commands
        #endregion



        #region Constructors
        public ViewModelAddButton(string title)
        {
            Title = title;
        }

        #endregion



        #region Methods
        #endregion

    }
}
