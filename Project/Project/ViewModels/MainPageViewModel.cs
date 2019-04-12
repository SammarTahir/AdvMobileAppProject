using Project.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Project
{
    class MainPageViewModel : BaseViewModel //INotifyPropertyChanged
    {
        //// needed for the INotifyPropertyChanged
        //public event PropertyChangedEventHandler PropertyChanged;

        #region == Private Fields ==

        // data bound to the listview SelectedItem
        // data bound to the BindingContext of slonelement
        private ShowsViewModel selectedShow;
        private ObservableCollection<ShowsViewModel> showsList;
        #endregion

        #region == Public Properties ==

        public ObservableCollection<ShowsViewModel> ShowsList
        {
            get { return showsList; }
            private set { SetValue(ref showsList, value); }
        }

        public ShowsViewModel SelectedShow
        {
            get { return selectedShow; }
            set { SetValue(ref selectedShow, value); }
        }
        #endregion

        #region == Command Properties ==
        public ICommand SaveListCommand { get; private set; }
        public ICommand DeleteFromListCommand { get; private set; }
        #endregion

       


        #region == public events ==

        private readonly IPageService _pageService;

        public MainPageViewModel(IPageService pageService)  // constructor
        {
            _pageService = pageService;
            ReadList();
            // set up the commands as new Command Objecgts
            // pass them the name of the method to execute in
            // response to being called
            // When data bound, XAML sees the ICommand object
            // and calls the execute method to invoke whatever
            // method is behind the command
            SaveListCommand = new Command(SaveList);
            DeleteFromListCommand =
                new Command<ShowsViewModel>(DeleteFromList);
        }

        public MainPageViewModel()
        {

        }

        public void SaveList()
        {
            ShowsViewModel.SaveShowListData(showsList);
        }

        public void ReadList()
        {
            ShowsList = ShowsViewModel.ReadShowListData();
        }


        public void DeleteFromList(ShowsViewModel s)
        {
            ShowsList.Remove(s);
            SelectedShow = null;
        }

        public async Task SelectOneShowAsync(Shows s)
        {
            /*
             * d is the selected dog that I want to pass to the Details page
             * Use an interface to set this up - contract for methods that will be implemented somewhere named as IPageService - decouple from the View
             */
            if (showsList == null) return;

            await _pageService.PushAsync(new ShowDetailPage(s));
        }

        internal void DeleteFromList(Shows show)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
