using System;
using System.Collections.Generic;

namespace bdDevCRM.FrontEnd.Entities;

public partial class Docmdetails
{
    public int DocumentId { get; set; }

    public int UploadedBy { get; set; }

    public int DepartmentId { get; set; }

    public int Responsiblepersonto { get; set; }

    public string? Subject { get; set; }

    public string? Filename { get; set; }

    public string? Filedescription { get; set; }

    public string? Fullpath { get; set; }

    public int? StatusId { get; set; }

    public DateTime? UploadedDate { get; set; }

    public int? Lastopenorclosebyid { get; set; }

    public DateTime? Lastupdate { get; set; }

    public string? Remarks { get; set; }
}
