using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InReach
{
    public partial class Index : System.Web.UI.Page
    {
        //Local Url
        //private string basePath = "http://localhost:63125/";
        private string basePath = "http://www.inreach.somee.com/";
        private string link = "";
        private MailMessage mail = new MailMessage();
        private SmtpClient smtp = new SmtpClient();
        private string email = "rehan.baig.bukc@gmail.com";
        private string password = "*********";
        private string folderpath = "";
        private string filename = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            sucessmsg.Visible = false;
            errormsg.Visible = false;
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            folderpath = Server.MapPath("~/Uploads/");
            filename = Path.GetFileName(FileUpload.FileName);
            if (FileUpload.HasFile)
            {
                if (!Directory.Exists(folderpath))
                {
                    Directory.CreateDirectory(folderpath);
                }
                FileUpload.SaveAs(folderpath + filename);
                link = basePath + ("/Uploads/"+ filename);
                SendEmail(txtemail.Value, link);
                sucessmsg.Visible = true;
            }
            else
            {
                errormsg.Visible = true;
            }
        }

        public void SendEmail(string recipent, string link)
        {
            mail.From = new MailAddress(email);
            mail.To.Add(new MailAddress(recipent));
            mail.Subject = "InReach FileUpload Test";
            mail.IsBodyHtml = true;
            mail.Body = "<div class='container' style='padding:20px; background-color: #f1f1f1; font-family:tahoma;'> <h2> InReach File </h2> <p>Hi</p> <br/> <b>" +link+"</b> <br/> <p> Following is uploaded Attachment Link</p> </div> ";
            smtp.Port = 587;
            smtp.Host = "smtp.gmail.com";
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential(email, password);
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Send(mail);
        }
    }
}