using Amazon.DynamoDBv2.DataModel;
using Aws.Data.PortsDriven;
using AWS.Core.Entities;

namespace Aws.Data.AdaptersDriven
{
    public class OrderDriven : IOrderDriven
    {
        private readonly IDynamoDBContext _context;
        public OrderDriven(IDynamoDBContext context) => _context = context;

        public async Task AddAsync(Order order)
        {
            await _context.LoadAsync<Order>(order.Id);

            await _context.SaveAsync(order);
        }
    }
}
