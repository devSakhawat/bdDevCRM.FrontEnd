using System;
using System.Collections.Generic;

namespace bdDevCRM.FrontEnd.Entities;

public partial class CrmInstituteType
{
    public int InstituteTypeId { get; set; }

    public string InstituteTypeName { get; set; } = null!;
}
