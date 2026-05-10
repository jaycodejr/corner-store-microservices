using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingBlocks.CQRS;

public class QueryDispatcher : IQueryDispatcher
{
    private readonly IServiceProvider _serviceProvider;

    public QueryDispatcher(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task<TResult> DispatchAsync<TQuery, TResult>(
        TQuery query)
        where TQuery : IQuery<TResult>
    {
        var handler = _serviceProvider
            .GetRequiredService<
                IQueryHandler<TQuery, TResult>>();

        return await handler.HandleAsync(query);
    }
}
