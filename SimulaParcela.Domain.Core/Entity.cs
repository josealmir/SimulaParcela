using SimulaParcela.Domain.Core.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimulaParcela.Domain.Core
{
    public abstract class Entity : IEntity
    {
        public int Id { get ; set ; }
    }
}
