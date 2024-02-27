using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WeatherApp.ViewModels.Commands
{
    public class SearchCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged
        // This event is typically used to notify consumers (usually UI elements) when the ability to execute the command has changed.
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
            // CommandManager.RequerySuggested: A special event in WPF that tells the UI to reevaluate the ability to execute commands. 
            // This event is raised in response to changes in the UI that might affect the ability to execute commands, like enabling or disabling buttons.

        }
        /*
        1. When a button is bound to a command (such as the `SearchCommand`), 
        the WPF framework automatically subscribes to the `CanExecuteChanged` event of the command.
        2. The `CanExecuteChanged` event is raised by the command object 
        when the conditions affecting the ability to execute the command change.
        - For example, if the `CanExecute` method of the command returns a different value, 
        the command raises the `CanExecuteChanged` event to notify subscribers (like the button) that the ability to execute the command has changed.
        3. The `CanExecuteChanged` event is not directly involved in the button press event. 
        It is mainly used to update the enabled/disabled state of UI elements (like buttons) 
        based on whether the associated command can currently be executed.
         */

        public WeatherVM WeatherVM { get; set; }

        public SearchCommand(WeatherVM weatherVM)
        {
            WeatherVM = weatherVM;
        }

        public bool CanExecute(object? parameter) // CommandParameter로 넘어옴
        {
            string query = parameter as string;
            if (string.IsNullOrWhiteSpace(query))
            {
                return false;
            }

            return true;
        }

        public void Execute(object? parameter)
        {
            WeatherVM.MakeQuery();
        }
    }
}
