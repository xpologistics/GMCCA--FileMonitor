using FileMonitor.Models;
using Microsoft.AspNetCore.Mvc;
using FileMonitor.DataDB;
using Microsoft.EntityFrameworkCore;

namespace FileMonitor.Controllers
{
    public class FileDirController : Controller
    {

        //private Microsoft.AspNetCore.Hosting.IWebHostEnvironment Environment;

        //public FileDirController(Microsoft.AspNetCore.Hosting.IWebHostEnvironment _environment)
        //{
        //    Environment = _environment;
        //}


        private readonly RlvFileActivityMonitorContext _context;

        public FileDirController(RlvFileActivityMonitorContext context)
        {
            _context = context;
        }


        [Route("/ServicePathToMonitors/FileDir/{ServicePathId}")]
        public ActionResult FileDir(int ServicePathId)
        {

            var path = _context.ServicePathToMonitors
             .Include(s => s.PathToMonitor)
             .AsNoTracking()
             .FirstOrDefaultAsync(nameof => nameof.ServicePathSysId == ServicePathId);


            var model = _context.ServicePathToMonitors.ServicePathSysId;
            return View(model);


            //Fetch all files in the Folder (Directory).
            string[] filePaths = Directory.GetFiles(Path.Combine("C:", path.ToString()));
            
            //Copy File names to Model collection.
            List<FileDirModel> files = new List<FileDirModel>();
            foreach (string filePath in filePaths)
            {
                files.Add(new FileDirModel { FileName = Path.GetFileName(filePath) });
            }

            return View(files);
           
        }




        



        /**

        public FileResult DownloadFile(string fileName)
        {
            //Build the File Path.
            string path = Path.Combine(this.Environment.WebRootPath, "Files/") + fileName;

            //Read the File data into Byte Array.
            byte[] bytes = System.IO.File.ReadAllBytes(@"C:\Users\DXGUIGAR\MR_Applications\BAC");

            //Send the File to Download.
            return File(bytes, "application/octet-stream", fileName);
        }
        **/
    }

}



