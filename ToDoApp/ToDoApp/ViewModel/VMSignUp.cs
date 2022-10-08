using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Input;
using ToDoApp.ViewModel.Template;
using Xamarin.Forms;

namespace ToDoApp.ViewModel
{
    public class VMSignUp : BaseViewModel
    {
        #region VARIABLES
        string _Texto;
        #endregion
        #region CONSTRUCTOR
        public VMSignUp(INavigation navigation)
        {
            Navigation = navigation;
        }
        #endregion
        #region OBJETOS
        public string Texto
        {
            get { return _Texto; }
            set { SetValue(ref _Texto, value); }
        }
        #endregion
        #region PROCESOS
        public void Back()
        {
            Debug.WriteLine("Ir atras");
        }
        public void SignUp()
        {
            Debug.WriteLine("Registrarse");
        }
        public void Login()
        {
            Debug.WriteLine("Ir a ingresar");
        }
        #endregion
        #region COMANDOS
        public ICommand BackCommand => new Command(Back);
        public ICommand SignupCommand => new Command(SignUp);
        public ICommand LoginCommand => new Command(Login);
        #endregion
    }
}
