using Amazon.DynamoDBv2.DataModel;
using AWS.Core.Common;
using AWS.Core.Enums;

namespace AWS.Core.Entities
{

    [DynamoDBTable("orders")]
    public sealed class Order : BaseEntity
    {
        [DynamoDBProperty]
        public string? OrderNumber { get; set; }

        [DynamoDBProperty]
        public decimal TotalPrice { get; set; }

        [DynamoDBProperty]
        public List<Product> Products { get; set; } = new List<Product>();

        [DynamoDBProperty]
        public Customer? Customer { get; init; }

        [DynamoDBProperty]
        public Payment? Payment { get; set; }

        [DynamoDBProperty]
        public string? Reason { get; set; }

        [DynamoDBProperty]
        public StatusOrder Status { get; set; } = StatusOrder.Collected;

        [DynamoDBProperty]
        public bool Cancelled { get; set; } = false;
    }
}
