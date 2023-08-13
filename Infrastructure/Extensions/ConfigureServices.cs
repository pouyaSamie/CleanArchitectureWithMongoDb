using Application.Common.Behaviours;
using Domain.Entities;
using FluentValidation;
using Infrastructure.Persistence;
using MediatR;
using Microsoft.Extensions.Configuration;
using Mongo.Repository.Extensions;
using Repository.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Extensions.DependencyInjection;

public static class ConfigureServices
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddTransient<IRepository<TodoItem>, TodoItemRepository>();
        services.AddMongoDbRepository(configuration);
        return services;
    }
}
