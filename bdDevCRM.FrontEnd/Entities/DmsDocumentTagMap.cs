using System;
using System.Collections.Generic;

namespace bdDevCRM.FrontEnd.Entities;

public partial class DmsDocumentTagMap
{
    public int DocumentId { get; set; }

    public int TagId { get; set; }

    public int TagMapId { get; set; }

    public virtual DmsDocument Document { get; set; } = null!;

    public virtual DmsDocumentTag Tag { get; set; } = null!;
}
