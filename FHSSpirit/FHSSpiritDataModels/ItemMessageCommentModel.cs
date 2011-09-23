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
    /*public class ItemMessageCommentModel : INotifyPropertyChanged
    {
        /// <summary>
        /// Modell für News
        /// </summary>
        private int m_nID;
        /// <summary>
        /// ViewModel-Beispieleigenschaft. Diese Eigenschaft wird in der Ansicht verwendet, um den Wert unter Verwendung einer Bindung anzuzeigen.
        /// </summary>
        /// <returns></returns>
        public int ID
        {
            get
            {
                return m_nID;
            }
            set
            {
                if (value != m_nID)
                {
                    m_nID = value;
                    NotifyPropertyChanged("ID");
                }
            }
        }

        private string m_strCreationDateTime;
        /// <summary>
        /// ViewModel-Beispieleigenschaft. Diese Eigenschaft wird in der Ansicht verwendet, um den Wert unter Verwendung einer Bindung anzuzeigen.
        /// </summary>
        /// <returns></returns>
        public string CreationDateTime
        {
            get
            {
                return m_strCreationDateTime;
            }
            set
            {
                if (value != m_strCreationDateTime)
                {
                    m_strCreationDateTime = value;
                    NotifyPropertyChanged("ID");
                }
            }
        }

        private string m_strContent;
        /// <summary>
        /// ViewModel-Beispieleigenschaft. Diese Eigenschaft wird in der Ansicht verwendet, um den Wert unter Verwendung einer Bindung anzuzeigen.
        /// </summary>
        /// <returns></returns>
        public string Content
        {
            get
            {
                return m_strContent;
            }
            set
            {
                if (value != m_strContent)
                {
                    m_strContent = value;
                    NotifyPropertyChanged("Content");
                }
            }
        }

        private string m_strOwner;
        /// <summary>
        /// ViewModel-Beispieleigenschaft. Diese Eigenschaft wird in der Ansicht verwendet, um den Wert unter Verwendung einer Bindung anzuzeigen.
        /// </summary>
        /// <returns></returns>
        public string Owner
        {
            get
            {
                return m_strOwner;
            }
            set
            {
                if (value != m_strOwner)
                {
                    m_strOwner = value;
                    NotifyPropertyChanged("Owner");
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
    }*/
}

