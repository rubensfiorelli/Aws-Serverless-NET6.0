using Aws.Application.PortsDriver;
using Aws.Data.PortsDriven;
using AWS.Core.DTOs.Input;

namespace Aws.Application.AdaptersDriver
{
    public class OrderDriver : IOrderDriver
    {
        private readonly IOrderDriven _repository;
        public OrderDriver(IOrderDriven repository) => _repository = repository;

        public async Task<string> Add(InputOrderDto model)
        {
            await _repository.AddAsync(model);

            return model.Status.ToString();
        }
    }
}
