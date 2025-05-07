# 📝 Sistema de Tarefas – API com ASP.NET Core + PostgreSQL

Este é um sistema de gerenciamento de tarefas com backend em C#, utilizando ASP.NET Core, Entity Framework Core e banco de dados PostgreSQL rodando em container Docker.

---

## 🚀 Tecnologias utilizadas

- [.NET 8 (ASP.NET Core)](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
- [Entity Framework Core](https://learn.microsoft.com/ef/core/)
- [PostgreSQL](https://www.postgresql.org/)
- [Docker](https://www.docker.com/)
- [Swagger (Swashbuckle)](https://swagger.io/tools/swagger-ui/)
- [Visual Studio Code](https://code.visualstudio.com/)

---

## 🧰 Como rodar o projeto

1. Clone o repositório

```bash
git clone https://github.com/seu-usuario/seu-repo.git
cd sistema-tarefas

2. Suba o banco de dados PostgreSQL com Docker

docker-compose up -d

##Banco disponível em:

Host: localhost

Porta: 5432

Usuário: meuuser

Senha: minhasenha

Banco: tarefasdb

3. Vá até o projeto da API e execute

cd sistema-tarefas-api/TarefasApi
dotnet run

A API estará disponível em:
📍 http://localhost:5194/swagger

##✅ Endpoints disponíveis

GET /tarefas
GET /tarefas?pagina=1&tamanho=10

POST /tarefas
{
  "titulo": "Estudar ASP.NET",
  "descricao": "Foco em controllers e EF Core"
}

PUT /tarefas/{id}
{
  "titulo": "Estudar C#",
  "descricao": "Com EF Core",
  "concluida": true
}

DELETE /tarefas/{id} (em breve)

📌 Status do Projeto
✅ Concluído:

Docker + PostgreSQL rodando

API criada com estrutura REST

GET + POST + PUT com validações e EF Core

🚧 Em desenvolvimento:

DELETE /tarefas/{id}

Login de usuário (futuro)

Frontend em React