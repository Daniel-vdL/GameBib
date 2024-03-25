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
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text.Json;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace GameBib.OtherPages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class WantedGamesViewPage : Page
    {
        public WantedGamesViewPage()
        {
            this.InitializeComponent();
            List<string> wantedGameNames = new List<string>(); // assuming you're providing wanted game names here
            LoadWantedGames(wantedGameNames);
        }
        public async void LoadWantedGames(List<string> wantedGameNames)
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

            // Filter games based on user's wanted game names
            var filteredGames = games.applist.apps
                .Where(game => wantedGameNames.Contains(game.name))
                .ToList();

            WantedGamesListView.ItemsSource = filteredGames;
        }

        private void ReturnButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(DashboardPage));
        }

        private void RemoveGame_Click(object sender, RoutedEventArgs e)
        {

        }

        private async void GamesListView_RightTapped(object sender, RoutedEventArgs e)
        {
            //
        }

        private void RefreshGames_Click(object sender, RoutedEventArgs e)
        {
            List<string> wantedGameNames = new List<string>();
            LoadWantedGames(wantedGameNames);
        }
    }
}
