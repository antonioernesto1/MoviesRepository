using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoviesRepository.Application.DTOs;
using MoviesRepository.Application.Services.Interfaces;
using MoviesRepository.Domain;

namespace MoviesRepository.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private readonly ICategoriaService _service;
        public CategoriasController(ICategoriaService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<IActionResult> Get(bool includeFilmes, bool includeSeries)
        {
            try
            {
                var categorias = await _service.GetCategorias(includeFilmes, includeSeries);
                if (categorias == null)
                    return NotFound("Nenhuma categoria encontrada");
                return Ok(categorias);
            }
            catch (Exception)
            {
                return StatusCode(500, "Erro interno de servidor");
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id, bool includeFilmes, bool includeSeries)
        {
            try
            {
                if (id <= 0)
                    return BadRequest("Id inválido");
                var categoria = await _service.GetCategoriaById(id, includeFilmes, includeSeries);
                if (categoria == null)
                    return NotFound("Nenhuma categoria encontrada");
                return Ok(categoria);
            }
            catch (Exception)
            {
                return StatusCode(500, "Erro interno de servidor");
            }
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CategoriaInputModel categoria)
        {
            try
            {
                if (categoria == null)
                    return BadRequest("Modelo inválido");
                if (await _service.AddCategoria(categoria) == false)
                    return BadRequest("Erro ao adicionar categoria");
                return Ok("Categoria adicionada com sucesso");
            }
            catch (Exception)
            {
                return StatusCode(500, "Erro interno de servidor");
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                if (id <= 0)
                    return BadRequest("Id inválido");
                var categoria = await _service.GetCategoriaById(id, false, false);
                if (categoria == null)
                    return NotFound("Nenhuma categoria encontrada");
                if (await _service.DeleteCategoria(categoria) == false)
                    return BadRequest("Erro ao remover categoria");
                return Ok("Categoria removida com sucesso");
            }
            catch (Exception)
            {
                return StatusCode(500, "Erro interno de servidor");
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Categoria model)
        {
            try
            {
                if (id <= 0)
                    return BadRequest("Id inválido");
                var categoria = await _service.GetCategoriaById(id, false, false);
                if (categoria == null)
                    return NotFound("Nenhuma categoria encontrada");
                if (await _service.UpdateCategoria(id, model) == false)
                    return BadRequest("Erro ao alterar categoria");
                return Ok("Categoria alterada com sucesso");
            }
            catch (Exception)
            {
                return StatusCode(500, "Erro interno de servidor");
            }
        }
    }
}
