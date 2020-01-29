using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using MyProject.BLL;
//Imports System.IO
//Imports System.Data
//Imports System.Configuration
//Imports System.Data.SqlClient
using System.Runtime.Serialization;
using System.Text;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Drawing;
using System.Timers;
//using System;
//using DlibDotNet;
//using DlibDotNet.Extensions;
//using Dlib = DlibDotNet.Dlib;



namespace MyProject
{
    [DataContract]
    public class RecaptchaApiResponse
    {
        [DataMember(Name = "success")]
        public bool Success;

        [DataMember(Name = "error-codes")]
        public List<string> ErrorCodes;
    }


    public partial class JE_ApplicationForm : System.Web.UI.Page
    {
        string filename;
        //List<mypic> ;
        string notrobot;
       
        protected void Page_Load(object sender, EventArgs e)
        {
            


            if (!IsPostBack)
            {
                lbwelcome.InnerText = "Welcome "+(string)Session["SSTGName"];
            }
            //if (rbFalseGL.Checked==true)
            //{
            //    GuideLicenseVisible.Visible = true;
            //        //lse;

            //}
            //else
            //{
            //    GuideLicenseVisible.Visible = true;
            //}
            //if (rbTrueGL.Checked == true)
            //{
            //    GuideLicenseVisible.Visible = true;

            //}
            //else
            //{
            //    GuideLicenseVisible.Visible = false;
            //}

        }

        


        //protected void rbTrueGL_CheckedChanged(object sender, EventArgs e)
        //{
        //    GuideLicenseVisible.Visible = true;
        //}

        //protected void rbFalseGL_CheckedChanged(object sender, EventArgs e)
        //{
        //    GuideLicenseVisible.Visible = false;
          

        //}




        //protected void Upload(object sender, EventArgs e)
        //{
        //    byte[] bytes;
        //    using (BinaryReader br = new BinaryReader(imgProfile.PostedFile.InputStream))
        //    {
        //        bytes = br.ReadBytes(imgProfile.PostedFile.ContentLength);
        //    }
        //    string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        //    using (SqlConnection conn = new SqlConnection(constr))
        //    {
        //        string sql = "INSERT INTO JE_TDTGInfo VALUES(@TGProfilePic)";
        //        using (SqlCommand cmd = new SqlCommand(sql, conn))
        //        {

        //            cmd.Parameters.AddWithValue("@TGProfilePic", bytes);
        //            conn.Open();
        //            cmd.ExecuteNonQuery();
        //            conn.Close();
        //        }
        //    }

        //    Response.Redirect(Request.Url.AbsoluteUri);
        //}

