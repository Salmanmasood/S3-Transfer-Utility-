using S3.SqlServer.Enums;

namespace S3.SqlServer.Models
{
   public class Document:BaseEntity
    {
        public string Name { get; set; } = null!;
        public FileType FileType { get; set; } = null!;
    }
}
