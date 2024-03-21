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

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace GameBib
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
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

        private void GenrePageButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(GenreViewPageAdmin));
        }

        private void FavoritePageButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(FavoriteViewPage));
        }

        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(LoginPage));
        }
    }
}
