using GameBib.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

namespace GameBib.GamePages
{
    public sealed partial class GameViewPage2 : Page
    {
        private ObservableCollection<Game> allGames;

        public GameViewPage2()
        {
            using var db = new AppDbContext();
            this.InitializeComponent();

            var games = db.Games
                .Include(g => g.Genre)
                .ToList()
                .OrderByDescending(r => r.Release).ToList();

            allGames = new ObservableCollection<Game>(games);

            GamesListView.ItemsSource = allGames;

        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            using var db = new AppDbContext();
        }

        private void SearchGames_Click(object sender, RoutedEventArgs e)
        {
            SearchGames.Content = "Refresh";

            using var db = new AppDbContext();
            var games = db.Games
                .Include(g => g.Genre)
                .OrderByDescending(r => r.Release).ToList();
            GamesListView.ItemsSource = games;
        }

        private void ReturnButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainViewPage));
        }

        private void GamesListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            var selectedGame = (Game)e.ClickedItem;
        }

        private async void GamesListView_RightTapped(object sender, RoutedEventArgs e)
        {
            var listViewItem = (FrameworkElement)e.OriginalSource;
            var selectedGame = (Game)listViewItem.DataContext;

            using (var db = new AppDbContext())
            {
                bool isFavorited = db.FavoritedGames
                    .Any(g => g.GameId == selectedGame.Id && g.UserId == User.CurrentUser.Id);

                if (isFavorited)
                {
                    ContentDialog ErrorDialog = new ContentDialog
                    {
                        Title = "Game is already favorited",
                        Content = "Click 'Ok' to continue",
                        CloseButtonText = "Ok",
                        XamlRoot = this.XamlRoot,
                    };

                    ContentDialogResult result1 = await ErrorDialog.ShowAsync();
                    return;
                }

                db.FavoritedGames.Add(new FavoritedGame
                {
                    GameId = selectedGame.Id,
                    UserId = User.CurrentUser.Id,
                });
                db.SaveChanges();

                ContentDialog FavoritedDialog = new ContentDialog
                {
                    Title = "Game added to Favorites",
                    Content = "Click 'Ok' to continue",
                    CloseButtonText = "Ok",
                    XamlRoot = this.XamlRoot,
                };

                ContentDialogResult result = await FavoritedDialog.ShowAsync();
            };
        }
    }
}
