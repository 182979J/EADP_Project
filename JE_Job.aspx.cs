using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Text;

namespace MyProject
{
    public partial class JE_Job : System.Web.UI.Page
    {
        //string strConnection = "Data Source=.; uid=sa; pwd=wintellect;database=Rohatash;";
        protected void Page_Load(object sender, EventArgs e)
        {
            show();
        }
        private void show()
        {
            {
                string DBConnect= ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
                SqlConnection myConn = new SqlConnection(DBConnect);
                string sqlquery = "select * from [dbo].[PurchasedPackage]";
                SqlCommand sqlcomm = new SqlCommand(sqlquery, myConn);
                myConn.Open();
                SqlDataAdapter sda = new SqlDataAdapter(sqlcomm);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                StringBuilder sb = new StringBuilder();
                myConn.Close();
                //sb.Append("<center>");
                //sb.Append("<table border=1>");
                //sb.Append("<tr>");
                //foreach (DataColumn dc in dt.Columns)
                //{
                //    sb.Append("<th>");
                //    sb.Append(dc.ColumnName);
                //    sb.Append("</th>");
                //}
                //sb.Append("</tr>");
                //foreach(DataRow dr in dt.Rows)
                //{
                //    sb.Append("<tr>");
                //    foreach(DataColumn dc in dt.Columns)
                //    {
                //        sb.Append("<th>");
                //        sb.Append(dr[dc.ColumnName].ToString());
                //        sb.Append("</th>");
                //    }
                //    sb.Append("</tr>");
                //}
                //sb.Append("</table>");
                //sb.Append("</center>");
                //Panel1.Controls.Add(new Label { Text = sb.ToString() });

                //SqlConnection con = new SqlConnection("Data Source=.; uid=sa; pwd=wintellect;database=JE_TDTGInfo;");
                //string strSQL = "Select * from [dbo].[PurchasedPackage]";
                //SqlDataAdapter dt = new SqlDataAdapter(strSQL, con);
                //DataSet ds = new DataSet();
                //dt.Fill(ds, "PurchasedPackage");
                //con.Close();
                //GridViewChoose.DataSource = ds;
                //GridViewChoose.DataBind();
            }
        }

        protected void GridViewChoose_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = GridViewChoose.SelectedRow;
            Session["SSPackageId"] = row.Cells[0].Text;
            Session["SSPackageName"] = row.Cells[1].Text;
            Session["SSTripDate"] = row.Cells[2].Text;
            Response.Redirect("JE_JobDetails.aspx");
        }
    }
}