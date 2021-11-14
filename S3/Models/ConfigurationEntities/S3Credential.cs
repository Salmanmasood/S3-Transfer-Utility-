namespace S3.Models.ConfigurationEntities
{
   public class S3Credential
    {
        public string AccessKey { get; set; } = null!;
        public string SecretKey { get; set; } = null!;
        public string BucketName { get; set; } = null!;

    }
}
