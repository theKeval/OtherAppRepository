// ------------------------------------------------------------------------
// ========================================================================
// THIS CODE AND INFORMATION ARE GENERATED BY AUTOMATIC CODE GENERATOR
// ========================================================================
// Template:   	PageCS.tt
// Version:		2.0
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Entities=WPAppStudio.Entities;
using Ioc=WPAppStudio.Ioc;
using IServices=WPAppStudio.Services.Interfaces;
using IViewModels=WPAppStudio.ViewModel.Interfaces;
using Localization=WPAppStudio.Localization;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using MyToolkit.Paging;
using Repositories=WPAppStudio.Repositories;
using WPAppStudio;
using WPAppStudio.Shared;

namespace WPAppStudio.View
{
    /// <summary>
    /// Phone application page for Microsoft_Videos.
    /// </summary>
    [CompilerGenerated]
    [GeneratedCode("Radarc", "4.0")]
    public partial class Microsoft_Videos : PhoneApplicationPage
    {       
        /// <summary>
        /// Initializes the phone application page for Microsoft_Videos and all its components.
        /// </summary>
        public Microsoft_Videos()
        {
            InitializeComponent();        
			if (Resources.Contains("PanoramaVideos0AppBar"))
				PhonePage.SetApplicationBar(this, Resources["PanoramaVideos0AppBar"] as BindableApplicationBar);                            
		}
		
        private void panoramaVideos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {		
			InitializeAppBarpanoramaVideos(PanoramaVideos.SelectedItem as PanoramaItem);
        }
		
		private void InitializeAppBarpanoramaVideos(PanoramaItem panoramaItem)        
        {
			if (Resources.Contains(panoramaItem.Name + "AppBar"))
			{
				PhonePage.SetApplicationBar(this, Resources[panoramaItem.Name + "AppBar"] as BindableApplicationBar);            
				ApplicationBar.IsVisible = true;
            }
		    else if(ApplicationBar != null)
		        ApplicationBar.IsVisible = false;
        }
 
        /// <summary>
        /// Called when the page becomes the active page.
        /// </summary>
        /// <param name="e">Contains information about the navigation done.</param>
        protected override  void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
		
            Microsoft_VideosListControl.SelectedItem = null;
		}
    }
}
