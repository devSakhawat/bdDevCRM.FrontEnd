using System;
using System.Collections.Generic;

namespace bdDevCRM.FrontEnd.Entities;

public partial class Employment
{
    public int HrrecordId { get; set; }

    public string? EmployeeId { get; set; }

    public int? EmployeeType { get; set; }

    public int? Designationid { get; set; }

    public DateTime? StartDate { get; set; }

    public DateOnly? EmploymentDate { get; set; }

    public int? CompanyId { get; set; }

    public int? DepartmentId { get; set; }

    public int? ReportTo { get; set; }

    public string? TelephoneExtension { get; set; }

    public string? OfficialEmail { get; set; }

    public string? EmergencyContactName { get; set; }

    public string? EmergencyContactNo { get; set; }

    public string? Duties { get; set; }

    public string? AttendanceCardNo { get; set; }

    public int? UserId { get; set; }

    public DateTime? LastUpdatedDate { get; set; }

    public int? BankBranchId { get; set; }

    public string? BankAccountNo { get; set; }

    public int? Branchid { get; set; }

    public int? Shiftid { get; set; }

    public string? Gpfno { get; set; }

    public DateOnly? JobEndDate { get; set; }

    public int? Joiningpost { get; set; }

    public string? Experience { get; set; }

    public int? Reportdepid { get; set; }

    public int? FuncId { get; set; }

    public DateOnly? ContractEndDate { get; set; }

    public int? JobEndTypeId { get; set; }

    public int? GradeId { get; set; }

    public string? TinNumber { get; set; }

    public int? PostingType { get; set; }

    public int? IsOteligible { get; set; }

    public string? ContactAddress { get; set; }

    public int? IsFieldForce { get; set; }

    public int? ApproverDepartmentId { get; set; }

    public int? Approver { get; set; }

    public int? DivisionId { get; set; }

    public int? FacilityId { get; set; }

    public int? SectionId { get; set; }

    public int? IsReserved { get; set; }

    public DateOnly? ConfirmationDate { get; set; }

    public DateOnly? AppointmentDate { get; set; }

    public int? SalaryLocation { get; set; }

    public int? OmitLate { get; set; }

    public DateOnly? PossibleConfirmationDate { get; set; }

    public string? JobResponsibilities { get; set; }

    public string? FunctionalJob { get; set; }

    public int? ApplicantId { get; set; }

    public string? SeparationRemarks { get; set; }

    public DateOnly? ResignationSummiteDate { get; set; }

    public int? IsProbExtnAllow { get; set; }

    public int? Jobid { get; set; }

    public int? VerificationStatus { get; set; }
}
