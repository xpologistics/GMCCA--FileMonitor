using System;
using System.Collections.Generic;

namespace FileMonitor.DataDB;

public partial class model2
{
    public int ServiceSysId { get; set; }

    public string ServiceName { get; set; } = null!;

    public DateTime CreateDate { get; set; }

    public bool Active { get; set; }
}
