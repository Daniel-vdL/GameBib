using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System.Text.Json;
using System.Net.Http;
using GameBib.Models;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace GameBib.OtherPages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class GameDetailViewPage : Page
    {
        private Models.App selectedGame;

        public GameDetailViewPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            if (e.Parameter is Models.App game)
            {
                selectedGame = game;
                LoadAppDetail();
            }
        }

        public async void LoadAppDetail()
        {
            if (selectedGame == null)
                return;

            string url = $"https://store.steampowered.com/api/appdetails?appids={selectedGame.appid}";

            var client = new HttpClient();
            var response = await client.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };

            var appDetail = JsonSerializer.Deserialize<Dictionary<string, AppDetails>>(content, options);

            if (appDetail != null && appDetail.ContainsKey(selectedGame.appid.ToString()))
            {
                var gameDetail = appDetail[selectedGame.appid.ToString()];
                gameDetailsListView.ItemsSource = new List<AppDetails> { gameDetail };
            }
        }

        private void returnButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(GameViewPageUser));
        }
    }

}

