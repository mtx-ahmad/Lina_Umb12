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
using System.Text.Json;
using Umbraco.Cms.Core.Models;

namespace Lina_v1_Umb_12.Controllers
{
    public class OurImpactController : UmbracoApiController
    {
        private readonly IPublishedContentQuery _publishedContentQuery;
        private readonly IContentService _contentService;
        private readonly IScopeProvider _scopeProvider;
        private Microsoft.AspNetCore.Hosting.IHostingEnvironment _hostingEnvironment;

        public OurImpactController(
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
        public string GetOurImpactPageContent()
        {
            var Homepage = _publishedContentQuery.Content(1062);
            var availableText = Homepage != null && Homepage.HasValue("availableText") && Homepage.Value("availableText") != null ? Homepage.Value<string>("availableText") : "";
            var leftButtonText = Homepage != null && Homepage.HasValue("leftButtonText") && Homepage.Value("leftButtonText") != null ? Homepage.Value<string>("leftButtonText") : "";
            var rightButtonText = Homepage != null && Homepage.HasValue("rightButtonText") && Homepage.Value("rightButtonText") != null ? Homepage.Value<string>("rightButtonText") : "";
            IEnumerable<Link> lstheaderLinks = Homepage != null && Homepage.HasValue("headerLinks") && Homepage.Value<IEnumerable<Link>>("headerLinks") != null ? Homepage.Value<IEnumerable<Link>>("headerLinks") : null;
            var strleftLink = Homepage != null && Homepage.HasValue("leftLink") && Homepage.Value("leftLink") != null ? Homepage.Value<Link>("leftLink") : null;
            var strrightLink = Homepage != null && Homepage.HasValue("rightLink") && Homepage.Value("rightLink") != null ? Homepage.Value<Link>("rightLink") : null;

            var OurImpactpage = _publishedContentQuery.Content(1105);
            var SeoTitle = OurImpactpage != null && OurImpactpage.HasValue("seoTitle") && OurImpactpage.Value("seoTitle") != null ? OurImpactpage.Value<string>("seoTitle") : "";
            var SeoDescription = OurImpactpage != null && OurImpactpage.HasValue("seoDescription") && OurImpactpage.Value("seoDescription") != null ? OurImpactpage.Value<string>("seoDescription") : "";
            var SharingImage = OurImpactpage != null && OurImpactpage.HasValue("sharingImage") && OurImpactpage.Value<IPublishedContent>("sharingImage") != null ? OurImpactpage.Value<IPublishedContent>("sharingImage").Url() : "";
            var SharingImageAlt = OurImpactpage != null && OurImpactpage.HasValue("sharingImageAlt") && OurImpactpage.Value("sharingImageAlt") != null ? OurImpactpage.Value<string>("sharingImageAlt") : "";
            var rightImage = OurImpactpage != null && OurImpactpage.HasValue("rightImage") && OurImpactpage.Value<IPublishedContent>("rightImage") != null ? OurImpactpage.Value<IPublishedContent>("rightImage").Url() : "";
            var rightImageAlt = OurImpactpage != null && OurImpactpage.HasValue("rightImageAlt") && OurImpactpage.Value("rightImageAlt") != null ? OurImpactpage.Value<string>("rightImageAlt") : "";
            var rightImageMobile = OurImpactpage != null && OurImpactpage.HasValue("rightImageMobile") && OurImpactpage.Value<IPublishedContent>("rightImageMobile") != null ? OurImpactpage.Value<IPublishedContent>("rightImageMobile").Url() : "";
            var rightImageMobileAlt = OurImpactpage != null && OurImpactpage.HasValue("rightImageMobileAlt") && OurImpactpage.Value("rightImageMobileAlt") != null ? OurImpactpage.Value<string>("rightImageAlt") : "";
            var leftImage = OurImpactpage != null && OurImpactpage.HasValue("leftImage") && OurImpactpage.Value<IPublishedContent>("leftImage") != null ? OurImpactpage.Value<IPublishedContent>("leftImage").Url() : "";
            var leftImageAlt = OurImpactpage != null && OurImpactpage.HasValue("leftImageAlt") && OurImpactpage.Value("leftImageAlt") != null ? OurImpactpage.Value<string>("leftImageAlt") : "";
            var leftImageMobile = OurImpactpage != null && OurImpactpage.HasValue("leftImageMobile") && OurImpactpage.Value<IPublishedContent>("leftImageMobile") != null ? OurImpactpage.Value<IPublishedContent>("leftImageMobile").Url() : "";
            var leftImageMobileAlt = OurImpactpage != null && OurImpactpage.HasValue("leftImageMobileAlt") && OurImpactpage.Value("leftImageMobileAlt") != null ? OurImpactpage.Value<string>("leftImageAlt") : "";
            var leftText = OurImpactpage != null && OurImpactpage.HasValue("leftText") && OurImpactpage.Value("leftText") != null ? OurImpactpage.Value<string>("leftText") : "";
            var rightText = OurImpactpage != null && OurImpactpage.HasValue("rightText") && OurImpactpage.Value("rightText") != null ? OurImpactpage.Value<string>("rightText") : "";
            var bottomText = OurImpactpage != null && OurImpactpage.HasValue("bottomText") && OurImpactpage.Value("bottomText") != null ? OurImpactpage.Value<string>("bottomText") : "";
            var lstmultiImages = OurImpactpage.Value<IEnumerable<BlockListItem>>("multiImages");

            List<ThreeColumnImages> multiImages = new List<ThreeColumnImages>();
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
                    multiImages.Add(new ThreeColumnImages
                    {
                        image = image,
                        imageAlt = imageAlt
                    });
                }
            }
            var objOurImpactpageContent = new OurImpactPage
            {
                seoTitle = SeoTitle,
                seoDescription = SeoDescription,
                sharingImage = SharingImage,
                sharingImageAlt = SharingImageAlt,
                rightImage = rightImage,
                rightImageAlt = rightImageAlt,
                leftImage = leftImage,
                leftImageAlt = leftImageAlt,
                rightImageMobile = rightImageMobile,
                rightImageMobileAlt = rightImageMobileAlt,
                leftImageMobile = leftImageMobile,
                leftImageMobileAlt = leftImageMobileAlt,
                leftText = leftText,
                rightText = rightText,
                bottomText = bottomText,
                multiImages = multiImages,
                availableText = availableText,
                leftButtonText = leftButtonText,
                rightButtonText = rightButtonText,
                lstheaderLinks = lstheaderLinks,
                leftLink = strleftLink,
                rightLink = strrightLink
            };
            string strJson = JsonSerializer.Serialize<OurImpactPage>(objOurImpactpageContent);

            return strJson;

        }
    }
}
