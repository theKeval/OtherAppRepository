﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

using Windows.ApplicationModel.Store;
using Store = Windows.ApplicationModel.Store;
using System.Collections.ObjectModel;
using WPAppStudio.Helper;

namespace WPAppStudio.View
{
    public partial class InAppPurchasePage : PhoneApplicationPage
    {
        public InAppPurchasePage()
        {
            InitializeComponent();
        }


        public ObservableCollection<ProductItem> picItems = new ObservableCollection<ProductItem>();

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            RenderStoreItems();
            base.OnNavigatedTo(e);
        }

        private async void RenderStoreItems()
        {
            picItems.Clear();

            try
            {
                //StoreManager mySM = new StoreManager();
                ListingInformation li = await Store.CurrentApp.LoadListingInformationAsync();

                foreach (string key in li.ProductListings.Keys)
                {
                    ProductListing pListing = li.ProductListings[key];
                    System.Diagnostics.Debug.WriteLine(key);

                    string status = Store.CurrentApp.LicenseInformation.ProductLicenses[key].IsActive ? "Purchased" : pListing.FormattedPrice;

                    string imageLink = string.Empty;

                    picItems.Add(
                        new ProductItem
                        {
                            imgLink = "/Assets/dd108095-338b-4da2-94d4-553cde3339d3.png",
                            Name = pListing.Name,
                            Status = status,
                            key = key,
                            BuyNowButtonVisible = Store.CurrentApp.LicenseInformation.ProductLicenses[key].IsActive ? System.Windows.Visibility.Collapsed : System.Windows.Visibility.Visible
                        }
                    );
                }

                pics.ItemsSource = picItems;
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.ToString());
            }
        }

        private async void ButtonBuyNow_Clicked(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;

            string key = btn.Tag.ToString();

            try
            {
                if (!Store.CurrentApp.LicenseInformation.ProductLicenses[key].IsActive)
                {
                    ListingInformation li = await Store.CurrentApp.LoadListingInformationAsync();
                    string pID = li.ProductListings[key].ProductId;

                    var receipt = await Store.CurrentApp.RequestProductPurchaseAsync(pID, false);

                    RenderStoreItems();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Purchase canceled..!!\n :'(");
            }

        }

    }
}