using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ToDoApp.ViewModel.Template;
using Xamarin.Forms;

namespace ToDoApp.ViewModel
{
    public class VMDashboardTasks : BaseViewModel
    {
        #region VARIABLES
        string _Texto;
        List<Core.Entities.Task> _Tasks = new List<Core.Entities.Task>()
        {
            new Core.Entities.Task()
            {
                Id = "1",
                Name = "Limpiar carro",
                Created = DateTime.Now,
                Status = 1,
                Project = new Core.Entities.Project() { Name = "Carro", Color = "#f58442" },
            },
            new Core.Entities.Task()
            {
                Id = "2",
                Name = "Retocar fotos",
                Created = DateTime.Now,
                Status = 1,
                Project = new Core.Entities.Project() { Name = "Fotografia", Color = "#f542dd" },
            },
        };
        #endregion
        #region CONSTRUCTOR
        public VMDashboardTasks(INavigation navigation)
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
        public List<Core.Entities.Task> Tasks
        {
            get { return _Tasks; }
        }
        #endregion
        #region PROCESOS
        private async Task DeleteTask(Core.Entities.Task data)
        {
            Debug.WriteLine($"[DEBUG] :: Eliminar | {data.Id} - {data.Name}");
        }

        private async Task EditTask(Core.Entities.Task data)
        {
            Debug.WriteLine($"[DEBUG] :: Editar | {data.Id} - {data.Name}");
        }

        private async Task ChangeStatusTask(Core.Entities.Task data)
        {
            Debug.WriteLine($"[DEBUG] :: Cambiar estado | {data.Id} - {data.Name}");
        }

        public void ToProfile()
        {
            Debug.WriteLine("[DEBUG] :: Ir al perfil");
        }
        
        public void LastWeek()
        {
            Debug.WriteLine("[DEBUG] :: Una semana antes");
        }
        
        public void NextWeek()
        {
            Debug.WriteLine("[DEBUG] :: Una semana despues");
        }

        public void AllProjects()
        {
            Debug.WriteLine("[DEBUG] :: Listar todos mis proyectos");
        }
        #endregion
        #region COMANDOS
        public ICommand DeleteTaskcommand => new Command<Core.Entities.Task>(async (data) => await DeleteTask(data));
        public ICommand EditTaskcommand => new Command<Core.Entities.Task>(async (data) => await EditTask(data));
        public ICommand ChangeStatusTaskcommand => new Command<Core.Entities.Task>(async (data) => await ChangeStatusTask(data));
        public ICommand ToProfileCommand => new Command(ToProfile);
        public ICommand LastWeekCommand => new Command(LastWeek);
        public ICommand NextWeekCommand => new Command(NextWeek);
        public ICommand AllProjectsCommand => new Command(AllProjects);
        #endregion
    }
}
