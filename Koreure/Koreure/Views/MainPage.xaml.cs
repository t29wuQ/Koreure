using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Net;
using System.IO;
using Newtonsoft.Json.Linq;

namespace Koreure.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        async void Handle_Clicked(object sender, System.EventArgs e)
        {
            Re.Text = await ResponseAsync();
        }

        public async Task<string> ResponseAsync()
        {
            /*string url = "https://reversemercari.mosin.jp/product/1";
            //返ってきたデータを保存する変数
            string result;
            var httpWebReq = (HttpWebRequest)WebRequest.Create(url);
            httpWebReq.Method = "GET";

            //レスポンスを受け取る
            using (var response = await httpWebReq.GetResponseAsync())
            {
                using (var resStream = response.GetResponseStream())
                {
                    using (var sr = new StreamReader(resStream))
                    {
                        JObject jObject = JObject.Parse(sr.ReadToEnd());
                        var list = jObject["tags"].Cast<JValue>().ToArray();
                        result = list[0].Value.ToString();
                    }
                }
            }*/
            /*var api = new Api.ProductsApi();
            Data.Product product = (Data.Product)(await api.GetRequest("");*/
            Api.ProductApi p = new Api.ProductApi();
            //await p.GetRequest("");
            await p.PostRequest("create", new Data.Product() { Title = "くるっぱ", Description = "頭くるくるぱー", Price = "1" });
            /*var l = p.ProductList;
            foreach (var pr in l)
                System.Diagnostics.Debug.WriteLine(pr.Description);*/
            return "ee";
        }

    }
}