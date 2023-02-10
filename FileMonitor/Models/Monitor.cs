


namespace FileMonitor.Models
{
    public class MonitorDetails
    {
        public int ServicePathSysid { get; set; }
        public string ServiceName { get; set; }
        public string PathToMonitor { get; set; }
        public int ServiceSysId { get; set; }
        public DateTime LastChangeDateTime { get; set; }
        public DateTime CreateDate { get; set; }
        public string TimeCheckInterval { get; set; }
        public string Status { get; set; }
        public string Active { get; set; }
        public string FileNamePattern { get; set; }
        public int NumberOfFilesForToday { get; set; }
        public string LastFileReceived { get; set; }
        public int NumberOfFilesForYesterday { get; set; }
    }


    public class MonitorService
    {
        public int ServiceSysId { get; set; }
        public string ServiceName { get; set; }
        public DateTime CreateDate { get; set; }
        public bool Active { get; set; }
    }

}
