using GatoAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace GatoAPI.Repositories
{
    public class GatoRepository<T> where T : class
    {
        public GatoRepository(Sistem21GatoContext context)
        {
            Context = context;
        }

        private readonly Sistem21GatoContext Context;

        public DbSet<T> GetAll()
        {
            return Context.Set<T>();
        }

        public T? Get(object id)
        {
            return Context.Find<T>(id);
        }

        public Jugador GetByName(string name)
        {
            return Context.Jugador.Where(x=>x.Nombre == name).FirstOrDefault();
        }

        public void Insert(T entity)
        {
            Context.Add(entity);
            Context.SaveChanges();
        }

        public void Update(T entity)
        {
            Context.Update(entity);
            Context.SaveChanges();
        }
        public void Delete(T entity)
        {
            Context.Remove(entity);
            Context.SaveChanges();
        }
    }
}
