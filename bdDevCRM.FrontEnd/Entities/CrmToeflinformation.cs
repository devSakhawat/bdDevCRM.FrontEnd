using System;
using System.Collections.Generic;

namespace bdDevCRM.FrontEnd.Entities;

public partial class CrmToeflinformation
{
    public int ToeflinformationId { get; set; }

    public int ApplicantId { get; set; }

    public decimal? Toefllistening { get; set; }

    public decimal? Toeflreading { get; set; }

    public decimal? Toeflwriting { get; set; }

    public decimal? Toeflspeaking { get; set; }

    public decimal? ToefloverallScore { get; set; }

    public DateTime? Toefldate { get; set; }

    public string? ToeflscannedCopyPath { get; set; }

    public string? ToefladditionalInformation { get; set; }

    public DateTime CreatedDate { get; set; }

    public int CreatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public int? UpdatedBy { get; set; }

    public virtual CrmApplication Applicant { get; set; } = null!;
}
