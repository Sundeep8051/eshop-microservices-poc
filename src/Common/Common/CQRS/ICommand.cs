using MediatR;

namespace Common.CQRS
{
    public interface ICommand : IRequest  { }

    public interface ICommand<out TResponse> : IRequest<TResponse> { }
}
