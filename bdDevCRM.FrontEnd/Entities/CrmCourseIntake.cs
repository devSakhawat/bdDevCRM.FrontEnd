using System;
using System.Collections.Generic;

namespace bdDevCRM.FrontEnd.Entities;

public partial class CrmCourseIntake
{
    public int CourseIntakeId { get; set; }

    public int CourseId { get; set; }

    public int? MonthId { get; set; }

    public string? IntakeTitile { get; set; }
}
