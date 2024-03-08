// Copyright (c) Microsoft Corporation and Contributors.
// Licensed under the MIT License.

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

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace GameBib
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class GameEditPage : Page
    {
        public Game CurrentGame { get; set; }

        public GameEditPage()
        {
            this.InitializeComponent();
            using var db = new AppDbContext();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {

            base.OnNavigatedTo(e);

            var selectedGameId = (int)e.Parameter;

            using var db = new AppDbContext();

            GameGenreComboBox.ItemsSource = db.Genres.ToList();

            var game = db.Games
                .Include(g => g.Genre)
                .Single(m => m.Id == selectedGameId);

            CurrentGame = game;

            nameTextBlock.Text = CurrentGame.Name;
            descriptionTextBlock.Text = "Description: " + CurrentGame.Description;
            genreTextBlock.Text = "Genre: " + CurrentGame.Genre.Name;
            releaseTextBlock.Text = "Release Date: " + CurrentGame.Release;
            ratingTextBlock.Text = "Rating: " + CurrentGame.Rating;

            GameName.Text = CurrentGame.Name;
            GameDescription.Text = CurrentGame.Description;
            GameRelease.SelectedDate = CurrentGame.Release;
            GameRating.Text = CurrentGame.Rating.ToString();
            GameGenreComboBox.SelectedItem = CurrentGame.Genre;
        }

        private void returnButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(GameViewPageAdmin));
        }

        private void myButton_Click(object sender, RoutedEventArgs e)
        {
            myButton.Content = "Game Changed";
            var selectedGenre = (Genre)GameGenreComboBox.SelectedItem;

            using (var db = new AppDbContext())
            {
                db.Attach(CurrentGame);
                CurrentGame.Name = GameName.Text;
                CurrentGame.Genre = selectedGenre;
                CurrentGame.Description = GameDescription.Text;
                CurrentGame.Release = GameRelease.SelectedDate.Value.DateTime;
                CurrentGame.Rating = double.Parse(GameRating.Text);
                db.SaveChanges();
            }

            nameTextBlock.Text = CurrentGame.Name;
            descriptionTextBlock.Text = "Description: " + CurrentGame.Description;
            genreTextBlock.Text = "Genre: " + CurrentGame.Genre.Name;
            releaseTextBlock.Text = "Release Date: " + CurrentGame.Release;
            ratingTextBlock.Text = "Rating: " + CurrentGame.Rating;
        }
    }
}
