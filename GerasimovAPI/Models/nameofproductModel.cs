using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GerasimovAPI.Models
{
    public class nameofproductModel
    {

        public nameofproductModel(nameofproduct nameofproduct)
        {

            id = nameofproduct.id;
            name = nameofproduct.name;
            price = (float)nameofproduct.price;
            weight = nameofproduct.weight;
            nameProiz = nameofproduct.nameProiz;
            countryProiz = nameofproduct.countryProiz;
            picture = nameofproduct.picture;

        }
        public int id { get; set; }
        public string name { get; set; }
        public float price { get; set; }
        public string weight { get; set; }
        public string nameProiz { get; set; }
        public string countryProiz { get; set; }
        public byte[] picture { get; set; }



    }

}