using System;
using System.Collections.Generic;

namespace bdDevCRM.FrontEnd.Entities;

public partial class CrmWorkExperience
{
    public int WorkExperienceId { get; set; }

    public int ApplicantId { get; set; }

    public string? NameOfEmployer { get; set; }

    public string? Position { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public decimal? Period { get; set; }

    public string? MainResponsibility { get; set; }

    public string? ScannedCopyPath { get; set; }

    public string? DocumentName { get; set; }

    public DateTime CreatedDate { get; set; }

    public int CreatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public int? UpdatedBy { get; set; }

    public virtual CrmApplication Applicant { get; set; } = null!;
}
