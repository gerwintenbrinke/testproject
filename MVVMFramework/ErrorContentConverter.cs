using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;

namespace MVVMFramework
{
    public class ErrorContentConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return string.Empty;

            if (value.GetType() == typeof(ValidationError))
                return ((ValidationError)value).ErrorContent;

            var errors = value as ReadOnlyObservableCollection<ValidationError>;

            if (errors == null) return string.Empty;

            return errors.Count > 0 ? errors[0].ErrorContent : string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

    