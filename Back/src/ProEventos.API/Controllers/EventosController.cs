using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ProEventos.Persistence;
using ProEventos.Domain;
using ProEventos.Application.Contratos;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace ProEventos.API.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class EventosController : ControllerBase
  {

    private readonly IEventoService _eventoService;

    public EventosController(IEventoService eventoService)
    {
      _eventoService = eventoService;

    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
      try
      {
        var eventos = await _eventoService.GetAllEventosAsync(true);
        if (eventos == null) return NotFound("Nenhum Evento encontrado.");
        return Ok(eventos);
      }
      catch (Exception ex)
      {
        return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar recuperar eventos.Error:{ex.Message}");
      }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
      try
      {
        var evento = await _eventoService.GetEventoByIdAsync(id, true);
        if (evento == null) return NotFound("Nenhum Evento encontrado.");
        return Ok(evento);
      }
      catch (Exception ex)
      {
        return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar recuperar eventos.Error:{ex.Message}");
      };

    }
    [HttpGet("{tema}/tema")]
    public async Task<IActionResult> GetByTema(string tema)
    {
      try
      {
        var evento = await _eventoService.GetAllEventosByTemaAsync(tema, true);
        if (evento == null) return NotFound("Eventos por Tema não encontrados.");
        return Ok(evento);
      }
      catch (Exception ex)
      {
        return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar recuperar eventos.Error:{ex.Message}");
      };

    }

    [HttpPost]
    public async Task<IActionResult> Post(Evento model)
    {
      try
      {
        var evento = await _eventoService.AddEventos(model);
        if (evento == null) return BadRequest("Erro ao tentar adicionar");
        return Ok(evento);
      }
      catch (Exception ex)
      {
        return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar Adicionar eventos.Error:{ex.Message}");
      };
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, Evento model)
    {
      try
      {
        var evento = await _eventoService.UpdateEventos(id, model);
        if (evento == null) return BadRequest("Erro ao tentar adicionar");
        return Ok(evento);
      }
      catch (Exception ex)
      {
        return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar Atualizar eventos.Error:{ex.Message}");
      };
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
      try
      {
        return await _eventoService.DeleteEvento(id) ? Ok("Deletado") : BadRequest("Evento não deletado");
      }
      catch (Exception ex)
      {
        return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar recuperar eventos.Error:{ex.Message}");
      };
    }
  }
}
