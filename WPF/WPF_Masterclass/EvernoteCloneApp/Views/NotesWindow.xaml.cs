using EvernoteCloneApp.ViewModels;
using EvernoteCloneApp.ViewModels.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace EvernoteCloneApp.Views
{
    /// <summary>
    /// Interaction logic for NotesWindow.xaml
    /// </summary>
    public partial class NotesWindow : Window
    {

        NotesViewModel notesViewModel;
        public NotesWindow()
        {
            InitializeComponent();

            notesViewModel = Resources["NotesViewModel"] as NotesViewModel;
            notesViewModel.SelectedNoteChanged += NotesViewModel_SelectedNoteChanged;

            var fontFamilies = Fonts.SystemFontFamilies.OrderBy(f => f.Source);
            fontFamilyComboBox.ItemsSource = fontFamilies;

            List<double> fontSizes = new List<double>() { 8, 9, 10, 11, 12, 14, 16, 18, 20, 24, 28, 36, 40, 48 };
            fontSizeComboBox.ItemsSource = fontSizes;
        }

        private void NotesViewModel_SelectedNoteChanged(object? sender, EventArgs e)
        {
            contentRichText.Document.Blocks.Clear();
            if(notesViewModel.SelectedNote != null)
            {
                if (!string.IsNullOrEmpty(notesViewModel.SelectedNote.FileLocation))
                {
                    FileStream fileStream = new FileStream(notesViewModel.SelectedNote.FileLocation, FileMode.Open);
                    var contents = new TextRange(contentRichText.Document.ContentStart, contentRichText.Document.ContentEnd);
                    contents.Load(fileStream, DataFormats.Rtf);
                }
            }
        }

        private void contentRichText_SelectionChanged(object sender, RoutedEventArgs e)
        {
            var selectedWeight = contentRichText.Selection.GetPropertyValue(Inline.FontWeightProperty);
            boldButton.IsChecked = (selectedWeight != DependencyProperty.UnsetValue) && (selectedWeight.Equals(FontWeights.Bold));
            // DependencyProperty.UnsetValue: 변수가 초기화되었는지 확인

            var selectedStyle = contentRichText.Selection.GetPropertyValue(Inline.FontStyleProperty);
            boldButton.IsChecked = (selectedWeight != DependencyProperty.UnsetValue) && (selectedStyle.Equals(FontStyles.Italic));

            var selectedDecoration= contentRichText.Selection.GetPropertyValue(Inline.TextDecorationsProperty);
            boldButton.IsChecked = (selectedWeight != DependencyProperty.UnsetValue) && (selectedDecoration.Equals(TextDecorations.Underline));

            fontFamilyComboBox.SelectedItem = contentRichText.Selection.GetPropertyValue(Inline.FontFamilyProperty);
            fontSizeComboBox.Text = (contentRichText.Selection.GetPropertyValue(Inline.FontSizeProperty)).ToString();
        }

        private void BoldButton_Click(object sender, RoutedEventArgs e)
        {
            bool isButtonChecked = (sender as ToggleButton).IsChecked ?? false;
            if (isButtonChecked)
            {
                contentRichText.Selection.ApplyPropertyValue(Inline.FontWeightProperty, FontWeights.Bold);
            }
            else
            {
                contentRichText.Selection.ApplyPropertyValue(Inline.FontWeightProperty, FontWeights.Normal);
            }
        }

        private void italicButton_Click(object sender, RoutedEventArgs e)
        {
            bool isButtonChecked = (sender as ToggleButton).IsChecked ?? false;
            if (isButtonChecked)
            {
                contentRichText.Selection.ApplyPropertyValue(Inline.FontStyleProperty, FontStyles.Italic);
            }
            else
            {
                contentRichText.Selection.ApplyPropertyValue(Inline.FontStyleProperty, FontWeights.Normal);
            }
        }

        private void underlineButton_Click(object sender, RoutedEventArgs e)
        {
            bool isButtonChecked = (sender as ToggleButton).IsChecked ?? false;
            if (isButtonChecked)
            {
                contentRichText.Selection.ApplyPropertyValue(Inline.TextDecorationsProperty, TextDecorations.Underline);
            }
            else
            {
                TextDecorationCollection textDecorations;
                (contentRichText.Selection.GetPropertyValue(Inline.TextDecorationsProperty) as TextDecorationCollection).TryRemove(TextDecorations.Underline, out textDecorations);
                contentRichText.Selection.ApplyPropertyValue(Inline.TextDecorationsProperty, textDecorations);
            }

        }

        private void fontFamilyComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(fontFamilyComboBox.SelectedItem != null)
            {
                contentRichText.Selection.ApplyPropertyValue(Inline.FontFamilyProperty, fontFamilyComboBox.SelectedItem);
            }

        }

        private void fontSizeComboBox_TextChanged(object sender, TextChangedEventArgs e)
        {
           contentRichText.Selection.ApplyPropertyValue(Inline.FontSizeProperty, fontSizeComboBox.Text);
        }

        private void SaveNotebookButton_Click(object sender, RoutedEventArgs e)
        {
            string rtfFile = System.IO.Path.Combine(Environment.CurrentDirectory, $"{notesViewModel.SelectedNote.Id}.rtf");
            notesViewModel.SelectedNote.FileLocation = rtfFile;
            DatabaseHelper.Update(notesViewModel.SelectedNote);

            FileStream fileStream = new FileStream(rtfFile, FileMode.Create);
            var contents = new TextRange(contentRichText.Document.ContentStart, contentRichText.Document.ContentEnd);
            contents.Save(fileStream, DataFormats.Rtf);
        }
    }
}
