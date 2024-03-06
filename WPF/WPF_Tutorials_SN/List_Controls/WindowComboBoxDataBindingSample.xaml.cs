using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace List_Controls
{
    /// <summary>
    /// Interaction logic for WindowComboBoxDataBindingSample.xaml
    /// </summary>
    public partial class WindowComboBoxDataBindingSample : Window
    {
        public WindowComboBoxDataBindingSample()
        {
            InitializeComponent();
            colorComboBox.ItemsSource = typeof(Colors).GetProperties();
        }

        private void colorComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Color selectedColor = (Color)(colorComboBox.SelectedItem as PropertyInfo).GetValue(null, null);
            // GetValue 첫 번째 Null
            // 첫 번째 매개변수는 속성의 값을 가져올 객체의 인스턴스
            // 만약 속성이 정적(Static)이면, 이 매개변수는 null(정적 속성은 특정 인스턴스에 속하지 않고 클래스 자체에 속하기 때문)
            // GetValue 두 번째 Null
            // 두 번째 매개변수는 인덱서 속성을 가져올 때 사용되는 인덱스 값
            // 인덱서 속성이 아닌 경우, 매개변수는 null
            this.Background = new SolidColorBrush(selectedColor);
        }

        private void buttonPrevious_Click(object sender, RoutedEventArgs e)
        {
            if (colorComboBox.SelectedIndex > 0)
            {
                colorComboBox.SelectedIndex -= 1;
            }
        }

        private void buttonNext_Click(object sender, RoutedEventArgs e)
        {
            if (colorComboBox.SelectedIndex < colorComboBox.Items.Count - 1)
            {
                colorComboBox.SelectedIndex += 1;
            }
        }

        private void buttonBlue_Click(object sender, RoutedEventArgs e)
        {
            colorComboBox.SelectedItem = typeof(Colors).GetProperty("Blue");
        }

    }
}
