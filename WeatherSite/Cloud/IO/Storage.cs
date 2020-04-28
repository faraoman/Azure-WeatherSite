using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherSite.Cloud.IO
{
    using Microsoft.WindowsAzure.Storage;
    public class Storage
    {
        public string ConnectionString { get; private set; }
        private CloudStorageAccount Account { get; set; }

        public Blob.BlobStorage Blob { get { return new IO.Blob.BlobStorage(Account); } }

        public Storage(string connectionString)
        {
            this.ConnectionString = connectionString;
            CloudStorageAccount storageAccount = null;
            if (CloudStorageAccount.TryParse(connectionString, out storageAccount))
            {
                Account = storageAccount;
            }
        }

        public static CloudStorageAccount GetStorageAccount(string connectionString)
        {
            CloudStorageAccount storageAccount = null;
            CloudStorageAccount.TryParse(connectionString, out storageAccount);
            return storageAccount;
        }
    }
}
