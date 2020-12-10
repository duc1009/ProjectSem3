namespace ETC.EQM.Domain.Core.Events
{
    public interface IEventStore
    {
        void Save<T>(T theEvent) where T : StoredEvent;
    }
}