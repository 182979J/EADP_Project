using MyProject.BLL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Collections;


namespace MyProject.DAL
{
    public class JE_TourGuideInfoDAO
    {
        public int Insert(JE_TourGuideInfo TG)
        {
            // Execute NonQuery return an integer value
            int result = 0;
            SqlCommand sqlCmd = new SqlCommand();

            //Step 1 -  Define a connection to the database by getting
            //          the connection string from web.config
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            // Step 2 - Instantiate SqlCommand instance to add record 
            //          with INSERT statement
            string sqlStmt = "INSERT INTO JE_TDTGInfo ([TGId],[TGName],[TGFirstName],[TGLastName], [TGMobile],[TGEmail]) " +
                "VALUES (@paraTGId,@paraTGName,@paraTGFirstName,@paraTGLastName, @paraTGMobile, @paraTGEmail)";
            sqlCmd = new SqlCommand(sqlStmt, myConn);

            // Step 3 : Add each parameterised variable with value
            sqlCmd.Parameters.AddWithValue("@paraTGId", TG.TGId);
            sqlCmd.Parameters.AddWithValue("@paraTGName", TG.TGName);
            sqlCmd.Parameters.AddWithValue("@paraTGFirstName", TG.TGFirstName);
            sqlCmd.Parameters.AddWithValue("@paraTGLastName", TG.TGLastName);
            sqlCmd.Parameters.AddWithValue("@paraTGMobile", TG.TGMobile);
            sqlCmd.Parameters.AddWithValue("@paraTGEmail", TG.TGEmail);

            // Step 4 Open connection the execute NonQuery of sql command   
            myConn.Open();
            result = sqlCmd.ExecuteNonQuery();

            // Step 5 :Close connection
            myConn.Close();

            return result;
        }


        public int UpdateProfile(JE_TourGuideInfo TG)
        {
            int result = 0;
            SqlCommand sqlCmd = new SqlCommand();

            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            // Step 2 - Instantiate SqlCommand instance to add record 
            //          with INSERT statement
            string sqlStmt = "UPDATE JE_TDTGInfo SET Type_of_bank=@paraType_of_bank ,Bank_num=@paraBank_num,TGProfilePic = @paraTGProfilePic,WorkHowLong=@paraWorkHowLong ,introinprofile=@paraIntroInProfile where TGEmail=@paraTGEmail";
            //TGProfilePic = @paraTGProfilePic

            sqlCmd = new SqlCommand(sqlStmt, myConn);

            // Step 3 : Add each parameterised variable with value
            sqlCmd.Parameters.AddWithValue("@paraTGEmail", TG.TGEmail);
            if (TG.TGProfilePic.Trim().StartsWith("image/"))
            {
               sqlCmd.Parameters.AddWithValue("@paraTGProfilePic", TG.TGProfilePic); 
            }
           else
            {
                
                sqlCmd.Parameters.AddWithValue("@paraTGProfilePic", "image/" + TG.TGEmail + "/" + TG.TGProfilePic);
            }


            sqlCmd.Parameters.AddWithValue("@paraType_of_bank", TG.Type_of_bank);
            sqlCmd.Parameters.AddWithValue("@paraBank_num", TG.Bank_num);
            sqlCmd.Parameters.AddWithValue("@paraWorkHowLong", TG.WorkHowLong);
            sqlCmd.Parameters.AddWithValue("@paraIntroInProfile", TG.IntroInProfile);
            // Step 4 Open connection the execute NonQuery of sql command   
            myConn.Open();
            result = sqlCmd.ExecuteNonQuery();

            // Step 5 :Close connection
            myConn.Close();

            return result;
        }




        public int AddForm(JE_TourGuideInfo TG)
        {
            int result = 0;
            SqlCommand sqlCmd = new SqlCommand();

            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);
            string sqlStmt = "UPDATE JE_TDTGInfo SET Type_of_bank=@paraType_of_bank ,Bank_num=@paraBank_num,TGProfilePic = @paraTGProfilePic,NRIC_front = @paraNRIC_front,NRIC_back = @paraNRIC_back ,LicenseYN=@paraLicenseYN,License_front = @paraLicense_front ,License_back = @paraLicense_back, ACRA1= @paraACRA1,ACRA2 = @paraACRA2,ACRA3 = @paraACRA3,Expertise=@paraExpertise,WorkHowLong=@paraWorkHowLong ,IntroInProfile=@paraIntroInProfile where TGEmail=@paraTGEmail";
            //TGProfilePic = @paraTGProfilePic
            
