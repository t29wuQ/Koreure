using System;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Commands;
using System.Windows.Input;
using System.Threading.Tasks;
using Koreure.Api;
using Koreure.Data;

namespace Koreure.ViewModels
{
    public class DetailProductPageViewModel : BindableBase, INavigationAware
    {
        string _title;
        public string Title{ get { return _title; } set { SetProperty(ref _title, value); }}
        string _description;
        public string Description{ get { return _description; } set { SetProperty(ref _description, value); }}
        string _price;
        public string Price{ get { return _price; } set { SetProperty(ref _price, value); }}

        string productID;

        public DetailProductPageViewModel()
        {
            
        }

        async Task GetProduct()
        {
            DataBase data = await new ProductApi().GetRequest(productID);
            Product product = (Product)data;
            Title = product.Title;
            Description = product.Description;
            Price = "希望額" + product.Price;
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {
        }

        public async void OnNavigatedTo(NavigationParameters parameters)
        {
            productID = parameters["id"].ToString();
            await GetProduct();
        }

        public void OnNavigatingTo(NavigationParameters parameters)
        {

        }
    }
}
