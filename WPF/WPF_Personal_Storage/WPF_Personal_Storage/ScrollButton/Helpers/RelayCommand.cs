using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ScrollButton.Helpers
{
    public class RelayCommand : ICommand
    {
        Action<object> _executeMethod;
        Func<object, bool> _canexecuteMethod;

        public RelayCommand(Action<object> executeMethod)
        {   
            this._executeMethod = executeMethod;
        }

        public RelayCommand(Action<object> executeMethod, Func<object, bool> canexecuteMethod)
        {
            this._executeMethod = executeMethod;
            this._canexecuteMethod = canexecuteMethod;
        }

        /**
         CanExecuteChanged 이벤트에 대한 가입 및 해지를 CommandManager.RequerySuggested에 연결
         명령의 실행 가능 상태가 변경될 때 UI가 이를 감지하고 반응할 수 있도록 함
         예를 들어, 사용자의 액션에 따라 명령이 실행 가능하거나 불가능해질 때 UI 컨트롤이 자동으로 활성화 또는 비활성화 되도록 해줌
         */
        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object? parameter)
        {
            //return parameter == null ? true : _canexecuteMethod(parameter);
            return true;
        }

        public void Execute(object? parameter)
        {
            _executeMethod(parameter);
        }
    }
}
