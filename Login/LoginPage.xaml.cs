using GameBib.Models;
using GameBib.OtherPages;
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

namespace GameBib.Login
{
    public sealed partial class LoginPage : Page
    {
        public LoginPage()
        {
            this.InitializeComponent();
        }

        private async void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            var username = UsernameTextbox.Text;
            var passwordBox = PasswordTextbox;
            var password = passwordBox.Password;
            var client = new HttpClient();

            var user = new User
            {
                Username = username,
                Password = password
            };

            var userJson = JsonSerializer.Serialize(user);

            var context = new StringContent(userJson, System.Text.Encoding.UTF8, "Application/Json");

            var response = await client.PostAsync("https://localhost:7063/api/Users/Login", context);

            if (response.IsSuccessStatusCode == false)
            {
                ContentDialog ErrorDialog = new ContentDialog
                {
                    Title = "Login failed!",
                    Content = "Click 'Ok' to continue",
                    CloseButtonText = "Ok",
                    XamlRoot = this.XamlRoot,
                };

                ContentDialogResult result = await ErrorDialog.ShowAsync();

                return;
            }

            var answerJson = await response.Content.ReadAsStringAsync();

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };

            var answerUser = JsonSerializer.Deserialize<User>(answerJson, options);

            User.CurrentUser = answerUser;

            this.Frame.Navigate(typeof(DashboardPage));
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(RegistrationPage));
        }
    }
}
