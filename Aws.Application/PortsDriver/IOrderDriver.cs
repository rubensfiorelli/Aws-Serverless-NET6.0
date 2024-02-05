using AWS.Core.DTOs.Input;

namespace Aws.Application.PortsDriver
{
    public interface IOrderDriver
    {
        Task<string> Add(InputOrderDto model);

    }
}
