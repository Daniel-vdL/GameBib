using GameBib.Login;
using GameBib.OtherPages;
using GameBib.Models;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

namespace GameBib
{
    public sealed partial class DashboardPage : Page
    {
       
        public DashboardPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            
        }

        private void GamePageButton_Click(object sender, RoutedEventArgs e)
        {
            if (User.CurrentUser.statusId == 1)
            {
                this.Frame.Navigate(typeof(GameViewPageAdmin));
            }
            else
            {
                this.Frame.Navigate(typeof(GameViewPageUser));
            }
        }

        private void AccountPageButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(AccountPage));
        }

        private void FavoritePageButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(FavoriteViewPage));
        }

        private void WantedGamesPageButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(WantedGamesViewPage));
        }

        //private void PlayedGamesPageButton_Click(object sender, RoutedEventArgs e)
        //{
        //    this.Frame.Navigate(typeof());
        //}

        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(LoginPage));
        }
    }
}
