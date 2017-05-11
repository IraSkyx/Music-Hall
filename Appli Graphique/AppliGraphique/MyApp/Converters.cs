using Biblio;
using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace MyApp
{
    public class ScaleConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) => (double)value * (double)parameter;

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class ValueToContent : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch ((string)parameter)
            {
                case "booltocontent": return (bool)value ? "||" : "▶";
                case "booltoforeground":  return (bool)value ? new SolidColorBrush(Color.FromRgb(3, 166, 120)) : new SolidColorBrush(Color.FromRgb(255, 255, 255));
                case "booltovisibility": return (bool)value ? Visibility.Visible : Visibility.Hidden;
                case "connexion": return (User)value == null ? "Connexion" : "Déconnexion";
                case "inscription": return (User)value == null ? "Inscription" : ((User)value).Infos.DisplayName;
                case "seconnecter": return (User)value == null ? "Se connecter" : "Fermer la session";
                case "sinscrire": return (User)value == null ? "S'inscrire" : "Voir mon profil";
                default : return null;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

