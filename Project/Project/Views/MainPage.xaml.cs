using Project.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Project
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

     
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

        private void btnAddShow_Clicked(object sender, EventArgs e)
        {

            Navigation.PushModalAsync(new AddShowPage());
        }

        private void BtnUnseen_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new UnseenMovies());
        }
    }
}
