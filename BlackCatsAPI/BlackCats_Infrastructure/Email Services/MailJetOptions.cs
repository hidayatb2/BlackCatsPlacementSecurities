namespace BlackCats_Infrastructure.Email_Services
{
    public class MailJetOptions
    {
        public string ApiKey { get; set; } = null!;

        public string ApiSecret { get; set; } = null!;

        public string FromEmail { get; set; } = null!;

        public string DisplayName { get; set; } = null!;
    }
}
