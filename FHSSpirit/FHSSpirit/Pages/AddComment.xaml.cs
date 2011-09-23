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
using System.Windows.Threading;

using Microsoft.Phone.Controls;

using FHSSpiritDataControl;
using FHSSpiritDataModelsFS;

namespace FHSSpirit.Pages
{
    public partial class AddComment : PhoneApplicationPage
    {
        DataControlNews m_DataControlNews;

        public AddComment()
        {
            InitializeComponent();

            // Datenkontext des Listenfeldsteuerelements auf die Beispieldaten festlegen
            DataContext = App.ViewModel;
            this.Loaded += new RoutedEventHandler(Comments_Loaded);

            this.m_DataControlNews = DataControlNews.Instance;
        }

        // Daten für die ViewModel-Elemente laden
        private void Comments_Loaded(object sender, RoutedEventArgs e)
        {
            if (!App.ViewModel.IsDataLoaded)
            {
                App.ViewModel.LoadData();
            }
        }

        private void ApplicationBarIconButton_Click_Save(object sender, EventArgs e)
        {
            this.m_DataControlNews.addComment(this.textBox_addComments.Text, App.ViewModel.Item_CurrentMessage.ID);

            this.m_DataControlNews.requestAllNews();

            NavigationService.Navigate(new Uri("/Pages/News.xaml", UriKind.Relative));
        }

        private void ApplicationBarIconButton_Click_Cancel(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/Pages/News.xaml", UriKind.Relative));
        }
    }
}