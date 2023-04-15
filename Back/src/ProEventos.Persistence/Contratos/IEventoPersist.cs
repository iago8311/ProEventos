using System.Threading.Tasks;
using ProEventos.Domain;

namespace ProEventos.Persistence
{
  public interface IEventosPersist
  {


    Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool includePalestrantes);
    Task<Evento[]> GetAllEventosAsync(bool includePalestrantes = false);
    Task<Evento> GetEventoByIdAsync(int eventosId, bool includePalestrantes = false);

  }
}