using Microsoft.Win32;
using Notepad.Helpers;
using Notepad.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Notepad.ViewModels
{
    public class ViewModelFile
    {
        #region Properties
        public DocumentModel DocumentModel { get; private set; }
        #endregion



        #region Commands
        public ICommand NewFileCommand => null ?? new RelayCommand(NewFileEvent);
        public ICommand SaveFileCommand => null ?? new RelayCommand(SaveFileEvent);
        public ICommand SaveFileAsCommand => null ?? new RelayCommand(SaveFileAsEvent);
        public ICommand OpenFileCommand => null ?? new RelayCommand(OpenFileEvent);
        #endregion



        #region Constructors
        public ViewModelFile(DocumentModel documentModel)
        {
            DocumentModel = documentModel;
        }

        #endregion



        #region Methods
        private void NewFileEvent()
        {
            DocumentModel.Text = string.Empty;
            DocumentModel.FilePath = string.Empty;
            DocumentModel.FileName = string.Empty;
        }

        private void SaveFileEvent()
        {
            File.WriteAllText(DocumentModel.FilePath, DocumentModel.Text);
        }

        private void SaveFileAsEvent()
        {
            var saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text File (*.txt)|*.txt";

            if(saveFileDialog.ShowDialog() == true)
            {
                DockFile(saveFileDialog);
                File.WriteAllText(DocumentModel.FilePath, DocumentModel.Text);
            }
        }

        private void OpenFileEvent()
        {
            var openFileDialog = new OpenFileDialog();
            if(openFileDialog.ShowDialog() == true)
            {
                DockFile(openFileDialog);
                DocumentModel.Text = File.ReadAllText(openFileDialog.FileName);
            }
        }

        private void DockFile<T>(T dialog) where T : FileDialog
        {
            DocumentModel.FilePath = dialog.FileName;
            DocumentModel.FileName = dialog.SafeFileName;
        }

        #endregion

    }
}
