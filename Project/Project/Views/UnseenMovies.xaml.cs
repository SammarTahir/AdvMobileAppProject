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

        private void RefreshShowsListView()
        {
            lvShows.ItemsSource = null;
            lvShows.ItemsSource = showsList;
        }

        private async void LvShows_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            await Navigation.PushAsync(new ShowDetailPage(e.SelectedItem as Shows));
            //await (BindingContext as MainPageViewModel).SelectOneShowAsync(e.SelectedItem as Shows);
        }




       
    }
}