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
using Umbraco.Cms.Core.Models.Blocks;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.Models;
using System.Text.Json;

namespace Lina_v1_Umb_12.Controllers
{
    public class FinishesController : UmbracoApiController
    {
        private readonly IPublishedContentQuery _publishedContentQuery;
        private readonly IContentService _contentService;
        private readonly IScopeProvider _scopeProvider;
        private Microsoft.AspNetCore.Hosting.IHostingEnvironment _hostingEnvironment;

        public FinishesController(
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
        public string GetFinishesPageContent()
        {
            var Homepage = _publishedContentQuery.Content(1062);
            var availableText = Homepage != null && Homepage.HasValue("availableText") && Homepage.Value("availableText") != null ? Homepage.Value<string>("availableText") : "";
            var leftButtonText = Homepage != null && Homepage.HasValue("leftButtonText") && Homepage.Value("leftButtonText") != null ? Homepage.Value<string>("leftButtonText") : "";
            var rightButtonText = Homepage != null && Homepage.HasValue("rightButtonText") && Homepage.Value("rightButtonText") != null ? Homepage.Value<string>("rightButtonText") : "";
            IEnumerable<Link> lstheaderLinks = Homepage != null && Homepage.HasValue("headerLinks") && Homepage.Value<IEnumerable<Link>>("headerLinks") != null ? Homepage.Value<IEnumerable<Link>>("headerLinks") : null;
            var strleftLink = Homepage != null && Homepage.HasValue("leftLink") && Homepage.Value("leftLink") != null ? Homepage.Value<Link>("leftLink") : null;
            var strrightLink = Homepage != null && Homepage.HasValue("rightLink") && Homepage.Value("rightLink") != null ? Homepage.Value<Link>("rightLink") : null;

            var Finishespage = _publishedContentQuery.Content(1110);
            var SeoTitle = Finishespage != null && Finishespage.HasValue("seoTitle") && Finishespage.Value("seoTitle") != null ? Finishespage.Value<string>("seoTitle") : "";
            var SeoDescription = Finishespage != null && Finishespage.HasValue("seoDescription") && Finishespage.Value("seoDescription") != null ? Finishespage.Value<string>("seoDescription") : "";
            var SharingImage = Finishespage != null && Finishespage.HasValue("sharingImage") && Finishespage.Value<IPublishedContent>("sharingImage") != null ? Finishespage.Value<IPublishedContent>("sharingImage").Url() : "";
            var SharingImageAlt = Finishespage != null && Finishespage.HasValue("sharingImageAlt") && Finishespage.Value("sharingImageAlt") != null ? Finishespage.Value<string>("sharingImageAlt") : "";
            var headerImage = Finishespage != null && Finishespage.HasValue("headerImage") && Finishespage.Value<IPublishedContent>("headerImage") != null ? Finishespage.Value<IPublishedContent>("headerImage").Url() : "";
            var headerImageAlt = Finishespage != null && Finishespage.HasValue("headerImageAlt") && Finishespage.Value("headerImageAlt") != null ? Finishespage.Value<string>("headerImageAlt") : "";
            var headerImageMobile = Finishespage != null && Finishespage.HasValue("headerImageMobile") && Finishespage.Value<IPublishedContent>("headerImageMobile") != null ? Finishespage.Value<IPublishedContent>("headerImageMobile").Url() : "";
            var headerImageMobileAlt = Finishespage != null && Finishespage.HasValue("headerImageMobileAlt") && Finishespage.Value("headerImageMobileAlt") != null ? Finishespage.Value<string>("headerImageMobileAlt") : "";
            var centerText = Finishespage != null && Finishespage.HasValue("centerText") && Finishespage.Value("centerText") != null ? Finishespage.Value<string>("centerText") : "";
            var leftImage = Finishespage != null && Finishespage.HasValue("leftImage") && Finishespage.Value<IPublishedContent>("leftImage") != null ? Finishespage.Value<IPublishedContent>("leftImage").Url() : "";
            var leftImageAlt = Finishespage != null && Finishespage.HasValue("leftImageAlt") && Finishespage.Value("leftImageAlt") != null ? Finishespage.Value<string>("leftImageAlt") : "";
            var leftCenterText = Finishespage != null && Finishespage.HasValue("leftCenterText") && Finishespage.Value("leftCenterText") != null ? Finishespage.Value<string>("leftCenterText") : "";
            var leftSmallImage = Finishespage != null && Finishespage.HasValue("leftSmallImage") && Finishespage.Value<IPublishedContent>("leftSmallImage") != null ? Finishespage.Value<IPublishedContent>("leftSmallImage").Url() : "";
            var leftSmallImageAlt = Finishespage != null && Finishespage.HasValue("leftSmallImageAlt") && Finishespage.Value("leftSmallImageAlt") != null ? Finishespage.Value<string>("leftSmallImageAlt") : "";
            var leftBelowText = Finishespage != null && Finishespage.HasValue("leftBelowText") && Finishespage.Value("leftBelowText") != null ? Finishespage.Value<string>("leftBelowText") : "";
            var leftPicture = Finishespage != null && Finishespage.HasValue("leftPicture") && Finishespage.Value<IPublishedContent>("leftPicture") != null ? Finishespage.Value<IPublishedContent>("leftPicture").Url() : "";
            var leftPictureAlt = Finishespage != null && Finishespage.HasValue("leftPictureAlt") && Finishespage.Value("leftPictureAlt") != null ? Finishespage.Value<string>("leftPictureAlt") : "";
            var rightPicture = Finishespage != null && Finishespage.HasValue("rightPicture") && Finishespage.Value<IPublishedContent>("rightPicture") != null ? Finishespage.Value<IPublishedContent>("rightPicture").Url() : "";
            var rightPictureAlt = Finishespage != null && Finishespage.HasValue("rightPictureAlt") && Finishespage.Value("rightPictureAlt") != null ? Finishespage.Value<string>("rightPictureAlt") : "";
            var centerInfo = Finishespage != null && Finishespage.HasValue("centerInfo") && Finishespage.Value("centerInfo") != null ? Finishespage.Value<string>("centerInfo") : "";
            var rightText = Finishespage != null && Finishespage.HasValue("rightText") && Finishespage.Value("rightText") != null ? Finishespage.Value<string>("rightText") : "";
            var rightLargeImage = Finishespage != null && Finishespage.HasValue("rightLargeImage") && Finishespage.Value<IPublishedContent>("rightLargeImage") != null ? Finishespage.Value<IPublishedContent>("rightLargeImage").Url() : "";
            var rightLargeImageAlt = Finishespage != null && Finishespage.HasValue("rightLargeImageAlt") && Finishespage.Value("rightLargeImageAlt") != null ? Finishespage.Value<string>("rightLargeImageAlt") : "";
            var leftLargeImage = Finishespage != null && Finishespage.HasValue("leftLargeImage") && Finishespage.Value<IPublishedContent>("leftLargeImage") != null ? Finishespage.Value<IPublishedContent>("leftLargeImage").Url() : "";
            var leftLargeImageAlt = Finishespage != null && Finishespage.HasValue("leftLargeImageAlt") && Finishespage.Value("leftLargeImageAlt") != null ? Finishespage.Value<string>("leftLargeImageAlt") : "";
            var leftLargeImageText = Finishespage != null && Finishespage.HasValue("leftLargeImageText") && Finishespage.Value("leftLargeImageText") != null ? Finishespage.Value<string>("leftLargeImageText") : "";
            var smallImage = Finishespage != null && Finishespage.HasValue("smallImage") && Finishespage.Value<IPublishedContent>("smallImage") != null ? Finishespage.Value<IPublishedContent>("smallImage").Url() : "";
            var smallImageAlt = Finishespage != null && Finishespage.HasValue("smallImageAlt") && Finishespage.Value("smallImageAlt") != null ? Finishespage.Value<string>("smallImageAlt") : "";

            var objFinishespageContent = new FinishesPage
            {
                seoTitle = SeoTitle,
                seoDescription = SeoDescription,
                sharingImage = SharingImage,
                sharingImageAlt = SharingImageAlt,
                headerImage = headerImage,
                headerImageAlt = headerImageAlt,
                headerImageMobile = headerImageMobile,
                headerImageMobileAlt = headerImageMobileAlt,
                centerText = centerText,
                leftImage = leftImage,
                leftImageAlt = leftImageAlt,
                leftCenterText = leftCenterText,
                leftSmallImage = leftSmallImage,
                leftSmallImageAlt = leftSmallImageAlt,
                leftBelowText = leftBelowText,
                leftPicture = leftPicture,
                leftPictureAlt = leftPictureAlt,
                rightPicture = rightPicture,
                rightPictureAlt = rightPictureAlt,
                centerInfo = centerInfo,
                rightText = rightText,
                rightLargeImage = rightLargeImage,
                rightLargeImageAlt = rightLargeImageAlt,
                leftLargeImage = leftLargeImage,
                leftLargeImageAlt = leftLargeImageAlt,
                leftLargeImageText = leftLargeImageText,
                smallImage = smallImage,
                smallImageAlt = smallImageAlt,
                availableText = availableText,
                leftButtonText = leftButtonText,
                rightButtonText = rightButtonText,
                lstheaderLinks = lstheaderLinks,
                leftLink = strleftLink,
                rightLink = strrightLink
            };
            string strJson = JsonSerializer.Serialize<FinishesPage>(objFinishespageContent);

            return strJson;

        }
    }
}
