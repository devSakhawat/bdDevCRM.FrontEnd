using System;
using System.Collections.Generic;

namespace bdDevCRM.FrontEnd.Entities;

public partial class Timesheet
{
    public int Timesheetid { get; set; }

    public int? Hrrecordid { get; set; }

    public int? Projectid { get; set; }

    public int? Taskid { get; set; }

    public DateTime? WorkingLogDate { get; set; }

    public double? WorkedLogHour { get; set; }

    public DateTime? LogEntryDate { get; set; }

    public double? BillableLogHour { get; set; }

    public double? NoBillableLogHour { get; set; }

    public int? Isapprove { get; set; }

    public int? ApproveRhRrecordid { get; set; }

    public DateTime? ApproveDate { get; set; }

    public int? BillStatus { get; set; }
}
