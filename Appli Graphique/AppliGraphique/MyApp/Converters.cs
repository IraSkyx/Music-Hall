using Biblio;
using System;
using System.Linq;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using System.Collections.ObjectModel;

namespace MyApp
{
    public class ScaleConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            return (double)value / 30.00;
        }

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
                case "objecttovalue":
                    {
                        try
                        {
                            return ((Lecteur)Application.Current.MainWindow.FindName("lecteur")).Player.CurrentUser.Favorite.PlaylistProperty.Count(x => x.Equals((Musique)value)) == 0 ? "✚" : "✓";
                        }
                        catch (NullReferenceException)
                        {
                            return "";
                        }                       
                    }
                case "booltocontent": return (bool)value ? "||" : "▶";
                case "volume": return (double)value == 0 ? "🔇" : "🔊";
                case "booltoforeground":  return (bool)value ? new SolidColorBrush(Color.FromRgb(3, 166, 120)) : new SolidColorBrush(Color.FromRgb(255, 255, 255));
                case "booltovisibility": return (bool)value ? Visibility.Visible : Visibility.Hidden;
                case "nulltovisibility": return value == null ? Visibility.Hidden : Visibility.Visible;
                case "connexion": return value == null ? "Connexion" : "Déconnexion";
                case "inscription": return value == null ? "Inscription" : ((User)value).Infos.DisplayName;
                case "seconnecter": return value == null ? "Se connecter" : "Fermer la session";
                case "sinscrire": return value == null ? "S'inscrire" : "Voir mon profil";
                case "count": return string.Format("{0} titres", ((ObservableCollection<Musique>)value).Count());
                default : return null;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }


    }
}