            sqlCmd = new SqlCommand(sqlStmt, myConn);

            // Step 3 : Add each parameterised variable with value
            sqlCmd.Parameters.AddWithValue("@paraTGEmail", TG.TGEmail);
            sqlCmd.Parameters.AddWithValue("@paraTGProfilePic", "image/"+ TG.TGEmail +"/"+ TG.TGProfilePic);
            if (TG.Nric_front==null) {

                sqlCmd.Parameters.AddWithValue("@paraNRIC_front","" );
            }
            else
            {
                sqlCmd.Parameters.AddWithValue("@paraNRIC_front", "image/" + TG.TGEmail + "/" + TG.Nric_front);
              
            }

            
            if (TG.Nric_back == null)
            {
                sqlCmd.Parameters.AddWithValue("@paraNRIC_back", "");
            }
            else
            {
                sqlCmd.Parameters.AddWithValue("@paraNRIC_back", "image/" + TG.TGEmail + "/" + TG.Nric_back);
            }
                
            
            if (TG.License_front == null)
            {
                sqlCmd.Parameters.AddWithValue("@paraLicense_front", "");
            }
            else
            {
                sqlCmd.Parameters.AddWithValue("@paraLicense_front", "image/" + TG.TGEmail + "/" + TG.License_front);
            }
            
            if (TG.License_back == null)
            {
                sqlCmd.Parameters.AddWithValue("@paraLicense_back", "");
            }
            else {
                sqlCmd.Parameters.AddWithValue("@paraLicense_back", "image/" + TG.TGEmail + "/" + TG.License_back);
            }
            
            if (TG.ACRA1 == null)
            {
                sqlCmd.Parameters.AddWithValue("@paraACRA1", "");
            }
            else
            {
                sqlCmd.Parameters.AddWithValue("@paraACRA1", "image/" + TG.TGEmail + "/" + TG.ACRA1);
            }

            
            if (TG.ACRA2 == null)
            {
                sqlCmd.Parameters.AddWithValue("@paraACRA2", "");
            }
            else
            {
                sqlCmd.Parameters.AddWithValue("@paraACRA2", "image/" + TG.TGEmail + "/" + TG.ACRA2);
            }
            if (TG.ACRA3 == null)
            {
                sqlCmd.Parameters.AddWithValue("@paraACRA3", "");
            }
            else
            {
                sqlCmd.Parameters.AddWithValue("@paraACRA3", "image/" + TG.TGEmail + "/" + TG.ACRA3);
            }

            sqlCmd.Parameters.AddWithValue("@paraLicenseYN", TG.LicenseYN);
            sqlCmd.Parameters.AddWithValue("@paraType_of_bank", TG.Type_of_bank);
            sqlCmd.Parameters.AddWithValue("@paraBank_num", TG.Bank_num);
            sqlCmd.Parameters.AddWithValue("@paraExpertise", TG.Expertise);
            sqlCmd.Parameters.AddWithValue("@paraWorkHowLong", TG.WorkHowLong);
            sqlCmd.Parameters.AddWithValue("@paraIntroInProfile", TG.IntroInProfile);
            // Step 4 Open connection the execute NonQuery of sql command   
            myConn.Open();
            result = sqlCmd.ExecuteNonQuery();

            // Step 5 :Close connection
            myConn.Close();

            return result;
        }


        //public int InsertForm(JE_TourGuideInfoForm TG)
        //{
        //    // Execute NonQuery return an integer value
        //    int result = 0;
        //    SqlCommand sqlCmd = new SqlCommand();

        //    //Step 1 -  Define a connection to the database by getting
        //    //          the connection string from web.config
        //    string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
        //    SqlConnection myConn = new SqlConnection(DBConnect);

        //    // Step 2 - Instantiate SqlCommand instance to add record 
        //    //          with INSERT statement


        //    byte[] bytes;
        //    using (BinaryReader br = new BinaryReader(TG.TGProfilePic.PostedFile.InputStream))
        //    {
        //        bytes = br.ReadBytes(TG.TGProfilePic.PostedFile.ContentLength);
        //    }


