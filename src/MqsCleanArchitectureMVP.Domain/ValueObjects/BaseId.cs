using System;
using System.Collections.Generic;
using System.Text;

namespace MqsCleanArchitectureMVP.Domain.ValueObjects
{
    public class BaseId
    {
        public Guid Id { get; private set; }

        public BaseId(Guid id)
        {
            Id = id != Guid.Empty ? id : throw new ArgumentException("ID Inválido.");
        }

        public static BaseId New() => new(Guid.NewGuid());

        public static implicit operator Guid(BaseId id) => id.Id;
        public static implicit operator BaseId(Guid guid) => new(guid);

        public override string ToString() => Id.ToString();
    }
}
