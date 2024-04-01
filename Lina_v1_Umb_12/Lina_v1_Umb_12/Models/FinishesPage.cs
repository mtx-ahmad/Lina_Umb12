using Umbraco.Cms.Core.Models;

namespace Lina_v1_Umb_12.Models
{
    public class FinishesPage
    {
        public string seoTitle { get; set; }
        public string seoDescription { get; set; }
        public string sharingImage { get; set; }
        public string sharingImageAlt { get; set; }
        public string headerImage { get; set; }
        public string headerImageAlt { get; set; }
        public string headerImageMobile { get; set; }
        public string headerImageMobileAlt { get; set; }
        public string centerText { get; set; }
        public string leftImage { get; set; }
        public string leftImageAlt { get; set; }
        public string leftCenterText { get; set; }
        public string leftSmallImage { get; set; }
        public string leftSmallImageAlt { get; set; }
        public string leftBelowText { get; set; }
        public string leftPicture { get; set; }
        public string leftPictureAlt { get; set; }
        public string rightPicture { get; set; }
        public string rightPictureAlt { get; set; }
        public string centerInfo { get; set; }
        public string rightText { get; set; }
        public string rightLargeImage { get; set; }
        public string rightLargeImageAlt { get; set; }
        public string leftLargeImage { get; set; }
        public string leftLargeImageAlt { get; set; }
        public string leftLargeImageText { get; set; }
        public string smallImage { get; set; }
        public string smallImageAlt { get; set; }
        public string availableText { get; set; }
        public string leftButtonText { get; set; }
        public string rightButtonText { get; set; }
        public IEnumerable<Link> lstheaderLinks { get; set; }
        public Link leftLink { get; set; }
        public Link rightLink { get; set; }




    }
}
