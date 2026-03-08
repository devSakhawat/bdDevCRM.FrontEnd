using System;
using System.Collections.Generic;

namespace bdDevCRM.FrontEnd.Entities;

/// <summary>
/// Stores payment methods available in CRM system
/// </summary>
public partial class CrmPaymentMethod
{
    public int PaymentMethodId { get; set; }

    public string PaymentMethodName { get; set; } = null!;

    public string? PaymentMethodCode { get; set; }

    public string? Description { get; set; }

    public decimal? ProcessingFee { get; set; }

    public string? ProcessingFeeType { get; set; }

    public bool IsOnlinePayment { get; set; }

    public bool? IsActive { get; set; }

    public DateTime CreatedDate { get; set; }

    public int CreatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public int? UpdatedBy { get; set; }
}
