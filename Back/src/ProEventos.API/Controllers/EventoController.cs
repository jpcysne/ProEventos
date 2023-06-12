using Microsoft.AspNetCore.Mvc;
using ProEventos.API.Models;

namespace ProEventos.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EventoController : ControllerBase
{

    public EventoController()
    {

    }

    [HttpGet]
    public Evento Get()
    {
        return new Evento()
        {
            EventoId = 1,
            Tema = "Angular 11 e .NET 6",
            Local = "1 lote",
            QtdPessoas = 250,
            DataEvento = DateTime.Now.AddDays(2).ToString(),


        };
    }
}
