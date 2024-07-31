# API de Gerenciamento de Tarefas

Uma API RESTful desenvolvida com ASP.NET Core para gerenciar tarefas.

## Funcionalidades
- Criar, listar, atualizar e excluir tarefas.
- Filtrar tarefas por status.
- Autenticação JWT.

## Tecnologias
- ASP.NET Core
- Entity Framework Core
- SQL Server

## Como Rodar
1. Clone o repositório.
2. Restaure as dependências com `dotnet restore`.
3. Execute o projeto com `dotnet run`.

## Endpoints
- `GET /api/tarefas`
- `POST /api/tarefas`
- `PUT /api/tarefas/{id}`
- `DELETE /api/tarefas/{id}`
