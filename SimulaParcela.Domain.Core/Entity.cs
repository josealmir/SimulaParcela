using SimulaParcela.Domain.Core.Interface;

namespace SimulaParcela.Domain.Core
{
    public abstract class Entity : IEntity
    {
        public int Id { get ; set ; }
    }
}
