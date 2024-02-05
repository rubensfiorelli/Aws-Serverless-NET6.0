using Amazon.DynamoDBv2.DataModel;
using AWS.Core.Common;

namespace AWS.Core.Entities
{
    [DynamoDBTable("payments")]
    public class Payment : BaseEntity
    {
        [DynamoDBProperty]
        public string? CardNumber { get; init; }

        [DynamoDBProperty]
        public string? Validate { get; init; }

        [DynamoDBProperty]
        public string? Cvv { get; init; }
    }
}
