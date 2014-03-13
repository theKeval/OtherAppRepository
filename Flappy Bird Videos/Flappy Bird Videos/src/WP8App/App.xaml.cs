// ------------------------------------------------------------------------
// ========================================================================
// THIS CODE AND INFORMATION ARE GENERATED BY AUTOMATIC CODE GENERATOR
// ========================================================================
// Template:   	AppCS.tt
// Version:		2.0
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Scheduler;
using Microsoft.Phone.Shell;
using Services = WPAppStudio.Services;
using ViewModels = WPAppStudio.ViewModel;
using WPAppStudio.ViewModel.Base;

namespace WPAppStudio
{
    /// <summary>
    /// Application management.
    /// </summary>
    [CompilerGenerated]
    [GeneratedCode("Radarc", "4.0")]
    public partial class App
    {
		private bool _loadingfromInstance;
		private VMBase _vm;
		
        /// <summary>
        /// Application execution entry point.
        /// </summary>
		public App()
        {
            // Global handler for uncaught exceptions. 
            UnhandledException += Application_UnhandledException;

            // Standard Silverlight initialization
            InitializeComponent();

            InitializePhoneApplication();
        }

        /// <summary>
        /// Gets/Sets the phone application UI root frame.
        /// </summary>
        public static PhoneApplicationFrame RootFrame { get; private set; }

        private void Application_Launching(object sender, LaunchingEventArgs e)
        {            
        }

        private void Application_Activated(object sender, ActivatedEventArgs e)
        {        
			if (e.IsApplicationInstancePreserved)
            {
                if (_vm != null)
                    _vm.Initialize(new Dictionary<string, string>());
            }
        }

        private void Application_Deactivated(object sender, DeactivatedEventArgs e)
        {
			if (_vm != null)
            {
                var phoneApplicationPage = RootFrame.Content as PhoneApplicationPage;
                if (phoneApplicationPage != null)
                    _vm = (VMBase)phoneApplicationPage.DataContext;
            }
        }

        private void Application_Closing(object sender, ClosingEventArgs e)
        {
        }

        private void RootFrame_NavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            if (Debugger.IsAttached)
            {
                Debugger.Break();
            }
        }

        private void Application_UnhandledException(object sender, ApplicationUnhandledExceptionEventArgs e)
        {
            if (Debugger.IsAttached)
            {
                Debugger.Break();
            }
        }

        private bool _phoneApplicationInitialized;

        private void InitializePhoneApplication()
        {
            if (_phoneApplicationInitialized)
                return;

            RootFrame = new TransitionFrame();
            RootFrame.Navigated += CompleteInitializePhoneApplication;
			RootFrame.Navigating += RootFrame_Navigating;
			
			// Handle navigation failures
            RootFrame.NavigationFailed += RootFrame_NavigationFailed;
			
			// Handle reset requests for clearing the backstack
            RootFrame.Navigated += CheckForResetNavigation;

            _phoneApplicationInitialized = true;
        }
		

		private void RootFrame_Navigating(object sender, NavigatingCancelEventArgs e)
        {
            if (!e.Uri.ToString().Contains("Microsoft_Videos") || !_loadingfromInstance) return;
			
            e.Cancel = true;
            _loadingfromInstance = false;
        }
		
		private void CheckForResetNavigation(object sender, NavigationEventArgs e)
        {
            if (e.NavigationMode == NavigationMode.New && _loadingfromInstance && RootFrame.CanGoBack)
                RootFrame.GoBack();

            // If the app has received a 'reset' navigation, then we need to check
            // on the next navigation to see if the page stack should be reset
            if (e.NavigationMode == NavigationMode.Reset)
                _loadingfromInstance = true;
        }
		
        private void CompleteInitializePhoneApplication(object sender, NavigationEventArgs e)
        {
			if (RootFrame != null && RootVisual != RootFrame)
                RootVisual = RootFrame;

            if (RootFrame != null)
                RootFrame.Navigated -= CompleteInitializePhoneApplication;
        }
    }
}
