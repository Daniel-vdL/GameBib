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

namespace GameBib
{
    public sealed partial class GameViewPageAdmin : Page
    {
        private ObservableCollection<Game> allGames;

        public GameViewPageAdmin()
        {
            using var db = new AppDbContext();
            this.InitializeComponent();
            GameGenreComboBox.ItemsSource = db.Genres.ToList();

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

        private void myButton_Click(object sender, RoutedEventArgs e)
        {
            myButton.Content = "Game Created";
            var selectedGenre = (Genre)GameGenreComboBox.SelectedItem;
            using (var db = new AppDbContext())
            {
                db.Attach(selectedGenre);
                db.Games.Add(new Game
                {
                    Name = GameName.Text,
                    Genre = selectedGenre,
                    Description = GameDescription.Text,
                    Release = GameRelease.SelectedDate.Value.DateTime,
                    Rating = double.
                    Parse(GameRating.Text),
                });
                db.SaveChanges();

                var games = db.Games
                    .Include(g => g.Genre)
                    .OrderByDescending(r => r.Release).ToList();
                GamesListView.ItemsSource = games;
            }
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

            this.Frame.Navigate(typeof(GameEditPage), selectedGame.Id);
        }

        private void GamesListView_RightTapped(object sender, RoutedEventArgs e)
        {
            var listViewItem = (FrameworkElement)e.OriginalSource;
            var selectedGame = (Game)listViewItem.DataContext;

            if (selectedGame == null)
            {
                return;
            }

            using var db = new AppDbContext();

            db.Games.Remove(selectedGame);
            allGames.Remove(selectedGame);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                foreach (var entry in ex.Entries)
                {
                    var proposedValues = entry.CurrentValues;

                    var databaseValues = entry.GetDatabaseValues();

                    if (databaseValues == null)
                    {

                    }
                    else
                    {
                        throw ex;
                    }
                }
            }
        }
    }
}