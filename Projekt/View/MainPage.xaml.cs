using Newtonsoft.Json;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using Xamarin.Forms;

namespace Projekt
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {

        UserObjectBasic userObjectBasic;
        public MainPage()
        {
            InitializeComponent();
            GetBasicJSON();
        }

        public async void GetBasicJSON()
        {
            if (NetworkCheck.IsInternet())
            {
                var client = new HttpClient();
                var response = await client.GetAsync("https://internshiptaskuserslist.azurewebsites.net/api/users?code=gbgu4CbgdAlsS0xIVaNkckK4vTd0qIFNxaQYzIHLaqyomquJwuy/ig==");
                string dataJson = response.Content.ReadAsStringAsync().Result;
                userObjectBasic = new UserObjectBasic();
                if (dataJson != "")
                {
                    //Converting JSON Array Objects into generic list
                    userObjectBasic = JsonConvert.DeserializeObject<UserObjectBasic>(dataJson);
                }
                //Binding listview with server response  
                ListOfUsers.ItemsSource = userObjectBasic.Data;
            }
            else
            {
                LabelThree.Text = "No Internet Connection! ";
            }
        }

        private void search_one_TextChanged(object sender, TextChangedEventArgs e)
        {
            
            ListOfUsers.BeginRefresh();

            if (string.IsNullOrWhiteSpace(e.NewTextValue))
                ListOfUsers.ItemsSource = userObjectBasic.Data;
            else
                ListOfUsers.ItemsSource = userObjectBasic.Data.Where(i => i.FirstName.Contains(e.NewTextValue));

            ListOfUsers.EndRefresh();

        }
        
        private void search_two_TextChanged(object sender, TextChangedEventArgs e)
        {
            
            ListOfUsers.BeginRefresh();

            if (string.IsNullOrWhiteSpace(e.NewTextValue))
                ListOfUsers.ItemsSource = userObjectBasic.Data;
            else
                ListOfUsers.ItemsSource = userObjectBasic.Data.Where(i => i.LastName.Contains(e.NewTextValue));

            ListOfUsers.EndRefresh();
            
        }

        async private void ListOfUsers_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var itemSelectedData = e.Item as UserDataBasic;
            int id = itemSelectedData.Id;
            await Navigation.PushAsync(new DetailPage(id));
        }
        
    }
}