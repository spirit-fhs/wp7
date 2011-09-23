using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

using FHSSpiritDataControl;

namespace FHSSpirit
{
    public partial class News : PhoneApplicationPage
    {
        DataControlNews m_DataControlNews;

        public News()
        {
            InitializeComponent();

            // Datenkontext des Listenfeldsteuerelements auf die Beispieldaten festlegen
            DataContext = App.ViewModel;
            this.Loaded += new RoutedEventHandler(News_Loaded);

            this.m_DataControlNews = DataControlNews.Instance;
        }

        // Daten für die ViewModel-Elemente laden
        private void News_Loaded(object sender, RoutedEventArgs e)
        {
            if (!App.ViewModel.IsDataLoaded)
            {
                App.ViewModel.LoadData();
            }

            App.ViewModel.refreshCurrentNewsAndComments();
        }

        private void ApplicationBarIconButton_Click_Add(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/Pages/AddComment.xaml", UriKind.Relative));
        }

        private void ApplicationBarIconButton_Click_Cancel(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/Pages/MainPage.xaml", UriKind.Relative));
        }
    }
}