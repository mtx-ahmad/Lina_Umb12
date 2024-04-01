using Umbraco.Cms.Core.Models;

namespace Lina_v1_Umb_12.Models
{
    public class HomePage
    {

        public string seoTitle { get; set; }
        public string seoDescription { get; set; }
        public string sharingImage { get; set; }
        public string sharingImageAlt { get; set; }
        public string desktopVideo { get; set; }
        public string mobileVideo { get; set; }
        public string posterImage { get; set; }
        public string posterImageAlt { get; set; }
        public string bottomCaption { get; set; }
        public string textImage { get; set; }
        public string textImageAlt { get; set; }
        public List<SpaceForLiving> leftSliderBlocks { get; set; }
        public string leftPrice { get; set; }
        public List<SpaceForLiving> centerSliderBlocks { get; set; }
        public string centerPrice { get; set; }
        public List<SpaceForLiving> rightSliderBlocks { get; set; }
        public string rightPrice { get; set; }
        public List<HomeSlider> homeSliderBlocks { get; set; }
        public List<LivingFacilities> livingFacilitiesBlocks { get; set; }
        public List<LocationMap> locationMapBlocks { get; set; }
        public List<OurCommunity> ourCommunityBlocks { get; set; }
        public List<FullWidthVideo> fullWidthVideoBlocks { get; set; }
        public IEnumerable<Link> lstheaderLinks { get; set; }
        public Link leftLink { get; set; }
        public Link rightLink { get; set; }
        public string availableServices { get; set; }
        public string text { get; set; }
        public string availableText { get; set; }
        public string leftButtonText { get; set; }
        public string rightButtonText { get; set; }


    }
}