        //    string sqlStmt = "UPDATE JE_TDTGInfo SET TGProfilePic=@paraTGProfilePic,Bank_num=@paraAccountNum where TGEmail=@paraTGEmail";

        //    sqlCmd = new SqlCommand(sqlStmt, myConn);

        //    // Step 3 : Add each parameterised variable with value
        //    sqlCmd.Parameters.AddWithValue("@paraTGEmail", TG.TGEmail);
        //    sqlCmd.Parameters.AddWithValue("@paraTGProfilePic", bytes);
        //    sqlCmd.Parameters.AddWithValue("@paraAccountNum", TG.Bank_num);

        //    // Step 4 Open connection the execute NonQuery of sql command   
        //    myConn.Open();
        //    result = sqlCmd.ExecuteNonQuery();

        //    // Step 5 :Close connection
        //    myConn.Close();

        //    return result;
        //}


        //protected void Upload(object sender, EventArgs e)
        //{
        //    byte[] bytes;
        //    using (BinaryReader br = new BinaryReader(imgProfile.PostedFile.InputStream))
        //    {
        //        bytes = br.ReadBytes(FileUpload1.PostedFile.ContentLength);
        //    }
        //    string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        //    using (SqlConnection conn = new SqlConnection(constr))
        //    {
        //        string sql = "INSERT INTO tblFiles VALUES(@Name, @ContentType, @Data)";
        //        using (SqlCommand cmd = new SqlCommand(sql, conn))
        //        {
        //            cmd.Parameters.AddWithValue("@Name", Path.GetFileName(FileUpload1.PostedFile.FileName));
        //            cmd.Parameters.AddWithValue("@ContentType", FileUpload1.PostedFile.ContentType);
        //            cmd.Parameters.AddWithValue("@Data", bytes);
        //            conn.Open();
        //            cmd.ExecuteNonQuery();
        //            conn.Close();
        //        }
        //    }

        //    Response.Redirect(Request.Url.AbsoluteUri);
        //}




        public JE_TourGuideInfo SelectByEmail(string emaill)
        {
            //Step 1 -  Define a connection to the database by getting
            //          the connection string from web.config
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            //Step 2 -  Create a DataAdapter to retrieve data from the database table
            string sqlStmt = "Select * from JE_TDTGInfo where TGEmail = @paraEmail";
            SqlDataAdapter da = new SqlDataAdapter(sqlStmt, myConn);

            da.SelectCommand.Parameters.AddWithValue("@paraEmail", emaill);

            //Step 3 -  Create a DataSet to store the data to be retrieved
            DataSet ds = new DataSet();

            //Step 4 -  Use the DataAdapter to fill the DataSet with data retrieved
            da.Fill(ds);

            //Step 5 -  Read data from DataSet.
            JE_TourGuideInfo TG = null;
            int rec_cnt = ds.Tables[0].Rows.Count;
            if (rec_cnt == 1)
            {
                DataRow row = ds.Tables[0].Rows[0];  // Sql command returns only one record
                string id= row["TGId"].ToString();
                string name = row["TGName"].ToString();
                string first = row["TGFirstName"].ToString();
                string last = row["TGLastName"].ToString();
                string email = row["TGEmail"].ToString();
                string  mobile= row["TGMobile"].ToString();
                string profilepic = row["TGProfilePic"].ToString();
                string nricfront = row["NRIC_front"].ToString();
                string nricback = row["NRIC_back"].ToString();
                string licenseyn = row["LicenseYN"].ToString();
                string licensefront = row["License_front"].ToString();
                string licenseback = row["License_back"].ToString();
                string ACRA1 = row["ACRA1"].ToString();
                string ACRA2 = row["ACRA2"].ToString();
                string ACRA3 = row["ACRA3"].ToString();
                string type_of_bank = row["Type_of_bank"].ToString();
                string bank_num = row["Bank_num"].ToString();
                string expertise = row["Expertise"].ToString();
                string workhowlong = row["WorkHowLong"].ToString();
                string introinprofile = row["IntroInProfile"].ToString();
                TG = new JE_TourGuideInfo(id,name, first, last,email,mobile,profilepic,nricfront,nricback,licenseyn,licensefront,licensefront,ACRA1,ACRA2,ACRA3,type_of_bank,bank_num,expertise,workhowlong,introinprofile);
            }
            else
            {
                TG = null;
            }

            return TG;
        }


    }
}