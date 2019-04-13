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
	public partial class UnseenMovies : ContentPage
	{
		public UnseenMovies ()
		{
			InitializeComponent ();
            SetDefaultStuffMethod();
        }

        ObservableCollection<Shows> showsList;

        private void SetDefaultStuffMethod()
        {
            if (showsList == null) showsList = new ObservableCollection<Shows>();

            showsList = Utils.ReadShowsListData();
            // set the data context for the list view
            lvShows.ItemsSource = showsList;

        }

        // This should bring the user the IMDB page using the movie title/id
        private async void LvShows_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            await Navigation.PushAsync(new ShowDetailPage(e.SelectedItem as Shows));
        }

        private void BtnHome_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new MainPage());
        }

        // UnUsed so far
        #region UN-USED
        private void DeleteContext_Clicked(object sender, EventArgs e)
        {
            // really nice to get the object that was clicked.
            Shows show = (sender as MenuItem).CommandParameter as Shows;
            //dogsList.Remove(dog);
            (BindingContext as MainPageViewModel).DeleteFromList(show);

        }

        private void btnSaveFile_Clicked(object sender, EventArgs e)
        {
            // save the list of show to the local application folder
            // MyUtils.SaveShowListData(showsList);
            // Need a reference to the current viewmodel
            (BindingContext as MainPageViewModel).SaveList();
        }

        #endregion

       
    }
}