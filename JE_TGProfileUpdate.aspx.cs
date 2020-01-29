using MyProject.BLL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyProject
{
    public partial class JE_TGProfileUpdate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["SSTGEmail"] = "105@gmail.com";
                JE_TourGuideInfo TG = new JE_TourGuideInfo();
                var name = TG.GetTGByEmail(Session["SSTGEmail"].ToString()).TGName;
                var intro = TG.GetTGByEmail(Session["SSTGEmail"].ToString()).IntroInProfile;
                var profilepic = TG.GetTGByEmail(Session["SSTGEmail"].ToString()).TGProfilePic;
                var nricfront = TG.GetTGByEmail(Session["SSTGEmail"].ToString()).Nric_front;
                var nricback = TG.GetTGByEmail(Session["SSTGEmail"].ToString()).Nric_back;
                var type = TG.GetTGByEmail(Session["SSTGEmail"].ToString()).Type_of_bank;
                var acc = TG.GetTGByEmail(Session["SSTGEmail"].ToString()).Bank_num;
                var work = TG.GetTGByEmail(Session["SSTGEmail"].ToString()).WorkHowLong;
                updateprofilepic.Src = profilepic;
                tbIntroUpdateTG.Text = intro;
                UpdateddlTypeBank.SelectedItem.Text = type;
                tbUpdateAccNum.Text = acc;
                tbWorkhowlong.Text = work;
            }
        }


        private bool ValidateInput()
        {
            int accnum;
            bool result;
            lbMsg.Text = String.Empty;

            if (Updatepic.HasFile == false)
            {
                
            }
          

            if (String.IsNullOrEmpty(tbUpdateAccNum.Text))
            {
                lbMsg.Text += "Account number is required!" + "<br/>";
                lbMsg.ForeColor = Color.Red;
            }
            else
            {
                result = int.TryParse(tbUpdateAccNum.Text, out accnum);
                if (!result)
                {
                    lbMsg.Text += "Enter a valid account number!" + "<br/>";
                    lbMsg.ForeColor = Color.Red;
                }
                else
                {


                    if (UpdateddlTypeBank.SelectedValue == "POSB")
                    {
                        if (tbUpdateAccNum.Text.Length != 9)
                        {
                            lbMsg.Text += "Enter a valid account number!" + "<br/>";
                            lbMsg.ForeColor = Color.Red;
                        }
                    }
                    if (UpdateddlTypeBank.SelectedValue == "DBS" || UpdateddlTypeBank.SelectedValue == "UOB" || UpdateddlTypeBank.SelectedValue == "FEB" || UpdateddlTypeBank.SelectedValue == "Standard Chartered" || UpdateddlTypeBank.SelectedValue == "Citibank")
                    {
                        if (tbUpdateAccNum.Text.Length != 10)
                        {
                            lbMsg.Text += "Enter a valid account number!" + "<br/>";
                            lbMsg.ForeColor = Color.Red;
                        }
                    }
                    if (UpdateddlTypeBank.SelectedValue == "HSBC")
                    {
                        if (tbUpdateAccNum.Text.Length != 9)
                        {
                            if (tbUpdateAccNum.Text.Length != 12)
                            {
                                lbMsg.Text += "Enter a valid account number!" + "<br/>";
                                lbMsg.ForeColor = Color.Red;
                            }
                            else
                            {
                                lbMsg.Text += "";
                            }
                        }
                    }
                    if (UpdateddlTypeBank.SelectedValue == "Maybank")
                    {
                        if (tbUpdateAccNum.Text.Length != 12)
                        {
                            lbMsg.Text += "Enter a valid account number!" + "<br/>";
                            lbMsg.ForeColor = Color.Red;
                        }
                    }
                    if (UpdateddlTypeBank.SelectedValue == "OCBC")
                    {
                        if (tbUpdateAccNum.Text.Length != 12)
                        {
                            if (tbUpdateAccNum.Text.Length != 10)
                            {
                                lbMsg.Text += "Enter a valid account number!" + "<br/>";
                                
                            }
                        }
                    }

                }
               
                //if (notrobot != "true")
                //{
                //    lbMsg.Text += "Please validate that you are not a robot." + "<br/>";
                //    lbMsg.ForeColor = Color.Red;
                //}
            }
            if (String.IsNullOrEmpty(lbMsg.Text))
            {
                return true;
            }
            else
            {
                return false;
            }

        }



        protected void btnUpdateProfile_Click(object sender, EventArgs e)
        {
            
            JE_TourGuideInfo TG = new JE_TourGuideInfo();
            string filenameProfile = null;
            if (Updatepic.HasFile == true)
            {
                filenameProfile = "";
             filenameProfile = Path.GetFileName(Updatepic.FileName);
             Updatepic.SaveAs(Server.MapPath("~/image/" + Session["SSTGEmail"].ToString() + "/" + filenameProfile));
           
            }
            else
            {
                filenameProfile = TG.GetTGByEmail(Session["SSTGEmail"].ToString()).TGProfilePic;
            }
            
            TG = new JE_TourGuideInfo(TG.TGId, TG.TGName, TG.TGFirstName, TG.TGLastName, TG.TGMobile, Session["SSTGEmail"].ToString(), filenameProfile, TG.Nric_front, TG.Nric_back, TG.LicenseYN, TG.License_front, TG.License_back, TG.ACRA1, TG.ACRA2, TG.ACRA3, UpdateddlTypeBank.SelectedValue, tbUpdateAccNum.Text, TG.Expertise, tbWorkhowlong.Text, tbIntroUpdateTG.Text);
            int result = TG.UpdateTGProfile();
                if (result == 1)
                {
                     Response.Redirect("JE_TGProfile.aspx");
                }
        }
    }
}