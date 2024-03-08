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
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

namespace GameBib.GamePages
{
    public sealed partial class GameInfoPage : Page
    {
        public Game CurrentGame { get; set; }

        public GameInfoPage()
        {
            this.InitializeComponent();
            using var db = new AppDbContext();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {

            base.OnNavigatedTo(e);

            var selectedGameId = (int)e.Parameter;

            using var db = new AppDbContext();

            var game = db.Games
                .Include(g => g.Genre)
                .Single(m => m.Id == selectedGameId);

            CurrentGame = game;

            nameTextBlock.Text = CurrentGame.Name;
            descriptionTextBlock.Text = "Description: " + CurrentGame.Description;
            genreTextBlock.Text = "Genre: " + CurrentGame.Genre.Name;
            releaseTextBlock.Text = "Release Date: " + CurrentGame.Release;
            ratingTextBlock.Text = "Rating: " + CurrentGame.Rating;
        }

        private void returnButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(GameViewPageUser));
        }
    }
}
