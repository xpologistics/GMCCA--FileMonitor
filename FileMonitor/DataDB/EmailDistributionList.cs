using System;
using System.Collections.Generic;

namespace FileMonitor.DataDB;

public partial class EmailDistributionList
{
    public int ServicePathSysId { get; set; }

    public string EmailAddress { get; set; } = null!;

    public DateTime CreateDate { get; set; }
}
