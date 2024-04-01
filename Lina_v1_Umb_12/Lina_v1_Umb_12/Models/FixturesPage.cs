using Umbraco.Cms.Core.Models;

namespace Lina_v1_Umb_12.Models
{
    public class FixturesPage
    {
        public string seoTitle { get; set; }
        public string seoDescription { get; set; }
        public string sharingImage { get; set; }
        public string sharingImageAlt { get; set; }
        public string leftText { get; set; }
        public string rightLargeImage { get; set; }
        public string rightLargeImageAlt { get; set; }
        public string leftFirstImage { get; set; }
        public string leftFirstImageAlt { get; set; }
        public string rightText { get; set; }
        public string leftFirstText { get; set; }
        public string leftSecondImage { get; set; }
        public string leftSecondImageAlt { get; set; }
        public string leftSecondText { get; set; }
        public string rightImage { get; set; }
        public string rightImageAlt { get; set; }
        public string rightImageText { get; set; }
        public string leftPicture { get; set; }
        public string leftPictureAlt { get; set; }
        public string centerText { get; set; }
        public string rightPicture { get; set; }
        public string rightPictureAlt { get; set; }
        public string leftCenterImage { get; set; }
        public string leftCenterImageAlt { get; set; }
        public string availableText { get; set; }
        public string leftButtonText { get; set; }
        public string rightButtonText { get; set; }
        public IEnumerable<Link> lstheaderLinks { get; set; }
        public Link leftLink { get; set; }
        public Link rightLink { get; set; }


    }
}
