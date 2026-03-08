using System;
using System.Collections.Generic;

namespace bdDevCRM.FrontEnd.Entities;

public partial class TokenBlacklist
{
    public string Token { get; set; } = null!;

    public DateTime ExpiryDate { get; set; }

    public Guid TokenId { get; set; }
}
