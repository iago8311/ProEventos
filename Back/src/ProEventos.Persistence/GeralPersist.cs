using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProEventos.Domain;

namespace ProEventos.Persistence
{
  public class GeralPersist : IGeralPersist
  {
    public readonly ProEventosContext _context;
    public GeralPersist(ProEventosContext context)
    {
      _context = context;

    }
    public void Add<T>(T Entity) where T : class
    {
      _context.Add(Entity);
    }
    public void Update<T>(T Entity) where T : class
    {
      _context.Update(Entity);
    }

    public void Delete<T>(T Entity) where T : class
    {
      _context.Remove(Entity);
    }

    public void DeleteRange<T>(T[] EntityArray) where T : class
    {
      _context.RemoveRange(EntityArray);
    }

    public async Task<bool> SaveChangesAsync()
    {
      return (await _context.SaveChangesAsync()) > 0;
    }

  }
}