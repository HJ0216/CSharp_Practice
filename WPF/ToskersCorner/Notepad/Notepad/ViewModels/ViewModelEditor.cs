using Notepad.Helpers;
using Notepad.Models;
using Notepad.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Notepad.ViewModels
{
    public class ViewModelEditor
    {
        #region Properties
        public FormatModel FormatModel { get; set; }
        public DocumentModel DocumentModel { get; set; }

        #endregion



        #region Commands
        public ICommand FormatCommand => null ?? new RelayCommand(OpenStyleDialog);
        public ICommand WrapCommand => null ?? new RelayCommand(ToggleWrap);

        #endregion



        #region Constructors
        public ViewModelEditor(DocumentModel documentModel)
        {
            DocumentModel = documentModel;
            FormatModel = new FormatModel();
        }

        #endregion



        #region Methods
        private void OpenStyleDialog()
        {
            var fontDialog = new WindowFontDialog();
            fontDialog.DataContext = FormatModel;
            fontDialog.ShowDialog();
        }

        private void ToggleWrap()
        {
            if(FormatModel.TextWrapping == System.Windows.TextWrapping.Wrap)
            {
                FormatModel.TextWrapping = System.Windows.TextWrapping.NoWrap;
            }
            else
            {
                FormatModel.TextWrapping = System.Windows.TextWrapping.Wrap;
            }
        }

        #endregion
    }
}
