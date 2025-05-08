import { TarefaList } from "./TarefaList";
import { TarefaForm } from "./TarefaForm";
import { useState } from "react";

function App() {
  const [refetch, setRefetch] = useState(false);

  const atualizarLista = () => setRefetch((prev) => !prev); // dispara recarregamento da lista

  return (
    <div style={{ padding: "2rem", fontFamily: "sans-serif" }}>
      <h1>📝 Sistema de Tarefas</h1>
      <TarefaForm onCriada={atualizarLista} />
      <TarefaList key={refetch} />
    </div>
  );
}

export default App;
