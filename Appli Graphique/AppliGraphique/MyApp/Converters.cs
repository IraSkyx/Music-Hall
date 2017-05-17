using Biblio;
using System;
using System.Linq;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace MyApp
{
    public class ValueToContent : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch ((string)parameter)
            {
                case "scale": return (double)value / 30.00;
                case "booltocontent": return (bool)value ? "||" : "▶";
                case "volume": return (double)value == 0 ? "🔇" : "🔊";
                case "booltoforeground":  return (bool)value ? new SolidColorBrush(Color.FromRgb(3, 166, 120)) : new SolidColorBrush(Color.FromRgb(255, 255, 255));
                case "booltovisibility": return (bool)value ? Visibility.Visible : Visibility.Hidden;
                case "nulltovisibility": return value == null ? Visibility.Hidden : Visibility.Visible;
                case "connexion": return value == null ? "Connexion" : "Déconnexion";
                case "inscription": return value == null ? "Inscription" : ((IUser)value).Infos.DisplayName;
                case "seconnecter": return value == null ? "Se connecter" : "Fermer la session";
                case "sinscrire": return value == null ? "S'inscrire" : "Voir mon profil";               
                case "objecttovalue":
                    {
                        try { return ((Lecteur)Application.Current.MainWindow.FindName("MyPlayer")).Player.CurrentUser.Favorite.PlaylistProperty.Count(x => x.Equals((IMusic)value)) == 0 ? "✚" : "✓"; }
                        catch (NullReferenceException) { return ""; }
                    }
                default : return null;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

