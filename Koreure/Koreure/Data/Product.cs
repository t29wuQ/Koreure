using System;
namespace Koreure.Data
{
    public class Product : DataBase
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public string[] Tags { get; set; }
    }
}
