using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;

namespace EvernoteCloneApp.ViewModels.Commands
{
    public class TextBoxCommand : ICommand
    {
        public NotesViewModel NotesViewModel { get; set; }

        private string _contentTextBox;

        public string ContentTextBox
        {
            get { return _contentTextBox; }
            set 
            { 
                _contentTextBox = NotesViewModel.ContentTextBox; 
            }
        }


        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public TextBoxCommand(NotesViewModel notesViewModel)
        {
            NotesViewModel = notesViewModel;
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            // TODO: Selection Bold

            //ContentTextBox.Selection.ApplyPropertyValue(Inline.FontWeightProperty, FontWeights.Bold);
        }
    }
}
