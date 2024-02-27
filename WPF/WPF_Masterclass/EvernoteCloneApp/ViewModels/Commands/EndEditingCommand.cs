using EvernoteCloneApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EvernoteCloneApp.ViewModels.Commands
{
    public class EndEditingCommand : ICommand
    {
        public NotesViewModel NotesViewModel { get; set; }
        public event EventHandler? CanExecuteChanged;

        public EndEditingCommand(NotesViewModel notesViewModel)
        {
            NotesViewModel = notesViewModel;
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            Notebook notebook = parameter as Notebook;
            if(notebook != null)
            {
                NotesViewModel.StopEditing(notebook);
            }
        }
    }
}
