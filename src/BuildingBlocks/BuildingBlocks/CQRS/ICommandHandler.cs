namespace BuildingBlocks.CQRS;

using System.Threading.Tasks;

/// <summary>
/// Handles a command and returns a result of type <typeparamref name="TResult"/>.
/// Use this when the handler needs to produce a value.
/// </summary>
public interface ICommandHandler<TCommand, TResult> where TCommand : ICommand<TResult>
{
    Task<TResult> HandleAsync(TCommand command,CancellationToken cancellation = default);
}


