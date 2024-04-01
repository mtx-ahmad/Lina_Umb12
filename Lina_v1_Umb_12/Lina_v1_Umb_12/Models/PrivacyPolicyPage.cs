using Umbraco.Cms.Core.Models;

namespace Lina_v1_Umb_12.Models
{
    public class PrivacyPolicyPage
    {
        public string seoTitle { get; set; }
        public string seoDescription { get; set; }
        public string sharingImage { get; set; }
        public string sharingImageAlt { get; set; }
        public string description { get; set; }
        public string availableText { get; set; }
        public string leftButtonText { get; set; }
        public string rightButtonText { get; set; }
        public IEnumerable<Link> lstheaderLinks { get; set; }
        public Link leftLink { get; set; }
        public Link rightLink { get; set; }
    }
}
