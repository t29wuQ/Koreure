using System;
using System.Text;
using System.Net;
using System.Net.Http;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Koreure.Data;

namespace Koreure.Api
{
    public abstract class Api
    {
        protected string url = "https://reversemercari.mosin.jp/";

        public async Task<DataBase> GetRequest(string param)
        {
            var request = (HttpWebRequest)WebRequest.Create(url + param);
            request.Method = "GET";

            using (var response = await request.GetResponseAsync())
            {
                using (var resStream = response.GetResponseStream())
                {
                    using (var sr = new StreamReader(resStream))
                    {
                         return ParseJson(JObject.Parse(sr.ReadToEnd()));
                    }
                }
            }
        }

        public async Task PostRequest(string param, DataBase data)
        {
            var json = JsonConvert.SerializeObject(data);
            using (var client = new HttpClient())
            {
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await client.PostAsync(url + param, content);
                System.Diagnostics.Debug.WriteLine(response.StatusCode);
            }
        }

        protected abstract DataBase ParseJson(JObject jObject);
    }
}
