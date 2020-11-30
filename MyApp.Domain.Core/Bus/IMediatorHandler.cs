using System.Threading.Tasks;
using ETC.EQM.Domain.Core.Commands;
using ETC.EQM.Domain.Core.Events;

namespace ETC.EQM.Domain.Core.Bus
{
    public interface IMediatorHandler
    {
        Task SendCommand<T>(T command) where T : Command;
        Task RaiseEvent<T>(T @event) where T : Event;
    }
}
