using System;
using System.Collections.Generic;

namespace bdDevCRM.FrontEnd.Entities;

public partial class CrmCourse
{
    public int CourseId { get; set; }

    public int InstituteId { get; set; }

    public string? CourseTitle { get; set; }

    public string? CourseLevel { get; set; }

    public decimal? CourseFee { get; set; }

    public decimal? ApplicationFee { get; set; }

    public int? CurrencyId { get; set; }

    public decimal? MonthlyLivingCost { get; set; }

    public string? PartTimeWorkDetails { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public string? CourseBenefits { get; set; }

    public string? LanguagesRequirement { get; set; }

    public string? CourseDuration { get; set; }

    public string? CourseCategory { get; set; }

    public string? AwardingBody { get; set; }

    public string? AdditionalInformationOfCourse { get; set; }

    public string? GeneralEligibility { get; set; }

    public string? FundsRequirementforVisa { get; set; }

    public string? InstitutionalBenefits { get; set; }

    public string? VisaRequirement { get; set; }

    public string? CountryBenefits { get; set; }

    public string? KeyModules { get; set; }

    public bool? Status { get; set; }

    public string? After2YearsPswcompletingCourse { get; set; }

    public string? DocumentId { get; set; }
}
