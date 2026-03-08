using System;
using System.Collections.Generic;

namespace bdDevCRM.FrontEnd.Entities;

public partial class SystemSettings
{
    public int SettingsId { get; set; }

    public int CompanyId { get; set; }

    public string? Theme { get; set; }

    public string? Language { get; set; }

    public int? MinLoginLength { get; set; }

    public int? MinPassLength { get; set; }

    /// <summary>
    /// 1=Alphanumeric, 2=Alphabetic, 3=Numeric
    /// </summary>
    public int? PassType { get; set; }

    public bool? SpecialCharAllowed { get; set; }

    public int? WrongAttemptNo { get; set; }

    public int? ChangePassDays { get; set; }

    public bool? ChangePassFirstLogin { get; set; }

    public int? PassExpiryDays { get; set; }

    public string? ResetPass { get; set; }

    /// <summary>
    /// 1=SysAdmin, 2=User
    /// </summary>
    public int? PassResetBy { get; set; }

    public int? OldPassUseRestriction { get; set; }

    public DateTime? LastUpdatedDate { get; set; }

    /// <summary>
    /// 0=Native SQL, 1=ODBC
    /// </summary>
    public bool? OdbcClientList { get; set; }

    public int? UserId { get; set; }

    public int? IsPasswordChange { get; set; }

    public int? IsPasswordExpire { get; set; }

    /// <summary>
    /// 0=Disable,1=Enable
    /// </summary>
    public int? IsWebLoginEnable { get; set; }

    public int? IsPaddingApplicable { get; set; }

    public int? DeleteApproveLeaveUponPunch { get; set; }

    public int? DeleteLateUponAttendanceApproval { get; set; }

    public int? IsOtLimitApplicable { get; set; }

    public int? IsSingleBranchApplicable { get; set; }

    public int? CheckPreviousAbsenteeism { get; set; }

    public int? BypassDefaultStateForSameBoss { get; set; }

    public int? DefaultLateDeductionDays { get; set; }

    public int? CheckingApproverSettings { get; set; }

    public int? IsOtCalculateForSalary { get; set; }

    public int? IsGradeWiseLeave { get; set; }

    public int? IsEmployeeIdAutoGenereted { get; set; }

    public int? DefaultEarlyExitDeductionDays { get; set; }

    public int? EnableMultiplePolicyForSameLeaveType { get; set; }

    public int? IsAbsenteeismMarge { get; set; }

    public int? IsTotalBillingApplicable { get; set; }

    public int? EnableApproverCheckingWhileApplication { get; set; }

    public int? EnableDelayOnShiftInGraceTime { get; set; }

    public int? EnableLateAfterShiftInGraceTime { get; set; }

    public int? EnableEarlyExitBeforeShiftOutGraceTime { get; set; }

    public int? EnableAbsentAfterLateTime { get; set; }

    public int? EnableAbsentBeforeEarlyExitTime { get; set; }

    public int? EnableAbsentForNoOutPunch { get; set; }

    public int? LateTime { get; set; }

    public int? EarlyExitTime { get; set; }

    public int? EnableCustomStatusOutPunch { get; set; }

    public string? CustomStatusForNoOutPunch { get; set; }

    public int? EnableCustomStatusAfterShiftInGraceTime { get; set; }

    public int? CustomStatusForAfterShiftinGraceTime { get; set; }

    public int? IsOtcalculateOnHolidayWekend { get; set; }

    public int? DefaultLateDeductionDaysNext { get; set; }

    public int? IsArearFestibleCalculateOnSalary { get; set; }

    public int? PerquisiteLimit { get; set; }

    public int? RegulariseAttendaceDaysLimit { get; set; }

    public int? DefaultLateDeductionDaysFirstTime { get; set; }

    public int? ShortLeaveSlot { get; set; }

    public decimal? CasualWorkerAmount { get; set; }

    public int? IsLateEarlyExistClearOutAgainstHoliday { get; set; }
}
