using System;
using System.Collections.Generic;

namespace FileMonitor.DataDB;



public partial class model1
{
    public int ServicePathSysId { get; set; }

    public int ServiceSysId { get; set; }
    public string PathToMonitor { get; set; } = null!;

    public DateTime LastChangeDateTime { get; set; }

    public DateTime CreateDate { get; set; }

    public int TimeCheckInterval { get; set; }

    public string Status { get; set; } = null!;

    public bool Active { get; set; }

    public string? FileNamePattern { get; set; }

    public int? NumberOfFilesForToday { get; set; }

    public string? LastFileReceived { get; set; }

    public int? NumberOfFilesForYesterday { get; set; }


}



