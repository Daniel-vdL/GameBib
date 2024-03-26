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
using Windows.UI.WebUI;
using System.Text.RegularExpressions;

namespace GameBib.OtherPages
{
    public sealed partial class GameDetailViewPage : Page
    {
        private Models.App selectedGame;
        public AppData gameDetails { get; set; }

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

        private void returnButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(GameViewPageUser));
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
                if (gameDetail.Data != null && gameDetail.Data.Background != null && IsImageUri(gameDetail.Data.Background))
                {
                    // Load the details into the UI
                    gameDetails = gameDetail.Data;
                    Bindings.Update(); // Ensure the UI updates with the new data
                }
                else
                {
                    ContentDialog ErrorDialog = new ContentDialog
                    {
                        Title = "This App does not have the correct data!",
                        Content = "Click 'Ok' to continue",
                        CloseButtonText = "Ok",
                        XamlRoot = this.XamlRoot,
                    };

                    ContentDialogResult result = await ErrorDialog.ShowAsync();

                    this.Frame.Navigate(typeof(GameViewPageUser));
                }
            }
        }
        private bool IsImageUri(string uriString)
        {
            // Try parsing the URI
            if (Uri.TryCreate(uriString, UriKind.Absolute, out Uri uri))
            {
                // Check if it's HTTP or HTTPS scheme (you may adjust this depending on your requirements)
                return uri.Scheme == Uri.UriSchemeHttp || uri.Scheme == Uri.UriSchemeHttps;
            }
            return false;
        }
    }
}
