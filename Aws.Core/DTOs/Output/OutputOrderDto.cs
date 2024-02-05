using AWS.Core.Entities;
using AWS.Core.Enums;

namespace AWS.Core.DTOs.Output
{
    public record OutputOrderDto
    {
        public string? Id { get; init; }
        public string? OrderNumber { get; set; }
        public decimal TotalPrice { get; set; }
        public Customer? Customer { get; init; }
        public Payment? Payment { get; set; }
        public string? Reason { get; set; }
        public StatusOrder Status { get; set; } = StatusOrder.Collected;
        public bool Cancelled { get; set; } = false;

        public List<Product>? Products { get; set; }

        public static implicit operator OutputOrderDto(Order entity)
            => new()
            {
                Id = entity.Id,
                OrderNumber = entity.OrderNumber,
                TotalPrice = entity.TotalPrice,
                Customer = entity.Customer,
                Payment = entity.Payment,
                Reason = entity.Reason,
                Status = entity.Status,
                Cancelled = entity.Cancelled,
                Products = new List<Product>()

            };

    }
}
