using FileMonitor.Models;
using Microsoft.AspNetCore.Mvc;
using FileMonitor.DataDB;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;

namespace FileMonitor.Controllers
{
    public class FileDirController : Controller
    {
        private readonly RlvFileActivityMonitorContext _context;
        private readonly IWebHostEnvironment Environment;

        public FileDirController(Microsoft.AspNetCore.Hosting.IWebHostEnvironment _environment, RlvFileActivityMonitorContext context)
        {
           Environment = _environment;
            _context = context;           
        }

        [Route("/ServicePathToMonitors/FileDir/{ServicePathId}")]
        public ActionResult FileDir(int ServicePathId)
        {
            var path = from paths in _context.ServicePathToMonitors
                       where paths.ServicePathSysId == ServicePathId
                       select
                       paths.PathToMonitor;
                       

            //string path1 = path.FirstOrDefault();
            string path1 = @"C:\Users\DXGUIGAR\FTPS\DHL\PDC_Docs";

            /***   lambda version
            var pathV2 = _context.ServicePathToMonitors.FirstOrDefault(p => p.ServicePathSysId.Equals(ServicePathId));
            if (pathV2 != null)
            {
                var something = pathV2.PathToMonitor;
            }
            ***/

            //Fetch all files in the Folder (Directory).
            string[] filePaths = Directory.GetFiles(path1);

            //Copy File names to Model collection.
            List<FileDirModel> files = new List<FileDirModel>();
            foreach (string filePath in filePaths)
            {
                DateTime createDate = System.IO.File.GetCreationTime(filePath);
                if (createDate.Date == DateTime.Now.Date)
                {
                    files.Add(new FileDirModel { FileName = Path.GetFileName(filePath), LastModifiedDate = System.IO.File.GetCreationTime(filePath) });
                }
            }

            return View(files);            
        }



        public FileResult DownloadFile(string fileName, int ServicePathId)
        {
            var path = from paths in _context.ServicePathToMonitors
                       where paths.ServicePathSysId == ServicePathId
                       select
                       paths.PathToMonitor;

            string path1 = path.FirstOrDefault();

            //Build the File Path.
            //string path = Path.Combine(this.Environment.ContentRootPath) + fileName;
            string path2 = Path.Combine(path1 + "\\") + fileName;
            //string path = fileName;

            //Read the File data into Byte Array.
            byte[] bytes = System.IO.File.ReadAllBytes(path2);

            //Send the File to Download.
            return File(bytes, "application/octet-stream", fileName);
        }

    }

}



