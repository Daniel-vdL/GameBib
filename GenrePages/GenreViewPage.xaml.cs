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
using System.Collections.ObjectModel;
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
    public sealed partial class GenreViewPage : Page
    {
        public static User CurrentUser { get; set; }
        private ObservableCollection<Genre> allGenres;

        public GenreViewPage()
        {
            this.InitializeComponent();
            using var db = new AppDbContext();

            var genres = db.Genres
               .ToList();

            allGenres = new ObservableCollection<Genre>(genres);

            GenreslistView.ItemsSource = allGenres;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            CurrentUser = e.Parameter as User;

            using var db = new AppDbContext();
        }

        private void SearchGenres_Click(object sender, RoutedEventArgs e)
        {
            SearchGenres.Content = "Refresh";
            using var db = new AppDbContext();
            var genres = db.Genres
                    //.Where(g => g.Name.Contains(SearchTextBox.Text))
                    .OrderByDescending(i => i.Id).ToList();
            GenreslistView.ItemsSource = genres;
        }

        private void ReturnButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainViewPage), CurrentUser);
        }

        private void myButton_Click(object sender, RoutedEventArgs e)
        {
            myButton.Content = "Genre Created";
            using (var db = new AppDbContext())
            {
                db.Genres.Add(new Genre
                {
                    Name = GenreName.Text,
                    Description = GenreDescription.Text,
                });
                db.SaveChanges();

                var genres = db.Genres
                    //.Where(g => g.Name.Contains(SearchTextBox.Text))
                    .OrderByDescending(i => i.Id).ToList();
                GenreslistView.ItemsSource = genres;
            }
        }

        private async void GenreslistView_RightTapped(object sender, RoutedEventArgs e)
        {
            var listViewItem = (FrameworkElement)e.OriginalSource;
            var selectedGenre = (Genre)listViewItem.DataContext;

            if (selectedGenre == null)
            {
                return;
            }

            using var db = new AppDbContext();

            db.Genres.Remove(selectedGenre);
            allGenres.Remove(selectedGenre);

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
                        await databaseErrorDialog.ShowAsync();
                        // BUG:     https://github.com/microsoft/microsoft-ui-xaml/issues/1679
                    }
                    else
                    {
                        throw ex;
                    }
                }
            }
        }

        private void GenreslistView_ItemClick(object sender, ItemClickEventArgs e)
        {
            var selectedGenre = (Genre)e.ClickedItem;

            this.Frame.Navigate(typeof(GenreEditPage), selectedGenre.Id);
        }
    }
}
