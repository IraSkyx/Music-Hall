using Biblio;
using System;
using System.Linq;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;
using BackEnd;
using System.Collections.ObjectModel;

namespace MyApp
{
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
        {            
            switch ((string)parameter)
            {
                case "average": return string.Format($"Avis : {((ObservableCollection<IComment>)value).Average(x => x.Rate)}");
                case "IsNullOrEmpty": return string.IsNullOrEmpty(((string)value)) ? "Parcourir" : (string)value;
                case "scale": return (double)value / 30.00;
                case "booltocontent": return (bool)value ? "||" : "▶";
                case "volume": return (double)value == 0 ? "🔇" : "🔊";
                case "booltoforeground":  return (bool)value ? new SolidColorBrush(Color.FromRgb(3, 166, 120)) : new SolidColorBrush(Color.FromRgb(255, 255, 255));
                case "booltovisibility": return (bool)value ? Visibility.Visible : Visibility.Hidden;
                case "nulltovisibility": return value == null ? Visibility.Hidden : Visibility.Visible;
                case "connexion": return value == null ? "Connexion" : "Déconnexion";
                case "inscription": return value == null ? "Inscription" : ((IUser)value).Username;
                case "seconnecter": return value == null ? "Se connecter" : "Fermer la session";
                case "sinscrire": return value == null ? "S'inscrire" : "Voir mon profil";               
                case "objecttovalue":
                    {
                        try { return PlayerFront.MyPlayer.CurrentUser.Favorite.PlaylistProperty.Count(x => x.Equals((IMusic)value)) == 0 ? "✚" : "✓"; }
                        catch (NullReferenceException) { return ""; }
                    }
                default : return null;
            }
        }

        /// <summary>
        /// Pas nécessaire
        /// </summary>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

