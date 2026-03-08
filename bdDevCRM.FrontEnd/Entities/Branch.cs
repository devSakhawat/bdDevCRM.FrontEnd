using System;
using System.Collections.Generic;

namespace bdDevCRM.FrontEnd.Entities;

public partial class Branch
{
    public int Branchid { get; set; }

    public string Branchname { get; set; } = null!;

    public string? Branchcode { get; set; }

    public string? Branchdescription { get; set; }

    public int? IsCostCentre { get; set; }

    public int? IsActive { get; set; }

    public int? DebitAccountHead { get; set; }

    public int? CreditAccountHead { get; set; }

    public int? ContraEntryApplicable { get; set; }

    public string? BranchAddress { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }
}
