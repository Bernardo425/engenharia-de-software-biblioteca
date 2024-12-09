using Biblioteca.API.DTO.Livro;
using Biblioteca.API.Service.Contracts;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Shared.Exceptions;

namespace Biblioteca.API.Controllers;

[Route("api/livros")]
[ApiController]
public class LivroController: ControllerBase
{
    private readonly ILivroService _livroService;

    public LivroController(ILivroService livroService)
    {
        _livroService = livroService;
    }
    
    [HttpGet]
    public IActionResult GetLivros([FromQuery] LivroParameters parameters)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var livros = _livroService.GetAllPaged(parameters);

            var metadata = new
            {
                livros.TotalCount,
                livros.PageSize,
                livros.CurrentPage,
                livros.TotalPages,
                livros.HasNext,
                livros.HasPrevious
            };
            
            Response.Headers.Append("X-Pagination", JsonConvert.SerializeObject(metadata));
            return Ok(livros);

        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, "um erro ocorreu no servidor");
        }
    }
    
    
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetLivro([FromRoute] int id)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var livro = await _livroService.GetByIdAsync(id);
            
            return Ok(livro);

        }
        catch (NotFoundException e)
        {
            return NotFound(e);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, "um erro ocorreu no servidor");
        }
    }
    
    // rota para obter criar uma livro
    [HttpPost]
    public async Task<IActionResult> CreateLivro([FromBody] LivroCreateDto request)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var livro = await _livroService.CreateAsync(request);
            return CreatedAtAction(nameof(GetLivro), new { id = livro.Id }, livro);

        }
        catch (NotFoundException e)
        {
            return NotFound(e);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, "um erro ocorreu no servidor");
        }
    }
    
    
    // rota para atualizar os principais dados de uma livro
    [HttpPatch("{id:int}")]
    public async Task<IActionResult> UpdateLivro([FromRoute] int id, [FromBody] LivroUpdateDto dto)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _livroService.UpdateAsync(id, dto);
            return NoContent();
            
        }
        catch (NotFoundException e)
        {
            return NotFound(e);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
    
    
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _livroService.DeleteAsync(id);
            return NoContent();
            
        }
        catch (NotFoundException e)
        {
            return NotFound(e);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, "um erro ocorreu no servidor");
        }
    }
    
}