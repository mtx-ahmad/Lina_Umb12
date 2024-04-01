using Microsoft.AspNetCore.Mvc;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Core;
using Umbraco.Cms.Web.Common.Controllers;
using Umbraco.Cms.Core.Scoping;
using Lina_v1_Umb_12.Models;
using System.Text.Json;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.Cache;
using Umbraco.Cms.Core.Logging;
using Umbraco.Cms.Core.Routing;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Infrastructure.Persistence;
using Umbraco.Cms.Core.Models.Blocks;
using Umbraco.Cms.Core.Models;

namespace Lina_v1_Umb_12.Controllers
{
    public class ActonController : UmbracoApiController
    {
        private readonly IPublishedContentQuery _publishedContentQuery;
        private readonly IContentService _contentService;
        private readonly IScopeProvider _scopeProvider;
        private Microsoft.AspNetCore.Hosting.IHostingEnvironment _hostingEnvironment;

        public ActonController(
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

        public string GetActonPageContent()
        {
            var Homepage = _publishedContentQuery.Content(1062);
            var availableText = Homepage != null && Homepage.HasValue("availableText") && Homepage.Value("availableText") != null ? Homepage.Value<string>("availableText") : "";
            var leftButtonText = Homepage != null && Homepage.HasValue("leftButtonText") && Homepage.Value("leftButtonText") != null ? Homepage.Value<string>("leftButtonText") : "";
            var rightButtonText = Homepage != null && Homepage.HasValue("rightButtonText") && Homepage.Value("rightButtonText") != null ? Homepage.Value<string>("rightButtonText") : "";
            IEnumerable<Link> lstheaderLinks = Homepage != null && Homepage.HasValue("headerLinks") && Homepage.Value<IEnumerable<Link>>("headerLinks") != null ? Homepage.Value<IEnumerable<Link>>("headerLinks") : null;
            var strleftLink = Homepage != null && Homepage.HasValue("leftLink") && Homepage.Value("leftLink") != null ? Homepage.Value<Link>("leftLink") : null;
            var strrightLink = Homepage != null && Homepage.HasValue("rightLink") && Homepage.Value("rightLink") != null ? Homepage.Value<Link>("rightLink") : null;
            
            var Actonpage = _publishedContentQuery.Content(1099);
            var SeoTitle = Actonpage != null && Actonpage.HasValue("seoTitle") && Actonpage.Value("seoTitle") != null ? Actonpage.Value<string>("seoTitle") : "";
            var SeoDescription = Actonpage != null && Actonpage.HasValue("seoDescription") && Actonpage.Value("seoDescription") != null ? Actonpage.Value<string>("seoDescription") : "";
            var SharingImage = Actonpage != null && Actonpage.HasValue("sharingImage") && Actonpage.Value<IPublishedContent>("sharingImage") != null ? Actonpage.Value<IPublishedContent>("sharingImage").Url() : "";
            var SharingImageAlt = Actonpage != null && Actonpage.HasValue("sharingImageAlt") && Actonpage.Value("sharingImageAlt") != null ? Actonpage.Value<string>("sharingImageAlt") : "";
            var headerImage = Actonpage != null && Actonpage.HasValue("headerImage") && Actonpage.Value<IPublishedContent>("headerImage") != null ? Actonpage.Value<IPublishedContent>("headerImage").Url() : "";
            var headerImageAlt = Actonpage != null && Actonpage.HasValue("headerImageAlt") && Actonpage.Value("headerImageAlt") != null ? Actonpage.Value<string>("headerImageAlt") : "";
            var textImage = Actonpage != null && Actonpage.HasValue("textImage") && Actonpage.Value<IPublishedContent>("textImage") != null ? Actonpage.Value<IPublishedContent>("textImage").Url() : "";
            var textImageAlt = Actonpage != null && Actonpage.HasValue("textImageAlt") && Actonpage.Value("textImageAlt") != null ? Actonpage.Value<string>("textImageAlt") : "";
            var logo = Actonpage != null && Actonpage.HasValue("logo") && Actonpage.Value<IPublishedContent>("logo") != null ? Actonpage.Value<IPublishedContent>("logo").Url() : "";
            var logoAlt = Actonpage != null && Actonpage.HasValue("logoAlt") && Actonpage.Value("logoAlt") != null ? Actonpage.Value<string>("logoAlt") : "";
            var BottomCaption = Actonpage != null && Actonpage.HasValue("bottomCaption") && Actonpage.Value("bottomCaption") != null ? Actonpage.Value<string>("bottomCaption") : "";

            var leftText = Actonpage != null && Actonpage.HasValue("leftText") && Actonpage.Value("leftText") != null ? Actonpage.Value<string>("leftText") : "";
            var lstrightImages = Actonpage.Value<IEnumerable<BlockListItem>>("rightImages");

            List<RightImages> rightImages = new List<RightImages>();
            if (lstrightImages != null)
            {
                foreach (var images in lstrightImages)
                {
                    string image = "", imageAlt = "";
                    if (images.Content.HasProperty("image") && images.Content.Value("image") != null && images.Content.Value<string>("image") != "")
                    {
                        image = images.Content.Value<IPublishedContent>("image").Url();
                    }
                    if (images.Content.HasProperty("imageAlt") && images.Content.Value("imageAlt") != null && images.Content.Value<string>("imageAlt") != "")
                    {
                        imageAlt = images.Content.Value<string>("imageAlt");
                    }
                    rightImages.Add(new RightImages
                    {
                        image = image,
                        imageAlt = imageAlt
                    });
                }
            }
            var objActonPageContent = new ActonPage
            {
                seoTitle = SeoTitle,
                seoDescription = SeoDescription,
                sharingImage = SharingImage,
                sharingImageAlt = SharingImageAlt,
                headerImage = headerImage,
                headerImageAlt = headerImageAlt,
                textImage = textImage,
                textImageAlt = textImageAlt,
                logo = logo,
                logoAlt = logoAlt,
                bottomCaption = BottomCaption,
                leftText = leftText,
                rightImages = rightImages,
                availableText = availableText,
                leftButtonText = leftButtonText,
                rightButtonText = rightButtonText,
                lstheaderLinks = lstheaderLinks,
                leftLink = strleftLink,
                rightLink = strrightLink

            };
            string strJson = JsonSerializer.Serialize<ActonPage>(objActonPageContent);

            return strJson;

        }
    }
}
