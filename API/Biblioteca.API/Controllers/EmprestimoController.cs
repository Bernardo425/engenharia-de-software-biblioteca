using Biblioteca.API.DTO.Emprestimo;
using Biblioteca.API.Service.Contracts;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Shared.Exceptions;

namespace Biblioteca.API.Controllers;

[Route("api/emprestimos")]
[ApiController]
public class EmprestimoController: ControllerBase
{
    private readonly IEmprestimoService _emprestimoService;

    public EmprestimoController(IEmprestimoService emprestimoService)
    {
        _emprestimoService = emprestimoService;
    }
    
    [HttpGet]
    public IActionResult GetEmprestimos([FromQuery] EmprestimoParameters parameters)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var emprestimos = _emprestimoService.GetAllPaged(parameters);

            var metadata = new
            {
                emprestimos.TotalCount,
                emprestimos.PageSize,
                emprestimos.CurrentPage,
                emprestimos.TotalPages,
                emprestimos.HasNext,
                emprestimos.HasPrevious
            };
            
            Response.Headers.Append("X-Pagination", JsonConvert.SerializeObject(metadata));
            return Ok(emprestimos);

        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, "um erro ocorreu no servidor");
        }
    }
    
    
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetEmprestimo([FromRoute] int id)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var emprestimo = await _emprestimoService.GetByIdAsync(id);
            
            return Ok(emprestimo);

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
    
    // rota para obter criar uma emprestimo
    [HttpPost]
    public async Task<IActionResult> CreateEmprestimo([FromBody] EmprestimoCreateDto request)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var emprestimo = await _emprestimoService.CreateAsync(request);
            return CreatedAtAction(nameof(GetEmprestimo), new { id = emprestimo.Id }, emprestimo);

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
    
    
    // rota para atualizar os principais dados de uma emprestimo
    [HttpPatch("{id:int}")]
    public async Task<IActionResult> UpdateEmprestimo([FromRoute] int id, [FromBody] EmprestimoUpdateDto dto)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _emprestimoService.UpdateAsync(id, dto);
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

            await _emprestimoService.DeleteAsync(id);
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