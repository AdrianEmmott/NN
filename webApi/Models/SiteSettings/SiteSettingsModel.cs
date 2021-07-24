namespace webApi.Models.SiteSettings
{
    public class SiteSettingsModel
    {
        public SiteSettingsModel()
        {
            Uploads = new SiteSettingsUploadsModel();
        }

        public SiteSettingsUploadsModel Uploads { get; set; }
    }
}