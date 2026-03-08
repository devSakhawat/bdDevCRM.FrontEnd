using System;
using System.Collections.Generic;

namespace bdDevCRM.FrontEnd.Entities;

public partial class AccessControl
{
    public int AccessId { get; set; }

    public string AccessName { get; set; } = null!;
}
