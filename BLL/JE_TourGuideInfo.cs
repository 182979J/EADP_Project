using MyProject.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI.WebControls;

namespace MyProject.BLL
{
    public class JE_TourGuideInfo
    {
        private HttpPostedFile postedFile;
        

        //sign up to apply variables to be saved
        public string TGId { get; set; }
        public string TGName { get; set; }
        public string TGFirstName { get; set; }
        public string TGLastName { get; set; }
        public string TGMobile { get; set; }
        public string TGEmail { get; set; }

        //private FileUpload imgProfile;

        //Application form variables needed to be saved
        public string TGProfilePic { get; set; }
        //public FileUpload TGProfilePic { get; set; }
        public string Nric_front { get; set; }
        public string Nric_back { get; set; }
        public string LicenseYN { get; set; }
        public string License_front { get; set; }
        public string License_back { get; set; }
        public string ACRA1 { get; set; }
        public string ACRA2 { get; set; }
        public string ACRA3 { get; set; }
        public string Type_of_bank { get; set; }
        public string Bank_num { get; set; }
        public string Expertise { get; set; }
        public string WorkHowLong { get; set; }
        public string IntroInProfile { get; set; }

        public JE_TourGuideInfo()
        {

        }
       

        public string Get10Digits()
        {
            var bytes = new byte[10];
            var rng = RandomNumberGenerator.Create();
            rng.GetBytes(bytes);
            uint random = BitConverter.ToUInt32(bytes, 0) % 100000000;
            return String.Format("{0:D10}", random);
        }

        public JE_TourGuideInfo(string TGid, string TGname, string TGfirstname, string TGlastname, string TGmobile, string TGemail, string imgProfile, string imgNRICFront, string imgNRICBack,string licenseyn ,string imgLicenseFront,string imgLicenseBack, string imgACRA1, string imgACRA2, string imgACRA3,string type_of_bank, string bank_num,string expertise,string workhowlong,string introinprofile)
        {
            //FileUpload imgProfile
            TGid = DateTime.Now.ToString("yyyyMMddHHmmss") + Get10Digits();
            this.TGId = TGid;
            this.TGFirstName = TGfirstname;
            this.TGLastName = TGlastname;
            TGname = TGLastName + " " + TGFirstName;
            this.TGName = TGname;

            this.TGMobile = TGmobile;
            this.TGEmail = TGemail;
            this.TGProfilePic = imgProfile;
            this.Nric_front = imgNRICFront;
            this.Nric_back = imgNRICBack;
            this.LicenseYN = licenseyn;
            this.License_front = imgLicenseFront;
            this.License_back = imgLicenseBack;
            this.ACRA1 = imgACRA1;
            this.ACRA2 = imgACRA2;
            this.ACRA3 = imgACRA3;
            this.Type_of_bank = type_of_bank;
            this.Bank_num = bank_num;
            this.Expertise = expertise;
            this.WorkHowLong = workhowlong;
            this.IntroInProfile = introinprofile;
            
        }


        public JE_TourGuideInfo GetTGByEmail(string TGEmaill)
        {
            JE_TourGuideInfoDAO dao = new JE_TourGuideInfoDAO();
            return dao.SelectByEmail(TGEmaill);
        }

        public int AddTG()
        {
            JE_TourGuideInfoDAO dao = new JE_TourGuideInfoDAO();
            int result = dao.Insert(this);
            return result;
        }
        public int AddTGForm()
        {
            JE_TourGuideInfoDAO dao = new JE_TourGuideInfoDAO();
            int result = dao.AddForm(this);
            return result;
        }
        public int UpdateTGProfile()
        {
            JE_TourGuideInfoDAO dao = new JE_TourGuideInfoDAO();
            int result = dao.UpdateProfile(this);
            return result;
        }
    }
    
}