using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoviesRepository.Application.DTOs;
using MoviesRepository.Application.Services.Interfaces;
using MoviesRepository.Domain;

namespace MoviesRepository.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeriesController : ControllerBase
    {
        private readonly ISerieService _service;

        public SeriesController(ISerieService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSeries()
        {
            try
            {
                var series = await _service.GetSeries(false, false);
                if (series == null)
                    return NotFound("Nenhuma série encontrada");

                return Ok(series);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSerie(int id)
        {
            try
            {
                var serie = await _service.GetSerieById(id, false, false);
                if(serie == null)
                    return NotFound();
                return Ok(serie);
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }
        [HttpGet("por-nome")]
        public async Task<IActionResult> GetSeriesPorNome([FromQuery] string nome)
        {
            try
            {
                var series = await _service.GetSerieByNome(nome);
                if(series == null)
                    return NotFound();
                return Ok(series);
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }

        [HttpGet("populares")]
        public async Task<IActionResult> GetSeriesPopulares()
        {
            try
            {
                var series = await _service.GetSeriesPopulares();
                if(series == null)
                    return NotFound("Nenhuma série encontrada");
                return Ok(series);
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] SerieInputModel model)
        {
            try
            {
                if (model == null)
                    return BadRequest("Modelo inválido");
                if (await _service.AddSerie(model) == false)
                    return BadRequest("Erro ao adicionar série");
                return Ok("Série adicionada com sucesso");
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
