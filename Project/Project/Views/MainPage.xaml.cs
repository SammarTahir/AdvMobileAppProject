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

        // This will bring the user to list view of all the movies
        private void BtnMovie_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new UnseenMovies());
        }

        // This will bring the user to a page where they can edit the list to suit
        // their own liking
        private void BtnEdit_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new EditMoviePage());
        }

        // This will allow the user to use the camera function only made for window platforms... so far
        private void BtnCamera_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new MakeMoviePage());
        }

        // Bring the user the about us page
        private void BtnInfo_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new SavedMedia());
        }
    }
}
