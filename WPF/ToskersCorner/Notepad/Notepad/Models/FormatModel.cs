using Notepad.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace Notepad.Models
{
    public class FormatModel : ObservableObject
    {
		private FontStyle _fontStyle;

		public FontStyle FontStyle
        {
			get { return _fontStyle; }
			set { OnPropertyChanged(ref _fontStyle, value); }
		}

		private FontWeight _fontWeight;

		public FontWeight FontWeight
		{
			get { return _fontWeight; }
            set { OnPropertyChanged(ref _fontWeight, value); }
        }

        private FontFamily _fontFamily;

		public FontFamily FontFamily
        {
			get { return _fontFamily; }
            set { OnPropertyChanged(ref _fontFamily, value); }
        }

        private TextWrapping _textWrapping;

		public TextWrapping TextWrapping
		{
			get { return _textWrapping; }
			set 
			{
				OnPropertyChanged(ref _textWrapping, value);
				_isWrapped = (value == TextWrapping.Wrap);
			}
		}

		private bool _isWrapped;

		public bool IsWrapped
		{
			get { return _isWrapped; }
			set { OnPropertyChanged(ref _isWrapped, value); }
		}

		private double _fontSize;

		public double FontSize
		{
			get { return _fontSize; }
			set { OnPropertyChanged(ref _fontSize, value); }
		}



	}
}
