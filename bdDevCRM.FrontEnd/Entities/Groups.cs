using System;
using System.Collections.Generic;

namespace bdDevCRM.FrontEnd.Entities;

public partial class Groups
{
    public int GroupId { get; set; }

    public string? GroupName { get; set; }

    public int? IsDefault { get; set; }
}
