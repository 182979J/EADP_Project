using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using ItsTheEADPProjectMannnn.BLL;

namespace ItsTheEADPProjectMannnn.DAL
{
    public class N_SitesDAO
    {
        public List<TouristSites> SelectAll()
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            string sqlStmt = "Select * from TouristSItes";
            SqlDataAdapter da = new SqlDataAdapter(sqlStmt, myConn);

            DataSet ds = new DataSet();

            da.Fill(ds);

            List<TouristSites> siteList = new List<TouristSites>();
            int rec_cnt = ds.Tables[0].Rows.Count;
            for (int i=0; i<rec_cnt; i++)
            {
                DataRow row = ds.Tables[0].Rows[i];
                string nameItem = row["itemname"].ToString();
                string priceStr = row["sitePrice"].ToString();
                double price = Convert.ToDouble(priceStr);
                string desc = row["description"].ToString();
                int qty = Convert.ToInt32(row["quantity"]);
                string type = row["ticketType"].ToString();
                //string url = row["picture"].ToString();
                string preview = row["view"].ToString();
                TouristSites obj = new TouristSites(nameItem, price, desc, qty, type,preview);
                siteList.Add(obj);

            }
            return siteList;

        }
        public byte[] SelectPic(string ItemName)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            string sqlStmt = "Select photo from TouristSites where ItemName = @paraitemName";
            SqlDataAdapter da = new SqlDataAdapter(sqlStmt, myConn);
            da.SelectCommand.Parameters.AddWithValue("@paraitemName", ItemName);

            DataSet ds = new DataSet();

            da.Fill(ds);

            int rec_cnt = ds.Tables[0].Rows.Count;
            byte[] photo = null;

            for (int i = 0; i < rec_cnt; i++)
            {
                DataRow row = ds.Tables[0].Rows[i];  // Sql command returns only one record
                if (row["photo"] != DBNull.Value)
                    photo = (byte[])(row["photo"]);
            }

            return photo;
        }
        public int Insert(TouristSites site, params object[] sitepic)
        {
            int result = 0;
            SqlCommand sqlCmd = new SqlCommand();

            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);
            string sqlSmt;

            if (sitepic.Length == 1)
            {
                sqlSmt = "INSERT INTO TouristSites ([ItemName], [Price], [Desc], [QuantityTickets], [TicketType], [posterURL], [Preview])" +
                "VALUES (@paraitemName,@paraprice, @paradesc, @paraquantity, @paraticketType, @paraPhoto, @parapreview)";
            }
            else
            {
              sqlSmt = "INSERT INTO TouristSites ([ItemName], [Price], [Desc], [QuantityTickets], [TicketType], [Preview])" +
                "VALUES (@paraitemName,@paraprice, @paradesc, @paraquantity, @paraticketType, @parapreview)";
            }
            sqlCmd = new SqlCommand(sqlSmt, myConn);

            sqlCmd.Parameters.AddWithValue("@paraitemName", site.itemName);
            sqlCmd.Parameters.AddWithValue("@paraprice", site.price);
            sqlCmd.Parameters.AddWithValue("@paradesc", site.desc);
            sqlCmd.Parameters.AddWithValue("@paraquantity", site.quantity);
            sqlCmd.Parameters.AddWithValue("@paraticketType", site.ticketType);
            //sqlCmd.Parameters.AddWithValue("@paraPoster", "images/" + site.picture);
            sqlCmd.Parameters.AddWithValue("@parapreview", site.view);
            if(sitepic.Length ==1)
            {
                sqlCmd.Parameters.AddWithValue("@paraPhoto", sitepic[0]);
            }

            myConn.Open();
            result = sqlCmd.ExecuteNonQuery();

            myConn.Close();

            return result;
        }
        public TouristSites SelectById(string ItemName)
        {
            //Step 1 -  Define a connection to the database by getting
            //          the connection string from web.config
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            //Step 2 -  Create a DataAdapter to retrieve data from the database table
            string sqlStmt = "Select * from TouristSites where ItemName = @paraitemName";
            SqlDataAdapter da = new SqlDataAdapter(sqlStmt, myConn);

            da.SelectCommand.Parameters.AddWithValue("@paraitemName", ItemName);

            //Step 3 -  Create a DataSet to store the data to be retrieved
            DataSet ds = new DataSet();

            //Step 4 -  Use the DataAdapter to fill the DataSet with data retrieved
            da.Fill(ds);

            //Step 5 -  Read data from DataSet.
            TouristSites site = null;
            int rec_cnt = ds.Tables[0].Rows.Count;
            if (rec_cnt == 1)
            {
                DataRow row = ds.Tables[0].Rows[0];
                string nameItem = row["itemname"].ToString();
                string priceStr = row["sitePrice"].ToString();
                double price = Convert.ToDouble(priceStr);
                string preview = row["preview"].ToString();
                //string url = row["picture"].ToString();
                string desc = row["description"].ToString();
                int qty = Convert.ToInt32(row["quantity"]);
                string type = row["ticketType"].ToString();
                
                TouristSites obj = new TouristSites(nameItem, price, desc, qty, type, preview);
            }
            else
            {
                site = null;
            }

            return site;
        }
    }
}