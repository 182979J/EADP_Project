using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ItsTheEADPProjectMannnn.BLL;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;


namespace ItsTheEADPProjectMannnn.DAL
{
    public class N_FoodDAO
    {
        //public List<Food> SelectAll()
        //{
        //    string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
        //    SqlConnection myConn = new SqlConnection(DBConnect);

        //    string sqlStmt = "Select * from Employee";
        //    SqlDataAdapter da = new SqlDataAdapter(sqlStmt, myConn);

        //    DataSet ds = new DataSet();

        //    da.Fill(ds);

        //    List<Food> foodList = new List<Food>();
        //    int rec_cnt = ds.Tables[0].Rows.Count;
        //    for(int i=0;i<rec_cnt;i++)
        //    {
        //        DataRow row = ds.Tables[0].Rows[i];
        //        string fName = row["foodName"].ToString();
        //        string fPriceStr = row["foodPrice"].ToString();
        //        double fPrice = Convert.ToDouble(fPriceStr);
        //        string fDesc = row["foodDesc"].ToString();
        //        string locate = row["locations"].ToString();
        //        Food obj = new Food(fName, fPrice, fDesc, locate);
        //    }
        //    return foodList;
        //}
    }
}