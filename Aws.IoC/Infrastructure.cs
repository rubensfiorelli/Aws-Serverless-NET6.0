using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Aws.Application.AdaptersDriver;
using Aws.Application.PortsDriver;
using Aws.Data.AdaptersDriven;
using Aws.Data.PortsDriven;
using Microsoft.Extensions.DependencyInjection;

namespace AWS.IoC
{
    public static class Infrastructure
    {
        public static IServiceCollection AddInfrastructureModule(this IServiceCollection services)
        {
            services
                .AddRepositories()
                .AddServices();


            services.TryAddAWSService<IAmazonDynamoDB>();
            services.AddScoped<IDynamoDBContext, DynamoDBContext>();
            services.AddAWSService<AmazonDynamoDBClient>();

            services.AddAWSLambdaHosting(LambdaEventSource.RestApi);


            return services;
        }

        private static IServiceCollection AddServices(this IServiceCollection services)
        {

            services.AddScoped(typeof(IOrderDriver), typeof(OrderDriver));


            return services;
        }


        private static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped(typeof(IOrderDriven), typeof(OrderDriven));

            return services;
        }

    }
}
