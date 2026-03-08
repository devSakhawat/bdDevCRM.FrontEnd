using System;
using System.Collections.Generic;

namespace bdDevCRM.FrontEnd.Entities;

public partial class CrmApplicantCourse
{
    public int ApplicantCourseId { get; set; }

    public int ApplicantId { get; set; }

    public int CountryId { get; set; }

    public string? CountryName { get; set; }

    public int InstituteId { get; set; }

    public string? CourseTitle { get; set; }

    public int IntakeMonthId { get; set; }

    public string? IntakeMonth { get; set; }

    public int IntakeYearId { get; set; }

    public string? IntakeYear { get; set; }

    public string? ApplicationFee { get; set; }

    public int CurrencyId { get; set; }

    public int PaymentMethodId { get; set; }

    public string? PaymentMethod { get; set; }

    public string? PaymentReferenceNumber { get; set; }

    public DateTime? PaymentDate { get; set; }

    public string? Remarks { get; set; }

    public DateTime CreatedDate { get; set; }

    public int CreatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public int? UpdatedBy { get; set; }

    public int? CourseId { get; set; }

    public virtual CrmApplication Applicant { get; set; } = null!;
}
