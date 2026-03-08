using System;
using System.Collections.Generic;

namespace bdDevCRM.FrontEnd.Entities;

public partial class GroupPermission
{
    public int PermissionId { get; set; }

    public string? Permissiontablename { get; set; }

    public int Groupid { get; set; }

    public int? Referenceid { get; set; }

    public int? Parentpermission { get; set; }
}
