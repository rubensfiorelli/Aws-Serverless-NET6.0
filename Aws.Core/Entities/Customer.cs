using Amazon.DynamoDBv2.DataModel;
using AWS.Core.Common;

namespace AWS.Core.Entities
{
    [DynamoDBTable("customers")]
    public sealed class Customer : BaseEntity
    {
        [DynamoDBProperty]
        public string Cpf { get; init; } = string.Empty;

        [DynamoDBProperty]
        public string Name { get; init; } = string.Empty;

        [DynamoDBProperty]
        public string Email { get; init; } = string.Empty;


    }
}
