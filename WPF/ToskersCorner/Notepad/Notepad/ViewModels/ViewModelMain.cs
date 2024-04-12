using Notepad.Helpers;
using Notepad.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Notepad.ViewModels
{
    public class ViewModelMain
    {
        #region Properties
        private DocumentModel _documentModel;
        public ViewModelEditor VmEditor { get; set; }
        public ViewModelFile VmFile { get; set; }
        public ViewModelHelp VmHelp { get; set; }

        #endregion



        #region Commands

        #endregion



        #region Constructors
        public ViewModelMain()
        {
            _documentModel = new DocumentModel();
            VmEditor = new ViewModelEditor(_documentModel);
            VmFile = new ViewModelFile(_documentModel);
            VmHelp = new ViewModelHelp();
        }

        #endregion



        #region Methods

        #endregion
    }
}
