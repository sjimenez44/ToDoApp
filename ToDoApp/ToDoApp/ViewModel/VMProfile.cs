using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Input;
using ToDoApp.ViewModel.Template;
using Xamarin.Forms;

namespace ToDoApp.ViewModel
{
    public class VMProfile : BaseViewModel
    {
        #region VARIABLES
        string _NameClient;
        int _NoTasks;
        int _NoDoneTasks;
        int _NoProjects;
        #endregion
        #region CONSTRUCTOR
        public VMProfile(INavigation navigation)
        {
            Navigation = navigation;
        }
        #endregion
        #region OBJETOS
        public string NameClient
        {
            get { return "Santiago Jimenez"; }
            set { SetValue(ref _NameClient, value); }
        }
        public int NoTasks
        {
            get { return 10; }
            set { SetValue(ref _NoTasks, value); }
        }
        public int NoDoneTasks
        {
            get { return 2; }
            set { SetValue(ref _NoDoneTasks, value); }
        }
        public int NoProjects
        {
            get { return 3; }
            set { SetValue(ref _NoProjects, value); }
        }
        #endregion
        #region PROCESOS
        public void GoBack()
        {
            Debug.WriteLine("Ir al dashboard de tareas");
        }
        public void Logout()
        {
            Debug.WriteLine("Cerrar sesion");
        }
        public void HideDoneTasks()
        {
            Debug.WriteLine("Ejecutar accion de tareas realizadas");
        }
        #endregion
        #region COMANDOS
        public ICommand HideDoneTasksCommand => new Command(HideDoneTasks);
        public ICommand GoBackCommand => new Command(GoBack);
        public ICommand LogoutCommand => new Command(Logout);
        #endregion
    }
}
