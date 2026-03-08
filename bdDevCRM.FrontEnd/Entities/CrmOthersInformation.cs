using System;
using System.Collections.Generic;

namespace bdDevCRM.FrontEnd.Entities;

public partial class CrmOthersInformation
{
    public int OthersInformationId { get; set; }

    public int ApplicantId { get; set; }

    public string? AdditionalInformation { get; set; }

    public string? OthersScannedCopyPath { get; set; }

    public DateTime CreatedDate { get; set; }

    public int CreatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public int? UpdatedBy { get; set; }

    public virtual CrmApplication Applicant { get; set; } = null!;
}
