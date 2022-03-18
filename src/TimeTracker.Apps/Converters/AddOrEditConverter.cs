using System;
using System.Globalization;
using Xamarin.Forms;

namespace TimeTracker.Apps.Converters
{
    public class AddOrEditConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is int index))
            {
                return "";
            }
            if (index < 0)
            {
                return "Ajouter";
            }

            return "Éditer";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}