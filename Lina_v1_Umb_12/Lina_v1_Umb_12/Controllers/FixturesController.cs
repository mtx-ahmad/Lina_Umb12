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
using Lina_v1_Umb_12.Models;
using Umbraco.Cms.Core.Models.PublishedContent;
using System.Text.Json;
using Umbraco.Cms.Core.Models;

namespace Lina_v1_Umb_12.Controllers
{
    public class FixturesController : UmbracoApiController
    {
        private readonly IPublishedContentQuery _publishedContentQuery;
        private readonly IContentService _contentService;
        private readonly IScopeProvider _scopeProvider;
        private Microsoft.AspNetCore.Hosting.IHostingEnvironment _hostingEnvironment;

        public FixturesController(
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
        public string GetFixturesPageContent()
        {
            var Homepage = _publishedContentQuery.Content(1062);
            var availableText = Homepage != null && Homepage.HasValue("availableText") && Homepage.Value("availableText") != null ? Homepage.Value<string>("availableText") : "";
            var leftButtonText = Homepage != null && Homepage.HasValue("leftButtonText") && Homepage.Value("leftButtonText") != null ? Homepage.Value<string>("leftButtonText") : "";
            var rightButtonText = Homepage != null && Homepage.HasValue("rightButtonText") && Homepage.Value("rightButtonText") != null ? Homepage.Value<string>("rightButtonText") : "";
            IEnumerable<Link> lstheaderLinks = Homepage != null && Homepage.HasValue("headerLinks") && Homepage.Value<IEnumerable<Link>>("headerLinks") != null ? Homepage.Value<IEnumerable<Link>>("headerLinks") : null;
            var strleftLink = Homepage != null && Homepage.HasValue("leftLink") && Homepage.Value("leftLink") != null ? Homepage.Value<Link>("leftLink") : null;
            var strrightLink = Homepage != null && Homepage.HasValue("rightLink") && Homepage.Value("rightLink") != null ? Homepage.Value<Link>("rightLink") : null;

            var Fixturespage = _publishedContentQuery.Content(1113);
            var SeoTitle = Fixturespage != null && Fixturespage.HasValue("seoTitle") && Fixturespage.Value("seoTitle") != null ? Fixturespage.Value<string>("seoTitle") : "";
            var SeoDescription = Fixturespage != null && Fixturespage.HasValue("seoDescription") && Fixturespage.Value("seoDescription") != null ? Fixturespage.Value<string>("seoDescription") : "";
            var SharingImage = Fixturespage != null && Fixturespage.HasValue("sharingImage") && Fixturespage.Value<IPublishedContent>("sharingImage") != null ? Fixturespage.Value<IPublishedContent>("sharingImage").Url() : "";
            var SharingImageAlt = Fixturespage != null && Fixturespage.HasValue("sharingImageAlt") && Fixturespage.Value("sharingImageAlt") != null ? Fixturespage.Value<string>("sharingImageAlt") : "";
            
            var centerText = Fixturespage != null && Fixturespage.HasValue("centerText") && Fixturespage.Value("centerText") != null ? Fixturespage.Value<string>("centerText") : "";
            var leftCentertImage = Fixturespage != null && Fixturespage.HasValue("leftCentertImage") && Fixturespage.Value<IPublishedContent>("leftCentertImage") != null ? Fixturespage.Value<IPublishedContent>("leftCentertImage").Url() : "";
            var leftCentertImageAlt = Fixturespage != null && Fixturespage.HasValue("leftCentertImageAlt") && Fixturespage.Value("leftCentertImageAlt") != null ? Fixturespage.Value<string>("leftCentertImageAlt") : "";
            var leftPicture = Fixturespage != null && Fixturespage.HasValue("leftPicture") && Fixturespage.Value<IPublishedContent>("leftPicture") != null ? Fixturespage.Value<IPublishedContent>("leftPicture").Url() : "";
            var leftPictureAlt = Fixturespage != null && Fixturespage.HasValue("leftPictureAlt") && Fixturespage.Value("leftPictureAlt") != null ? Fixturespage.Value<string>("leftPictureAlt") : "";
            var rightPicture = Fixturespage != null && Fixturespage.HasValue("rightPicture") && Fixturespage.Value<IPublishedContent>("rightPicture") != null ? Fixturespage.Value<IPublishedContent>("rightPicture").Url() : "";
            var rightPictureAlt = Fixturespage != null && Fixturespage.HasValue("rightPictureAlt") && Fixturespage.Value("rightPictureAlt") != null ? Fixturespage.Value<string>("rightPictureAlt") : "";

            var leftText = Fixturespage != null && Fixturespage.HasValue("leftText") && Fixturespage.Value("leftText") != null ? Fixturespage.Value<string>("leftText") : "";
            var rightText = Fixturespage != null && Fixturespage.HasValue("rightText") && Fixturespage.Value("rightText") != null ? Fixturespage.Value<string>("rightText") : "";
            var leftFirstText = Fixturespage != null && Fixturespage.HasValue("leftFirstText") && Fixturespage.Value("leftFirstText") != null ? Fixturespage.Value<string>("leftFirstText") : "";
            var rightLargeImage = Fixturespage != null && Fixturespage.HasValue("rightLargeImage") && Fixturespage.Value<IPublishedContent>("rightLargeImage") != null ? Fixturespage.Value<IPublishedContent>("rightLargeImage").Url() : "";
            var rightLargeImageAlt = Fixturespage != null && Fixturespage.HasValue("rightLargeImageAlt") && Fixturespage.Value("rightLargeImageAlt") != null ? Fixturespage.Value<string>("rightLargeImageAlt") : "";
            var leftFirstImage = Fixturespage != null && Fixturespage.HasValue("leftFirstImage") && Fixturespage.Value<IPublishedContent>("leftFirstImage") != null ? Fixturespage.Value<IPublishedContent>("leftFirstImage").Url() : "";
            var leftFirstImageAlt = Fixturespage != null && Fixturespage.HasValue("leftFirstImageAlt") && Fixturespage.Value("leftFirstImageAlt") != null ? Fixturespage.Value<string>("leftFirstImageAlt") : "";
            var leftSecondImage = Fixturespage != null && Fixturespage.HasValue("leftSecondImage") && Fixturespage.Value<IPublishedContent>("leftSecondImage") != null ? Fixturespage.Value<IPublishedContent>("leftSecondImage").Url() : "";
            var leftSecondImageAlt = Fixturespage != null && Fixturespage.HasValue("leftSecondImageAlt") && Fixturespage.Value("leftSecondImageAlt") != null ? Fixturespage.Value<string>("leftSecondImageAlt") : "";
            var leftSecondText = Fixturespage != null && Fixturespage.HasValue("leftSecondText") && Fixturespage.Value("leftSecondText") != null ? Fixturespage.Value<string>("leftSecondText") : "";
            var rightImage = Fixturespage != null && Fixturespage.HasValue("rightImage") && Fixturespage.Value<IPublishedContent>("rightImage") != null ? Fixturespage.Value<IPublishedContent>("rightImage").Url() : "";
            var rightImageAlt = Fixturespage != null && Fixturespage.HasValue("rightImageAlt") && Fixturespage.Value("rightImageAlt") != null ? Fixturespage.Value<string>("rightImageAlt") : "";
            var rightImageText = Fixturespage != null && Fixturespage.HasValue("rightImageText") && Fixturespage.Value<IPublishedContent>("rightImageText") != null ? Fixturespage.Value<IPublishedContent>("rightImageText").Url() : "";

            var objFixturespageContent = new FixturesPage
            {
                seoTitle = SeoTitle,
                seoDescription = SeoDescription,
                sharingImage = SharingImage,
                sharingImageAlt = SharingImageAlt,
                leftText = leftText,
                leftFirstImage = leftFirstImage,
                leftFirstImageAlt = leftFirstImageAlt,
                leftFirstText = leftFirstText,
                leftSecondImage = leftSecondImage,
                leftSecondImageAlt = leftSecondImageAlt,
                rightImage = rightImage,
                rightImageAlt = rightImageAlt,
                leftSecondText = leftSecondText,
                rightImageText = rightImageText,
                centerText = centerText,
                leftPicture = leftPicture,
                leftPictureAlt = leftPictureAlt,
                rightPicture = rightPicture,
                rightPictureAlt = rightPictureAlt,
                rightText = rightText,
                rightLargeImage = rightLargeImage,
                rightLargeImageAlt = rightLargeImageAlt,
                leftCenterImage = leftCentertImage,
                leftCenterImageAlt = leftCentertImageAlt,
                availableText = availableText,
                leftButtonText = leftButtonText,
                rightButtonText = rightButtonText,
                lstheaderLinks = lstheaderLinks,
                leftLink = strleftLink,
                rightLink = strrightLink
            };
            string strJson = JsonSerializer.Serialize<FixturesPage>(objFixturespageContent);

            return strJson;

        }
    }
}
