using ABI.System;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using GameBib.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text.Json;
using Windows.Foundation;
using Windows.Foundation.Collections;
using static System.Net.WebRequestMethods;
using System.Diagnostics;

namespace GameBib.OtherPages
{
    public sealed partial class GameViewPageUser : Page
    {
        public GameViewPageUser()
        {
            this.InitializeComponent();

            LoadGames();
        }

        public async void LoadGames()
        {

            string url = "https://api.steampowered.com/ISteamApps/GetAppList/v0002/?key=B976BE1109B7F01F799B71141600B4F9&format=json";

            var client = new HttpClient();
            var response = await client.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };

            var games = JsonSerializer.Deserialize<RootObject>(content, options);

            var filteredGames = games.applist.apps.Where(game => !string.IsNullOrEmpty(game.name)).ToList();
            GamesListView.ItemsSource = filteredGames;

        }

        //private async Task<GameDetailInfo> GetDetailedGameInfo(int appId)
        //{
        //    // Here you make another API call to get detailed information about the game using its ID.
        //    // You might need to replace this with your actual API endpoint and implementation.
        //    string detailedInfoUrl = $"https://store.steampowered.com/api/appdetails?appids={appId}";

        //    using (var client = new HttpClient())
        //    {
        //        try
        //        {
        //            var response = await client.GetAsync(detailedInfoUrl);
        //            if (response.IsSuccessStatusCode)
        //            {
        //                var content = await response.Content.ReadAsStringAsync();
        //                // Deserialize the JSON response to your detailed game info model
        //                var detailedInfo = JsonSerializer.Deserialize<GameDetailInfo>(content);
        //                return detailedInfo;
        //            }
        //            else
        //            {
        //                // Handle non-success status code
        //                // You might want to log the error or handle it accordingly.
        //                return null;
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            // Handle exceptions
        //            // You might want to log the exception or handle it accordingly.
        //            return null;
        //        }
        //    }
        //}

        private void ReturnButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(DashboardPage));
        }

        private void GamesListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            //var selectedGame = (App)e.ClickedItem;

            //// Assuming your API provides detailed information about the game based on its ID.
            //var detailedGameInfo = await GetDetailedGameInfo(selectedGame.appid);

            //if (detailedGameInfo != null)
            //{
            //    // Navigate to GameDetailViewPage and pass detailed game information
            //    this.Frame.Navigate(typeof(GameDetailViewPage), detailedGameInfo);
            //}
            //else
            //{
            //    // Handle case where detailed information about the game is not available
            //    // You can display an error message or handle it as per your requirement.
            //}

            //if (e.ClickedItem != null && e.ClickedItem is App selectedGame)
            //{
            //    // Ensure that the appid is accessible
            //    if (selectedGame.appid != 0) // Assuming appid cannot be 0
            //    {
            //        this.Frame.Navigate(typeof(GameDetailViewPage), selectedGame.appid);
            //    }
            //    else
            //    {
            //        Debug.WriteLine("Invalid appid.");
            //    }
            //}
            //else
            //{
            //    Debug.WriteLine("Clicked item is not an App or is null.");
            //}
        }

        private async void GamesListView_RightTapped(object sender, RoutedEventArgs e)
        {
            //
        }

        private void RefreshGames_Click(object sender, RoutedEventArgs e)
        {
            LoadGames(); 
        }
    }
}
