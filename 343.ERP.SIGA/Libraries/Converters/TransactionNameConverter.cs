using System;
using System.Globalization;

namespace _343.ERP.SIGA.Libraries.Converters
{
    public class TransactionNameConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return String.Empty;

            String transactionName = (String)value;
            return transactionName.ToUpper()[0];
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

