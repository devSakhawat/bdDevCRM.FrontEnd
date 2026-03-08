using System;
using System.Collections.Generic;

namespace bdDevCRM.FrontEnd.Entities;

public partial class ApproverDetails
{
    public int RemarksId { get; set; }

    public int MenuId { get; set; }

    public int ApplicationId { get; set; }

    public bool IsOpen { get; set; }

    public string? Comments { get; set; }

    public DateTime? ApprovedDate { get; set; }

    public int? ApplicantHrRecordId { get; set; }

    public int? ApprovedBy { get; set; }

    public int? ApproverType { get; set; }

    public int? Sequence { get; set; }

    public int? ModuleId { get; set; }

    public int? CompanyId { get; set; }

    public int? BranchId { get; set; }

    public int? DivisionId { get; set; }

    public int? DepartmentId { get; set; }

    public int? FacilityId { get; set; }

    public int? SectionId { get; set; }

    public int? DesignationId { get; set; }

    public int? GradeId { get; set; }

    public int? EmployeeTypeId { get; set; }

    public int? FuncId { get; set; }

    public int? AssignApproverId { get; set; }
}
