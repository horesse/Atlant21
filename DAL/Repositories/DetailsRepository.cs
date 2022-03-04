using System.Collections.Generic;
using System.Data.Entity;
using DAL.EF;
using DAL.Entities;
using DAL.Interfaces;

namespace DAL.Repositories
{
    public class DetailsRepository : IRepository<Details>
    {
        private AppDBContext db;

        public DetailsRepository(AppDBContext context)
        {
            this.db = context;
        }

        public IEnumerable<Details> GetAll()
        {
            return db.Details;
        }

        public Details Get(int id)
        {
            return db.Details.Find(id);
        }

        public void Create(Details Details)
        {
            db.Details.Add(Details);
        }

        public void Update(Details Details)
        {
            db.Entry(Details).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Details Details = db.Details.Find(id);
            if (Details != null)
                db.Details.Remove(Details);
        }

        public int MathCount(int id)
        {
            return 1;
        }
    }
}
