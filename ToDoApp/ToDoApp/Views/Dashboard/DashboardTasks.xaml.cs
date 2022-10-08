using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using ToDoApp.ViewModel;

namespace ToDoApp.Views.Dashboard
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DashboardTasks : ContentPage
    {
        public DashboardTasks()
        {
            InitializeComponent();
            BindingContext = new VMDashboardTasks(Navigation);
        }
    }
}