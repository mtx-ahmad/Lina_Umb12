using Microsoft.AspNetCore.Mvc;
using Umbraco.Cms.Core.Cache;
using Umbraco.Cms.Core.Logging;
using Umbraco.Cms.Core.Routing;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Core;
using Umbraco.Cms.Infrastructure.Persistence;
using Umbraco.Cms.Web.Common.Controllers;
using Umbraco.Cms.Core.Scoping;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.Models;
using Lina_v1_Umb_12.Models;
using System.Text.Json;

namespace Lina_v1_Umb_12.Controllers
{
    public class PrivacyPolicyController : UmbracoApiController
    {
        private readonly IPublishedContentQuery _publishedContentQuery;
        private readonly IContentService _contentService;
        private readonly IScopeProvider _scopeProvider;
        private Microsoft.AspNetCore.Hosting.IHostingEnvironment _hostingEnvironment;

        public PrivacyPolicyController(
            Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnvironment,
            IUmbracoContextAccessor umbracoContextAccessor,
            IUmbracoDatabaseFactory databaseFactory,
            ServiceContext services,
            AppCaches appCaches,
            IProfilingLogger profilingLogger,
            IPublishedUrlProvider publishedUrlProvider,
            IPublishedContentQuery publishedContentQuery,
            Microsoft.AspNetCore.Hosting.IHostingEnvironment _environment,
            IContentService contentService, IScopeProvider scopeProvider
            )
        {
            _publishedContentQuery = publishedContentQuery;
            _contentService = contentService;
            _scopeProvider = scopeProvider;
            _hostingEnvironment = hostingEnvironment;
        }
        public string GetPrivacyPolicyPageContent()
        {
            var Homepage = _publishedContentQuery.Content(1062);
            var availableText = Homepage != null && Homepage.HasValue("availableText") && Homepage.Value("availableText") != null ? Homepage.Value<string>("availableText") : "";
            var leftButtonText = Homepage != null && Homepage.HasValue("leftButtonText") && Homepage.Value("leftButtonText") != null ? Homepage.Value<string>("leftButtonText") : "";
            var rightButtonText = Homepage != null && Homepage.HasValue("rightButtonText") && Homepage.Value("rightButtonText") != null ? Homepage.Value<string>("rightButtonText") : "";
            IEnumerable<Link> lstheaderLinks = Homepage != null && Homepage.HasValue("headerLinks") && Homepage.Value<IEnumerable<Link>>("headerLinks") != null ? Homepage.Value<IEnumerable<Link>>("headerLinks") : null;
            var strleftLink = Homepage != null && Homepage.HasValue("leftLink") && Homepage.Value("leftLink") != null ? Homepage.Value<Link>("leftLink") : null;
            var strrightLink = Homepage != null && Homepage.HasValue("rightLink") && Homepage.Value("rightLink") != null ? Homepage.Value<Link>("rightLink") : null;

            var PrivacyPolicypage = _publishedContentQuery.Content(1120);
            var SeoTitle = PrivacyPolicypage != null && PrivacyPolicypage.HasValue("seoTitle") && PrivacyPolicypage.Value("seoTitle") != null ? PrivacyPolicypage.Value<string>("seoTitle") : "";
            var SeoDescription = PrivacyPolicypage != null && PrivacyPolicypage.HasValue("seoDescription") && PrivacyPolicypage.Value("seoDescription") != null ? PrivacyPolicypage.Value<string>("seoDescription") : "";
            var SharingImage = PrivacyPolicypage != null && PrivacyPolicypage.HasValue("sharingImage") && PrivacyPolicypage.Value<IPublishedContent>("sharingImage") != null ? PrivacyPolicypage.Value<IPublishedContent>("sharingImage").Url() : "";
            var SharingImageAlt = PrivacyPolicypage != null && PrivacyPolicypage.HasValue("sharingImageAlt") && PrivacyPolicypage.Value("sharingImageAlt") != null ? PrivacyPolicypage.Value<string>("sharingImageAlt") : "";

            var description = PrivacyPolicypage != null && PrivacyPolicypage.HasValue("description") && PrivacyPolicypage.Value("description") != null ? PrivacyPolicypage.Value<string>("description") : "";

            var objPrivacyPolicypageContent = new PrivacyPolicyPage
            {
                seoTitle = SeoTitle,
                seoDescription = SeoDescription,
                sharingImage = SharingImage,
                sharingImageAlt = SharingImageAlt,
                description = description,
                availableText = availableText,
                leftButtonText = leftButtonText,
                rightButtonText = rightButtonText,
                lstheaderLinks = lstheaderLinks,
                leftLink = strleftLink,
                rightLink = strrightLink
            };
            string strJson = JsonSerializer.Serialize<PrivacyPolicyPage>(objPrivacyPolicypageContent);

            return strJson;

        }
    }
}
