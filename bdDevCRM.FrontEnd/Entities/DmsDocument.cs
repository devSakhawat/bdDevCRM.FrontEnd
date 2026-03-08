using System;
using System.Collections.Generic;

namespace bdDevCRM.FrontEnd.Entities;

public partial class DmsDocument
{
    public int DocumentId { get; set; }

    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    public string FileName { get; set; } = null!;

    public string FileExtension { get; set; } = null!;

    public long FileSize { get; set; }

    public string FilePath { get; set; } = null!;

    public DateTime? UploadDate { get; set; }

    public string? UploadedByUserId { get; set; }

    public int DocumentTypeId { get; set; }

    public string? ReferenceEntityType { get; set; }

    public string? ReferenceEntityId { get; set; }

    public int? FolderId { get; set; }

    public string? SystemTag { get; set; }

    public int? CurrentEntityId { get; set; }

    public virtual ICollection<DmsDocumentAccessLog> DmsDocumentAccessLog { get; set; } = new List<DmsDocumentAccessLog>();

    public virtual ICollection<DmsDocumentTagMap> DmsDocumentTagMap { get; set; } = new List<DmsDocumentTagMap>();

    public virtual ICollection<DmsDocumentVersion> DmsDocumentVersion { get; set; } = new List<DmsDocumentVersion>();

    public virtual DmsDocumentType DocumentType { get; set; } = null!;
}
