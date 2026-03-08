using System;
using System.Collections.Generic;

namespace bdDevCRM.FrontEnd.Entities;

public partial class CrmInstitute
{
    public int InstituteId { get; set; }

    public int CountryId { get; set; }

    public string InstituteName { get; set; } = null!;

    public string? Campus { get; set; }

    public string? Website { get; set; }

    public decimal? MonthlyLivingCost { get; set; }

    public string? FundsRequirementforVisa { get; set; }

    public decimal? ApplicationFee { get; set; }

    public int? CurrencyId { get; set; }

    public bool? IsLanguageMandatory { get; set; }

    public string? LanguagesRequirement { get; set; }

    public string? InstitutionalBenefits { get; set; }

    public string? PartTimeWorkDetails { get; set; }

    public string? ScholarshipsPolicy { get; set; }

    public string? InstitutionStatusNotes { get; set; }

    public string? InstitutionLogo { get; set; }

    public string? InstitutionProspectus { get; set; }

    public int? InstituteTypeId { get; set; }

    public string? InstituteCode { get; set; }

    public string? InstituteEmail { get; set; }

    public string? InstituteAddress { get; set; }

    public string? InstitutePhoneNo { get; set; }

    public string? InstituteMobileNo { get; set; }

    public bool? Status { get; set; }
}
