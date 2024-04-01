using Umbraco.Cms.Core.Models;

namespace Lina_v1_Umb_12.Models
{
    public class NeighbourhoodPage
    {
        public string seoTitle { get; set; }
        public string seoDescription { get; set; }
        public string sharingImage { get; set; }
        public string sharingImageAlt { get; set; }
        public string headerImage { get; set; }
        public string headerImageAlt { get; set; }
        public string logoText { get; set; }
        public string logoTextAlt { get; set; }
        public string leftTopText { get; set; }
        public string leftDescription { get; set; }
        public List<NeighbourhoodMultiImages> multiImages { get; set; }
        public string heading { get; set; }
        public string leftStandFirst { get; set; }
        public string rightSmallImage { get; set; }
        public string rightSmallImageAlt { get; set; }
        public string leftSmallImage { get; set; }
        public string leftSmallImageAlt { get; set; }
        public string rightStandFirst { get; set; }
        public string leftIntro { get; set; }
        public string rightImage { get; set; }
        public string rightImageAlt { get; set; }
        public string leftShortImage { get; set; }
        public string leftShortImageAlt { get; set; }
        public string rightLargeImage { get; set; }
        public string rightLargeImageAlt { get; set; }
        public string leftText { get; set; }
        public string rightShortImage { get; set; }
        public string rightShortImageAlt { get; set; }
        public string availableText { get; set; }
        public string leftButtonText { get; set; }
        public string rightButtonText { get; set; }
        public IEnumerable<Link> lstheaderLinks { get; set; }
        public Link leftLink { get; set; }
        public Link rightLink { get; set; }
    }
}
