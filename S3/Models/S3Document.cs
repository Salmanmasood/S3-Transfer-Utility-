using System.IO;

namespace S3.Models
{
   public class S3Document
    {
        public MemoryStream InputStream { get; set; } = null!;
        public string Key { get; set; } = null!;
        public string BucketName { get; set; } = null!;
    }
}
