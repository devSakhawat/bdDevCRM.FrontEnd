using System;
using System.Collections.Generic;

namespace bdDevCRM.FrontEnd.Entities;

/// <summary>
/// Stores intake months for CRM applications
/// </summary>
public partial class CrmIntakeMonth
{
    public int IntakeMonthId { get; set; }

    public string MonthName { get; set; } = null!;

    public string? MonthCode { get; set; }

    public int MonthNumber { get; set; }

    public string? Description { get; set; }

    public bool? IsActive { get; set; }

    public DateTime CreatedDate { get; set; }

    public int CreatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public int? UpdatedBy { get; set; }
}
