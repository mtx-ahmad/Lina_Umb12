using Umbraco.Cms.Core.Models;

namespace Lina_v1_Umb_12.Models
{
    public class ActonPage
    {
        public string seoTitle { get; set; }
        public string seoDescription { get; set; }
        public string sharingImage { get; set; }
        public string sharingImageAlt { get; set; }
        public string headerImage { get; set; }
        public string headerImageAlt { get; set; }
        public string textImage { get; set; }
        public string textImageAlt { get; set; }
        public List<RightImages> rightImages { get; set; }
        public string leftText { get; set; }
        public string bottomCaption { get; set; }
        public string logo { get; set; }
        public string logoAlt { get; set; }
        public string availableText { get; set; }
        public string leftButtonText { get; set; }
        public string rightButtonText { get; set; }
        public IEnumerable<Link> lstheaderLinks { get; set; }
        public Link leftLink { get; set; }
        public Link rightLink { get; set; }

    }
}
