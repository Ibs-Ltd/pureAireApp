using PureAire_APP.ViewModels;
using PureAire_APP.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace PureAire_APP
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(IAQMonitorPage), typeof(IAQMonitorPage));
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}
