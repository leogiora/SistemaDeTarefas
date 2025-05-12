using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TarefasApi.Data;
using TarefasApi.Models;
using Microsoft.AspNetCore.Authorization;

namespace TarefasApi.Controllers
{
    [ApiController]
    [Route("tarefas")]
    [Authorize]
    public class TarefasController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TarefasController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Authorize]
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

        [HttpPut("{id}")]
        public async Task<ActionResult> AtualizarTarefa(int id, [FromBody] Tarefa tarefaAtualizada)
        {
            var tarefaExistente = await _context.Tarefas.FindAsync(id);

            if (tarefaExistente == null)
            {
                return NotFound("Tarefa não encontrada.");
            }

            if (string.IsNullOrWhiteSpace(tarefaAtualizada.Titulo))
            {
                return BadRequest("O campo 'Titulo' é obrigatório.");
            }

            tarefaExistente.Titulo = tarefaAtualizada.Titulo;
            tarefaExistente.Descricao = tarefaAtualizada.Descricao;
            tarefaExistente.Concluida = tarefaAtualizada.Concluida;

            await _context.SaveChangesAsync();

            return NoContent(); // sucesso sem retorno
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletarTarefa(int id)
        {
            var tarefa = await _context.Tarefas.FindAsync(id);

            if (tarefa == null)
            {
                return NotFound("Tarefa não encontrada.");
            }

            _context.Tarefas.Remove(tarefa);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
