using System;
using System.Threading.Tasks;
using Koreure.Data;
using Newtonsoft.Json.Linq;

namespace Koreure.Api
{
    public class UserApi : Api
    {
        public UserApi()
        {
            url += "user/";
        }


        protected override DataBase ParseJson(JObject jObject)
        {
            int userID = int.Parse(((jObject["userId"] as JValue).Value).ToString());
            string userName = (string)((jObject["username"] as JValue).Value);
            string intro = (string)((jObject["intro"] as JValue).Value);
            return new User() { ID = userID, UserName = userName, Intro = intro };
        }

    }
}
