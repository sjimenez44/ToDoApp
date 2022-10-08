using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ToDoApp.Views;
using ToDoApp.Views.Dashboard;
using ToDoApp.Views.Profile;
using ToDoApp.Views.Register;

namespace ToDoApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new SignUp());
            //MainPage = new NavigationPage(new Login());
            //MainPage = new NavigationPage(new Profile());
            //MainPage = new NavigationPage(new DashboardTasks());
            //MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
