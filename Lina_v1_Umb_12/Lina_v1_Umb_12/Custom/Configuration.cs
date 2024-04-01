using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using Umbraco.Cms.Core;
using Umbraco.Cms.Core.Cache;
using Umbraco.Cms.Core.Logging;
using Umbraco.Cms.Core.Routing;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Infrastructure.Persistence;
using Umbraco.Cms.Web.Website.Controllers;
using Umbraco.Extensions;
using Umbraco.Cms.Core.Scoping;
using Umbraco.Cms.Core.Models.PublishedContent;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Microsoft.Extensions.DependencyInjection;
using System.Net;
using Microsoft.AspNetCore.Hosting;


namespace Lina_v1_Umb_12.Custom
{
    public class Configuration
    {

        // private IHttpContextAccessor _httpContextAccessor;
        private static IHttpContextAccessor HttpContextAccessor;
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment _hostingEnvironment;
        private readonly IWebHostEnvironment _env;
        private static string _baseURL;

        public Configuration(IHttpContextAccessor httpContextAccessor, Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnvironment, IWebHostEnvironment env)
        {

            HttpContextAccessor = httpContextAccessor;
            _hostingEnvironment = hostingEnvironment;
            _env = env;

            ////var request = httpContextAccessor.HttpContext.Request;
            ////_baseURL = $"{request.Scheme}://{request.Host}";
        }

        public static string DomainUrl
        {
            get
            {
                IHttpContextAccessor _httpContextAccessor = new HttpContextAccessor();
                var request = _httpContextAccessor.HttpContext.Request;
                var baseUrl = $"{request.Scheme}://{request.Host}/";

                return baseUrl;

                //return "http://systech.sbronline.co.uk/";
            }
        }
        public static string SetOrGetProjectName(string pProjectName)
        {
            return pProjectName;
        }
        public static string UrlWithDomain(IPublishedContent content)
        {
            return content.Url();
        }

        public static string SMTPUser
        {
            get
            {
                return "";//ConfigurationManager.AppSettings["smtpUser"].ToString();
            }
        }
        public static string SMTP
        {
            get
            {
                return "localhost";
            }
        }

        public static IWebHostEnvironment WebEnv()
        {
            var _accessor = new HttpContextAccessor();
            return _accessor.HttpContext.RequestServices.GetRequiredService<IWebHostEnvironment>();
        }

        public static string AdminEmailForApplicationsForm
        {
            get
            {
                return "";//ConfigurationManager.AppSettings["AdminEmailForApplicationsForm"].ToString();
            }
        }

        public static string AdminEmailTollgate
        {
            get
            {
                return "tollgate@thedulwichestate.org.uk,Linda.Rampling@thedulwichestate.org.uk";
            }
        }

        public static string AdminEmail
        {
            get
            {
                return "I.Yunis@smallbackroom.co.uk";
            }
        }

        public static string ProjectName
        {
            get
            {
                return "SYSTECH";
            }
        }

        public static string AdminEmailCC
        {
            get
            {
                return "";//ConfigurationManager.AppSettings["AdminEmailCC"].ToString();
            }
        }
        public static string AdminEmailBCC
        {
            get
            {
                return "";//ConfigurationManager.AppSettings["AdminEmailBCC"].ToString();
            }
        }

        public static string SMTPPassword
        {
            get
            {
                return "";//ConfigurationManager.AppSettings["smtpPassword"].ToString();
            }
        }

        //Hide 10-8-2023
        //public static bool SendEmailV2(string recipient, string cc, string bcc, string subject, string body, string sender, string senderName, string attachment, string smtpServer,
        // string smtpPassword, string smtpUser, bool sslRequired, bool tslRequired, string port)
        //{


        //    string webRootPath = Configuration.WebEnv().WebRootPath;
        //    string MediaVehiclepath = Path.Combine(webRootPath, "data/");

        //    using (SmtpClient smtpClient = new SmtpClient())
        //    {

        //        NetworkCredential basicCredential = new NetworkCredential(smtpUser, smtpPassword);
        //        using (MailMessage message = new MailMessage())
        //        {

