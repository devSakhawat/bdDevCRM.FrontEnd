using System;
using System.Collections.Generic;

namespace bdDevCRM.FrontEnd.Entities;

public partial class CrmEducationHistory
{
    public int EducationHistoryId { get; set; }

    public int ApplicantId { get; set; }

    public string? Institution { get; set; }

    public string? Qualification { get; set; }

    public int? PassingYear { get; set; }

    public string? Grade { get; set; }

    public string? DocumentPath { get; set; }

    public string? DocumentName { get; set; }

    public DateTime CreatedDate { get; set; }

    public int CreatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public int? UpdatedBy { get; set; }

    public virtual CrmApplication Applicant { get; set; } = null!;
}
