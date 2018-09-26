using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestNSwagNetCoreApp
{
    using Microsoft.AspNetCore.Http;

    /// <summary>
    /// The model used when uploading a file
    /// </summary>
    public class FileUploadModel
    {
        /// <summary>
        /// The file that is getting uploaded
        /// </summary>
        public IFormFile File { get; set; }
    }
}
