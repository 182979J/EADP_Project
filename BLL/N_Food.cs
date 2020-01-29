using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ItsTheEADPProjectMannnn.DAL;

namespace ItsTheEADPProjectMannnn.BLL
{
    public class N_Food
    {
        public string Foodname { get; set; }
        public double Foodprice { get; set; }
        public string Fooddesc { get; set; }
        public string Locations { get; set; }

        public N_Food()
        {

        }
        public N_Food(string name, double price, string desc, string locations)
        {
            Foodname = name;
            Foodprice = price;
            Fooddesc = desc;
            Locations = locations;
        }
        //public int AddFood()
        //{
        //    FoodDAO dao = new FoodDAO();
        //    int result = dao.Insert(this);
        //    return result;
        //}
    }
}