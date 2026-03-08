using System;
using System.Collections.Generic;

namespace bdDevCRM.FrontEnd.Entities;

public partial class CrmApplicantReference
{
    public int ApplicantReferenceId { get; set; }

    public int ApplicantId { get; set; }

    public string Name { get; set; } = null!;

    public string? Designation { get; set; }

    public string? Institution { get; set; }

    public string? EmailId { get; set; }

    public string? PhoneNo { get; set; }

    public string? FaxNo { get; set; }

    public string? Address { get; set; }

    public string? City { get; set; }

    public string? State { get; set; }

    public int? CountryId { get; set; }

    public string? PostOrZipCode { get; set; }

    public DateTime CreatedDate { get; set; }

    public int CreatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public int? UpdatedBy { get; set; }

    public virtual CrmApplication Applicant { get; set; } = null!;
}
