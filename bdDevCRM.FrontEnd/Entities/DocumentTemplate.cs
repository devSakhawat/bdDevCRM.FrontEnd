using System;
using System.Collections.Generic;

namespace bdDevCRM.FrontEnd.Entities;

public partial class DocumentTemplate
{
    public int DocumentId { get; set; }

    public string DocumentTitle { get; set; } = null!;

    public string? DocumentText { get; set; }

    public string TemplateName { get; set; } = null!;

    public int? DocumentTypeId { get; set; }
}
