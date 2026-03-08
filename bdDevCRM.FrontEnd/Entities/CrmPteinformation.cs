using System;
using System.Collections.Generic;

namespace bdDevCRM.FrontEnd.Entities;

public partial class CrmPteinformation
{
    public int PteinformationId { get; set; }

    public int ApplicantId { get; set; }

    public decimal? Ptelistening { get; set; }

    public decimal? Ptereading { get; set; }

    public decimal? Ptewriting { get; set; }

    public decimal? Ptespeaking { get; set; }

    public decimal? PteoverallScore { get; set; }

    public DateTime? Ptedate { get; set; }

    public string? PtescannedCopyPath { get; set; }

    public string? PteadditionalInformation { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public int? UpdatedBy { get; set; }

    public virtual CrmApplication Applicant { get; set; } = null!;
}
