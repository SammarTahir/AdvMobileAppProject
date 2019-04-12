using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Project.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AddShowPage : ContentPage
	{
		public AddShowPage ()
		{
			InitializeComponent ();
		}

        private void btnSaveFile_Clicked(object sender, EventArgs e)
        {
            var initialJson = File.ReadAllText(@"C:\Users\samma\Documents\Visual Studio 2017\Project\Project\Project\Data\myShows.txt");

            var array = JArray.Parse(initialJson);

            var itemToAdd = new JObject();
            itemToAdd["Title"] = "new show";
            itemToAdd["Ranking"] = "carl2";
            array.Add(itemToAdd);

            var jsonToOutput = JsonConvert.SerializeObject(array, Formatting.Indented);
        }
    }
}