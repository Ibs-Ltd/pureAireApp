using PureAire_APP.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PureAire_APP.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class IAQMonitorPage : ContentPage
    {

        public IAQMonitorPage()
        {
            InitializeComponent();
            BindingContext = new IAQMonitorViewModel();
        }




    }
}