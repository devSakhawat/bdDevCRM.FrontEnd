using System;
using System.Collections.Generic;

namespace bdDevCRM.FrontEnd.Entities;

public partial class DmsDocumentFolder
{
    public int FolderId { get; set; }

    public int? ParentFolderId { get; set; }

    public string FolderName { get; set; } = null!;

    public string? OwnerId { get; set; }

    public string? ReferenceEntityType { get; set; }

    public string? ReferenceEntityId { get; set; }

    public int? DocumentId { get; set; }

    public virtual ICollection<DmsDocumentFolder> InverseParentFolder { get; set; } = new List<DmsDocumentFolder>();

    public virtual DmsDocumentFolder? ParentFolder { get; set; }
}
