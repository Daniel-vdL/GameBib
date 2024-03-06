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
using Windows.Security.Authentication.OnlineId;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace GameBib
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class FavoriteViewPage : Page
    {
        private ObservableCollection<FavoritedGame> allGames;
        private ObservableCollection<FavoritedGenre> allGenres;

        public FavoriteViewPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {

            using var db = new AppDbContext();

            var favoritedGames = db.FavoritedGames.Include(fg => fg.game)
                .Include(fg => fg.user)
                .ToList()
                .Where(fg => fg.user.Id == User.CurrentUser.Id);


            var favoritedGenres = db.FavoritedGenres.Include(fg => fg.genre)
                .Include(fg => fg.user)
                .ToList()
                .Where(fg => fg.user.Id == User.CurrentUser.Id);

            allGames = new ObservableCollection<FavoritedGame>(favoritedGames);
            allGenres = new ObservableCollection<FavoritedGenre>(favoritedGenres);

            GamesListView.ItemsSource = allGames;
            GenreslistView.ItemsSource = allGenres;
        }

        private void GamesListView_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void GenreslistView_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void ReturnButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainViewPage) );
        }
    }
}
