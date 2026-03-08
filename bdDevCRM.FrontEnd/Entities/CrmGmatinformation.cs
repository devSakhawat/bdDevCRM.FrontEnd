using System;
using System.Collections.Generic;

namespace bdDevCRM.FrontEnd.Entities;

public partial class CrmGmatinformation
{
    public int GmatinformationId { get; set; }

    public int ApplicantId { get; set; }

    public decimal? Gmatlistening { get; set; }

    public decimal? Gmatreading { get; set; }

    public decimal? Gmatwriting { get; set; }

    public decimal? Gmatspeaking { get; set; }

    public decimal? GmatoverallScore { get; set; }

    public DateTime? Gmatdate { get; set; }

    public string? GmatscannedCopyPath { get; set; }

    public string? GmatadditionalInformation { get; set; }

    public DateTime CreatedDate { get; set; }

    public int CreatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public int? UpdatedBy { get; set; }

    public virtual CrmApplication Applicant { get; set; } = null!;
}
