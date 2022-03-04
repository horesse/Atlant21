using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DAL.EF;
using DAL.Entities;
using DAL.Interfaces;

namespace DAL.Repositories
{
    public class KeepersRepository : IRepository<Keepers>
    {
        private AppDBContext db;

        public KeepersRepository(AppDBContext context)
        {
            this.db = context;
        }

        public IEnumerable<Keepers> GetAll()
        {
            return db.Keepers;
        }

        public Keepers Get(int id)
        {
            return db.Keepers.Find(id);
        }

        public void Create(Keepers Keepers)
        {
            db.Keepers.Add(Keepers);
        }

        public void Update(Keepers Keepers)
        {
            db.Entry(Keepers).State = EntityState.Modified;
        }
        public void Delete(int id)
        {
            Keepers Keepers = db.Keepers.FirstOrDefault(x => x.Id == id);
            var c = db.Details
                .Where(p => p.KeepersId == id && p.DeleteDate == null)
                .Count();
            if (Keepers != null)
            {
                if (c <= 0)
                {
                    db.Keepers.Remove(Keepers);
                    db.SaveChanges();
                }
            }
        }
        public int MathCount(int id)
        {
            var c = db.Details
                    .Where(p => p.KeepersId == id && p.DeleteDate == null)
                    .Count();
            return c;
        }
    }
}
