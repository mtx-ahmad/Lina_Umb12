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
using Umbraco.Cms.Core.Models.Blocks;

namespace Lina_v1_Umb_12.Controllers
{
    public class NeighbourhoodController : UmbracoApiController
    {
        private readonly IPublishedContentQuery _publishedContentQuery;
        private readonly IContentService _contentService;
        private readonly IScopeProvider _scopeProvider;
        private Microsoft.AspNetCore.Hosting.IHostingEnvironment _hostingEnvironment;

        public NeighbourhoodController(
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
        public string GetNeighbourhoodPageContent()
        {
            var Homepage = _publishedContentQuery.Content(1062);
            var availableText = Homepage != null && Homepage.HasValue("availableText") && Homepage.Value("availableText") != null ? Homepage.Value<string>("availableText") : "";
            var leftButtonText = Homepage != null && Homepage.HasValue("leftButtonText") && Homepage.Value("leftButtonText") != null ? Homepage.Value<string>("leftButtonText") : "";
            var rightButtonText = Homepage != null && Homepage.HasValue("rightButtonText") && Homepage.Value("rightButtonText") != null ? Homepage.Value<string>("rightButtonText") : "";
            IEnumerable<Link> lstheaderLinks = Homepage != null && Homepage.HasValue("headerLinks") && Homepage.Value<IEnumerable<Link>>("headerLinks") != null ? Homepage.Value<IEnumerable<Link>>("headerLinks") : null;
            var strleftLink = Homepage != null && Homepage.HasValue("leftLink") && Homepage.Value("leftLink") != null ? Homepage.Value<Link>("leftLink") : null;
            var strrightLink = Homepage != null && Homepage.HasValue("rightLink") && Homepage.Value("rightLink") != null ? Homepage.Value<Link>("rightLink") : null;

            var Neighbourhoodpage = _publishedContentQuery.Content(1116);
            var SeoTitle = Neighbourhoodpage != null && Neighbourhoodpage.HasValue("seoTitle") && Neighbourhoodpage.Value("seoTitle") != null ? Neighbourhoodpage.Value<string>("seoTitle") : "";
            var SeoDescription = Neighbourhoodpage != null && Neighbourhoodpage.HasValue("seoDescription") && Neighbourhoodpage.Value("seoDescription") != null ? Neighbourhoodpage.Value<string>("seoDescription") : "";
            var SharingImage = Neighbourhoodpage != null && Neighbourhoodpage.HasValue("sharingImage") && Neighbourhoodpage.Value<IPublishedContent>("sharingImage") != null ? Neighbourhoodpage.Value<IPublishedContent>("sharingImage").Url() : "";
            var SharingImageAlt = Neighbourhoodpage != null && Neighbourhoodpage.HasValue("sharingImageAlt") && Neighbourhoodpage.Value("sharingImageAlt") != null ? Neighbourhoodpage.Value<string>("sharingImageAlt") : "";

            var headerImage = Neighbourhoodpage != null && Neighbourhoodpage.HasValue("headerImage") && Neighbourhoodpage.Value<IPublishedContent>("headerImage") != null ? Neighbourhoodpage.Value<IPublishedContent>("headerImage").Url() : "";
            var headerImageAlt = Neighbourhoodpage != null && Neighbourhoodpage.HasValue("headerImageAlt") && Neighbourhoodpage.Value("headerImageAlt") != null ? Neighbourhoodpage.Value<string>("headerImageAlt") : "";
            var logoText = Neighbourhoodpage != null && Neighbourhoodpage.HasValue("logoText") && Neighbourhoodpage.Value<IPublishedContent>("logoText") != null ? Neighbourhoodpage.Value<IPublishedContent>("logoText").Url() : "";
            var logoTextAlt = Neighbourhoodpage != null && Neighbourhoodpage.HasValue("logoTextAlt") && Neighbourhoodpage.Value("logoTextAlt") != null ? Neighbourhoodpage.Value<string>("logoTextAlt") : "";
            var leftTopText = Neighbourhoodpage != null && Neighbourhoodpage.HasValue("leftTopText") && Neighbourhoodpage.Value("leftTopText") != null ? Neighbourhoodpage.Value<string>("leftTopText") : "";
            var leftDescription = Neighbourhoodpage != null && Neighbourhoodpage.HasValue("leftDescription") && Neighbourhoodpage.Value("leftDescription") != null ? Neighbourhoodpage.Value<string>("leftDescription") : "";
            
            var lstmultiImages = Neighbourhoodpage.Value<IEnumerable<BlockListItem>>("multiImages");
            List<NeighbourhoodMultiImages> multiImages = new List<NeighbourhoodMultiImages>();
            if (lstmultiImages != null)
            {
                foreach (var images in lstmultiImages)
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
                    multiImages.Add(new NeighbourhoodMultiImages
                    {
                        image = image,
                        imageAlt = imageAlt
                    });
                }
            }
            var heading = Neighbourhoodpage != null && Neighbourhoodpage.HasValue("heading") && Neighbourhoodpage.Value("heading") != null ? Neighbourhoodpage.Value<string>("heading") : "";
            var leftStandFirst = Neighbourhoodpage != null && Neighbourhoodpage.HasValue("leftStandFirst") && Neighbourhoodpage.Value("leftStandFirst") != null ? Neighbourhoodpage.Value<string>("leftStandFirst") : "";
            var rightSmallImage = Neighbourhoodpage != null && Neighbourhoodpage.HasValue("rightSmallImage") && Neighbourhoodpage.Value<IPublishedContent>("rightSmallImage") != null ? Neighbourhoodpage.Value<IPublishedContent>("rightSmallImage").Url() : "";
            var rightSmallImageAlt = Neighbourhoodpage != null && Neighbourhoodpage.HasValue("rightSmallImageAlt") && Neighbourhoodpage.Value("rightSmallImageAlt") != null ? Neighbourhoodpage.Value<string>("rightSmallImageAlt") : "";
            var leftSmallImage = Neighbourhoodpage != null && Neighbourhoodpage.HasValue("leftSmallImage") && Neighbourhoodpage.Value<IPublishedContent>("leftSmallImage") != null ? Neighbourhoodpage.Value<IPublishedContent>("leftSmallImage").Url() : "";
            var leftSmallImageAlt = Neighbourhoodpage != null && Neighbourhoodpage.HasValue("leftSmallImageAlt") && Neighbourhoodpage.Value("leftSmallImageAlt") != null ? Neighbourhoodpage.Value<string>("leftSmallImageAlt") : "";
            var rightStandFirst = Neighbourhoodpage != null && Neighbourhoodpage.HasValue("rightStandFirst") && Neighbourhoodpage.Value("rightStandFirst") != null ? Neighbourhoodpage.Value<string>("rightStandFirst") : "";
            var leftIntro = Neighbourhoodpage != null && Neighbourhoodpage.HasValue("leftIntro") && Neighbourhoodpage.Value("leftIntro") != null ? Neighbourhoodpage.Value<string>("leftIntro") : "";
            var rightImage = Neighbourhoodpage != null && Neighbourhoodpage.HasValue("rightImage") && Neighbourhoodpage.Value<IPublishedContent>("rightImage") != null ? Neighbourhoodpage.Value<IPublishedContent>("rightImage").Url() : "";
            var rightImageAlt = Neighbourhoodpage != null && Neighbourhoodpage.HasValue("rightImageAlt") && Neighbourhoodpage.Value("rightImageAlt") != null ? Neighbourhoodpage.Value<string>("rightImageAlt") : "";
            var leftShortImage = Neighbourhoodpage != null && Neighbourhoodpage.HasValue("leftShortImage") && Neighbourhoodpage.Value<IPublishedContent>("leftShortImage") != null ? Neighbourhoodpage.Value<IPublishedContent>("leftShortImage").Url() : "";
            var leftShortImageAlt = Neighbourhoodpage != null && Neighbourhoodpage.HasValue("leftShortImageAlt") && Neighbourhoodpage.Value("leftShortImageAlt") != null ? Neighbourhoodpage.Value<string>("leftShortImageAlt") : "";
            var rightLargeImage = Neighbourhoodpage != null && Neighbourhoodpage.HasValue("rightLargeImage") && Neighbourhoodpage.Value<IPublishedContent>("rightLargeImage") != null ? Neighbourhoodpage.Value<IPublishedContent>("rightLargeImage").Url() : "";
            var rightLargeImageAlt = Neighbourhoodpage != null && Neighbourhoodpage.HasValue("rightLargeImageAlt") && Neighbourhoodpage.Value("rightLargeImageAlt") != null ? Neighbourhoodpage.Value<string>("rightLargeImageAlt") : "";
            var leftText = Neighbourhoodpage != null && Neighbourhoodpage.HasValue("leftText") && Neighbourhoodpage.Value("leftText") != null ? Neighbourhoodpage.Value<string>("leftText") : "";
            var rightShortImage = Neighbourhoodpage != null && Neighbourhoodpage.HasValue("rightShortImage") && Neighbourhoodpage.Value<IPublishedContent>("rightShortImage") != null ? Neighbourhoodpage.Value<IPublishedContent>("rightShortImage").Url() : "";
            var rightShortImageAlt = Neighbourhoodpage != null && Neighbourhoodpage.HasValue("rightShortImageAlt") && Neighbourhoodpage.Value("rightShortImageAlt") != null ? Neighbourhoodpage.Value<string>("rightShortImageAlt") : "";
            
            var objNeighbourhoodpageContent = new NeighbourhoodPage
            {
                seoTitle = SeoTitle,
                seoDescription = SeoDescription,
                sharingImage = SharingImage,
                sharingImageAlt = SharingImageAlt,
                headerImage = headerImage,
                headerImageAlt = headerImageAlt,
                logoText = logoText,
                logoTextAlt = logoTextAlt,
                leftTopText = leftTopText,
                leftDescription = leftDescription,
                multiImages = multiImages,
                heading = heading,
                leftStandFirst = leftStandFirst,
                rightSmallImage = rightSmallImage,
                rightSmallImageAlt = rightSmallImageAlt,
                leftSmallImage = leftSmallImage,
                leftSmallImageAlt = leftSmallImageAlt,
                rightStandFirst = rightStandFirst,
                leftIntro = leftIntro,
                rightImage = rightImage,
                rightImageAlt = rightImageAlt,
                leftShortImage = leftShortImage,
                leftShortImageAlt = leftShortImageAlt,
                rightLargeImage = rightLargeImage,
                rightLargeImageAlt = rightLargeImageAlt,
                leftText = leftText,
                rightShortImage = rightShortImage,
                rightShortImageAlt = rightShortImageAlt,
                availableText = availableText,
                leftButtonText = leftButtonText,
                rightButtonText = rightButtonText,
                lstheaderLinks = lstheaderLinks,
                leftLink = strleftLink,
                rightLink = strrightLink
            };
            string strJson = JsonSerializer.Serialize<NeighbourhoodPage>(objNeighbourhoodpageContent);

            return strJson;

        }
    }
}
