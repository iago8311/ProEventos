using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProEventos.Application.Contratos;
using ProEventos.Domain;
using ProEventos.Persistence;

namespace ProEventos.Application
{
  public class EventoService : IEventoService
  {
    private readonly IGeralPersist _geralPersist;
    private readonly IEventosPersist _eventosPersist;
    public EventoService(IGeralPersist geralPersist, IEventosPersist eventosPersist)
    {
      _eventosPersist = eventosPersist;
      _geralPersist = geralPersist;

    }
    public async Task<Evento> AddEventos(Evento model)
    {
      try
      {
        _geralPersist.Add<Evento>(model);
        if (await _geralPersist.SaveChangesAsync())
        {
          return await _eventosPersist.GetEventoByIdAsync(model.Id, false);
        }
        return null;
      }
      catch (Exception ex)
      {

        throw new Exception(ex.Message);
      }
    }
    public async Task<Evento> UpdateEventos(int eventoId, Evento model)
    {
      try
      {
        var evento = await _eventosPersist.GetEventoByIdAsync(eventoId, false);
        if (evento == null) return null;
        model.Id = evento.Id;

        _geralPersist.Update(model);
        if (await _geralPersist.SaveChangesAsync())
        {
          return await _eventosPersist.GetEventoByIdAsync(model.Id, false);
        }
        return null;
      }
      catch (Exception ex)
      {

        throw new Exception(ex.Message);
      }
    }

    public async Task<bool> DeleteEvento(int eventoId)
    {
      try
      {
        var evento = await _eventosPersist.GetEventoByIdAsync(eventoId, false);
        if (evento == null) throw new Exception("Evento Delete não encontrado");

        _geralPersist.Delete<Evento>(evento);
        return (await _geralPersist.SaveChangesAsync());

      }
      catch (Exception ex)
      {

        throw new Exception(ex.Message);
      }
    }

    public async Task<Evento[]> GetAllEventosAsync(bool includePalestrantes = false)
    {
      try
      {
        var eventos = await _eventosPersist.GetAllEventosAsync(includePalestrantes);
        if (eventos == null) return null;
        return eventos;

      }
      catch (Exception ex)
      {
        throw new Exception(ex.Message);
      }
    }

    public async Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool includePalestrantes = false)
    {
      try
      {
        var eventos = await _eventosPersist.GetAllEventosByTemaAsync(tema, includePalestrantes);
        if (eventos == null) return null;
        return eventos;

      }
      catch (Exception ex)
      {
        throw new Exception(ex.Message);
      }
    }

    public async Task<Evento> GetEventoByIdAsync(int eventosId, bool includePalestrantes = false)
    {
      try
      {
        var eventos = await _eventosPersist.GetEventoByIdAsync(eventosId, includePalestrantes);
        if (eventos == null) return null;
        return eventos;

      }
      catch (Exception ex)
      {
        throw new Exception(ex.Message);
      }
    }


  }
}