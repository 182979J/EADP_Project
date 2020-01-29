using MyProject.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyProject
{
    public partial class JE_TGProfile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {    Session["SSTGEmail"]= "105@gmail.com";
             //JE_TourGuideInfo TG = new JE_TourGuideInfo();
             JE_TourGuideInfo TG = new JE_TourGuideInfo();
            //TG.GetTGByEmail(Session["SSTGEmail"].ToString());
            var name = TG.GetTGByEmail(Session["SSTGEmail"].ToString()).TGName;
            var intro = TG.GetTGByEmail(Session["SSTGEmail"].ToString()).IntroInProfile;
            var profilepic = TG.GetTGByEmail(Session["SSTGEmail"].ToString()).TGProfilePic;
            var nricfront = TG.GetTGByEmail(Session["SSTGEmail"].ToString()).Nric_front;
            var nricback = TG.GetTGByEmail(Session["SSTGEmail"].ToString()).Nric_back;
            ProfilePageTGName.InnerText = name;
            ProfilePageTGIntro.InnerText =intro;
            ProfilePicDisplay.Src = profilepic;
            if (nricfront != "")
            {
                profilenricfront.Src = nricfront;
                profilenricback.Src = nricback;
            }

            //ProfilePageTGName.InnerText = (string)Session["SSTGName"];
            //ProfilePicDisplay.Src = (string)Session[""];
            //ProfilePageTGIntro.InnerText = (string)Session["SSTGIntro"];

        }

        //public void GetInformation()
        //{
        //    OleDbCommand cmd = new OleDbCommand();
        //    cmd.Connection = connection;
        //    cmd.CommandText = "SELECT * FROM tblUsers WHERE voter_name = '" + Request.QueryString["VotersID"].ToString() + "'";
        //    OleDbDataReader reader = cmd.ExecuteReader();
        //    if (reader.Read())
        //    {
        //        lblVoterName.Text = reader["usr_FirstN"].ToString() + " " + reader["usr_LastN"].ToString();
        //    }
        //}
        protected void btnEdit_Click(object sender, EventArgs e)
        {
           
            Response.Redirect("JE_TGProfileUpdate.aspx");
        }
    }
}