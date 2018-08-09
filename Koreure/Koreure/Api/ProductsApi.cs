using System;
using Koreure.Data;
using Newtonsoft.Json.Linq;
using System.Collections.ObjectModel;
using System.Linq;

namespace Koreure.Api
{
    public class ProductsApi : Api
    {
        public ObservableCollection<Product> ProductList { get; set; }

        public ProductsApi()
        {
            url += "products/";
            ProductList = new ObservableCollection<Product>();
        }

        protected override DataBase ParseJson(JObject jObject)
        {
            var productList = jObject["products"].ToArray();
            foreach(var product in productList)
            {
                ProductList.Add(new Product()
                {
                    ID = int.Parse(product["productId"].ToString()),
                    Title = product["title"].ToString(),
                    Description = product["description"].ToString(),
                    Price = product["price"].ToString() + "円"
                });
                System.Diagnostics.Debug.WriteLine(product["title"]);
            }
            return null;

        }

    }
}
