using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherSite.Cloud.IO.File
{
    using Microsoft.WindowsAzure.Storage;

    public class FileStorage
    {
        private CloudStorageAccount Account { get; set; }

        public FileStorage(CloudStorageAccount account)
        {
            this.Account = account;
        }
    }
}
