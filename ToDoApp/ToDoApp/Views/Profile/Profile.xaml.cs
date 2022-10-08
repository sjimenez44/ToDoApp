using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ToDoApp.Views.Profile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Profile : ContentPage
    {
        public Profile()
        {
            InitializeComponent();
            BindingContext = new VMProfile(Navigation);
        }
    }
}