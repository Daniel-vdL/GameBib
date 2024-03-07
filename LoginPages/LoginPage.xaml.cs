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
using static System.Net.Mime.MediaTypeNames;
using Windows.Security.Cryptography.Core;
using Windows.UI.Popups;
using static System.Net.WebRequestMethods;
using System.Net;
using Windows.System;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace GameBib
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class LoginPage : Page
    {

        public LoginPage()
        {
            this.InitializeComponent();
        }


        internal async void loginButton_Click(object sender, RoutedEventArgs e)
        {
            string username = Username.Text;
            string inputPassword = Password.Password;

            using (var db = new AppDbContext())
            {
                var user = db.Users.FirstOrDefault(u => u.Username == username);
                //Check if password is correct. 
                if (user != null && VerifyPassword(inputPassword, user.Password, username))
                {
                    Models.User.CurrentUser = user;

                    Frame.Navigate(typeof(MainViewPage));
                }
                else
                {
                    //Removes input from input boxes.
                    Username.Text = null;
                    Password.Password = null;

                    //Error message
                    ContentDialog wrongCredentialsDialog = new ContentDialog
                    {
                        Title = "Login Failed",
                        Content = "Please check your credentials.",
                        CloseButtonText = "Ok",
                        XamlRoot = this.XamlRoot,
                    };

                    ContentDialogResult result = await wrongCredentialsDialog.ShowAsync();
                }
            }
        }
        private bool VerifyPassword(string inputPassword, string hashedPassword, string email)
        {
            return SecureHasher.Verify(inputPassword, hashedPassword);
        }

        private void registerButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(CreateUserPage));
        }
    }
}
