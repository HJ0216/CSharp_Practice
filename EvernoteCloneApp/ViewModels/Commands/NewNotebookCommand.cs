using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EvernoteCloneApp.ViewModels.Commands
{
    public class NewNotebookCommand : ICommand
    {
        public NotesViewModel NotesViewModel { get; set; }
        public event EventHandler? CanExecuteChanged;

        public NewNotebookCommand(NotesViewModel notesViewModel)
        {
            NotesViewModel = notesViewModel;
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            NotesViewModel.CreateNotebbok();
        }
    }
}
