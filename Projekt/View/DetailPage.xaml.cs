using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Projekt
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailPage : ContentPage
    {
        private int id;

        public DetailPage(int id)
        {
            InitializeComponent();
            this.id = id;
            GetExtendedJSON();
        }

        public async void GetExtendedJSON()
        {
            if (NetworkCheck.IsInternet())
            {
                String idString = id.ToString();
                string link = "https://internshiptaskuserslist.azurewebsites.net/api/users/" + idString + "?code=9XuCxWZqJavOAWHPcWD/97mMeJkK0mSVMA9A6MQ9n4R1B/6fpsxGqw==";
                var client = new HttpClient();
                var response = await client.GetAsync(link);
                string dataJson = response.Content.ReadAsStringAsync().Result;
                JObject json = JObject.Parse(dataJson);
                UserObjectExtended userObjectExtended = new UserObjectExtended()
                {
                    IsSuccess = (bool)json["IsSuccess"],
                };

                if (userObjectExtended.IsSuccess == true)
                {
                    userObjectExtended.Data = new UserDataExtended
                    {
                        Id = (int)json["Data"]["Id"],
                        FirstName = (string)json["Data"]["FirstName"],
                        LastName = (string)json["Data"]["LastName"],
                        Age = (int)json["Data"]["Age"],
                        City = (string)json["Data"]["City"]
                    };
                    //Binding grid
                    GridDetails.BindingContext = userObjectExtended.Data;
                }
                else {
                    Test.Text = "JSON Parsing Error";
                }
            }
            else
            {
                Test.Text = "No Internet Connection!";
            }
        }
    }
}