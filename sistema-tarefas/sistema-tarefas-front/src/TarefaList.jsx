import { useEffect, useState } from "react";
import axios from "axios";

export function TarefaList() {
  const [tarefas, setTarefas] = useState([]);
  const [pagina, setPagina] = useState(1);
  const [tamanho, setTamanho] = useState(5);

  useEffect(() => {
    axios
      .get(`http://localhost:5194/tarefas?pagina=${pagina}&tamanho=${tamanho}`)
      .then((res) => {
        setTarefas(res.data);
      })
      .catch((err) => {
        console.error("Erro ao buscar tarefas:", err);
      });
  }, [pagina, tamanho]);

  return (
    <div>
      <h2>Lista de Tarefas</h2>
      <ul>
        {tarefas.map((tarefa) => (
          <li key={tarefa.id}>
            <strong>{tarefa.titulo}</strong> - {tarefa.descricao} [
            {tarefa.concluida ? "✔️" : "❌"}]
          </li>
        ))}
      </ul>

      <div style={{ marginTop: "1rem" }}>
        <button onClick={() => setPagina((p) => Math.max(p - 1, 1))}>
          Página Anterior
        </button>
        <span style={{ margin: "0 1rem" }}>Página {pagina}</span>
        <button onClick={() => setPagina((p) => p + 1)}>Próxima Página</button>
      </div>
    </div>
  );
}
