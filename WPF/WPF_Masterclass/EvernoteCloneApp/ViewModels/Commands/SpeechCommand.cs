using Microsoft.CognitiveServices.Speech;
using Microsoft.CognitiveServices.Speech.Audio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EvernoteCloneApp.ViewModels.Commands
{
    public class SpeechCommand : ICommand
    {
        public NotesViewModel NotesViewModel { get; set; }

        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public SpeechCommand(NotesViewModel notesViewModel)
        {
            NotesViewModel = notesViewModel;
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public async void Execute(object? parameter)
        {
            string region = "koreacentral";
            string key = "";

            var speechConfig = SpeechConfig.FromSubscription(key, region);
            using(var audioConfig = AudioConfig.FromDefaultMicrophoneInput())
            {
                using(var recognizer = new SpeechRecognizer(speechConfig, audioConfig))
                {
                    var result = await recognizer.RecognizeOnceAsync();

                    // contentRichTextBox.Document.Blocks.Add(new Paragraph(new Run(result.Text)));
                    NotesViewModel.ContentTextBox = result.Text;

                }
            }
        }
    }
}
