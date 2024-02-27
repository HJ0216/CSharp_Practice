using EvernoteCloneApp.Model;
using EvernoteCloneApp.ViewModels.Commands;
using EvernoteCloneApp.ViewModels.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

namespace EvernoteCloneApp.ViewModels
{
    public class NotesViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Notebook> Notebooks { get; set; }

		private Notebook _selectedNotebook;
        public Notebook SelectedNotebook
		{
			get { return _selectedNotebook; }
			set
			{
				_selectedNotebook = value;
                OnPropertyChanged("SelectedNotebook");
                GetNotes();
			}
		}

        private Note _selectedNote;
        public Note SelectedNote
        {
            get { return _selectedNote; }
            set
            {
                _selectedNote = value;
                OnPropertyChanged("SelectedNote");
                SelectedNoteChanged?.Invoke(this, new EventArgs());
            }
        }

        private string _contentTextBox;

        public string ContentTextBox
        {
            get { return _contentTextBox; }
            set 
            { 
                _contentTextBox = value;
                OnPropertyChanged("ContentTextBox");
                CalculateLengthOfText();
            }
        }

        private string _statusTextBlock;

        public string StatusTextBlock
        {
            get { return _statusTextBlock; }
            set 
            { 
                _statusTextBlock = value;
                OnPropertyChanged("StatusTextBlock");
            }
        }

        private FlowDocument _contentFlowDocument;

        public FlowDocument ContentFlowDocument
        {
            get { return _contentFlowDocument; }
            set 
            {
                _contentFlowDocument = value;
                OnPropertyChanged("ContentFlowDocument");
                MessageBox.Show("하이");
                ContentRichTextBox = _contentFlowDocument.ToString();
            }
        }

        private string _contentRichTextBox;
        public string ContentRichTextBox
        {
            get { return _contentRichTextBox; }
            set 
            {
                _contentRichTextBox = value;
                OnPropertyChanged("ContentRichTextBox");
                MessageBox.Show("하이");
            }
        }

        private Visibility _isVisible;

        public Visibility IsVisible
        {
            get { return _isVisible; }
            set 
            { 
                _isVisible = value;
                OnPropertyChanged("IsVisible");
            }
        }


        public event PropertyChangedEventHandler? PropertyChanged;
        public event EventHandler SelectedNoteChanged;

        public ObservableCollection<Note> Notes { get; set; }

        public NewNotebookCommand NewNotebookCommand { get; set; }
        public NewNoteCommand NewNoteCommand { get; set; }
        public ExitCommand ExitCommand { get; set; }
        public SpeechCommand SpeechCommand { get; set; }
        public TextBoxCommand TextBoxCommand { get; set; }
        public EditCommand EditCommand { get; set; }
        public EndEditingCommand EndEditingCommand { get; set; }

        public NotesViewModel()
        {
            NewNotebookCommand = new NewNotebookCommand(this);
            NewNoteCommand = new NewNoteCommand(this);
            ExitCommand = new ExitCommand(this);
            SpeechCommand = new SpeechCommand(this);
            TextBoxCommand = new TextBoxCommand(this);
            EditCommand = new EditCommand(this);
            EndEditingCommand = new EndEditingCommand(this);

            Notebooks = new ObservableCollection<Notebook>();
            Notes = new ObservableCollection<Note>();

            IsVisible = Visibility.Collapsed;

            GetNoteBooks();
        }

        public void CreateNotebbok()
        {
            Notebook NewNotebook = new Notebook()
            {
                Name = "New Notebook"
            };

            DatabaseHelper.Insert(NewNotebook);

            GetNoteBooks();
        }

        public void CreateNote(int notebookId)
        {
            Note newNote = new Note()
            {
                NotebookId = notebookId,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                Title = "New Note"
            };

            DatabaseHelper.Insert(newNote);

            GetNotes();
        }

        private void GetNoteBooks()
        {
            var notebooks = DatabaseHelper.Read<Notebook>();

            Notebooks.Clear();
            foreach(var notebook in notebooks)
            {
                Notebooks.Add(notebook);
            }
        }

        private void GetNotes()
        {
            if (SelectedNotebook != null) 
            { 
                var notes = DatabaseHelper.Read<Note>().Where(n => n.NotebookId == SelectedNotebook.Id).ToList();

                Notes.Clear();
                foreach(var note in notes)
                {
                    Notes.Add(note);
                }
            }
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void CalculateLengthOfText()
        {
            int amountCharacters = 0;
            
            if (!string.IsNullOrWhiteSpace(ContentTextBox))
            {
                amountCharacters = ContentTextBox.Length;
            }

            StatusTextBlock = $"Document length: {amountCharacters} characters";

        }

        public void StartEditing()
        {
            IsVisible = Visibility.Visible;
        }
        public void StopEditing(Notebook notebook)
        {
            IsVisible = Visibility.Collapsed;
            DatabaseHelper.Update(notebook);

            GetNoteBooks();
        }

    }
}
