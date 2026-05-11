using Microsoft.Extensions.DependencyInjection;

namespace BuildingBlocks.CQRS;

public class CommandDispatcher : ICommandDispatcher
{
    private readonly IServiceProvider _serviceProvider;

    public CommandDispatcher(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task<TResult> DispatchAsync<TCommand, TResult>(
        TCommand command)
        where TCommand : ICommand<TResult>
    {
        var handler = _serviceProvider
            .GetRequiredService<
                ICommandHandler<TCommand, TResult>>();

        return await handler.HandleAsync(command);
    }
}
