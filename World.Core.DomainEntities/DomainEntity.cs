using System;
using System.Collections.Generic;
using System.Text;

namespace World.Core.DomainEntities
{
    public abstract class DomainEntity<TId>
    {
        public TId Id { get; protected set; }
        protected DomainEntity()
        {

        }

        protected DomainEntity(TId id)
        {
            Id = id;
        }
    }
}
