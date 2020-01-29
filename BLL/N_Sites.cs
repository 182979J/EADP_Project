using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ItsTheEADPProjectMannnn.DAL;

namespace ItsTheEADPProjectMannnn.BLL
{
    public class TouristSites
    {
        public string itemName { get; set; }
        public double price { get; set; }
        public string desc { get; set; }
        public int quantity { get; set; }
        public string ticketType { get; set; }
        //public string picture { get; set; }
        public string view { get; set; }


        public TouristSites()
        {

        }

        public TouristSites(string nameItem, double Price, string description, int qty, string type, string preview)
        {
            itemName = nameItem;
            price = Price;
            desc = description;
            quantity = qty;
            ticketType = type;
            //picture = url;
            view = preview;
        }
        public List<TouristSites> GetAllSites()
        {
            N_SitesDAO dao = new N_SitesDAO();
            return dao.SelectAll();
        }
        public int AddSites(params object[] sitepic)
        {
            N_SitesDAO dao = new N_SitesDAO();
            return( dao.Insert(this));
            
        }

        public byte[] GetSitePicture(string ItemName)
        {
            N_SitesDAO dao = new N_SitesDAO();
            return dao.SelectPic(ItemName);
        }

        

    }
    
}