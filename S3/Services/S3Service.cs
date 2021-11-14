using Amazon.Runtime;
using Amazon.S3;
using Amazon.S3.Transfer;
using S3.Configurations;
using S3.Models;
using S3.Models.DTO;
using System.Threading.Tasks;

namespace S3.Services
{
   public class S3Service : IS3Service
    {
        private readonly ConfigurationManager _configurationManager;
        public S3Service()
        {
            _configurationManager = new ConfigurationManager();
        }
        public async Task<S3DTO> UploadFiletoS3BucketAsync(S3Document s3Document)
        {
            var s3DTO = new S3DTO();
            
            try
            {
                var s3Credential = _configurationManager.ReadS3CredintialsFromEnvironmentVariable(); //read Access key ,secret key and Default Bucketname 
                var credentials = new BasicAWSCredentials(s3Credential.SecretKey, s3Credential.SecretKey);
                var config = new AmazonS3Config()
                {
                    RegionEndpoint = Amazon.RegionEndpoint.APSouth1
                };
                using var client = new AmazonS3Client(credentials, config);
                var uploadRequest = new TransferUtilityUploadRequest()
                {
                    InputStream = s3Document.InputStream,
                    Key = s3Document.Key,
                    BucketName = s3Document.BucketName,
                    CannedACL = S3CannedACL.PublicRead
                };
                var fileTransferUtility = new TransferUtility(client);
                await fileTransferUtility.UploadAsync(uploadRequest);
                s3DTO.StatusCode = "200";
                s3DTO.Message = $"{s3Document.Key} Uploaded Successfully on {s3Document.BucketName}";
            }
            catch (AmazonS3Exception amazonS3Exception)
            {
                s3DTO.StatusCode = amazonS3Exception.ErrorCode;
                s3DTO.Message = amazonS3Exception.Message;
            }

            return s3DTO;
        }
    }
}
