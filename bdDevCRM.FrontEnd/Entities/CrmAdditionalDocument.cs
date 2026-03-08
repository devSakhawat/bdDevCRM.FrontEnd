using System;
using System.Collections.Generic;

namespace bdDevCRM.FrontEnd.Entities;

public partial class CrmAdditionalDocument
{
    public int AdditionalDocumentId { get; set; }

    public string DocumentTitle { get; set; } = null!;

    public string DocumentPath { get; set; } = null!;

    public string DocumentName { get; set; } = null!;

    public string RecordType { get; set; } = null!;

    public DateTime CreatedDate { get; set; }

    public int CreatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public int? UpdatedBy { get; set; }

    public int? ApplicantId { get; set; }
}