        private bool ValidateInput()
        {
            int accnum;
            bool result;
            lbMsg.Text = String.Empty;

            if (imgProfile.HasFile == false)
            {
                lbMsg.Text += "Profile Picture is required!" + "<br/>";
                lbMsg.ForeColor = Color.Red;
            }
            if (imgNRICFront.HasFile == false)
            {
                lbMsg.Text += "Photo of the front of NRIC is required!" + "<br/>";
                lbMsg.ForeColor = Color.Red;
            }
            if (imgNRICBack.HasFile == false)
            {
                lbMsg.Text += "Photo of the back of NRIC is required!" + "<br/>";
                lbMsg.ForeColor = Color.Red;
            }
            if (ddlTypeBank.SelectedIndex == 0)
            {
                lbMsg.Text += "Type of bank is required!" + "<br/>";
                lbMsg.ForeColor = Color.Red;
            }

            if (String.IsNullOrEmpty(tbAccountNum.Text))
            {
                lbMsg.Text += "Account number is required!" + "<br/>";
                lbMsg.ForeColor = Color.Red;
            }
            else
            {
                result = int.TryParse(tbAccountNum.Text, out accnum);
                if (!result)
                {
                    lbMsg.Text += "Enter a valid account number!" + "<br/>";
                    lbMsg.ForeColor = Color.Red;
                }
                else
                {


                    if (ddlTypeBank.SelectedValue == "POSB")
                    {
                        if (tbAccountNum.Text.Length != 9)
                        {
                            lbMsg.Text += "Enter a valid account number!" + "<br/>";
                            lbMsg.ForeColor = Color.Red;
                        }
                    }
                    if (ddlTypeBank.SelectedValue == "DBS" || ddlTypeBank.SelectedValue == "UOB"|| ddlTypeBank.SelectedValue == "FEB" || ddlTypeBank.SelectedValue == "Standard Chartered" || ddlTypeBank.SelectedValue == "Citibank")
                    {
                        if (tbAccountNum.Text.Length != 10)
                        {
                            lbMsg.Text += "Enter a valid account number!" + "<br/>";
                            lbMsg.ForeColor = Color.Red;
                        }
                    }
                    if (ddlTypeBank.SelectedValue == "HSBC")
                    {
                        if (tbAccountNum.Text.Length != 9 )
                        {
                            if (tbAccountNum.Text.Length != 12)
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
                    if (ddlTypeBank.SelectedValue == "Maybank")
                    {
                        if (tbAccountNum.Text.Length != 12)
                        {
                            lbMsg.Text += "Enter a valid account number!" + "<br/>";
                            lbMsg.ForeColor = Color.Red;
                        }
                    }
                    if (ddlTypeBank.SelectedValue == "OCBC")
                    {
                        if (tbAccountNum.Text.Length != 12) {
                            if (tbAccountNum.Text.Length != 10)
                            {
                                //lbMsg.Text += "Enter a valid account number!" + "<br/>";
                                lbMsg.Text += "NARUTOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO" + "<br/>";
                            }
                        } }
                    
            }
                if (cbDeclare1.Checked == false)
                {
                    lbMsg.Text += "Please read the declaration." + "<br/>";
                    lbMsg.ForeColor = Color.Red;
                }
                else
                {
                    if (cbDeclare2.Checked == false)
                    {
                        lbMsg.Text += "Please read the declaration." + "<br/>";
                        lbMsg.ForeColor = Color.Red;
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


        protected void btnSubmitApplication_Click(object sender, EventArgs e)
        {
            //JE_TourGuideInfoForm TG = new JE_TourGuideInfoForm();
            if (ValidateInput())
            {
                JE_TourGuideInfo TG = new JE_TourGuideInfo();

                Directory.CreateDirectory(Server.MapPath("~/image/" + Session["SSTGEmail"].ToString()));

                string filenameProfile = Path.GetFileName(imgProfile.FileName);
                imgProfile.SaveAs(Server.MapPath("~/image/" + Session["SSTGEmail"].ToString() + "/" + filenameProfile));
                string filenameNricFront = null;
                string filenameNricBack = null;
                string filenameLicenseFront = null;
                string filenameLicenseBack = null;
                string filenameACRA1 = null;
                string filenameACRA2 = null;
                string filenameACRA3 = null;

                if (imgNRICFront.HasFiles == true)
                {
                    filenameNricFront = Path.GetFileName(imgNRICFront.FileName);
                    imgNRICFront.SaveAs(Server.MapPath("~/image/" + Session["SSTGEmail"].ToString() + "/" + filenameNricFront));
                }


                if (imgNRICBack.HasFiles == true)
                {
                    filenameNricBack = Path.GetFileName(imgNRICBack.FileName);
                    imgNRICBack.SaveAs(Server.MapPath("~/image/" + Session["SSTGEmail"].ToString() + "/" + filenameNricBack));
                }


                if (imgLicenseFront.HasFiles == true)
                {
                    filenameLicenseFront = Path.GetFileName(imgLicenseFront.FileName);
                    imgLicenseFront.SaveAs(Server.MapPath("~/image/" + Session["SSTGEmail"].ToString() + "/" + filenameLicenseFront));
                }


                if (imgLicenseBack.HasFiles == true)
                {
                    filenameLicenseBack = Path.GetFileName(imgLicenseBack.FileName);
                    imgLicenseBack.SaveAs(Server.MapPath("~/image/" + Session["SSTGEmail"].ToString() + "/" + filenameLicenseBack));
                }


                if (imgACRA1.HasFiles == true)
                {
                    filenameACRA1 = Path.GetFileName(imgACRA1.FileName);
                    imgACRA1.SaveAs(Server.MapPath("~/image/" + Session["SSTGEmail"].ToString() + "/" + filenameACRA1));
                }



                if (imgACRA2.HasFiles == true)
                {
                    filenameACRA2 = Path.GetFileName(imgACRA2.FileName);
                    imgACRA2.SaveAs(Server.MapPath("~/image/" + Session["SSTGEmail"].ToString() + "/" + filenameACRA2));
                }


                if (imgACRA3.HasFiles == true)
                {
                    filenameACRA3 = Path.GetFileName(imgACRA3.FileName);
                    imgACRA3.SaveAs(Server.MapPath("~/image/" + Session["SSTGEmail"].ToString() + "/" + filenameACRA3));
                }
                string haveordontLicense = "";
                if (rbTrueGL.Checked)
                {
                    haveordontLicense = "Have";
                }
                else
                {
                    haveordontLicense = "Don't Have";
                }
                string intro = "Nice To Meet You.";
                TG = new JE_TourGuideInfo(TG.TGId, TG.TGName, TG.TGFirstName, TG.TGLastName, TG.TGMobile, Session["SSTGEmail"].ToString(), filenameProfile, filenameNricFront, filenameNricBack,haveordontLicense, filenameLicenseFront, filenameLicenseBack, filenameACRA1, filenameACRA2, filenameACRA3, ddlTypeBank.SelectedValue, tbAccountNum.Text, tbExpertise.Text, tbWorkhowlong.Text,intro);
                int result = TG.AddTGForm();
                if (result == 1)
                {
                    Session["SSTGId"] = TG.TGId;
                    Session["SSTGProfile"] = filenameProfile;
                    Session["SSTGNRICFront"] = filenameNricFront;
                    Session["SSTGNRICBack"] = filenameNricBack;
                    Session["SSTGLicenseFront"] = filenameLicenseFront;
                    Session["SSTGLicenseBack"] = filenameLicenseBack;
                    Session["SSTGACRA1"] = filenameACRA1;
                    Session["SSTGACRA2"] = filenameACRA2;
                    Session["SSTGACRA3"] = filenameACRA3;
                    Session["SSTGTypeBank"] = ddlTypeBank.SelectedValue;
                    Session["SSTGAccNum"] = tbAccountNum.Text;
                    Session["SSTGExpertise"] = tbExpertise.Text;
                    Session["SSTGWorkHowLong"] = tbWorkhowlong.Text;
                    Session["SSTGIntro"] = intro;
                    Response.Redirect("JE_Job.aspx");
                }
                //int result = TG.AddTG();
                
            }
            

        }
        
        protected void btnValidateReCaptcha_Click(object sender, EventArgs e)
        {
            var sb = new StringBuilder();
            sb.Append("https://www.google.com/recaptcha/api/siteverify?secret=");

            //our secret key
            var secretKey = "6Le8vMoUAAAAAExKh_heXAy6vyswuLHnXqnk91jh";
            sb.Append(secretKey);

            //response from recaptch control
            sb.Append("&");
            sb.Append("response=");
            var reCaptchaResponse = Request["g-recaptcha-response"];
            sb.Append(reCaptchaResponse);
            //make the api call and determine validity
            using (var client = new WebClient())
            {
                var uri = sb.ToString();
                var json = client.DownloadString(uri);
                var serializer = new DataContractJsonSerializer(typeof(RecaptchaApiResponse));
                var ms = new MemoryStream(Encoding.Unicode.GetBytes(json));
                var result = serializer.ReadObject(ms) as RecaptchaApiResponse;

                //--- Check if we are able to call api or not.
                if (result == null)
                {
                    lblForMessage.Text = "Captcha was unable to make the api call";
                }
                else // If Yes
                {
                    //api call contains errors
                    if (result.ErrorCodes != null)
                    {
                        if (result.ErrorCodes.Count > 0)
                        {
                            foreach (var error in result.ErrorCodes)
                            {
                                lblForMessage.Text = "reCAPTCHA Error: " + error;
                            }
                        }
                    }
                    else //api does not contain errors
                    {
                        if (!result.Success) //captcha was unsuccessful for some reason
                        {
                            lblForMessage.Text = "Captcha did not pass, please try again.";
                        }
                        else //---- If successfully verified. Do your rest of logic.
                        {
                            lblForMessage.Text = "Captcha cleared  hehe";
                            notrobot = "true";
                        }
                    }

                }

            }
        }



        //private Timer Timer1;
        //public void InitTimer()
        //{
        //    Timer1 = new Timer();
        //    Timer1.Tick += new EventHandler(Timer1_Tick);
        //    Timer1.Interval = 2000; // in miliseconds
        //    Timer1.Start();
        //}

        //private void Timer1_Tick(object sender, EventArgs e)
        //{
        //    checkingtick();
        //}


        //System.TimeSpan startTimeSpan = TimeSpan.Zero;
        //System.TimeSpan periodTimeSpan = TimeSpan.FromMinutes(5);

        //string timer = new System.Threading.Timer((e) =>
        //{
            
            
        //}, null, startTimeSpan, periodTimeSpan);

       


        
        protected void ddlTypeBank_TextChanged(object sender, EventArgs e)
        {
            //if (tbAccountNum.Text != String.Empty && ddlTypeBank.SelectedValue != "0")
            if (tbAccountNum.Text != String.Empty)
            {
                litPersonal.Text = "<style> #tickbank{ visibility: visible;}</style>";

            }
            else
            {
                litPersonal.Text = "<style> #tickbank{ visibility: hidden;}</style>";

            }
        }
        protected void tbAccountNum_TextChanged(object sender, EventArgs e)
        {
            if (tbAccountNum.Text != String.Empty && ddlTypeBank.SelectedValue != "0")
            //    if (tbAccountNum.Text != String.Empty)
                {
                litBank.Text = "<style> #tickbank{ visibility: visible;}</style>";

            }
            else
            {
                litBank.Text = "<style> #tickbank{ visibility: hidden;}</style>";

            }
        }
        protected void tbExpertise_TextChanged(object sender, EventArgs e)
        {
            if (tbExpertise.Text != String.Empty && tbWorkhowlong.Text != String.Empty)
           // if(imgProfile.HasFile==true)
            {
                litPersonal.Text = "<style> #tickpersonal{ visibility: visible;}</style>";
                //tickpersonal.Visible = true;
                //tickpersonal.Text = "1";
            }
            else
            {
                litPersonal.Text = "<style> #tickpersonal{ visibility: hidden;}</style>";
                //tickpersonal.Visible = false;
                //tickpersonal.Text = "2";
            }
        }
        protected void tbWorkHowLong_TextChanged(object sender, EventArgs e)
        {
            if (tbExpertise.Text != String.Empty && tbWorkhowlong.Text != String.Empty)
            {
                litPersonal.Text = "<style> #tickpersonal{ visibility: visible;}</style>";
                //tickpersonal.Visible = true;
                //tickpersonal.Text = "3";
            }
            else
            {
                litPersonal.Text = "<style> #tickpersonal{ visibility: hidden;}</style>";
                //tickpersonal.Text = "4";
               // tickpersonal.Visible = false;
            }
        }

        protected void cbDeclare1_CheckedChanged(object sender, EventArgs e)
        {
            if (cbDeclare1.Checked==true && cbDeclare2.Checked==true)
            {
                litDeclare.Text = "<style> #tickdeclare{ visibility: visible;}</style>";
                
            }
            else
            {
                litDeclare.Text = "<style> #tickdeclare{ visibility: hidden;}</style>";
                
            }
        }

        protected void cbDeclare2_CheckedChanged(object sender, EventArgs e)
        {
            if (cbDeclare1.Checked == true && cbDeclare2.Checked == true)
            {
                litDeclare.Text = "<style> #tickdeclare{ visibility: visible;}</style>";

            }
            else
            {
                litDeclare.Text = "<style> #tickdeclare{ visibility: hidden;}</style>";

            }
        }


       

       
    }






}