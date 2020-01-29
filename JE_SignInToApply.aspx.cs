using MyProject.BLL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyProject
{
    public partial class JE_SignInToApply : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
        private bool ValidateInput()
        {
            
            lbErrorName.Text = String.Empty;
            lbErrorMobile.Text = String.Empty;
            lbErrorEmail.Text = String.Empty;
            lbErrorTick.Text = String.Empty;
            lbErrorExist.Text = String.Empty;
            if (tbFirstName.Text == "")
            {
               lbErrorName.Text += "First name is required!" + "<br/>";
                lbErrorName.ForeColor = Color.Red;
                
            }if (String.IsNullOrEmpty(tbLastName.Text))
            {
                lbErrorName.Text += "Last Name is required!" + "<br/>";
                lbErrorName.ForeColor = Color.Red;
            }
            bool result;
            int mobile;
            if (String.IsNullOrEmpty(tbMobile.Text))
            {
                lbErrorMobile.Text += "Mobile Number is required!" ;
                lbErrorMobile.ForeColor = Color.Red;
            }
            else
            {
             result = int.TryParse(tbMobile.Text, out mobile);
                        if (!result)
                        {
                            lbErrorMobile.Text += "Please enter a valid Mobile Number!" ;
                    lbErrorMobile.ForeColor = Color.Red;
                }
                        else
                        {
                        if (tbMobile.Text.Length!=8)
                                    {
                                        lbErrorMobile.Text += "Please enter a valid Mobile Number!";
                        lbErrorMobile.ForeColor = Color.Red;
                    }
                    //else
                    //{
                    //    if(tbMobile.Text[0]= )
                    //}
                        }
            }
           
            if (String.IsNullOrEmpty(tbEmail.Text))
            {
                lbErrorEmail.Text += "Email is required!" ;
                lbErrorEmail.ForeColor = Color.Red;
            }
            else
            {
                if (IsValidEmail(tbEmail.Text) == false)
                {
                    lbErrorEmail.Text += "Please enter a valid Email!" ;
                    lbErrorEmail.ForeColor = Color.Red;
                }

            }
            
            if (cbTick.Checked == false)
            {
                lbErrorTick.Text += "Please Tick" ;
                lbErrorTick.ForeColor = Color.Red;
            }
            if (String.IsNullOrEmpty(lbErrorEmail.Text)&& String.IsNullOrEmpty(lbErrorMobile.Text)&& String.IsNullOrEmpty(lbErrorName.Text) && String.IsNullOrEmpty(lbErrorTick.Text))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public string Get10Digits()
        {
            var bytes = new byte[10];
            var rng = RandomNumberGenerator.Create();
            rng.GetBytes(bytes);
            uint random = BitConverter.ToUInt32(bytes, 0) % 100000000;
            return String.Format("{0:D10}", random);
        }

        
   
        public string Get6Digits()
        {
            Random r = new Random();
            var random = r.Next(100000, 999999);
            
            return String.Format("{0:D6}", random);
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            JE_TourGuideInfo TG = new JE_TourGuideInfo();

            SMSSvrRef.SMSSoapClient S = new SMSSvrRef.SMSSoapClient();


            if (TG.GetTGByEmail(tbEmail.Text) != null)
            {
                lbErrorExist.Text = "Record already exists!";
                lbErrorExist.ForeColor = Color.Red;
            }
            else
            {

                if (ValidateInput())
                {
                    var id = DateTime.Now.ToString("MMddyyyyHHmmss") + Get10Digits();
                    
                    var name = tbLastName.Text +" "+ tbFirstName.Text;
                    TG = new JE_TourGuideInfo(id,name,tbFirstName.Text, tbLastName.Text, tbMobile.Text, tbEmail.Text,null,null,null,null,null,null,null,null,null,null,null,null,null,null);
                    int result = TG.AddTG();
                    if (result == 1)
                    {
                        Session["SSTGName"] = tbLastName.Text+" "+ tbFirstName.Text;
                        Session["SSTGEmail"] = tbEmail.Text;
                        Session["SSTGMobile"] = tbMobile.Text;
                        Session["SSTGOTP"] = Get6Digits();
                        var message = "Your OTP is " + Session["SSTGOTP"].ToString() + " for you to continue to apply as a Tour guide.";
                        //string display = S.sendMessage("EA02", "609000", Session["SSTGMobile"].ToString(), message );


                        //var mdlPopup = $find('MODALPOPUPBEHAVIORID');
                        //if (mdlPopup)
                        //{
                        //    mdlPopup.show();
                        //    return false;
                        //}
                        Response.Redirect("JE_OTP.aspx");
                       // ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup('hello');", true);
                     
                    }
                }
                    else
                    {
                        lbErrorExist.Text = "Error in adding record! Inform System Administrator!";
                        lbErrorExist.ForeColor = Color.Red;
                    }
                }
            }

        protected void btntry_Click(object sender, EventArgs e)
        {
           
        }
    }


        //protected void btnSubmitOTP_Click(object sender, EventArgs e)
        //{

        //    //lbError.Text = String.Empty;
        //    //if (tbOTP.Text == Session["SSTGOTP"].ToString())
        //    //{

        //    //    Response.Redirect("JE_ApplicationForm.aspx");
        //    //}
        //    //if (Session["SSTGOTP"].ToString() == "-1")
        //    //{
        //    //    lbError.Text = "Your OTP have expired!";
        //    //    lbError.ForeColor = Color.Red;
        //    //}
        //    //if (tbOTP.Text != Session["SSTGOTP"].ToString() && tbOTP.Text != "-1")
        //    //{
        //    //    lbError.Text = "Wrong OTP!";
        //    //    lbError.ForeColor = Color.Red;
        //    //}

        //}
        //protected void btnSubmitOTP0_Click(object sender, EventArgs e)
        //{
        //    Response.Redirect("JE_ApplicationForm.aspx");
        //}

        //protected void btntry_Click(object sender, EventArgs e)
        //{

        //}
    }
//}