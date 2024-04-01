using Umbraco.Cms.Core.Services.Implement;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Infrastructure.Persistence;
using Umbraco.Cms.Web.Website.Controllers;
using Umbraco.Extensions;
using Umbraco.Cms.Core.Scoping;
using Microsoft.AspNetCore.Http;
using System.Net.Http.Headers;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using System.Text;
using System.ServiceModel.Syndication;
using System.Xml;
using System.Xml.Linq;
using Umbraco.Cms.Core.Models.PublishedContent;
using System.Xml.Serialization;
using Umbraco.Cms.Core.Models;
using Lina_v1_Umb_12.Custom;
using Umbraco.Cms.Core.Cache;
using Umbraco.Cms.Core.Logging;
using Umbraco.Cms.Core.Routing;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Core;
using Microsoft.AspNetCore.Mvc;


namespace Lina_v1_Umb_12.Controllers
{
    public class ContactController : SurfaceController
    {
        private Microsoft.AspNetCore.Hosting.IHostingEnvironment Environment;
        private readonly IPublishedContentQuery _publishedContentQuery;
        private readonly IContentService _contentService;
        private readonly IScopeProvider _scopeProvider;
        private Microsoft.AspNetCore.Hosting.IHostingEnvironment _hostingEnvironment;
        public ContactController(
            Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnvironment,
            IUmbracoContextAccessor umbracoContextAccessor,
            IUmbracoDatabaseFactory databaseFactory,
            ServiceContext services,
            AppCaches appCaches,
            IProfilingLogger profilingLogger,
            IPublishedUrlProvider publishedUrlProvider,
            IPublishedContentQuery publishedContentQuery,
            Microsoft.AspNetCore.Hosting.IHostingEnvironment _environment,
            IContentService contentService, IScopeProvider scopeProvider)
            : base(umbracoContextAccessor, databaseFactory, services, appCaches, profilingLogger, publishedUrlProvider)
        {
            _publishedContentQuery = publishedContentQuery;
            _contentService = contentService;
            _scopeProvider = scopeProvider;
            _hostingEnvironment = hostingEnvironment;
            Environment = _environment;
        }
        [HttpGet]
        public bool ContactDetailMethod(string StrName, string StrPhone, string StrEmail, string StrDescription, string StrSocials, string StrKeyworker,string StrKeyWorkerDropdown)
        {
            var ContactValue = _publishedContentQuery.Content(1062).Children.Where(x => x.ContentType.Alias == "contactUs").FirstOrDefault();
           
            var contentService = Services.ContentService;
            var parentId = Guid.Parse("2c05582a-506d-4188-8b07-b63237330911");
            var person = contentService.Create(StrName, parentId, "contactDetail");
            bool keyWorkeroption = false;
            if(StrKeyworker == "Yes")
            {
                keyWorkeroption = true;
            }
           
                person.SetValue("fullName", StrName);
                person.SetValue("phoneNumber", StrPhone);
                person.SetValue("email", StrEmail);
                person.SetValue("enquiryDetail", StrDescription);
                person.SetValue("aboutLina", StrSocials);
                person.SetValue("keyWorker", keyWorkeroption);
                if (!string.IsNullOrEmpty(StrKeyWorkerDropdown) && StrKeyWorkerDropdown != "Please select from the list")
                {
                    person.SetValue("keyWorkerType", StrKeyWorkerDropdown);
                }
            try
            {
                contentService.SaveAndPublish(person);
            }
            catch (Exception ex)
            {

            }
            try
            {
            

                var strFromEmail = "";
                var strToEmail = "";
                var strSubjectValue = "";
                var strsmtpServer = "";
                var strsmtpPassword = "";
                var strsmtpUser = "";
                var strsslRequired = false;
                var strtslRequired = false;
                var strport = "";

                if (ContactValue.HasProperty("fromEmail") && ContactValue.Value("fromEmail") != null && ContactValue.Value<string>("fromEmail") != "")
                {
                    strFromEmail = ContactValue.Value<string>("fromEmail");
                }
                if (ContactValue.HasProperty("toEmail") && ContactValue.Value("toEmail") != null && ContactValue.Value<string>("toEmail") != "")
                {
                    strToEmail = ContactValue.Value<string>("toEmail");
                }
                if (ContactValue.HasProperty("smtpServer") && ContactValue.Value("smtpServer") != null && ContactValue.Value<string>("smtpServer") != "")
                {
                    strsmtpServer = ContactValue.Value<string>("smtpServer");
                }
                if (ContactValue.HasProperty("smtpPassword") && ContactValue.Value("smtpPassword") != null && ContactValue.Value<string>("smtpPassword") != "")
                {
                    strsmtpPassword = ContactValue.Value<string>("smtpPassword");
                }
                if (ContactValue.HasProperty("smtpUser") && ContactValue.Value("smtpUser") != null && ContactValue.Value<string>("smtpUser") != "")
                {
                    strsmtpUser = ContactValue.Value<string>("smtpUser");
                }
                if (ContactValue.HasProperty("sslRequired") && ContactValue.Value("sslRequired") != null && ContactValue.Value<string>("sslRequired") != "")
                {
                    strsslRequired = ContactValue.Value<bool>("sslRequired");
                }
                if (ContactValue.HasProperty("tslRequired") && ContactValue.Value("tslRequired") != null && ContactValue.Value<string>("tslRequired") != "")
                {
                    strtslRequired = ContactValue.Value<bool>("tslRequired");
                }
                if (ContactValue.HasProperty("port") && ContactValue.Value("port") != null && ContactValue.Value<string>("port") != "")
                {
                    strport = ContactValue.Value<string>("port");
                }
                if (ContactValue.HasProperty("subject") && ContactValue.Value("subject") != null && ContactValue.Value<string>("subject") != "")
                {
                    strSubjectValue = ContactValue.Value<string>("subject");
                }

                //  string txtSubject = "Enquiry form - " + Solution.Common.Configuration.ProjectName;

                string EmailBody = "<p><br/>";

                //string SenderEmailAddress = Solution.Common.Configuration.AdminEmail;

                if (!string.IsNullOrEmpty(StrName))
                {
                    EmailBody += "<strong>Name:</strong>  " + StrName + "<br/><br/>";
                }
                if (!string.IsNullOrEmpty(StrPhone))
                {
                    EmailBody += "<strong>Phone:</strong>  " + StrPhone + "<br/><br/>";
                }
                if (!string.IsNullOrEmpty(StrEmail))
                {
                    EmailBody += "<strong>Email address:</strong>  " + StrEmail + "<br/><br/>";
                }
                
                if (!string.IsNullOrEmpty(StrDescription))
                {
                    EmailBody += "<strong>General Enquiry:</strong>  " + StrDescription + "<br/><br/></p>";
                }
                if (!string.IsNullOrEmpty(StrSocials))
                {
                    EmailBody += "<strong>How did you hear about Lina?:</strong>  " + StrSocials + "<br/><br/></p>";
                }
                if (!string.IsNullOrEmpty(StrKeyworker))
                {
                    EmailBody += "<strong>Are you a key worker?:</strong>  " + StrKeyworker + "<br/><br/></p>";
                }
                if (!string.IsNullOrEmpty(StrKeyWorkerDropdown) && StrKeyWorkerDropdown != "Please select from the list")
                {
                    EmailBody += "<strong>key worker:</strong>  " + StrKeyWorkerDropdown + "<br/><br/></p>";
                }
                if (string.IsNullOrEmpty(strFromEmail))
                    strFromEmail = StrEmail.ToString().Trim();

                strFromEmail = strFromEmail.ToString().Trim();
                

                //  strFromEmail =  "ECDC Request <" + strFromEmail + ">";
                if (!string.IsNullOrEmpty(strFromEmail) && !string.IsNullOrEmpty(strToEmail))
                {
                    Configuration.SendEmailV2(strToEmail, "", "", strSubjectValue, EmailBody, strFromEmail, StrName, "", strsmtpServer, strsmtpPassword, strsmtpUser, strsslRequired, strtslRequired, strport);
                }

                // return true;
            }
            catch (Exception ex)
            {

            }


            return true;
        }
    }
}
