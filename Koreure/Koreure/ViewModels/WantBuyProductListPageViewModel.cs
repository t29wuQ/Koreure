using System;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Commands;
using System.Windows.Input;
using Koreure.Data;
using Koreure.Api;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace Koreure.ViewModels
{
    public class WantBuyProductListPageViewModel : BindableBase, INavigationAware
    {
        public ICommand PostCommand { get; }
        public Command<Product> ProductInfoCommand { get; }

        ObservableCollection<Product> _productList;
        public ObservableCollection<Product> ProductList{ get { return _productList; } set { SetProperty(ref _productList, value); }}

        public WantBuyProductListPageViewModel(INavigationService navigationService)
        {
            PostCommand = new DelegateCommand(() =>
            {
                navigationService.NavigateAsync("WantBuyPage");
            });
            ProductInfoCommand = new Command<Product>(x =>
            {
                var navigationParameters = new NavigationParameters();
                navigationParameters.Add("id", x.ID);
                navigationService.NavigateAsync("DetailProductPage", navigationParameters);
            });
            var productsApi = new ProductsApi();
            productsApi.GetRequest("");
            ProductList = productsApi.ProductList;
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {

        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            var productsApi = new ProductsApi(); 
            productsApi.GetRequest("");
            ProductList = productsApi.ProductList;
        }

        public void OnNavigatingTo(NavigationParameters parameters)
        {

        }
    }
}
