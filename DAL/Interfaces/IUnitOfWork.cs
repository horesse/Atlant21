using System;
using DAL.Entities;

namespace DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Details> Details { get; }
        IRepository<Keepers> Keepers { get; }
        void Save();
    }
}
