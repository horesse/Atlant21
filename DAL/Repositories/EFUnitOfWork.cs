using System;
using DAL.EF;
using DAL.Entities;
using DAL.Interfaces;

namespace DAL.Repositories
{
    public class EFUnitOfWork : IDisposable, IUnitOfWork
    {
        private AppDBContext db;
        private DetailsRepository DetailsRepository;
        private KeepersRepository KeepersRepository;

        public EFUnitOfWork()
        {
            db = new AppDBContext("DefaultConnection");
        }
        public IRepository<Keepers> Keepers
        {
            get
            {
                if (KeepersRepository == null)
                    KeepersRepository = new KeepersRepository(db);
                return KeepersRepository;
            }
        }

        public IRepository<Details> Details
        {
            get
            {
                if (DetailsRepository == null)
                    DetailsRepository = new DetailsRepository(db);
                return DetailsRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
