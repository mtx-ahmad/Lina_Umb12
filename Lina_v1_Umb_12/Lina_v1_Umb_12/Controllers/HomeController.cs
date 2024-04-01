using Lina_v1_Umb_12.Models;
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
using System.Text.Json;
using Umbraco.Cms.Web.Common.UmbracoContext;
using Umbraco.Cms.Web.Common;
using Umbraco.Cms.Core.Models.Blocks;
using static Umbraco.Cms.Core.Constants.HttpContext;
using Umbraco.Extensions;
using Umbraco.Cms.Core.Models;

namespace Lina_v1_Umb_12.Controllers
{
    public class HomeController : UmbracoApiController
    {


        private readonly IPublishedContentQuery _publishedContentQuery;
        private readonly IContentService _contentService;
        private readonly IScopeProvider _scopeProvider;
        private Microsoft.AspNetCore.Hosting.IHostingEnvironment _hostingEnvironment;
        public HomeController(
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
        public string GetHomePageContent()
        {

            var Homepage = _publishedContentQuery.Content(1062);
            var lstleftSlider = Homepage.Value<IEnumerable<BlockListItem>>("leftSlider");
            var leftSliderBlocks = new List<SpaceForLiving>();
            if (lstleftSlider != null && lstleftSlider.Count() > 0)
            {
                foreach (var items in lstleftSlider)
                {
                    var item = items.Content;
                    string strdesktopImage = "", strdesktopImageAlt = "";
                    if (item.HasProperty("desktopImage") && item.Value("desktopImage") != null
                    && item.Value<IPublishedContent>("desktopImage") != null)
                    {
                        strdesktopImage = item.Value<IPublishedContent>("desktopImage").Url();
                    }
                    if (item.HasProperty("desktopImageAlt") && item.Value("desktopImageAlt") != null
                    && item.Value<string>("desktopImageAlt") != "")
                    {
                        strdesktopImageAlt = item.Value<string>("desktopImageAlt");
                    }
                    leftSliderBlocks.Add(new SpaceForLiving
                    {
                        desktopImage = strdesktopImage,
                        desktopImageAlt = strdesktopImageAlt
                    });
                }
            }
            string strleftPrice = "";
            if (Homepage.HasProperty("leftPrice") && Homepage.Value("leftPrice") != null
              && Homepage.Value<string>("leftPrice") != "")
            {
                strleftPrice = Homepage.Value<string>("leftPrice");
            }
            var lstcenterSlider = Homepage.Value<IEnumerable<BlockListItem>>("centerSlider");
            var centerSliderBlocks = new List<SpaceForLiving>();
            if (lstcenterSlider != null && lstcenterSlider.Count() > 0)
            {
                foreach (var items in lstcenterSlider)
                {
                    var item = items.Content;
                    string strdesktopImage = "", strdesktopImageAlt = "";
                    if (item.HasProperty("desktopImage") && item.Value("desktopImage") != null
                    && item.Value<IPublishedContent>("desktopImage") != null)
                    {
                        strdesktopImage = item.Value<IPublishedContent>("desktopImage").Url();
                    }
                    if (item.HasProperty("desktopImageAlt") && item.Value("desktopImageAlt") != null
                    && item.Value<string>("desktopImageAlt") != "")
                    {
                        strdesktopImageAlt = item.Value<string>("desktopImageAlt");
                    }
                    centerSliderBlocks.Add(new SpaceForLiving
                    {
                        desktopImage = strdesktopImage,
                        desktopImageAlt = strdesktopImageAlt
                    });
                }
            }
            string strcenterPrice = "";
            if (Homepage.HasProperty("centerPrice") && Homepage.Value("centerPrice") != null
              && Homepage.Value<string>("centerPrice") != "")
            {
                strcenterPrice = Homepage.Value<string>("centerPrice");
            }
            var lstrightSlider = Homepage.Value<IEnumerable<BlockListItem>>("rightSlider");
            var rightSliderBlocks = new List<SpaceForLiving>();
            if (lstrightSlider != null && lstrightSlider.Count() > 0)
            {
                foreach (var items in lstrightSlider)
                {
                    var item = items.Content;
                    string strdesktopImage = "", strdesktopImageAlt = "";
                    if (item.HasProperty("desktopImage") && item.Value("desktopImage") != null
                    && item.Value<IPublishedContent>("desktopImage") != null)
                    {
                        strdesktopImage = item.Value<IPublishedContent>("desktopImage").Url();
                    }
                    if (item.HasProperty("desktopImageAlt") && item.Value("desktopImageAlt") != null
                    && item.Value<string>("desktopImageAlt") != "")
                    {
                        strdesktopImageAlt = item.Value<string>("desktopImageAlt");
                    }
                    rightSliderBlocks.Add(new SpaceForLiving
                    {
                        desktopImage = strdesktopImage,
                        desktopImageAlt = strdesktopImageAlt
                    });
                }
            }
            string strrightPrice = "";
            if (Homepage.HasProperty("rightPrice") && Homepage.Value("rightPrice") != null
              && Homepage.Value<string>("rightPrice") != "")
            {
                strrightPrice = Homepage.Value<string>("rightPrice");
            }
            //var blockList = Homepage.Value<IEnumerable<BlockListItem>>("livingSpace");
            //var blocks = new List<SpaceForLiving>();

            //if (blockList != null)
            //{
            //    foreach (var items in blockList)
            //    {
            //        var item = items.Content;
            //        var Type = item.HasProperty("type") && item.HasValue("type") && item.Value("type") != null && item.Value<string>("type") != "" ? item.Value<string>("type") : "";
            //        string strUrl = "";
            //        if (item.HasProperty("url") && item.Value("url") != null
            //        && item.Value<IPublishedContent>("url") != null)
            //        {
            //             strUrl = item.Value<IPublishedContent>("url").Url();
            //        }
            //        var Url = "";
            //        if (strUrl != null)
            //        {
            //            Url = strUrl;
            //        }
            //        string strdesktopImage = "", strdesktopImageAlt = "";
            //        if (item.HasProperty("desktopImage") && item.Value("desktopImage") != null
            //        && item.Value<IPublishedContent>("desktopImage") != null)
            //        {
            //            strdesktopImage = item.Value<IPublishedContent>("desktopImage").Url();
            //        }
            //        if (item.HasProperty("desktopImageAlt") && item.Value("desktopImageAlt") != null
            //        && item.Value<string>("desktopImageAlt") != "")
            //        {
            //            strdesktopImageAlt = item.Value<string>("desktopImageAlt");
            //        }
            //        string strmobileImage = "", strmobileImageAlt = "";
            //        if (item.HasProperty("mobileImage") && item.Value("mobileImage") != null
            //        && item.Value<IPublishedContent>("mobileImage") != null)
            //        {
            //            strmobileImage = item.Value<IPublishedContent>("mobileImage").Url();
            //        }
            //        if (item.HasProperty("mobileImageAlt") && item.Value("mobileImageAlt") != null
            //        && item.Value<string>("mobileImageAlt") != "")
            //        {
            //            strmobileImageAlt = item.Value<string>("mobileImageAlt");
            //        }
            //        string strprice = "";
            //        if (item.HasProperty("price") && item.Value("price") != null
            //        && item.Value<string>("price") != "")
            //        {
            //            strprice = item.Value<string>("price");
            //        }

            //        blocks.Add(new SpaceForLiving
            //        {
            //            //Type = Type,
            //            //Url = Url,
            //            desktopImage = strdesktopImage,
            //            //mobileImage = strmobileImage,
            //            desktopImageAlt = strdesktopImageAlt,
            //            //mobileImageAlt = strmobileImageAlt,
            //            //Price = strprice
            //        });
            //    }
            //}
            var blockGrid = Homepage.Value<IEnumerable<BlockGridItem>>("gridItems");
            var sliderBlocks = new List<HomeSlider>();
            var livingFacilities = new List<LivingFacilities>();
            var facilities = new List<LivingFacility>();
            var locationMap = new List<LocationMap>();
            var locationMapContent = new List<LocationMapContent>();
            var ourCommunity = new List<OurCommunity>();
            var ourCommunityList = new List<OurCommunityList>();
            var fullWidthVideo = new List<FullWidthVideo>();
            if (blockGrid != null)
            {
                foreach (var items in blockGrid)
                {
                    var item = items.Content;
                    var sliderItems = item.Value<IEnumerable<BlockListItem>>("slider");
                    if (sliderItems != null)
                    {
                        foreach (var slides in sliderItems)
                        {
                            string sliderImage = "", sliderImageAlt = "";
                            if (slides.Content.HasProperty("image") && slides.Content.Value("image") != null && slides.Content.Value<string>("image") != "")
                            {
                                sliderImage = slides.Content.Value<IPublishedContent>("image").Url();
                            }
                            if (slides.Content.HasProperty("imageAlt") && slides.Content.Value("imageAlt") != null && slides.Content.Value<string>("imageAlt") != "")
                            {
                                sliderImageAlt = slides.Content.Value<string>("imageAlt");
                            }
                            sliderBlocks.Add(new HomeSlider
                            {
                                image = sliderImage,
                                imageAlt = sliderImageAlt
                            });
                        }
                    }
                    var strheading = "";
                    var lstfacilities = item.Value<IEnumerable<BlockListItem>>("facilities");
                    string strImage = "", strImageAlt = "", strstandFirst = "";
                    if (item.ContentType.Alias == "livingFacilities")
                    {
                        if (item.HasProperty("heading") && item.HasValue("heading"))
                        {
                            strheading = item.Value<string>("heading");
                        }
                        if (lstfacilities != null && lstfacilities.Count() > 0)
                        {
                            foreach (var facility in lstfacilities)
                            {
                                if (facility.Content.HasProperty("image") && facility.Content.Value("image") != null && facility.Content.Value<string>("image") != "")
                                {
                                    strImage = facility.Content.Value<IPublishedContent>("image").Url();
                                }
                                if (facility.Content.HasProperty("imageAlt") && facility.Content.Value("imageAlt") != null && facility.Content.Value<string>("imageAlt") != "")
                                {
                                    strImageAlt = facility.Content.Value<string>("imageAlt");
                                }
                                if (facility.Content.HasProperty("standFirst") && facility.Content.Value("standFirst") != null && facility.Content.Value<string>("standFirst") != "")
                                {
                                    strstandFirst = facility.Content.Value<string>("standFirst");
                                }
                                facilities.Add(new LivingFacility
                                {
                                    image= strImage,
                                    imageAlt = strImageAlt,
                                    standFirst = strstandFirst
                                });
                            }
                         }
                        if (!string.IsNullOrEmpty(strheading) && !string.IsNullOrEmpty(strImage))
                        {
                            livingFacilities.Add(new LivingFacilities
                            {
                                heading = strheading,
                                facilities = facilities
                            });
                        }
                    }
                    if (item.ContentType.Alias == "locationMap")
                    {
                        var strdescription = "";
                        if (item.HasProperty("description") && item.HasValue("description"))
                        {
                            strdescription = item.Value<string>("description");
                        }
                        var lstlocation = item.Value<IEnumerable<BlockListItem>>("location");
                        if (lstlocation != null && lstlocation.Count() > 0)
                        {
                            foreach (var locations in lstlocation)
                            {
                                string strlogoSelection = "";
                                if (locations.Content.HasProperty("logoSelection") && locations.Content.Value("logoSelection") != null && locations.Content.Value<string>("logoSelection") != "")
                                {
                                    strlogoSelection = locations.Content.Value<string>("logoSelection");
                                }
                                string strstation = "";
                                if (locations.Content.HasProperty("station") && locations.Content.Value("station") != null && locations.Content.Value<string>("station") != "")
                                {
                                    strstation = locations.Content.Value<string>("station");
                                }
                                string strlocation = "";
                                if (locations.Content.HasProperty("location") && locations.Content.Value("location") != null && locations.Content.Value<string>("location") != "")
                                {
                                    strlocation = locations.Content.Value<string>("location");
                                }
                                locationMapContent.Add(new LocationMapContent
                                {
                                    logoSelection = strlogoSelection,
                                    station = strstation,
                                    location = strlocation
                                });
                            }
                        }
                        string strleftImage = "", strleftImageAlt = "";
                        if (item.HasProperty("leftImage") && item.Value("leftImage") != null
                           && item.Value<IPublishedContent>("leftImage") != null)
                        {
                            strleftImage = item.Value<IPublishedContent>("leftImage").Url();
                        }
                        if (item.HasProperty("leftImageAlt") && item.Value("leftImageAlt") != null
                           && item.Value<string>("leftImageAlt") != "")
                        {
                            strleftImageAlt = item.Value<string>("leftImageAlt");
                        }
                        var strbottomCaption = "";
                        if (item.HasProperty("bottomCaption") && item.HasValue("bottomCaption"))
                        {
                            strbottomCaption = item.Value<string>("bottomCaption");
                        }
                        locationMap.Add(new LocationMap
                        {
                            description = strdescription,
                            location = locationMapContent,
                            leftImage = strleftImage,
                            leftImageAlt = strleftImageAlt,
                            bottomCaption = strbottomCaption
                        });
                    }
                    if (item.ContentType.Alias == "ourCommunity")
                    {
                        var heading = "";
                        if (item.HasProperty("heading") && item.HasValue("heading"))
                        {
                            heading = item.Value<string>("heading");
                        }
                        var lstcommunity = item.Value<IEnumerable<BlockListItem>>("community");
                        if (lstcommunity != null && lstcommunity.Count() > 0)
                        {
                            foreach (var listItems in lstcommunity)
                            {
                                var listItem = listItems.Content;
                                string strurl = "";
                                string strFinalurl = "";
                                if (listItem.HasProperty("url") && listItem.Value("url") != null
                                   && listItem.Value<IPublishedContent>("url") != null)
                                {
                                    strurl = listItem.Value<IPublishedContent>("url").Url();
                                    if (strurl != null)
                                    {
                                        strFinalurl = "href=" + strurl + "";

                                    }
                                }
                                var strurlText = "";
                                if (listItem.HasProperty("urlText") && listItem.HasValue("urlText"))
                                {
                                    strurlText = listItem.Value<string>("urlText");
                                }
                                string strimage = "", strimageAlt = "";
                                if (listItem.HasProperty("image") && listItem.Value("image") != null
                                   && listItem.Value<IPublishedContent>("image") != null)
                                {
                                    strimage = listItem.Value<IPublishedContent>("image").Url();
                                }
                                if (listItem.HasProperty("imageAlt") && listItem.Value("imageAlt") != null
                                   && listItem.Value<string>("imageAlt") != "")
                                {
                                    strimageAlt = listItem.Value<string>("imageAlt");
                                }
                                ourCommunityList.Add(new OurCommunityList
                                {
                                    url = strurl,
                                    urlText = strurlText,
                                    image = strimage,
                                    imageAlt = strimageAlt

                                });
                            }
                        }
                        ourCommunity.Add(new OurCommunity{
                            heading = heading,
                            community = ourCommunityList
                            //url = strurl,
                            //urlText = strurlText,
                            //image = strimage,
                            //imageAlt = strimageAlt
                        });
                    }
                    if (item.ContentType.Alias == "fullWidthVideo")
                    {
                        string strvideo = "";
                        if (item.HasProperty("video") && item.Value("video") != null
                            && item.Value<IPublishedContent>("video") != null)
                        {
                            strvideo = item.Value<IPublishedContent>("video").Url();
                        }
                        string strposterImage = "", strposterImageAlt = "";
                        if (item.HasProperty("posterImage") && item.Value("posterImage") != null
                           && item.Value<IPublishedContent>("posterImage") != null)
                        {
                            strposterImage = item.Value<IPublishedContent>("posterImage").Url();
                        }
                        if (item.HasProperty("posterImageAlt") && item.Value("posterImageAlt") != null
                           && item.Value<string>("posterImageAlt") != "")
                        {
                            strposterImageAlt = item.Value<string>("posterImageAlt");
                        }
                        string strvideoMobile = "";
                        if (item.HasProperty("videoMobile") && item.Value("videoMobile") != null
                            && item.Value<IPublishedContent>("videoMobile") != null)
                        {
                            strvideoMobile = item.Value<IPublishedContent>("videoMobile").Url();
                        }
                        string strposterImageMobile = "", strposterImageMobileAlt = "";
                        if (item.HasProperty("posterImageMobile") && item.Value("posterImageMobile") != null
                           && item.Value<IPublishedContent>("posterImageMobile") != null)
                        {
                            strposterImageMobile = item.Value<IPublishedContent>("posterImageMobile").Url();
                        }
                        if (item.HasProperty("posterImageMobileAlt") && item.Value("posterImageMobileAlt") != null
                           && item.Value<string>("posterImageMobileAlt") != "")
                        {
                            strposterImageMobileAlt = item.Value<string>("posterImageMobileAlt");
                        }
                        if (strvideoMobile == "")
                        {
                            strvideoMobile = strvideo;
                        }

                        if (strposterImage == "")
                        {
                            strposterImage = "/images/img-acton-time.jpg";
                        }
                        if (strposterImageMobile == "")
                        {
                            strposterImageMobile = "/images/img-acton-time.jpg";
                        }
                        fullWidthVideo.Add(new FullWidthVideo
                        {
                            video = strvideo,
                            videoMobile = strvideoMobile,
                            posterImage = strposterImage,
                            posterImageAlt = strposterImageAlt,
                            posterImageMobile = strposterImageMobile,
                            posterImageMobileAlt = strposterImageMobileAlt

                        });

                    }
                    

                }
            }

            var SeoTitle = Homepage != null && Homepage.HasValue("seoTitle") && Homepage.Value("seoTitle") != null ? Homepage.Value<string>("seoTitle") : "";
            var SeoDescription = Homepage != null && Homepage.HasValue("seoDescription") && Homepage.Value("seoDescription") != null ? Homepage.Value<string>("seoDescription") : "";
            var SharingImage = Homepage != null && Homepage.HasValue("sharingImage") && Homepage.Value<IPublishedContent>("sharingImage") != null ? Homepage.Value<IPublishedContent>("sharingImage").Url() : "";
            var SharingImageAlt = Homepage != null && Homepage.HasValue("sharingImageAlt") && Homepage.Value("sharingImageAlt") != null ? Homepage.Value<string>("sharingImageAlt") : "";

            var DesktopVideo = Homepage != null && Homepage.HasValue("desktopVideo") && Homepage.Value<IPublishedContent>("desktopVideo") != null ? Homepage.Value<IPublishedContent>("desktopVideo").Url() : "";
            var MobileVideo = Homepage != null && Homepage.HasValue("mobileVideo") && Homepage.Value<IPublishedContent>("mobileVideo") != null ? Homepage.Value<IPublishedContent>("mobileVideo").Url() : "";
            var PosterImage = Homepage != null && Homepage.HasValue("posterImage") && Homepage.Value<IPublishedContent>("posterImage") != null ? Homepage.Value<IPublishedContent>("posterImage").Url() : "";
            var PosterImageAlt = Homepage != null && Homepage.HasValue("posterImageAlt") && Homepage.Value("posterImageAlt") != null ? Homepage.Value<string>("posterImageAlt") : "";
            var BottomCaption = Homepage != null && Homepage.HasValue("bottomCaption") && Homepage.Value("bottomCaption") != null ? Homepage.Value<string>("bottomCaption") : "";

            var availableServices = Homepage != null && Homepage.HasValue("availableServices") && Homepage.Value("availableServices") != null ? Homepage.Value<string>("availableServices") : "";

            var textImage = Homepage != null && Homepage.HasValue("textImage") && Homepage.Value<IPublishedContent>("textImage") != null ? Homepage.Value<IPublishedContent>("textImage").Url() : "";
            var textImageAlt = Homepage != null && Homepage.HasValue("textImageAlt") && Homepage.Value("textImageAlt") != null ? Homepage.Value<string>("textImageAlt") : "";
            var text = Homepage != null && Homepage.HasValue("text") && Homepage.Value("text") != null ? Homepage.Value<string>("text") : "";
            var availableText = Homepage != null && Homepage.HasValue("availableText") && Homepage.Value("availableText") != null ? Homepage.Value<string>("availableText") : "";
            var leftButtonText = Homepage != null && Homepage.HasValue("leftButtonText") && Homepage.Value("leftButtonText") != null ? Homepage.Value<string>("leftButtonText") : "";
            var rightButtonText = Homepage != null && Homepage.HasValue("rightButtonText") && Homepage.Value("rightButtonText") != null ? Homepage.Value<string>("rightButtonText") : "";
            IEnumerable<Link> lstheaderLinks = Homepage != null && Homepage.HasValue("headerLinks") && Homepage.Value<IEnumerable<Link>>("headerLinks") != null ? Homepage.Value<IEnumerable<Link>>("headerLinks") : null;
            var strleftLink = Homepage != null && Homepage.HasValue("leftLink") && Homepage.Value("leftLink") != null ? Homepage.Value<Link>("leftLink") : null;
            var strrightLink = Homepage != null && Homepage.HasValue("rightLink") && Homepage.Value("rightLink") != null ? Homepage.Value<Link>("rightLink") : null;

            var objHomePageContent = new HomePage
            {
                seoTitle = SeoTitle,
                seoDescription = SeoDescription,
                sharingImage = SharingImage,
                sharingImageAlt = SharingImageAlt,
                desktopVideo=DesktopVideo,
                mobileVideo=MobileVideo,
                posterImage=PosterImage,
                posterImageAlt=PosterImageAlt,
                bottomCaption=BottomCaption,
                //spaceForLivingBlocks = blocks,
                leftSliderBlocks = leftSliderBlocks,
                leftPrice = strleftPrice,
                centerSliderBlocks = centerSliderBlocks,
                centerPrice = strcenterPrice,
                rightSliderBlocks = rightSliderBlocks,
                rightPrice = strrightPrice,
                homeSliderBlocks = sliderBlocks,
                livingFacilitiesBlocks = livingFacilities,
                locationMapBlocks = locationMap,
                ourCommunityBlocks = ourCommunity,
                fullWidthVideoBlocks = fullWidthVideo,
                lstheaderLinks = lstheaderLinks,
                availableServices = availableServices,
                textImage = textImage,
                textImageAlt = textImageAlt,
                text = text,
                availableText = availableText,
                leftButtonText = leftButtonText,
                rightButtonText = rightButtonText,
                leftLink = strleftLink,
                rightLink = strrightLink
            };

            string strJson = JsonSerializer.Serialize<HomePage>(objHomePageContent);

            return strJson;
        }


    }
}
