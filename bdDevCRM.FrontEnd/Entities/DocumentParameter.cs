using System;
using System.Collections.Generic;

namespace bdDevCRM.FrontEnd.Entities;

public partial class DocumentParameter
{
    public int ParameterId { get; set; }

    public string ParameterName { get; set; } = null!;

    public string ParameterKey { get; set; } = null!;

    public string? ControlRole { get; set; }

    public string? DataSource { get; set; }

    public int? ControlSequence { get; set; }

    public string? DataTextField { get; set; }

    public string? DataValueField { get; set; }

    public string? CaseCading { get; set; }
}
