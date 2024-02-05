using Amazon.DynamoDBv2.DataModel;
using AWS.Core.Common;

namespace AWS.Core.Entities
{
    [DynamoDBTable("products")]
    public class Product : BaseEntity
    {

        [DynamoDBProperty]
        public string? Title { get; set; }

        [DynamoDBProperty]
        public decimal Price { get; set; }

        [DynamoDBProperty]
        public int Qty { get; set; }

        [DynamoDBProperty]
        public bool Reserved { get; set; } = false;
    }
}