using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Reflection;
using System.Text;

namespace Project
{
    class ShowsViewModel : BaseViewModel
    {
        // grab everything from shows.cs
        //// required event handler to implement the interface
        //public event PropertyChangedEventHandler PropertyChanged;
        #region == Private Fields ==
        private string _id;
        private string _rank;
        #endregion

        #region == Public Properties ==
        public string Title { get; set; }
        public string ID
        {
            get { return _id; }
            set { SetValue(ref _id, value); }
            
        }
        public string Rank
        {
            get { return _rank; }
            set { SetValue(ref _rank, value); }
          
        }

        #endregion

        #region == constructors ==
        public ShowsViewModel()
        {
        }

        public ShowsViewModel(string t, string r, string i)
        {
            Title = t;
            Rank = r;
            ID = i;
        }

        #endregion

        #region  == Public Methods ==
        public static ObservableCollection<ShowsViewModel> ReadShowListData()
        {
            ObservableCollection<ShowsViewModel> myList = new ObservableCollection<ShowsViewModel>();
            string jsonText;

            try  // reading the localApplicationFolder first
            {
                string path = Environment.GetFolderPath(
                                Environment.SpecialFolder.LocalApplicationData);
                string filename = Path.Combine(path, Utils.JSON_SHOWS_FILE);
                using (var reader = new StreamReader(filename))
                {
                    jsonText = reader.ReadToEnd();
                    // need json library
                }
            }
            catch // fallback is to read the default file
            {
                var assembly = IntrospectionExtensions.GetTypeInfo(typeof(MainPage)).Assembly;
                // create the stream
                Stream stream = assembly.GetManifestResourceStream(
                    "Project.Data.myShows.txt");

                using (var reader = new StreamReader(stream))
                {
                    jsonText = reader.ReadToEnd();
                    // include JSON library now
                }
            }

            myList = JsonConvert.DeserializeObject<ObservableCollection<ShowsViewModel>>(jsonText);

            return myList;
        } // End of ReadShowsListData()

        // Save new information about shows
        public static void SaveShowListData(ObservableCollection<ShowsViewModel> saveList)
        {
            // need the path to the file
            string path = Environment.GetFolderPath(
                Environment.SpecialFolder.LocalApplicationData);
            string filename = Path.Combine(path, Utils.JSON_SHOWS_FILE);
            // use a stream writer to write the list
            using (var writer = new StreamWriter(filename, false))
            {
                // stringify equivalent
                string jsonText = JsonConvert.SerializeObject(saveList);
                writer.WriteLine(jsonText);
            }
        }
        #endregion


    }
}
