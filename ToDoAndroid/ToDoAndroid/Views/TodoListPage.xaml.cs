using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ToDoAndroid
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TodoListPage : ContentPage
    {
        public TodoListPage()
        {
            InitializeComponent();

        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            DatabaseLocation.Text = Constants.DatabasePath;
            SpecialFolder.Text = Constants.SpecialFolder;
            //string mystring = Constants.SpecialFolder;
            listView.ItemsSource = await App.Database.GetItemsAsync();
        }
        async void OnSearchClicked(object sender, EventArgs e)
        {
            if (SearchToDo.Text != "")
            {
                listView.ItemsSource = await App.Database.GetItemsSearch(SearchToDo.Text);
            }

        }
        async void OnItemAdded(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TodoItemPage
            {
                BindingContext = new TodoItem()
            });
        }
        async void OnListItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new TodoItemPage
                {
                    BindingContext = e.SelectedItem as TodoItem
                });
            }
        }
    }
}