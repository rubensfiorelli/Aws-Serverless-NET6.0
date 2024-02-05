using Amazon;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.Model;
using Amazon.Lambda.Core;
using Amazon.Lambda.DynamoDBEvents;
using AWS.Core.Entities;
using AWS.Core.Enums;
using AWS.Core.Helpers;

[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace Collector;

public class Function
{
    public async Task FunctionHandler(DynamoDBEvent dynamoDBEvent, ILambdaContext context)
    {
        var clientDynamoDb = new AmazonDynamoDBClient(RegionEndpoint.USEast1);
        var db = new DynamoDBContext(clientDynamoDb);

        foreach (var record in dynamoDBEvent.Records)
        {
            if (record.EventName == OperationType.INSERT)
            {
                var order = record.Dynamodb.NewImage.ToObject<Order>();
                order.Status = StatusOrder.Collected;

                try
                {
                    await ProcessOrderValue(order);

                    await db.SaveAsync(order);
                    context.Logger.LogLine($"Order collected successfully, {order.Id}");

                }
                catch (Exception ex)
                {
                    context.Logger.LogLine($"Error: '{ex.Message}'");
                    order.Reason = ex.Message;
                    order.Cancelled = true;
                }

            }


        }
    }

    private async Task ProcessOrderValue(Order order)
    {
        foreach (var product in order.Products)
        {
            var prodStock = await GetProductDynamoDBAsync(product.Id) ??
                throw new InvalidOperationException($"Product not found! {product.Id}");

            product.Price = prodStock.Price;
            product.Title = prodStock.Title;
        }

        var totalPrice = order.Products.Sum(x => x.Price * x.Qty);

        totalPrice += order.TotalPrice;
    }

    private async Task<Product> GetProductDynamoDBAsync(string id)
    {
        var clientDynamoDB = new AmazonDynamoDBClient(RegionEndpoint.USEast1);
        var request = new QueryRequest
        {
            TableName = "stock",
            KeyConditionExpression = "Id = :v_id",
            ExpressionAttributeValues =
                new Dictionary<string, AttributeValue> { { ":v_id", new AttributeValue { S = id } } }
        };
        var response = await clientDynamoDB.QueryAsync(request);

        var item = response.Items.FirstOrDefault();
        if (item is null)
            return null;

        return item.ToObject<Product>();
    }
}
