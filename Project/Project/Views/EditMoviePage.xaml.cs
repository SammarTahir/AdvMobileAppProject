using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Project.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class EditMoviePage : ContentPage
	{
        ObservableCollection<Shows> showList;

        public EditMoviePage ()
		{
			InitializeComponent ();
            SetDefaultStuffMethod();
        }

        private void SetDefaultStuffMethod()
        {
            if (showList == null) showList = new ObservableCollection<Shows>();

            showList = Utils.ReadShowsListData();
            // set the data context for the list view
            lvShow.ItemsSource = showList;

        }

        private void lvShow_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            // set the binding context for slOneElement to be the 
            // selected item on the listview
            slOneElement.BindingContext = (Shows)e.SelectedItem;
        }

        private void btnSaveFile_Clicked(object sender, EventArgs e)
        {
            // save the list of dogs to the local application folder
            Utils.SaveShowListData(showList);
        }

        private void btnUpdateOne_Clicked(object sender, EventArgs e)
        {
            // use a foreach statement to check the elements of the
            // list.  if a match with the current one (slOneElement)
            // then update that one on the showList
            foreach (var movie in showList)
            {
                if (movie.ID == lblOneMovieID.Text)
                {
                    movie.Title = entTitle.Text;
                }
            } // end of foreach
            RefreshShowListView();
        }

        private void RefreshShowListView()
        {
            lvShow.ItemsSource = null;
            lvShow.ItemsSource = showList;
        }

        private void Home_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new MainPage());

        }

        
    }
}