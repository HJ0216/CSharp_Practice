using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace SmartHomeApp.ViewModels
{
    public class ViewModelCard
    {
		private string _title = string.Empty;

		public string Title
		{
			get { return _title; }
			set { _title = value; }
		}

		private bool _isChecked;

		public bool IsChecked
		{
			get { return _isChecked; }
			set { _isChecked = value; }
		}

		private bool _isHorizontal;

		public bool IsHorizontal
		{
			get { return _isHorizontal; }
			set { _isHorizontal = value; }
		}

		private ImageSource _imageOn;

		public ImageSource ImageOn
		{
			get { return _imageOn; }
			set { _imageOn = value; }
		}

        private ImageSource _imageOff;

        public ImageSource ImageOff
        {
            get { return _imageOff; }
            set { _imageOff = value; }
        }

    }
}
