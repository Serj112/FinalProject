using FinalProject.Data.Context;
using System.Data.Entity;
using System.Data.Entity.Migrations;

namespace FinalProject.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected DbContext _db;
        public DbSet<T> Set { get; private set; }

        /*public Repository(FPDbContext db)
        {
            _db = db;
            var set = _db.Set<T>();
            set.Load();

            Set = set;
        }*/

        public void Create(T item)
        {
            Set.Add(item);
            _db.SaveChanges();
        }

        public void Delete(T item) 
        { 
            Set.Remove(item);
            _db.SaveChanges();
        }

        public T Get(int id)
        {
            return Set.Find(id);
        }

        public IEnumerable<T> GetAll()
        {
            return Set;
        }

        public void Update(T item)
        {
            Set.AddOrUpdate(item);
            _db.SaveChanges();
        }
    }
}
