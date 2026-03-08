using System;
using System.Collections.Generic;

namespace bdDevCRM.FrontEnd.Entities;

public partial class RefreshTokens
{
    public int RefreshTokenId { get; set; }

    public int UserId { get; set; }

    public string Token { get; set; } = null!;

    public DateTime ExpiryDate { get; set; }

    public DateTime CreatedDate { get; set; }

    public bool IsRevoked { get; set; }

    public DateTime? RevokedDate { get; set; }

    public string? CreatedByIp { get; set; }

    public string? ReplacedByToken { get; set; }
}
