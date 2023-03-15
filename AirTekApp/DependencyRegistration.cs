using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessRepository.Core;
using BusinessRepository.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace AirTekApp
{
    public class DependencyRegistration
    {
        public ServiceProvider RegisterDependencies()
        {
            var serviceProvider = new ServiceCollection()
                .AddSingleton<IFlightScheduleRepository, FlightScheduleRepository>()
                .AddSingleton<IOrderRepository, OrderRepository>()
                .AddSingleton<IInventoryManagementRepository, InventoryManagementRepository>()
                .BuildServiceProvider();

            return serviceProvider;
        }
    }
}
