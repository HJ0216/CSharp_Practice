using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ExperimentWithControls
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void numberTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            number.Text = numberTextBox.Text;
            // 초기 실행 시, TextBox 객체(numberTextBox)의 이벤트 처리기(TextChanged)가 실행됨
            // number가 numberTextBox보다 뒤에 있을 경우, TextBlock 객체(number)가 안만들어진 상태이므로 NullPointerException 발생
        }

        private void numberTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        // PreviewTextInput: 텍스트 입력이 실제로 발생하기 전에 발생하는 이벤트
        {
            e.Handled = !int.TryParse(e.Text, out int result);
            // e.Handled: 이벤트를 처리한 후에 더 이상의 처리가 필요하지 않음을 나타내는 부울 값
            // false로 설정되면 이벤트가 현재 핸들러에서 처리되지 않았으며, 다른 핸들러들이나 기본 동작이 계속해서 실행
        }

        private void smallSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            number.Text = smallSlider.Value.ToString("0");
        }

        private void bigSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            number.Text = bigSlider.Value.ToString("00-0000-0000");
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            if (sender is RadioButton radioButton)
            {
                number.Text = radioButton.Content.ToString();
            }
        }

        private void myListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (myListBox.SelectedItem is ListBoxItem listBoxItem)
            {
                number.Text = listBoxItem.Content.ToString();
            }
        }

        private void readOnlyComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (readOnlyComboBox.SelectedItem is ComboBoxItem comboBoxItem)
            {
                number.Text = comboBoxItem.Content.ToString();
            }
        }

        private void editableComboBox_TextChanged(object sender, RoutedEventArgs e)
        {
            if (sender is ComboBox comboBox)
            {
                number.Text = comboBox.Text;
            }
        }
    }
}