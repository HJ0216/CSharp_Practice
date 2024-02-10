using System.Security.Cryptography;
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

namespace CalculatorApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double result;
        double lastNumber;
        SelectedOperation selectedOperation;

        public MainWindow()
        {
            InitializeComponent();
            acButton.Click += AcButton_Click;
            negativeButton.Click += NegativeButton_Click;
            percentageButton.Click += PercentageButton_Click;
            equalButton.Click += EqualButton_Click;
        }

        private void EqualButton_Click(object sender, RoutedEventArgs e)
        {
            double newNumber;
            if (double.TryParse(resultLabel.Content.ToString(), out newNumber))
            {
                switch (selectedOperation)
                {
                    case SelectedOperation.Addtion:
                        result = SimpleMath.Add(lastNumber, newNumber);
                        break;
                    case SelectedOperation.Substractopn:
                        result = SimpleMath.Substraction(lastNumber, newNumber);
                        break;
                    case SelectedOperation.Muliplication:
                        result = SimpleMath.Multiply(lastNumber, newNumber);
                        break;
                    case SelectedOperation.Division:
                        result = SimpleMath.Divide(lastNumber, newNumber);
                        break;
                }

                resultLabel.Content = result.ToString();
            }
        }

        private void PercentageButton_Click(object sender, RoutedEventArgs e)
        {
            if(double.TryParse(resultLabel.Content.ToString(), out lastNumber))
            {
                lastNumber = lastNumber / 100;
                resultLabel.Content = lastNumber.ToString();
            }
        }

        private void NegativeButton_Click(object sender, RoutedEventArgs e)
        {
            if(double.TryParse(resultLabel.Content.ToString(), out lastNumber))
            // double.TryParse 메소드는 문자열을 double 형식으로 변환하려고 시도하고, 성공하면 true를 반환하고 변환된 값을 out 매개변수에 할당
            {
                lastNumber = lastNumber * (-1);
                resultLabel.Content = lastNumber.ToString();
            }
        }

        private void operationButton_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(resultLabel.Content.ToString(), out lastNumber))
            {
                resultLabel.Content = "0";
            }

            if(sender == multiplicationButton)
            {
                selectedOperation = SelectedOperation.Muliplication;
            }
            if(sender == divisionButton)
            {
                selectedOperation = SelectedOperation.Division;
            }
            if(sender == minusButton)
            {
                selectedOperation = SelectedOperation.Substractopn;
            }
            if(sender == plusButton)
            {
                selectedOperation = SelectedOperation.Addtion;
            }
        }

        private void AcButton_Click(object sender, RoutedEventArgs e)
        {
            resultLabel.Content = "0";
            result = 0;
            lastNumber = 0;
        }

        private void numberButton_Click(object sender, RoutedEventArgs e)
        {

            int selectedValue = int.Parse((sender as Button).Content.ToString());
            // 클릭된 버튼 객체를 가져와서 이를 "Button" 클래스의 인스턴스로 취급하고자 합니다.
            // 이렇게 함으로써 우리는 버튼의 특정한 속성이나 메소드에 접근할 수 있게 됩니다.

/*            
            int selectedValue = 0;
            
            if (sender == zeroButton) selectedValue = 0;
            if (sender == oneButton) selectedValue = 1;
            if (sender == twoButton) selectedValue = 2;
            if (sender == threeButton) selectedValue = 3;
            if (sender == fourButton) selectedValue = 4;
            if (sender == fiveButton) selectedValue = 5;
            if (sender == sixButton) selectedValue = 6;
            if (sender == sevenButton) selectedValue = 7;
            if (sender == eightButton) selectedValue = 8;
            if (sender == nineButton) selectedValue = 9;
*/
            if(resultLabel.Content.ToString() == "0")
            {
                resultLabel.Content = $"{selectedValue}";
            }
            else
            {
                resultLabel.Content = $"{resultLabel.Content}{selectedValue}";
            }
        }

        private void pointButton_Click(object sender, RoutedEventArgs e)
        {
            if (resultLabel.Content.ToString().Contains("."))
            {
                // Do Nothing
            }
            else
            {
                resultLabel.Content = $"{resultLabel.Content}.";
            }
        }
    }

    public enum SelectedOperation
    {
        Addtion,
        Substractopn,
        Muliplication,
        Division
    }

    public class SimpleMath
    {
        public static double Add(double n1, double n2)
        {
            return n1 + n2;
        }
        public static double Substraction(double n1, double n2)
        {
            return n1 - n2;
        }
        public static double Multiply(double n1, double n2)
        {
            return n1 * n2;
        }
        public static double Divide(double n1, double n2)
        {
            if(n2 == 0)
            {
                MessageBox.Show("Division 0 is not supported", "Wrong Operation", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                return 0;
            }
            return n1 / n2;
        }
    }
}