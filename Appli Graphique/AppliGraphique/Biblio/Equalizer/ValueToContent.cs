using System;
using System.Globalization;
using System.Windows.Data;

public class ValueToContent : IValueConverter
{
    /// <summary>
    /// Convertit des valeurs
    /// </summary>
    /// <param name="value"> Object envoyeur </param>
    /// <param name="targetType"> Type de l'objet envoyeur </param>
    /// <param name="parameter"> Converter Parameter </param>
    /// <param name="culture"> Infos sur la culture </param>
    /// <returns> La nouvelle valeur convertit </returns>
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        => (double)value / 30.00;

    /// <summary>
    /// Pas nécessaire
    /// </summary>
    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}