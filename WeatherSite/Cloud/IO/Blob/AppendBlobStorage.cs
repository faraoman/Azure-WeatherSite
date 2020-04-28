using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherSite.Cloud.IO.Blob
{
    using Microsoft.WindowsAzure.Storage;
    using Microsoft.WindowsAzure.Storage.Blob;
    public class AppenBlobStorage
    {
        private CloudStorageAccount Account { get; set; }

        public AppenBlobStorage(CloudStorageAccount account)
        {
            Account = account;
        }


    }
}
