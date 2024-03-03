using System;
using System.Collections.Generic;
using System.Linq;
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

namespace Basic_Controls
{
    /// <summary>
    /// Interaction logic for CheckBoxSampleWindow.xaml
    /// </summary>
    public partial class CheckBoxSampleWindow : Window
    {
        public CheckBoxSampleWindow()
        {
            InitializeComponent();
        }

        private void checkBoxAllFeatures_Changed(object sender, RoutedEventArgs e)
        {
            bool newValue = checkBoxAllFeatures.IsChecked == true;

            checkBoxFeatureAbc.IsChecked = newValue;
            checkBoxFeatureXyz.IsChecked = newValue;
            checkBoxFeatureWww.IsChecked = newValue;
        }

        private void checkBoxFeatures_Changed(object sender, RoutedEventArgs e)
        {
            checkBoxAllFeatures.IsChecked = null;
            if ((checkBoxFeatureAbc.IsChecked == true) && (checkBoxFeatureXyz.IsChecked == true) && (checkBoxFeatureWww.IsChecked == true))
                checkBoxAllFeatures.IsChecked = true;
            if ((checkBoxFeatureAbc.IsChecked == false) && (checkBoxFeatureXyz.IsChecked == false) && (checkBoxFeatureWww.IsChecked == false))
                checkBoxAllFeatures.IsChecked = false;
        }

    }
}
