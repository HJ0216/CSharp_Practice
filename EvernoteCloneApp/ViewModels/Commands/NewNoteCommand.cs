using EvernoteCloneApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EvernoteCloneApp.ViewModels.Commands
{
    public class NewNoteCommand : ICommand
    {
        public NotesViewModel NotesViewModel { get; set; }
        public event EventHandler? CanExecuteChanged
        // CanExecuteChanged: 해당 명령이 실행 가능 여부에 대한 변화가 있을 때마다 발생
        //  만약 CanExecuteChanged 이벤트에 구독자가 추가되지 않으면,
        //  해당 명령이 사용 가능한지 여부에 변화가 있을 때 UI가 업데이트되지 않을 수 있음
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public NewNoteCommand(NotesViewModel notesViewModel)
        {
            NotesViewModel = notesViewModel;
        }

        public bool CanExecute(object? parameter)
        {
            Notebook selectedNotebook = parameter as Notebook;

            if(selectedNotebook != null)
            {
                return true;
            }

            return false;
        }

        public void Execute(object? parameter)
        {
            Notebook selectedNotebook = parameter as Notebook;
            // TODO: Create new Note
            NotesViewModel.CreateNote(selectedNotebook.Id);
        }
    }
}
