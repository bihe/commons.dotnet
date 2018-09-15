namespace Commons.Api.Configuration
{
    public class BaseApplicationConfiguration
    {
        public BaseApplicationConfiguration()
        { }

        public virtual string Name { get; set; }
        public virtual string BaseUrl { get; set; }
        public virtual string ApplicationSalt { get; set; }
    }
}
