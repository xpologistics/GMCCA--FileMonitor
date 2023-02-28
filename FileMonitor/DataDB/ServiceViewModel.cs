using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FileMonitor.DataDB
{
    public class ServiceViewModel
    {
        public string? ServiceName { get; set; }
        public string? FileNamePattern { get; set; }
        public int TimeCheckInterval { get; set; }
        public string? LastFileReceived { get; set; }
        public DateTime LastChangeDateTime { get; set; }
        public int? NumberOfFilesForToday { get; set; }
        public int? NumberOfFilesForYesterday { get; set; }
        public string Status { get; set; } = null!;
        public string? ServicePathSysId { get; set; }
        public string? PathToMonitor { get; set; }  
    }
}


