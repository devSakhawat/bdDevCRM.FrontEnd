using System;
using System.Collections.Generic;

namespace bdDevCRM.FrontEnd.Entities;

public partial class DmsFileUpdateHistory
{
    public int Id { get; set; }

    public string? EntityId { get; set; }

    public string? EntityType { get; set; }

    public string? DocumentType { get; set; }

    public string? OldFilePath { get; set; }

    public string? NewFilePath { get; set; }

    public int? VersionNumber { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public string? UpdateReason { get; set; }

    public string? Notes { get; set; }
}
