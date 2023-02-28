using Microsoft.AspNetCore.Mvc;
using FileMonitor.DataDB;

namespace FileMonitor.Controllers
{
    public class ServicePathToMonitorsController : Controller
    {
        private readonly RlvFileActivityMonitorContext _context;

        public ServicePathToMonitorsController(RlvFileActivityMonitorContext context)
        {
            _context = context;
        }


        public ActionResult Monitor()
        {

            
            var viewModels = (from m1 in _context.ServicePathToMonitors
                              join m2 in _context.Services on m1.ServiceSysId equals m2.ServiceSysId
                              select new ServiceViewModel()
                              {
                                  ServiceName = m2.ServiceName,
                                  FileNamePattern = m1.FileNamePattern,
                                  TimeCheckInterval = m1.TimeCheckInterval,
                                  LastFileReceived = m1.LastFileReceived,
                                  LastChangeDateTime = m1.LastChangeDateTime,
                                  NumberOfFilesForToday = m1.NumberOfFilesForToday,
                                  NumberOfFilesForYesterday = m1.NumberOfFilesForYesterday,
                                  Status = m1.Status,
                                  ServicePathSysId = m1.ServicePathSysId.ToString()                               
                              }
                             ).ToList();

            return View(viewModels);
        }



    }
}