        //            smtpClient.Host = smtpServer;
        //            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
        //            smtpClient.UseDefaultCredentials = false;
        //            smtpClient.Credentials = basicCredential;

        //            int portToUse = 587;
        //            if (!string.IsNullOrEmpty(port))
        //                int.TryParse(port, out portToUse);

        //            smtpClient.Port = portToUse;

        //            if (sslRequired)
        //                smtpClient.EnableSsl = sslRequired;

        //            smtpClient.Timeout = (60 * 5 * 1000);

        //            if (!String.IsNullOrEmpty(recipient))
        //            {
        //                foreach (var itm in recipient.Trim().Split(','))
        //                {
        //                    message.To.Add(new MailAddress(itm.Trim()));
        //                }
        //            }

        //            if (!String.IsNullOrEmpty(cc))
        //            {
        //                foreach (var itm in cc.Trim().Split(','))
        //                {
        //                    message.CC.Add(new MailAddress(itm.Trim()));
        //                }
        //            }

        //            if (!String.IsNullOrEmpty(bcc))
        //            {
        //                foreach (var itm in bcc.Trim().Split(','))
        //                {
        //                    message.Bcc.Add(new MailAddress(itm.Trim()));
        //                }
        //            }

        //            if (!String.IsNullOrEmpty(sender))
        //            {
        //                message.From = new MailAddress(sender.Trim(), senderName);
        //            }

        //            if (attachment != null && attachment != "" && System.IO.File.Exists(MediaVehiclepath + attachment))
        //                message.Attachments.Add(new Attachment(Path.Combine(MediaVehiclepath, attachment)));


        //            message.Subject = subject;
        //            body += "<br/><br/>";
        //            message.Body = body;
        //            message.IsBodyHtml = true;
        //            message.BodyEncoding = System.Text.Encoding.UTF8;
        //            //message.SubjectEncoding = System.Text.Encoding.Default;

        //            try
        //            {
        //                smtpClient.Send(message);
        //                return true;
        //            }
        //            catch (Exception ex)
        //            {
        //                Error, could not send the message
        //                / Response.Write(ex.Message);
        //            }
        //        }
        //    }

        //    return false;

        //}
        public static bool SendEmailV2(string recipient, string cc, string bcc, string subject, string body, string sender, string senderName, string attachment, string smtpServer,
           string smtpPassword, string smtpUser, bool sslRequired, bool tslRequired, string port)
        {
            try
            {
                string webRootPath = Configuration.WebEnv().WebRootPath;
                string MediaVehiclepath = Path.Combine(webRootPath, "data/");

                MailMessage Msg = new MailMessage();

                SmtpClient ObjSmtp = new SmtpClient("localhost");

                if (smtpServer != null
                    && smtpServer != ""
                    && smtpUser != null
                        && smtpUser != ""
                        && smtpPassword != null
                        && smtpPassword != "")
                {
                    if (!string.IsNullOrEmpty(smtpServer))
                        ObjSmtp = new SmtpClient(smtpServer);

                    if (smtpServer.ToLower().Contains("gmail.com"))
                        ObjSmtp = new SmtpClient(smtpServer, Convert.ToInt32(port));
                    System.Net.NetworkCredential smtp_credentials = new System.Net.NetworkCredential(smtpUser, smtpPassword);
                    ObjSmtp.Credentials = smtp_credentials;
                    if (sslRequired)
                        ObjSmtp.EnableSsl = sslRequired;
                }
                if (!String.IsNullOrEmpty(recipient))
                {
                    foreach (var itm in recipient.Trim().Split(','))
                    {
                        Msg.To.Add(new MailAddress(itm.Trim()));
                    }
                }
                else { return false; }

                if (!String.IsNullOrEmpty(cc))
                {

                    foreach (var itm in cc.Trim().Split(','))
                    {
                        Msg.CC.Add(new MailAddress(itm.Trim()));
                    }
                }

                if (!String.IsNullOrEmpty(bcc))
                {

                    foreach (var itm in bcc.Trim().Split(','))
                    {
                        Msg.Bcc.Add(new MailAddress(itm.Trim()));
                    }
                }

                if (!String.IsNullOrEmpty(sender))
                {
                    Msg.From = new MailAddress(sender.Trim(), senderName);
                }
                else { return false; }
                if (attachment != null && attachment != "" && System.IO.File.Exists(MediaVehiclepath + attachment))
                    Msg.Attachments.Add(new Attachment(Path.Combine(MediaVehiclepath, attachment)));

                Msg.Subject = subject; ;

                body += "<br/><br/>";
                ////body += "Regards,";
                ////body += "<br/>";
                ////body += Solution.Common.Configuration.ProjectName + " Team";
                ////body += "<br/>";

                Msg.Body = body;
                Msg.IsBodyHtml = true;
                Msg.BodyEncoding = System.Text.Encoding.UTF8;

                ObjSmtp.Send(Msg);

                return true;
            }
            catch (Exception ex)
            { return false; }



        }

