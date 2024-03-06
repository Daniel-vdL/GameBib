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
    public sealed partial class CreateUserPage : Page
    {
        public CreateUserPage()
        {
            this.InitializeComponent();
        }

        private void createButton_Click(object sender, RoutedEventArgs e)
        {
            createButton.Content = "User Created"; ;
            using (var db = new AppDbContext())
            {
                db.Users.Add(new User
                {
                    Username = Username.Text,
                    Password = SecureHasher.Hash(Password.Password),
                });
                db.SaveChanges();
            }
        }

        private void loginButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(LoginPage));
        }
    }
}
