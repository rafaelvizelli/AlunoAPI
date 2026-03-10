using AlunoAPI.Application.Services;
using AlunoAPI.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace AlunoAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AlunoController : ControllerBase
    {
        private readonly AlunoService _service;

        public AlunoController(AlunoService service)
        {
            _service = service;
        }

        [HttpGet("ListarTodos")]
        public IActionResult ListarTodos()
        {
            List<Aluno> alunos = _service.ListarTodos();
            return Ok(alunos);
        }

        [HttpPost("Matricular")]
        public IActionResult Matricular([FromBody] Aluno aluno)
        {
            try
            {
                _service.Matricular(aluno);
                return Created();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}