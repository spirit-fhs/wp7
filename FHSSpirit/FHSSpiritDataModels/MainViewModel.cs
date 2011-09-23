using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Collections.ObjectModel;

using FHSSpiritDataModelsFS;

namespace FHSSpiritDataModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public MainViewModel()
        {
            this.Items = new ObservableCollection<ItemViewModel>();
            this.Items_Message = new ObservableCollection<ItemMessageModel>();
            this.Items_TimeTable = new ObservableCollection<ItemTimeTable>();
            this.Items_MessageCommentModel = new ObservableCollection<ItemMessageCommentModel>();
            
            this.Item_CurrentMessage = new ItemMessageModel();
        }

        /// <summary>
        /// Eine Auflistung für ItemViewModel-Objekte.
        /// </summary>
        public ObservableCollection<ItemViewModel> Items { get; private set; }
        public ObservableCollection<ItemMessageModel> Items_Message { get; private set; }
        public ObservableCollection<ItemTimeTable> Items_TimeTable { get; private set; }
        public ObservableCollection<ItemMessageCommentModel> Items_MessageCommentModel { get; private set; }

        //only one entrie for the current Message
        public ItemMessageModel Item_CurrentMessage { get; private set; }
        //public System.
        private string _sampleProperty = "Beispielwert für die Laufzeiteigenschaft";
        /// <summary>
        /// ViewModel-Beispieleigenschaft. Diese Eigenschaft wird in der Ansicht verwendet, um den Wert unter Verwendung einer Bindung anzuzeigen
        /// </summary>
        /// <returns></returns>
        public string SampleProperty
        {
            get
            {
                return _sampleProperty;
            }
            set
            {
                if (value != _sampleProperty)
                {
                    _sampleProperty = value;
                    NotifyPropertyChanged("SampleProperty");
                }
            }
        }

        public bool IsDataLoaded
        {
            get;
            private set;
        }

        /// <summary>
        /// Erstellt und fügt einige ItemViewModel-Objekte zur Items-Auflistung hinzu.
        /// </summary>
        public void LoadData()
        {
            // Beispieldaten. Durch echte Daten ersetzen
            this.Items.Add(new ItemViewModel() { LineOne = "Laufzeit eins", LineTwo = "Maecenas praesent accumsan bibendum", LineThree = "Facilisi faucibus habitant inceptos interdum lobortis nascetur pharetra placerat pulvinar sagittis senectus sociosqu" });
            this.Items.Add(new ItemViewModel() { LineOne = "Laufzeit zwei", LineTwo = "Dictumst eleifend facilisi faucibus", LineThree = "Suscipit torquent ultrices vehicula volutpat maecenas praesent accumsan bibendum dictumst eleifend facilisi faucibus" });
            this.Items.Add(new ItemViewModel() { LineOne = "Laufzeit drei", LineTwo = "Habitant inceptos interdum lobortis", LineThree = "Habitant inceptos interdum lobortis nascetur pharetra placerat pulvinar sagittis senectus sociosqu suscipit torquent" });
            this.Items.Add(new ItemViewModel() { LineOne = "Laufzeit vier", LineTwo = "Nascetur pharetra placerat pulvinar", LineThree = "Ultrices vehicula volutpat maecenas praesent accumsan bibendum dictumst eleifend facilisi faucibus habitant inceptos" });
            this.Items.Add(new ItemViewModel() { LineOne = "Laufzeit fünf", LineTwo = "Maecenas praesent accumsan bibendum", LineThree = "Maecenas praesent accumsan bibendum dictumst eleifend facilisi faucibus habitant inceptos interdum lobortis nascetur" });
            this.Items.Add(new ItemViewModel() { LineOne = "Laufzeit sechs", LineTwo = "Dictumst eleifend facilisi faucibus", LineThree = "Pharetra placerat pulvinar sagittis senectus sociosqu suscipit torquent ultrices vehicula volutpat maecenas praesent" });
            this.Items.Add(new ItemViewModel() { LineOne = "Laufzeit sieben", LineTwo = "Habitant inceptos interdum lobortis", LineThree = "Accumsan bibendum dictumst eleifend facilisi faucibus habitant inceptos interdum lobortis nascetur pharetra placerat" });
            this.Items.Add(new ItemViewModel() { LineOne = "Laufzeit acht", LineTwo = "Nascetur pharetra placerat pulvinar", LineThree = "Pulvinar sagittis senectus sociosqu suscipit torquent ultrices vehicula volutpat maecenas praesent accumsan bibendum" });
            this.Items.Add(new ItemViewModel() { LineOne = "Laufzeit neun", LineTwo = "Maecenas praesent accumsan bibendum", LineThree = "Facilisi faucibus habitant inceptos interdum lobortis nascetur pharetra placerat pulvinar sagittis senectus sociosqu" });
            this.Items.Add(new ItemViewModel() { LineOne = "Laufzeit zehn", LineTwo = "Dictumst eleifend facilisi faucibus", LineThree = "Suscipit torquent ultrices vehicula volutpat maecenas praesent accumsan bibendum dictumst eleifend facilisi faucibus" });
            this.Items.Add(new ItemViewModel() { LineOne = "Laufzeit elf", LineTwo = "Habitant inceptos interdum lobortis", LineThree = "Habitant inceptos interdum lobortis nascetur pharetra placerat pulvinar sagittis senectus sociosqu suscipit torquent" });
            this.Items.Add(new ItemViewModel() { LineOne = "Laufzeit zwölf", LineTwo = "Nascetur pharetra placerat pulvinar", LineThree = "Ultrices vehicula volutpat maecenas praesent accumsan bibendum dictumst eleifend facilisi faucibus habitant inceptos" });
            this.Items.Add(new ItemViewModel() { LineOne = "Laufzeit dreizehn", LineTwo = "Maecenas praesent accumsan bibendum", LineThree = "Maecenas praesent accumsan bibendum dictumst eleifend facilisi faucibus habitant inceptos interdum lobortis nascetur" });
            this.Items.Add(new ItemViewModel() { LineOne = "Laufzeit vierzehn", LineTwo = "Dictumst eleifend facilisi faucibus", LineThree = "Pharetra placerat pulvinar sagittis senectus sociosqu suscipit torquent ultrices vehicula volutpat maecenas praesent" });
            this.Items.Add(new ItemViewModel() { LineOne = "Laufzeit fünfzehn", LineTwo = "Habitant inceptos interdum lobortis", LineThree = "Accumsan bibendum dictumst eleifend facilisi faucibus habitant inceptos interdum lobortis nascetur pharetra placerat" });
            this.Items.Add(new ItemViewModel() { LineOne = "Laufzeit sechzehn", LineTwo = "Nascetur pharetra placerat pulvinar", LineThree = "Pulvinar sagittis senectus sociosqu suscipit torquent ultrices vehicula volutpat maecenas praesent accumsan bibendum" });


            //Testdaten News
            /*
            this.Items_Message.Add(new ItemMessageModel() { ID = "0001", CreationDateTime = "10.05.11 17:53:22", ExpireDate = "201009101200", Title = "Vorlesung fällt aus", Content = "Maecenas praesent accumsan bibendum dictumst eleifend facilisi faucibus habitant inceptos interdum lobortis nascetur", Owner = "Prof. Golz", Course = "MAI3" });
            this.Items_Message.Add(new ItemMessageModel() { ID = "0002", CreationDateTime = "10.05.11 17:53:22", ExpireDate = "201009101200", Title = "Verlegung Vorlesung ProzProg", Content = "Maecenas praesent accumsan bibendum dictumst eleifend facilisi faucibus habitant inceptos interdum lobortis nascetur", Owner = "Prof. Golz", Course = "MAI2" });
            this.Items_Message.Add(new ItemMessageModel() { ID = "0003", CreationDateTime = "10.05.11 17:53:22", ExpireDate = "201009101200", Title = "Vorlesung fällt aus", Content = "Maecenas praesent accumsan bibendum dictumst eleifend facilisi faucibus habitant inceptos interdum lobortis nascetur", Owner = "Prof. Golz", Course = "WI2" });
            this.Items_Message.Add(new ItemMessageModel() { ID = "0004", CreationDateTime = "10.05.11 17:53:22", ExpireDate = "201009101200", Title = "Verlegung Vorlesung ProzProg und so weiter und so weiter!", Content = "Maecenas praesent accumsan bibendum dictumst eleifend facilisi faucibus habitant inceptos interdum lobortis nascetur", Owner = "Prof. Golz", Course = "I4" });
            this.Items_Message.Add(new ItemMessageModel() { ID = "0005", CreationDateTime = "10.05.11 17:53:22", ExpireDate = "201009101200", Title = "Vorlesung fällt aus", Content = "Maecenas praesent accumsan bibendum dictumst eleifend facilisi faucibus habitant inceptos interdum lobortis nascetur", Owner = "Prof. Golz", Course = "I4" });
            this.Items_Message.Add(new ItemMessageModel() { ID = "0006", CreationDateTime = "10.05.11 17:53:22", ExpireDate = "201009101200", Title = "Verlegung Vorlesung ProzProg", Content = "Maecenas praesent accumsan bibendum dictumst eleifend facilisi faucibus habitant inceptos interdum lobortis nascetur", Owner = "Prof. Golz", Course = "I2, MAI3, I5" });
            this.Items_Message.Add(new ItemMessageModel() { ID = "0007", CreationDateTime = "10.05.11 17:53:22", ExpireDate = "201009101200", Title = "Verlegung Vorlesung ProzProg und so weiter und so weiter!", Content = "Maecenas praesent accumsan bibendum dictumst eleifend facilisi faucibus habitant inceptos interdum lobortis nascetur", Owner = "Prof. Golz", Course = "MAI3" });
            */
            

            this.Items_MessageCommentModel.Add(new ItemMessageCommentModel() { ID = 1, CreationDateTime = "10.05.11 17:53:22", Content = "Das ist aber nicht gut. Schon der 3. Ausfall in diesem Monat. Wann sollen die Veranstaltugen denn nachgeholt werden.", Owner = "B. Lüdicke" });
            this.Items_MessageCommentModel.Add(new ItemMessageCommentModel() { ID = 2, CreationDateTime = "11.05.11 12:53:22", Content = "Auch das schaffen wir schon...", Owner = "B. Lüdicke" });
            this.Items_MessageCommentModel.Add(new ItemMessageCommentModel() { ID = 3, CreationDateTime = "12.05.11 10:52:22", Content = "Naja?!", Owner = "B. Lüdicke" });
            this.Items_MessageCommentModel.Add(new ItemMessageCommentModel() { ID = 4, CreationDateTime = "13.05.11 08:53:22", Content = "Das ist aber nicht gut. Schon der 3. Ausfall in diesem Monat. Wann sollen die Veranstaltugen denn nachgeholt werden. Das ist aber nicht gut. Schon der 3. Ausfall in diesem Monat. Wann sollen die Veranstaltugen denn nachgeholt werden.", Owner = "B. Lüdicke" });
            this.Items_MessageCommentModel.Add(new ItemMessageCommentModel() { ID = 5, CreationDateTime = "14.05.11 11:13:22", Content = "Das ist aber nicht gut. Schon der 3. Ausfall in diesem Monat. Wann sollen die Veranstaltugen denn nachgeholt werden.", Owner = "B. Lüdicke" });
            this.Items_MessageCommentModel.Add(new ItemMessageCommentModel() { ID = 6, CreationDateTime = "15.05.11 17:11:78", Content = "Das ist aber nicht gut. Schon der 3. Ausfall in diesem Monat. Wann sollen die Veranstaltugen denn nachgeholt werden.", Owner = "B. Lüdicke" });
           
            this.Items_TimeTable.Add(new ItemTimeTable() { ClassName = "mein Stundenplan" });
            this.Items_TimeTable.Add(new ItemTimeTable() { ClassName = "MAI 2" });
            this.Items_TimeTable.Add(new ItemTimeTable() { ClassName = "MAI 4" });
            this.Items_TimeTable.Add(new ItemTimeTable() { ClassName = "BI 2" });
            this.Items_TimeTable.Add(new ItemTimeTable() { ClassName = "BI 4" });
            this.Items_TimeTable.Add(new ItemTimeTable() { ClassName = "BI 6" });
            this.Items_TimeTable.Add(new ItemTimeTable() { ClassName = "BWI 2" });
            this.Items_TimeTable.Add(new ItemTimeTable() { ClassName = "BWI 4" });
            this.Items_TimeTable.Add(new ItemTimeTable() { ClassName = "BWI 6" });

            //Testdate Ausgewählte News
            this.Item_CurrentMessage = new ItemMessageModel() { ID = 0001, CreationDateTime = "10.05.11 17:53:22", ExpireDate = "201009101200", Title = "Vorlesung fällt aus", Content = "Maecenas praesent accumsan bibendum dictumst eleifend facilisi faucibus habitant inceptos interdum lobortis nascetur", Owner = "Prof. Golz", Course = "MAI3" };

            this.IsDataLoaded = true;
        }

        public void refreshNews(ItemMessageModel[] arrItemsMessageModel)
        {
            this.Items_Message.Clear();

            foreach (ItemMessageModel m in arrItemsMessageModel)
            {
                this.Items_Message.Add(m);
            }
        }

        public void setCurrentNewsAndComments(ItemMessageModel itemMessageModel)
        {
            this.Item_CurrentMessage = itemMessageModel;

        }

        public void refreshCurrentNewsAndComments()
        {
            this.Items_MessageCommentModel.Clear();

            foreach (ItemMessageCommentModel m in this.Item_CurrentMessage.NewsComments)
            {
                this.Items_MessageCommentModel.Add(m);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (null != handler)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}