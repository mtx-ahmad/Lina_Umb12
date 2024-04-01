using Umbraco.Cms.Web.Website.Controllers;
using Microsoft.AspNetCore.Mvc;
using Umbraco.Cms.Core;
using Umbraco.Cms.Core.Cache;
using Umbraco.Cms.Core.Logging;
using Umbraco.Cms.Core.Routing;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Infrastructure.Persistence;
using Umbraco.Cms.Core.Scoping;
using System.Text;
using Umbraco.Cms.Core.Models.PublishedContent;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;
using Lina_v1_Umb_12.Custom;
using System.Data;
using Umbraco.Cms.Core.Models.Blocks;
using static Umbraco.Cms.Core.Constants.HttpContext;

namespace Lina_v1_Umb_12.Controllers
{
    public class ExcelDownloadController : SurfaceController
    {
        private readonly IPublishedContentQuery _publishedContentQuery;
        private readonly IContentService _contentService;
        private readonly IScopeProvider _scopeProvider;
        private IHostingEnvironment _hostingEnvironment;
        private IServiceProvider _servicesProvider;

        public ExcelDownloadController(
            IHostingEnvironment hostingEnvironment,
            IUmbracoContextAccessor umbracoContextAccessor,
            IUmbracoDatabaseFactory databaseFactory,
            ServiceContext services,
            AppCaches appCaches,
            IProfilingLogger profilingLogger,
            IPublishedUrlProvider publishedUrlProvider,
            IPublishedContentQuery publishedContentQuery,
            IContentService contentService,
            IScopeProvider scopeProvider,
            IServiceProvider servicesProvider)
            : base(umbracoContextAccessor, databaseFactory, services, appCaches, profilingLogger, publishedUrlProvider)
        {
            _publishedContentQuery = publishedContentQuery;
            _contentService = contentService;
            _scopeProvider = scopeProvider;
            _hostingEnvironment = hostingEnvironment;
            _servicesProvider = servicesProvider;


        }

        protected string DomainUrl = Configuration.DomainUrl;
        protected string DBConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\\competition-rs-v2.mdb;Jet OLEDB:Database Password=admin786;";

