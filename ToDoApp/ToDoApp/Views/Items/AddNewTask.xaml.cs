﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ToDoApp.Views.Items
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddNewTask : ContentPage
    {
        public AddNewTask()
        {
            InitializeComponent();
        }
    }
}