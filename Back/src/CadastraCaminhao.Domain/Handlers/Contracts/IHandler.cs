using CadastraCaminhao.Domain.Commands;
using System.Threading.Tasks;

namespace CadastraCaminhao.Domain.Handlers.Contracts
{
    public interface IHandler<T> where T : ICommand
    {
        Task<ICommandResult> Handle(T command);
    }
}