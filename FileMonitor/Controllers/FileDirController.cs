using FileMonitor.Models;
using Microsoft.AspNetCore.Mvc;

namespace FileMonitor.Controllers
{
    public class FileDirController : Controller
    {
        private Microsoft.AspNetCore.Hosting.IWebHostEnvironment Environment;

        public FileDirController(Microsoft.AspNetCore.Hosting.IWebHostEnvironment _environment)
        {
            Environment = _environment;
        }

        public IActionResult FileDirView()
        {
            //Fetch all files in the Folder (Directory).
            string[] filePaths = Directory.GetFiles(Path.Combine(this.Environment.WebRootPath, @"E:\XMS_File_Interfaces\XMSFileDistributorService\Archive"));

            //Copy File names to Model collection.
            List<FileDirModel> files = new List<FileDirModel>();
            foreach (string filePath in filePaths)
            {
                files.Add(new FileDirModel { FileName = Path.GetFileName(filePath) });
            }

            return View(files);
        }

        public FileResult DownloadFile(string fileName)
        {
            //Build the File Path.
            string path = Path.Combine(this.Environment.WebRootPath, "Files/") + fileName;

            //Read the File data into Byte Array.
            byte[] bytes = System.IO.File.ReadAllBytes(path);

            //Send the File to Download.
            return File(bytes, "application/octet-stream", fileName);
        }
    }
}



