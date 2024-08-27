﻿namespace EXE201.SmartThrive.Domain.Entities;

public class Order : BaseEntity
{
    public Guid? PackageId { get; set; }
    
    public Guid? VoucherId { get; set; }

    public string? PaymentMethod { get; set; }

    public int? Amount { get; set; }

    public decimal? TotalPrice { get; set; }

    public string? Description { get; set; }

    public string? Status { get; set; }

    public virtual Package? Package { get; set; }
    
    public virtual Voucher? Voucher { get; set; }
    
    public virtual ICollection<OrderDetail>? OrderDetails { get; set; }
}