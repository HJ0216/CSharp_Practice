using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Notepad.Helpers
{
    public class RelayCommand : ICommand
    {
        readonly Action _execute;
        readonly Func<bool> _canExecute;

        public RelayCommand(Action execute, Func<bool> canExecute)
        {
            if(execute == null) throw new ArgumentNullException(nameof(execute));

            _execute = execute;
            _canExecute = canExecute;
        }

        // Overload, canExecute = true
        public RelayCommand(Action execute) : this(execute, null)
        {

        }

        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object? parameter)
        {
            return _canExecute == null ? true : _canExecute();
            // _canExecute 델리게이트에 아무 함수도 할당되지 않았다면, 명령은 실행 가능한 상태로 간주
            // 실행 가능 여부를 결정하는 함수가 제공되었다면, 이 함수를 호출하여 그 결과를 반환
        }

        public void Execute(object? parameter)
        {
            _execute.Invoke();
        }
    }
}
