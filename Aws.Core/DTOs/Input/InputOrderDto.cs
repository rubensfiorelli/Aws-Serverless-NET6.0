using AWS.Core.Entities;
using AWS.Core.Enums;

namespace AWS.Core.DTOs.Input
{
    public record InputOrderDto
    {
        public string? OrderNumber { get; set; }
        public decimal TotalPrice { get; set; }
        public Customer? Customer { get; init; }
        public Payment? Payment { get; set; }
        public string? Reason { get; set; }
        public StatusOrder Status { get; set; } = StatusOrder.Collected;
        public bool Cancelled { get; set; }

        public static implicit operator Order(InputOrderDto dto)
           => new()
           {
               OrderNumber = dto.OrderNumber,
               TotalPrice = dto.TotalPrice,
               Customer = dto.Customer,
               Payment = dto.Payment,
               Reason = dto.Reason,
               Status = dto.Status,
               Cancelled = dto.Cancelled
           };


    }
}
