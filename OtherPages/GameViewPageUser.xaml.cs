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

        private void SearchGames_Click(object sender, RoutedEventArgs e)
        {
            //
        }

        private void ReturnButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(DashboardPage));
        }

        private void GamesListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            //var selectedGame = (Game)e.ClickedItem;

            //this.Frame.Navigate(typeof(GameInfoPage), selectedGame.Id);
        }

        private async void GamesListView_RightTapped(object sender, RoutedEventArgs e)
        {
            //
        }
    }
}
