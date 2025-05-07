using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TarefasApi.Data;
using TarefasApi.Models;

namespace TarefasApi.Controllers
{
    [ApiController]
    [Route("tarefas")]
    public class TarefasController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TarefasController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tarefa>>> GetTarefas(
            [FromQuery] int pagina = 1,
            [FromQuery] int tamanho = 10)
        {
            if (pagina < 1 || tamanho < 1)
            {
                return BadRequest("Parâmetros de paginação inválidos.");
            }

            var tarefas = await _context.Tarefas
                .Skip((pagina - 1) * tamanho)
                .Take(tamanho)
                .ToListAsync();

            return Ok(tarefas);
        }

        [HttpPost]
        public async Task<ActionResult<Tarefa>> CriarTarefa([FromBody] Tarefa novaTarefa)
        {
            if (string.IsNullOrWhiteSpace(novaTarefa.Titulo))
            {
                return BadRequest("O campo 'Titulo' é obrigatório.");
            }

            novaTarefa.CriadaEm = DateTime.Now;
            novaTarefa.Concluida = false;

            _context.Tarefas.Add(novaTarefa);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTarefas), new { id = novaTarefa.Id }, novaTarefa);
        }
    }
}
