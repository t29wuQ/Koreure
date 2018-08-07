using System;
namespace Koreure.Data
{
    public class User : DataBase
    {
        public int ID { get; set; }
        public string UserName { get; set; }
        public string Intro { get; set; }
    }
}
