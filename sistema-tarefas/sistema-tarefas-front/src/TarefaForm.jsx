import { useState } from "react";
import axios from "axios";

export function TarefaForm({ onCriada }) {
  const [titulo, setTitulo] = useState("");
  const [descricao, setDescricao] = useState("");

  const handleSubmit = async (e) => {
    e.preventDefault();

    if (!titulo.trim()) {
      alert("O título é obrigatório!");
      return;
    }

    try {
      await axios.post("http://localhost:5194/tarefas", {
        titulo,
        descricao,
      });

      setTitulo("");
      setDescricao("");
      if (onCriada) onCriada();
    } catch (err) {
      console.error("Erro ao criar tarefa:", err);
      alert("Erro ao criar tarefa.");
    }
  };

  return (
    <form onSubmit={handleSubmit} style={{ marginBottom: "2rem" }}>
      <h3>Nova Tarefa</h3>
      <input
        type="text"
        placeholder="Título"
        value={titulo}
        onChange={(e) => setTitulo(e.target.value)}
        required
        style={{ marginRight: "1rem", padding: "0.4rem" }}
      />
      <input
        type="text"
        placeholder="Descrição"
        value={descricao}
        onChange={(e) => setDescricao(e.target.value)}
        style={{ marginRight: "1rem", padding: "0.4rem" }}
      />
      <button type="submit">Adicionar</button>
    </form>
  );
}
