using System;
using System.Globalization;
using _343.ERP.SIGA.Models;

namespace _343.ERP.SIGA.Libraries.Converters
{
    public class TransactionValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Transaction transaction = (Transaction)value;

            if (transaction == null)
            {
                return "";
            }

            if (transaction.Type == TransactionType.Income)
                return transaction.Value.ToString("C");
            else
                return $"- {transaction.Value.ToString("C")}";

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

