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
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text.Json;
using Windows.Foundation;
using Windows.Foundation.Collections;

namespace GameBib.OtherPages
{
    public sealed partial class AccountPage : Page
    {
        public AccountPage()
        {
            this.InitializeComponent();
        }

        private void ReturnButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(DashboardPage));
        }

        private async void NameChangeButton_Click(object sender, RoutedEventArgs e)
        {
            var username = UsernameTextbox.Text;

            if (!string.IsNullOrWhiteSpace(username))
            {
                using var client = new HttpClient();

                var user = new User
                {
                    Id = User.CurrentUser.Id,
                    Username = username
                };

                var userJson = JsonSerializer.Serialize(user);
                var context = new StringContent(userJson, System.Text.Encoding.UTF8, "application/json");

                try
                {
                    var response = await client.PutAsync($"https://localhost:7063/api/Users/{User.CurrentUser.Id}", context);

                    // Check if the request was successful
                    if (response.IsSuccessStatusCode)
                    {
                        User.CurrentUser = user;
                        this.Frame.Navigate(typeof(AccountPage));
                    }
                    else
                    {
                        // Handle the failure scenario
                        // For example, display an error message to the user
                    }
                }
                catch (Exception ex)
                {
                    // Handle any exceptions that might occur during the API call
                    // For example, log the exception or display an error message to the user
                }
            }
        }

    }
}
