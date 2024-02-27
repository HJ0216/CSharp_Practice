using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace EvernoteCloneApp.ViewModels.Commands
{
    public class ExitCommand : ICommand
    {
        public NotesViewModel NotesViewModel { get; set; }
        public event EventHandler? CanExecuteChanged;

        public ExitCommand(NotesViewModel notesViewModel)
        {
            NotesViewModel = notesViewModel;
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            var window = parameter as Window;
            if(window != null)
            {
                window.Close();
            }
        }
    }
}
