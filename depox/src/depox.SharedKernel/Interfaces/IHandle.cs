﻿using System.Threading.Tasks;
using depox.SharedKernel;

namespace depox.SharedKernel.Interfaces
{
    public interface IHandle<in T> where T : BaseDomainEvent
    {
        Task Handle(T domainEvent);
    }
}