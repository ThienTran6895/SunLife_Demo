using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SunLife.Web.Models;
using SunLife.Web.Repository;

namespace SunLife.Web.Controllers
{
    public class TablesController : Controller
    {
        public FileRepository fileRepository = new FileRepository();
        // GET: Tables
        public ActionResult Index(SunLifeFileModels file)
        {
            var data = fileRepository.GetAllFile(FileName: file.FileName, UploadDate: file.UploadDate);
            return View(data);
        }

        // GET: Tables/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Tables/Upload
        [HttpPost]
        public JsonResult Upload(SunLifeFileModels files)
        {
            for (int i = 0; i < Request.Files.Count; i++)
            {
                HttpPostedFileBase file = Request.Files[i]; //Uploaded file
                //Use the following properties to get file's name, size and MIMEType
                //var fileupload = Request.Files[i];   
                //files.FileID = Guid.NewGuid();
                files.FileName = file.FileName;
                //files.UploadDate = DateTime.Now.ToLocalTime();
                files.UploadPerson = "Admin";
                //int fileSize = file.ContentLength;
                //string fileName = file.FileName;
                //string mimeType = file.ContentType;
                //System.IO.Stream fileContent = file.InputStream;
                //To save file, use SaveAs method
                file.SaveAs(Server.MapPath("~/UploadFiles/") + files.FileName); //File will be saved in application root
            }
            var result = fileRepository.AddFile(files);
            return Json(result);           
        }

        public ActionResult DeleteFile(SunLifeFileModels file)
        {
            var result = fileRepository.DeleteFile(FileName: file.FileName);
            return View(result);
        }

        //public ActionResult Download()
        //{
        //    byte[] bytes;
        //    try
        //    {
        //        using (var stream = new MemoryStream)
        //        {
        //            if (stream == null)
        //            {
        //                throw new ArgumentNullException("stream");
        //            }
        //        }
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //    return null;
        //}
    }
}
