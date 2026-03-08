using System;
using System.Collections.Generic;

namespace bdDevCRM.FrontEnd.Entities;

public partial class CrmIeltsinformation
{
    public int IeltsinformationId { get; set; }

    public int ApplicantId { get; set; }

    public decimal? Ieltslistening { get; set; }

    public decimal? Ieltsreading { get; set; }

    public decimal? Ieltswriting { get; set; }

    public decimal? Ieltsspeaking { get; set; }

    public decimal? IeltsoverallScore { get; set; }

    public DateTime? Ieltsdate { get; set; }

    public string? IeltsscannedCopyPath { get; set; }

    public string? IeltsadditionalInformation { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public int? UpdatedBy { get; set; }

    public virtual CrmApplication Applicant { get; set; } = null!;
}
