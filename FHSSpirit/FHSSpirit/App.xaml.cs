﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

using FHSSpiritDataModels;

namespace FHSSpirit
{
    public partial class App : Application
    {
        private static MainViewModel viewModel = null;

        /// <summary>
        /// Eine statisches ViewModel, an das die Ansichten gebunden werden.
        /// </summary>
        /// <returns>MainViewModel-Objekt.</returns>
        public static MainViewModel ViewModel
        {
            get
            {
                // Erstellung des Ansichtsmodells verzögern bis erforderlich
                if (viewModel == null)
                    viewModel = new MainViewModel();

                return viewModel;
            }
        }

        /// <summary>
        /// Bietet einen einfachen Zugriff auf den Stammframe der Phone-Anwendung.
        /// </summary>
        /// <returns>Der Stammframe der Phone-Anwendung.</returns>
        public PhoneApplicationFrame RootFrame { get; private set; }

        /// <summary>
        /// Konstruktor für das Application-Objekt.
        /// </summary>
        public App()
        {
            // Globaler Handler für nicht abgefangene Ausnahmen. 
            UnhandledException += Application_UnhandledException;

            // Während des Debuggens Profilerstellungsinformationen zur Grafikleistung anzeigen.
            if (System.Diagnostics.Debugger.IsAttached)
            {
                // Zähler für die aktuelle Bildrate anzeigen.
                Application.Current.Host.Settings.EnableFrameRateCounter = true;

                // Bereiche der Anwendung hervorheben, die mit jedem Bild neu gezeichnet werden.
                //Application.Current.Host.Settings.EnableRedrawRegions = true;

                // Nicht produktiven Visualisierungsmodus für die Analyse aktivieren, 
                // in dem GPU-beschleunigte Bereiche der Seite farbig hervorgehoben werden.
                //Application.Current.Host.Settings.EnableCacheVisualization = true;
            }

            // Silverlight-Standardinitialisierung
            InitializeComponent();

            // Phone-spezifische Initialisierung
            InitializePhoneApplication();
        }

        // Code, der beim Starten der Anwendung ausgeführt werden soll (z. B. über "Start")
        // Dieser Code wird beim Reaktivieren der Anwendung nicht ausgeführt
        private void Application_Launching(object sender, LaunchingEventArgs e)
        {
        }

        // Code, der ausgeführt werden soll, wenn die Anwendung aktiviert wird (in den Vordergrund gebracht wird)
        // Dieser Code wird beim ersten Starten der Anwendung nicht ausgeführt
        private void Application_Activated(object sender, ActivatedEventArgs e)
        {
            // Sicherstellen, dass der Anwendungszustand ordnungsgemäß wiederhergestellt wird
            if (!App.ViewModel.IsDataLoaded)
            {
                App.ViewModel.LoadData();
            }
        }

        // Code, der ausgeführt werden soll, wenn die Anwendung deaktiviert wird (in den Hintergrund gebracht wird)
        // Dieser Code wird beim Schließen der Anwendung nicht ausgeführt
        private void Application_Deactivated(object sender, DeactivatedEventArgs e)
        {
            // Sicherstellen, dass der erforderliche Anwendungszustand hier beibehalten wird
        }

        // Code, der beim Schließen der Anwendung ausgeführt wird (z. B. wenn der Benutzer auf "Zurück" klickt)
        // Dieser Code wird beim Deaktivieren der Anwendung nicht ausgeführt
        private void Application_Closing(object sender, ClosingEventArgs e)
        {
        }

        // Code, der bei einem Navigationsfehler ausgeführt wird
        private void RootFrame_NavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            if (System.Diagnostics.Debugger.IsAttached)
            {
                // Navigationsfehler. Unterbrechen und Debugger öffnen
                System.Diagnostics.Debugger.Break();
            }
        }

        // Code, der bei nicht behandelten Ausnahmen ausgeführt wird
        private void Application_UnhandledException(object sender, ApplicationUnhandledExceptionEventArgs e)
        {
            if (System.Diagnostics.Debugger.IsAttached)
            {
                // Eine nicht behandelte Ausnahme ist aufgetreten. Unterbrechen und Debugger öffnen
                System.Diagnostics.Debugger.Break();
            }
        }

        #region Initialisierung der Phone-Anwendung

        // Doppelte Initialisierung vermeiden
        private bool phoneApplicationInitialized = false;

        // Fügen Sie keinen zusätzlichen Code zu dieser Methode hinzu
        private void InitializePhoneApplication()
        {
            if (phoneApplicationInitialized)
                return;

            // Frame erstellen, aber noch nicht als RootVisual festlegen. Dadurch kann der Begrüßungsbildschirm
            // aktiv bleiben, bis die Anwendung bereit für das Rendern ist.
            RootFrame = new PhoneApplicationFrame();
            RootFrame.Navigated += CompleteInitializePhoneApplication;

            // Navigationsfehler behandeln
            RootFrame.NavigationFailed += RootFrame_NavigationFailed;

            // Sicherstellen, dass keine erneute Initialisierung erfolgt
            phoneApplicationInitialized = true;
        }

        // Fügen Sie keinen zusätzlichen Code zu dieser Methode hinzu
        private void CompleteInitializePhoneApplication(object sender, NavigationEventArgs e)
        {
            // Visuelle Stammkomponente festlegen, sodass die Anwendung gerendert werden kann
            if (RootVisual != RootFrame)
                RootVisual = RootFrame;

            // Dieser Handler wird nicht mehr benötigt und kann entfernt werden
            RootFrame.Navigated -= CompleteInitializePhoneApplication;
        }

        #endregion
    }
}