namespace TarefasApi.Models
{
    public class Tarefa
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string? Descricao { get; set; }
        public bool Concluida { get; set; } = false;
        public DateTime CriadaEm { get; set; } = DateTime.Now;
    }
}