        // GET: ExcelDownload
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Download(string fromdate, string todate, bool chkDownloadAll)
        {
            IPublishedContent strContact = _publishedContentQuery.Content(1134);
            
            StringBuilder str = new StringBuilder();
            //StringBuilder str2 = new StringBuilder();

            DateTime startingDate = new DateTime();
            DateTime EndingDateDate = new DateTime();

            if (!string.IsNullOrEmpty(fromdate))
            {
                startingDate = Convert.ToDateTime(fromdate);
                int strYear = startingDate.Year;
                int strmonTh = startingDate.Month;
                int strDay = startingDate.Day;
                startingDate = new DateTime(strYear, strmonTh, strDay);
            }
            else
                startingDate = DateTime.Now;

            if (!string.IsNullOrEmpty(todate))
            {
                EndingDateDate = Convert.ToDateTime(todate);
                int EndYear = EndingDateDate.Year;
                int EndmonTh = EndingDateDate.Month;
                int EndDay = EndingDateDate.Day;

                EndingDateDate = new DateTime(EndYear, EndmonTh, EndDay);
            }
            else
                EndingDateDate = DateTime.Now;

            //if (startingDate == EndingDateDate)
            { EndingDateDate = EndingDateDate.AddDays(1); }
            

            IList<IPublishedContent> Contactchilditems = null;
          
                if (chkDownloadAll)
                { Contactchilditems = strContact.Children.ToList(); }
                else
                    Contactchilditems = strContact.Children.Where(x => (x.CreateDate >= startingDate && x.CreateDate <= EndingDateDate)).ToList();

                if (Contactchilditems != null && Contactchilditems.Count() > 0)
                {
                    str.Append("<table border=`" + "1px" + ">");
                    str.Append("<tr>");
                    str.Append("<td><b><font face=Arial Narrow size=3>Full Name</font></b></td>");
                    str.Append("<td><b><font face=Arial Narrow size=3>Phone Number</font></b></td>");
                    str.Append("<td><b><font face=Arial Narrow size=3>Email</font></b></td>");
                    str.Append("<td><b><font face=Arial Narrow size=3>Enquiry Detail</font></b></td>");
                    str.Append("<td><b><font face=Arial Narrow size=3>About lina</font></b></td>");
                    str.Append("<td><b><font face=Arial Narrow size=3>Key Worker</font></b></td>");
                    str.Append("<td><b><font face=Arial Narrow size=3>Key Worker Type</font></b></td>");
                    str.Append("<td><b><font face=Arial Narrow size=3>Dated</font></b></td>");
                    str.Append("</tr>");

                    foreach (var items in Contactchilditems)
                    {

                        var strname = "";
                        var strEmail = "";
                    var strphoneNumber = "";
                        var strDescription = "";
                        var straboutLina = "";
                    bool strkeyWorker = false;
                    var KeyWorker = "No";
                    var strkeyWorkerType = "";
                        DateTime strCreatedDate;
                        if (items.HasProperty("fullName") && items.Value("fullName") != null && items.Value<string>("fullName") != "")
                        {
                            strname = items.Value<string>("fullName");
                        }
                    if (items.HasProperty("phoneNumber") && items.Value("phoneNumber") != null && items.Value<string>("phoneNumber") != "")
                    {
                        strphoneNumber = items.Value<string>("phoneNumber");
                    }
                    if (items.HasProperty("email") && items.Value("email") != null && items.Value<string>("email") != "")
                        {
                            strEmail = items.Value<string>("email");
                        }
                        if (items.HasProperty("enquiryDetail") && items.Value("enquiryDetail") != null && items.Value<string>("enquiryDetail") != "")
                        {
                            strDescription = items.Value<string>("enquiryDetail");
                        }
                        if (items.HasProperty("aboutLina") && items.Value("aboutLina") != null && items.Value<string>("aboutLina") != "")
                        {
                        straboutLina = items.Value<string>("aboutLina");
                        }
                    if (items.HasProperty("keyWorker") && items.Value("keyWorker") != null && items.Value<string>("keyWorker") != "")
                    {
                        strkeyWorker = items.Value<bool>("keyWorker");
                    }
                    if(strkeyWorker == true)
                    {
                        KeyWorker = "Yes";
                    }
                    if (items.HasProperty("keyWorkerType") && items.Value("keyWorkerType") != null && items.Value<string>("keyWorkerType") != "")
                    {
                        strkeyWorkerType = items.Value<string>("keyWorkerType");
                    }
                    strCreatedDate = items.CreateDate;

                        str.Append("<tr>");
                        str.Append("<td><font face=Arial Narrow size=" + "14px" + ">" + strname + "</font></td>");
                    str.Append("<td><font face=Arial Narrow size=" + "14px" + ">" + strphoneNumber + "</font></td>");
                    str.Append("<td><font face=Arial Narrow size=" + "14px" + ">" + strEmail + "</font></td>");
                        str.Append("<td><font face=Arial Narrow size=" + "14px" + ">" + strDescription + "</font></td>");
                        str.Append("<td><font face=Arial Narrow size=" + "14px" + ">" + straboutLina + "</font></td>");
                    str.Append("<td><font face=Arial Narrow size=" + "14px" + ">" + KeyWorker + "</font></td>");
                    str.Append("<td><font face=Arial Narrow size=" + "14px" + ">" + strkeyWorkerType + "</font></td>");
                    str.Append("<td><font face=Arial Narrow size=" + "14px" + ">" + strCreatedDate + "</font></td>");
                        str.Append("</tr>");
                    }
                    str.Append("</table>");
                }
                else if(Contactchilditems.Count() == 0)
                {
                    str.Append("<table border=`" + "1px" + ">");
                    str.Append("<tr>");
                    str.Append("<td><font face=Arial Narrow size=" + "14px" + ">" + "No Record found" + "</font></td>");
                    str.Append("</tr>");
                    str.Append("</table>");
                }


                HttpContext.Response.Headers.Add("content-disposition", "attachment; filename=LINA-CONTACT-INFORMATION-" + DateTime.Now.Year.ToString() + ".xls");
           
                this.Response.ContentType = "application/vnd.ms-excel";

            byte[] temp = System.Text.Encoding.UTF8.GetBytes(str.ToString());
            return File(temp, "application/vnd.ms-excel");

        }

       
    }
}