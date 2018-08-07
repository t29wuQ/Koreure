using System;
using System.Net;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Koreure.Data;

namespace Koreure.Api
{
    public abstract class Api
    {
        protected string url = "https://reversemercari.mosin.jp/";

        public async Task<DataBase> GetRequest(int id)
        {
            var request = (HttpWebRequest)WebRequest.Create(url + id);
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

        protected abstract DataBase ParseJson(JObject jObject);
    }
}
