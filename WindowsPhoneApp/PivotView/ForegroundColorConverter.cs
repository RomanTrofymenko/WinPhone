using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media;

namespace PivotView
{
    class ForegroundColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var brush = ((bool) value)
                ? (Application.Current.Resources["PhoneAccentBrush"] as Brush)
                : ((parameter is Brush)
                    ? parameter as Brush
                    : Application.Current.Resources["PhoneForegroundBrush"] as Brush);

            return brush;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
