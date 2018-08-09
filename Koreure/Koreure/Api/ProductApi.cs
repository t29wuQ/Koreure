using System;
using System.Threading.Tasks;
using System.Linq;
using Koreure.Data;
using Newtonsoft.Json.Linq;

namespace Koreure.Api
{
    public class ProductApi : Api
    {
        public ProductApi()
        {
            url += "product/";
        }


        protected override DataBase ParseJson(JObject jObject)
        {
            int productID = int.Parse(((jObject["productId"] as JValue).Value).ToString());
            string title = (string)((jObject["title"] as JValue).Value);
            string description = (string)((jObject["description"] as JValue).Value);
            string price = (jObject["price"] as JValue).Value.ToString() + "円";
            var tagsValues = jObject["tags"].Cast<JValue>().ToArray();
            string[] tags = new string[tagsValues.Length];
            for (int i = 0; i < tags.Length; i++)
                tags[i] = tagsValues[i].Value.ToString();
            return new Product()
            {
                ID = productID,
                Title = title,
                Description = description,
                Price = price,
                Tags = tags
            };
        }


        public void PostProductInformation(string title, string description, int price)
        {
            
        }

    }
}
