using Notepad.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notepad.Models
{
    public class DocumentModel : ObservableObject
    {
		private string _text;

		public string Text
		{
			get { return _text; }
			set { OnPropertyChanged(ref _text, value); }
		}

		private string _filePath;

		public string FilePath
		{
			get { return _filePath; }
            set { OnPropertyChanged(ref _filePath, value); }
        }

		private string _fileName;

		public string FileName
		{
			get { return _fileName; }
            set { OnPropertyChanged(ref _fileName, value); }
        }

		public bool IsEmpty
		{
			get 
			{
				if (string.IsNullOrEmpty(FilePath) || string.IsNullOrEmpty(FileName)){
					return true;
				}

				return false;
			}
		}



	}
}
