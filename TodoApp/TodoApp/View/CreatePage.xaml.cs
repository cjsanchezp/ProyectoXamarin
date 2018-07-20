using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TodoApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CreatePage : ContentPage
	{
        //public List<TodoItem> TodoItems = new List<TodoItem>();
        private CreatePageViewModel vm;
        private int updateId;
        public CreatePage (int id)
		{
            vm = new CreatePageViewModel();
            this.BindingContext = vm;            
			InitializeComponent ();

            var todo = App.Database.GetTodo(id);
            Todo.Text = todo.ToDo;
            Prioridad.Text = todo.Prioridad;
            FechaFin.Date = todo.FechaFin;
            HoraFin.Time = todo.FechaFin.TimeOfDay;
            updateId = todo.Id;

		}

        public CreatePage()
        {
            vm = new CreatePageViewModel();
            this.BindingContext = vm;
            InitializeComponent();
        }
        private void OnGuardar(object o, EventArgs e)
        {
            vm.AddTask(ToDo.Text, Prioridad.Text, FechaFin.Date,
                HoraFin.Time.Hours,
                HoraFin.Time.Minutes,
                HoraFin.Time.Seconds,
                updateId,
                false);
            Limpiar();
         
        }
      

        private void Limpiar()
        {
            ToDo.Text = string.Empty;
            Prioridad.Text = string.Empty;
            FechaFin.Date = DateTime.Now;
            HoraFin.Time = DateTime.Now.TimeOfDay;
        }
        private void OnCancelar(object o, EventArgs e)
        {

        }

        private void OnRevisar(object o, EventArgs e)
        {
           
            Navigation.PushAsync(new ListTaskPage());
        }
    }
}