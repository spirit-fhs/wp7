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

using FHSSpiritDataModelsFS;

namespace FHSSpiritDataModels
{
    public class ItemMessageModel : INotifyPropertyChanged
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

        private string m_strExpireDate;
        /// <summary>
        /// ViewModel-Beispieleigenschaft. Diese Eigenschaft wird in der Ansicht verwendet, um den Wert unter Verwendung einer Bindung anzuzeigen.
        /// </summary>
        /// <returns></returns>
        public string ExpireDate
        {
            get
            {
                return m_strExpireDate;
            }
            set
            {
                if (value != m_strExpireDate)
                {
                    m_strExpireDate = value;
                    NotifyPropertyChanged("ExpireDate");
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

        private string m_strTitle;
        /// <summary>
        /// ViewModel-Beispieleigenschaft. Diese Eigenschaft wird in der Ansicht verwendet, um den Wert unter Verwendung einer Bindung anzuzeigen.
        /// </summary>
        /// <returns></returns>
        public string Title
        {
            get
            {
                return m_strTitle;
            }
            set
            {
                if (value != m_strTitle)
                {
                    m_strTitle = value;
                    NotifyPropertyChanged("Title");
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
        /// <summary>
        /// Modell für DegressGroupCourse
        /// </summary>
        private string m_strCourse;
        /// <summary>
        /// ViewModel-Beispieleigenschaft. Diese Eigenschaft wird in der Ansicht verwendet, um den Wert unter Verwendung einer Bindung anzuzeigen.
        /// </summary>
        /// <returns></returns>
        public string Course
        {
            get
            {
                return m_strCourse;
            }
            set
            {
                if (value != m_strCourse)
                {
                    m_strCourse = value;
                    NotifyPropertyChanged("Course");
                }
            }
        }

        /// <summary>
        /// Modell für News
        /// </summary>
        private int m_nCountComments;
        /// <summary>
        /// ViewModel-Beispieleigenschaft. Diese Eigenschaft wird in der Ansicht verwendet, um den Wert unter Verwendung einer Bindung anzuzeigen.
        /// </summary>
        /// <returns></returns>
        public int CountComments
        {
            get
            {
                return m_nCountComments;
            }
            set
            {
                if (value != m_nCountComments)
                {
                    m_nCountComments = value;
                    NotifyPropertyChanged("CountComments");
                }
            }
        }

        /// <summary>
        /// Modell für News
        /// </summary>
        private ItemMessageCommentModel[] m_arrNewsComments;
        /// <summary>
        /// ViewModel-Beispieleigenschaft. Diese Eigenschaft wird in der Ansicht verwendet, um den Wert unter Verwendung einer Bindung anzuzeigen.
        /// </summary>
        /// <returns></returns>
        public ItemMessageCommentModel[] NewsComments
        {
            get
            {
                return m_arrNewsComments;
            }
            set
            {
                if (value != m_arrNewsComments)
                {
                    m_arrNewsComments = value;
                    NotifyPropertyChanged("CountComments");
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
