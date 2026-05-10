using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingBlocks.CQRS;

public interface ICommandDispatcher
{
    Task<TResult> DispatchAsync<TCommand, TResult>(
        TCommand command)
        where TCommand : ICommand<TResult>;
}
