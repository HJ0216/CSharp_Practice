using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Documents;

namespace EvernoteCloneApp.ViewModels.Helpers
{
    public class StringToFlowDocumentConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string str)
            {
                var flowDocument = new FlowDocument();
                var paragraph = new Paragraph();
                paragraph.Inlines.Add(new Run(str));
                flowDocument.Blocks.Add(paragraph);

                return flowDocument;
            }

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is FlowDocument flowDocument)
            {
                return new TextRange(flowDocument.ContentStart, flowDocument.ContentEnd).Text;
            }

            return null;
        }
    }

}
