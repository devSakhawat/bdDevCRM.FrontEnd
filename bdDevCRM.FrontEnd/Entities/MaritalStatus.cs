using System;
using System.Collections.Generic;

namespace bdDevCRM.FrontEnd.Entities;

public partial class MaritalStatus
{
    public int MaritalStatusId { get; set; }

    public string? MaritalStatusName { get; set; }

    public int? IsActive { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }
}
