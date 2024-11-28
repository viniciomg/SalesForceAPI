using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SalesForce.Domain.Entities;
using SalesForce.Domain.Interfaces.Services;
using SalesForce.Services.Notification.Handler;
using SalesForce.Services.Notification.Implementation;
using SalesForce.Services.Notification.Interface;
using SalesForce.Services.Notification.Model;
using SalesForce.Services.Services;
using System.Diagnostics.CodeAnalysis;

namespace SalesForce.Services
{
    [ExcludeFromCodeCoverage]
    public static class RegisterServiceInstances
    {
        public static IServiceCollection AddRegisterServices(this IServiceCollection services)
        {

            #region Serviço

            services.AddScoped<INotificationHandler<Notifications>, NotifyHandler>();
            services.AddScoped<INotify, Notify>();
            services.AddScoped<IClientService, ClientService>();
            #endregion

            #region Serviço Validações
            #endregion

            return services;
        }
    }
}
