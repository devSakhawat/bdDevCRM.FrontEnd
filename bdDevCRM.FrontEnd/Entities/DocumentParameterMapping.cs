using System;
using System.Collections.Generic;

namespace bdDevCRM.FrontEnd.Entities;

public partial class DocumentParameterMapping
{
    public int MappingId { get; set; }

    public int? DocumentTypeId { get; set; }

    public int? ParameterId { get; set; }

    public bool? IsVisible { get; set; }

    public virtual Documanttype? DocumentType { get; set; }

    public virtual DocumentParameter? Parameter { get; set; }
}
