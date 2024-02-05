using AWS.Core.Entities;

namespace Aws.Data.PortsDriven
{
    public interface IOrderDriven
    {
        Task AddAsync(Order order);
    }
}
