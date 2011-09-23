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

using FHSSpiritDataModels;
using FHSSpiritDataControl;

namespace FHSSpirit
{
    public partial class MainPage : PhoneApplicationPage
    {
        DataControlNews m_DataControlNews;
        // Konstruktor
        public MainPage()
        {
            InitializeComponent();

            // Datenkontext des Listenfeldsteuerelements auf die Beispieldaten festlegen
            DataContext = App.ViewModel;
            this.Loaded += new RoutedEventHandler(MainPage_Loaded);

            this.m_DataControlNews = DataControlNews.Instance;
            this.m_DataControlNews.m_del_ErrorMessage = this.showError;
            this.m_DataControlNews.m_del_GetUIR       = this.getURI;
            this.m_DataControlNews.m_del_GetFHSID     = this.getFHSID;
            this.m_DataControlNews.m_del_ResponseNews = this.responseNews;

            this.comboBoxFHSIDPort.Items.Add("braun");
            this.comboBoxFHSIDPort.Items.Add("knolle");
            this.comboBoxFHSIDPort.Items.Add("hettler");
            this.comboBoxFHSIDPort.Items.Add("englmeier");
            this.comboBoxFHSIDPort.Items.Add("schleicher");

            this.comboBoxFHSIDPort.SelectedIndex = 4;
        }

        // Daten für die ViewModel-Elemente laden
        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            if (!App.ViewModel.IsDataLoaded)
            {
                App.ViewModel.LoadData();
            }

            this.m_DataControlNews.requestAllNews();
        }

        private void Rectangle_News_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                FHSSpiritDataModels.ItemMessageModel currentNews = (FHSSpiritDataModels.ItemMessageModel)((System.Windows.FrameworkElement)sender).DataContext;

                App.ViewModel.setCurrentNewsAndComments(currentNews);

                NavigationService.Navigate(new Uri("/Pages/News.xaml", UriKind.Relative));
            }
            catch (Exception ex)
            {
                this.showError(ex.Message);
            }
        }

        private void Rectangle_TimeTable_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Pages/TimeTable.xaml", UriKind.Relative));
        }

        private void radioButtonHttps_Click(object sender, RoutedEventArgs e)
        {
            this.refreshUI();
        }

        private void textBoxIP_KeyDown(object sender, KeyEventArgs e)
        {
            this.refreshUI();
        }

        private void refreshUI()
        {
            string strURI = "http";

            if (this.radioButtonHttps.IsChecked ==  true)
            {
                strURI += "s";
            }

            strURI += @"://" + this.textBoxIP.Text + ":" + this.textBoxPort.Text;

            this.textBlockURI.Text = strURI;

            this.m_DataControlNews.requestAllNews();
        }

        public string getURI()
        {
            //connect with the real Windows Phone (only with the FHS certificate)
            //return "https://212.201.64.226:8443";

            //connect with the Emulator and FHS VPN
            return "http://212.201.64.226:8080";

            //use the Settings in the UI
            //return this.textBlockURI.Text;
        }

        public string getFHSID()
        {
            return this.comboBoxFHSIDPort.SelectedItem.ToString();
        }

        public void showError(string strErrorMessage)
        {
            Dispatcher.BeginInvoke(() =>
            {
                this.progressbarNews.Visibility = System.Windows.Visibility.Collapsed;

                MessageBox.Show(strErrorMessage);
            });
        }

        public void responseNews(ItemMessageModel[] messages)
        {
            Dispatcher.BeginInvoke(() =>
            {
                this.progressbarNews.Visibility = System.Windows.Visibility.Collapsed;
                // This code is on the UI thread.
                App.ViewModel.refreshNews(messages);
            });
        }

        private void button_refreshAll_Click(object sender, RoutedEventArgs e)
        {
            this.m_DataControlNews.requestAllNews();
        }
    }
}