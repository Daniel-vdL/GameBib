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

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace GameBib.OtherPages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class GameViewPageUser : Page
    {
        public GameViewPageUser()
        {
            this.InitializeComponent();

            LoadGames();
        }

        public async void LoadGames()
        {

            string url = "https://api.steampowered.com/ISteamApps/GetAppList/v2/";

            var client = new HttpClient();
            var response = await client.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };

            var games = JsonSerializer.Deserialize<List<Game>>(content, options);

            nameTextBlock.Text = games[0].Name.ToString;
            //GamesListView.ItemsSource = games;

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
            var selectedGame = (Game)e.ClickedItem;

            //this.Frame.Navigate(typeof(GameInfoPage), selectedGame.Id);
        }

        private async void GamesListView_RightTapped(object sender, RoutedEventArgs e)
        {
            //
        }
    }
}