        public static Object GetNext<T>(IEnumerable<T> list, int pCurrentItemIndex)
        {
            try
            {
                if (list.Count() <= 1)
                    return null;

                if ((list.Count() - 1) == pCurrentItemIndex)
                    return list.Skip(0).First();

                return list.Skip((pCurrentItemIndex + 1)).First();
            }
            catch
            {

            }

            return null;
        }

        public static Object GetPrevious<T>(IEnumerable<T> list, int pCurrentItemIndex)
        {
            try
            {
                if (list.Count() <= 1)
                    return null;

                if (0 == pCurrentItemIndex)
                    return list.Skip((list.Count() - 1)).First();

                return list.Skip((pCurrentItemIndex - 1)).First();
            }
            catch
            {

            }

            return null;


        }

        public static bool SendEmail(string recipient, string cc, string bcc, string subject, string body, string sender, string attachment)
        {
            try
            {
                MailMessage Msg = new MailMessage();

                SmtpClient ObjSmtp = new SmtpClient("localhost");

                if (Configuration.SMTP != null
                    && Configuration.SMTP != ""
                    && Configuration.SMTPUser != null
                        && Configuration.SMTPUser != ""
                        && Configuration.SMTPPassword != null
                        && Configuration.SMTPPassword != "")
                {
                    ObjSmtp = new SmtpClient(Configuration.SMTP);

                    if (Configuration.SMTP.ToLower().Contains("gmail.com"))
                        ObjSmtp = new SmtpClient(Configuration.SMTP, Convert.ToInt32(587));
                    System.Net.NetworkCredential smtp_credentials = new System.Net.NetworkCredential(Configuration.SMTPUser, Configuration.SMTPPassword);
                    ObjSmtp.Credentials = smtp_credentials;
                    ObjSmtp.EnableSsl = true;
                }

                ////if (attachment != null && attachment != "" && System.IO.File.Exists(HttpContext.Current.Request.MapPath("~/data/" + attachment + "")))
                ////    Msg.Attachments.Add(new Attachment(HttpContext.Current.Request.MapPath("~/data/" + attachment + "")));

                if (!String.IsNullOrEmpty(recipient))
                {
                    foreach (var itm in recipient.Trim().Split(','))
                    {
                        Msg.To.Add(new MailAddress(itm.Trim()));
                    }
                }
                else { return false; }

                if (!String.IsNullOrEmpty(cc))
                {

                    foreach (var itm in cc.Trim().Split(','))
                    {
                        Msg.CC.Add(new MailAddress(itm.Trim()));
                    }
                }

                if (!String.IsNullOrEmpty(bcc))
                {

                    foreach (var itm in bcc.Trim().Split(','))
                    {
                        Msg.Bcc.Add(new MailAddress(itm.Trim()));
                    }
                }

                if (!String.IsNullOrEmpty(sender))
                {
                    Msg.From = new MailAddress(sender.Trim());
                }
                else { return false; }
                Msg.Subject = subject;


                body += "<br/><br/>";
                ////body += "Regards,";
                ////body += "<br/>";
                ////body += Solution.Common.Configuration.ProjectName + " Team";
                ////body += "<br/>";

                Msg.Body = body;
                Msg.IsBodyHtml = true;
                Msg.BodyEncoding = System.Text.Encoding.UTF8;

                ObjSmtp.Send(Msg);

                return true;
            }
            catch { return false; }
        }
    }
}
