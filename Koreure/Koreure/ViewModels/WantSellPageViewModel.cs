using System;
using System.Windows.Input;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Commands;

namespace Koreure.ViewModels
{
    public class WantSellPageViewModel : BindableBase, INavigationAware
    {
        public ICommand PostCommand { get; }

        string _productName;
        public string ProductName { get { return _productName; } set { SetProperty(ref _productName, value); } }
        string _productPrice;
        public string ProductPrice { get { return _productPrice; } set { SetProperty(ref _productPrice, value); } }
        string _productInfo;
        public string ProductInfo { get { return _productInfo; } set { SetProperty(ref _productInfo, value); } }


        public WantSellPageViewModel()
        {
            PostCommand = new DelegateCommand(() =>
            {

            });
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {

        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {

        }

        public void OnNavigatingTo(NavigationParameters parameters)
        {

        }
    }
}
