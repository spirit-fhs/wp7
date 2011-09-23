using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;


namespace FHSSpiritDataModels
{
    public class ItemTimeTable : INotifyPropertyChanged
    {
        private string m_strClassName;
        /// <summary>
        /// ViewModel-Beispieleigenschaft. Diese Eigenschaft wird in der Ansicht verwendet, um den Wert unter Verwendung einer Bindung anzuzeigen.
        /// </summary>
        /// <returns></returns>
        public string ClassName
        {
            get
            {
                return m_strClassName;
            }
            set
            {
                if (value != m_strClassName)
                {
                    m_strClassName = value;
                    NotifyPropertyChanged("ClassName");
                }
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
