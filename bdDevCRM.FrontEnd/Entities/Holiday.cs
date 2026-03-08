using System;
using System.Collections.Generic;

namespace bdDevCRM.FrontEnd.Entities;

public partial class Holiday
{
    public int HolidayId { get; set; }

    public int? HolidayType { get; set; }

    public DateOnly? HolidayDate { get; set; }

    public int? Shiftid { get; set; }

    public int? Month { get; set; }

    public string? MonthName { get; set; }

    public int? YearName { get; set; }

    public DateTime? LastUpdatedDate { get; set; }

    public string? DayName { get; set; }

    public string? Description { get; set; }

    public int? RosterReschedule { get; set; }
}
