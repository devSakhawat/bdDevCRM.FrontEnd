using System;
using System.Collections.Generic;

namespace bdDevCRM.FrontEnd.Entities;

public partial class CrmApplicantInfo
{
    public int ApplicantId { get; set; }

    public int ApplicationId { get; set; }

    public int GenderId { get; set; }

    public string? TitleValue { get; set; }

    public string? TitleText { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public DateTime? DateOfBirth { get; set; }

    public int MaritalStatusId { get; set; }

    public string? Nationality { get; set; }

    public bool? HasValidPassport { get; set; }

    public string? PassportNumber { get; set; }

    public DateTime? PassportIssueDate { get; set; }

    public DateTime? PassportExpiryDate { get; set; }

    public string? PhoneCountryCode { get; set; }

    public string? PhoneAreaCode { get; set; }

    public string? PhoneNumber { get; set; }

    public string? Mobile { get; set; }

    public string? EmailAddress { get; set; }

    public string? SkypeId { get; set; }

    public string? ApplicantImagePath { get; set; }

    public DateTime CreatedDate { get; set; }

    public int CreatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public int? UpdatedBy { get; set; }

    public virtual CrmApplication Application { get; set; } = null!;
}
