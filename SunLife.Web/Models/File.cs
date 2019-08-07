using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SunLife.Web.Models
{
    public class SunLifeFileModels
    {
        public Guid FileID { get; set; }
        public string FileName { get; set; }
        public DateTime UploadDate { get; set; }
        public string UploadPerson { get; set; }
        
    }
}