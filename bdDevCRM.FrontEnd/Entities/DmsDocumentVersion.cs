using System;
using System.Collections.Generic;

namespace bdDevCRM.FrontEnd.Entities;

public partial class DmsDocumentVersion
{
    public int VersionId { get; set; }

    public int DocumentId { get; set; }

    public int VersionNumber { get; set; }

    public string FileName { get; set; } = null!;

    public string FilePath { get; set; } = null!;

    public DateTime? UploadedDate { get; set; }

    public string? UploadedBy { get; set; }

    public bool? IsCurrentVersion { get; set; }

    public string? VersionNotes { get; set; }

    public int? PreviousVersionId { get; set; }

    public long? FileSize { get; set; }

    public virtual DmsDocument Document { get; set; } = null!;
}
