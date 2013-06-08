using System;
using Microsoft.Phone.Controls;

namespace LlsStaticTest
{
    using System.Diagnostics;
    using System.Windows.Input;

    public partial class MainPage : PhoneApplicationPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void ForceGdTapped(object sender, GestureEventArgs e)
        {
            Debug.WriteLine("FORCING GARBAGE COLLECTION");
            GC.Collect();
        }

        private void LbsTapped(object sender, GestureEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/Views/ListBoxStatic.xaml", UriKind.Relative));
        }

        private void LbnsTapped(object sender, GestureEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/Views/ListBoxNonStatic.xaml", UriKind.Relative));
        }

        private void LlsTapped(object sender, GestureEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/Views/LlsStatic.xaml", UriKind.Relative));
        }

        private void LlsNTapped(object sender, GestureEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/Views/LlsNonStatic.xaml", UriKind.Relative));
        }
    }
}