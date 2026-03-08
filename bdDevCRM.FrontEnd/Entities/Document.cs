using System;
using System.Collections.Generic;

namespace bdDevCRM.FrontEnd.Entities;

public partial class Document
{
    public int Documentid { get; set; }

    public int? Hrrecordid { get; set; }

    public int? Documenttypeid { get; set; }

    public string? Titleofdocument { get; set; }

    public string? Attacheddocument { get; set; }

    public string? Summary { get; set; }
}
