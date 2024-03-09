// Copyright (c) Microsoft Corporation and Contributors.
// Licensed under the MIT License.

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
    public sealed partial class GenreEditPage : Page
    {
        public Genre CurrentGenre { get; set; }

        public GenreEditPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            var selectedGenreId = (int)e.Parameter;

            using var db = new AppDbContext();

            var genre = db.Genres
                .Single(m => m.Id == selectedGenreId);

            CurrentGenre = genre;

            nameTextBlock.Text = genre.Name;
            descriptionTextBlock.Text = "Description: " + genre.Description;

            GenreName.Text = genre.Name;
            GenreDescription.Text = genre.Description;
        }

        private void returnButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(GenreViewPageAdmin));
        }

        private void myButton_Click(object sender, RoutedEventArgs e)
        {
            myButton.Content = "Game Changed";

            using (var db = new AppDbContext())
            {
                db.Attach(CurrentGenre);
                CurrentGenre.Name = GenreName.Text;
                CurrentGenre.Description = GenreDescription.Text;
                db.SaveChanges();
            }

            nameTextBlock.Text = CurrentGenre.Name;
            descriptionTextBlock.Text = "Description: " + CurrentGenre.Description;
        }
    }
}
