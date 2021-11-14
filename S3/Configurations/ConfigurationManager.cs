using S3.Constants;
using S3.Models.ConfigurationEntities;
using System;

namespace S3.Configurations
{
   public class ConfigurationManager
    {
       
        public S3Credential ReadS3CredintialsFromEnvironmentVariable(string bucketName=null)
        {
            var s3Credential = new S3Credential()
            {
                AccessKey = GetEnvironmentVariableValue(S3Constant.AccessKey),
                SecretKey = GetEnvironmentVariableValue(S3Constant.SecretKey),
                BucketName = GetEnvironmentVariableValue(bucketName!=null?bucketName:S3Constant.BucketName)
            };
            return s3Credential;    
        }
        private string GetEnvironmentVariableValue(string key) => Environment.GetEnvironmentVariable(key, EnvironmentVariableTarget.Machine);
    }
}
