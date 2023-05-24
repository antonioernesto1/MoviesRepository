using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoviesRepository.Application.DTOs;
using MoviesRepository.Application.Services.Interfaces;
using MoviesRepository.Domain;

namespace MoviesRepository.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmesController : ControllerBase
    {
        private readonly IFilmeService _service;
        public FilmesController(IFilmeService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get(bool includeAtores)
        {
            try
            {
                var filmes = await _service.GetFilmes(includeAtores);
                if (filmes == null)
                    return NotFound("Nenhum filme encontrado");
                return Ok(filmes);
            }
            catch (Exception)
            {

                return this.StatusCode(500, "Erro interno no servidor");
            }
        }
        [HttpGet("lancamentos")]
        public async Task<IActionResult> GetLancamentos()
        {
            try
            {
                var filmes = await _service.GetLancamentos();
                if (filmes == null)
                    return NotFound("Nenhum filme encontrado");
                return Ok(filmes);
            }
            catch (Exception)
            {

                return this.StatusCode(500, "Erro interno no servidor");
            }
        }

        [HttpGet("populares")]
        public async Task<IActionResult> GetPopulares()
        {
            try
            {
                var filmes = await _service.GetPopulares();
                if (filmes == null)
                    return NotFound("Nenhum filme encontrado");
                return Ok(filmes);
            }
            catch (Exception)
            {

                return this.StatusCode(500, "Erro interno no servidor");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id, bool includeAtores)
        {
            try
            {
                if (id <= 0)
                    return NotFound("Id inválido");

                var filme = await _service.GetFilmeById(id, includeAtores);
                if (filme == null)
                    return NotFound("Nenhum filme encontrado");
                return Ok(filme);
            }
            catch (Exception)
            {
                return this.StatusCode(500, "Erro interno no servidor");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] FilmeInputModel filme)
        {
            try
            {
                if (filme == null)
                    return BadRequest("Objeto inválido");
                if (await _service.AddFilme(filme) == false)
                    return BadRequest("Erro ao adicionar o filme");
                return Ok("Filme adicionado com sucesso ao banco de dados");
            }
            catch (Exception)
            {
                return this.StatusCode(500, "Erro interno no servidor");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                if (id <= 0)
                    return NotFound("Id inválido");

                var filme = await _service.GetFilmeById(id, false);
                if (filme == null)
                    return NotFound("Nenhum filme encontrado");

                if (await _service.DeleteFilme(filme) == false)
                    return BadRequest("Erro ao remover o filme");
                return Ok("Filme removido com sucesso");
            }
            catch (Exception)
            {
                return StatusCode(500, "Erro interno no servidor");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] FilmeInputModel model)
        {
            try
            {
                if (id <= 0)
                    return NotFound("Id inválido");

                var filme = await _service.GetFilmeById(id, true);
                if (filme == null)
                    return NotFound("Nenhum filme encontrado");

                if (await _service.UpdateFilme(id, model) == false)
                    return BadRequest("Erro ao alterar os dados do filme");
                return Ok("Filme alterado com sucesso");
            }
            catch (Exception e)
            {
                return StatusCode(500, "Erro interno no servidor " + e.Message);
            }
        }
    }
}
