using Umbraco.Cms.Core.Models;

namespace Lina_v1_Umb_12.Models
{
    public class OurImpactPage
    {
        public string seoTitle { get; set; }
        public string seoDescription { get; set; }
        public string sharingImage { get; set; }
        public string sharingImageAlt { get; set; }
        public string rightImage { get; set; }
        public string rightImageAlt { get; set; }
        public string rightImageMobile { get; set; }
        public string rightImageMobileAlt { get; set; }
        public string leftImage { get; set; }
        public string leftImageAlt { get; set; }
        public string leftImageMobile { get; set; }
        public string leftImageMobileAlt { get; set; }
        public string leftText { get; set; }
        public string rightText { get; set; }
        public string bottomText { get; set; }
        public List<ThreeColumnImages> multiImages { get; set; }
        public string availableText { get; set; }
        public string leftButtonText { get; set; }
        public string rightButtonText { get; set; }
        public IEnumerable<Link> lstheaderLinks { get; set; }
        public Link leftLink { get; set; }
        public Link rightLink { get; set; }


    }
}
