using System.Threading.Tasks;
using ProEventos.Domain;

namespace ProEventos.Persistence
{
  public interface IPalestrantePersist
  {

    //Palestrantes
    Task<Palestrante[]> GetAllPalestrantesByNomeAsync(string nome, bool includeEventos);
    Task<Palestrante[]> GetAllPalestrantesAsync(bool includeEventos);
    Task<Palestrante> GetPalestranteByIdAsync(int palestrantesId, bool includeEventos);

  }
}