using System;
using System.Collections.Generic;

namespace bdDevCRM.FrontEnd.Entities;

public partial class DmsDocumentType
{
    public int DocumentTypeId { get; set; }

    public string Name { get; set; } = null!;

    public string DocumentType { get; set; } = null!;

    public bool IsMandatory { get; set; }

    public string? AcceptedExtensions { get; set; }

    public int? MaxFileSizeMb { get; set; }

    public virtual ICollection<DmsDocument> DmsDocument { get; set; } = new List<DmsDocument>();
}
