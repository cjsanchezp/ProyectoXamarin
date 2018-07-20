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
	public partial class ListTaskPage : ContentPage
	{
        
        public ListTaskPage ()
		{
            this.BindingContext = this;
			InitializeComponent ();
		}

        private void OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            var todo = e.Item as TodoItem;
            DisplayAlert("Elegida", todo.ToDo+"fue elegida", "ok");
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            LstTodos.ItemsSource = App.Database.GetTodos();
        }
	}
}