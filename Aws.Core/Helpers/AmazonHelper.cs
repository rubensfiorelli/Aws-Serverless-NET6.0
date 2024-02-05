using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.Model;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DocumentModel;
using Amazon;

namespace AWS.Core.Helpers
{
    public static class AmazonHelper
    {
        public static T ToObject<T>(this Dictionary<string, AttributeValue> keyValues)
        {
            var document = Document.FromAttributeMap(keyValues);
            var clientDynamoDB = new AmazonDynamoDBClient(RegionEndpoint.USEast1);
            var context = new DynamoDBContext(clientDynamoDB);

            return context.FromDocument<T>(document);

        }
    }
}
