using System;
using System.Collections.Generic;

namespace bdDevCRM.FrontEnd.Entities;

public partial class CrmAdditionalInfo
{
    public int AdditionalInfoId { get; set; }

    public int ApplicantId { get; set; }

    public bool? RequireAccommodation { get; set; }

    public bool? HealthNmedicalNeeds { get; set; }

    public string? HealthNmedicalNeedsRemarks { get; set; }

    public string? AdditionalInformationRemarks { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public int? UpdatedBy { get; set; }

    public virtual CrmApplication Applicant { get; set; } = null!;
}
