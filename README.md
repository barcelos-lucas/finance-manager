# Finance Manager 

Este repositório reúne:

- **`apps/backend`**  
  API RESTful em ASP.NET Core 9 com Entity Framework Core + SQLite, JWT, Swagger/OpenAPI e exportação de relatórios em Excel.

- **`apps/frontend`**  
  SPA em React + TypeScript (Create React App) consumindo a API.

- **`docker-compose.yml`**  
  Orquestra backend, frontend e volume do banco para desenvolvimento local.

---

## 📦 Estrutura

```
/
├─ apps/
│  ├─ backend/       ← Projeto ASP.NET Core
│  └─ frontend/      ← Projeto React + TS
├─ docker-compose.yml
└─ README.md
```

---

## 🔧 Pré-requisitos

- [.NET 9 SDK](https://dotnet.microsoft.com/download)  
- [Node.js ≥18 + npm](https://nodejs.org/)  
- [Docker & Docker Compose](https://www.docker.com/products/docker-desktop) (opcional)

---

## 🚀 Execução local

### 1. Backend

```bash
cd apps/backend
dotnet restore
dotnet build
dotnet ef database update    # aplica migrações e cria `finance_manager.db`
dotnet run                    # expõe http://localhost:5098
```

Abra o Swagger em  
```
http://localhost:5098/swagger/index.html
```

### 2. Frontend

```bash
cd apps/frontend
npm install
npm start
```

Abra no navegador  
```
http://localhost:3000
```

---

## 🐳 Docker Compose

```yaml
version: '3.8'

services:
  backend:
    image: mcr.microsoft.com/dotnet/sdk:9.0
    container_name: finance-backend
    working_dir: /src
    volumes:
      - ./apps/backend:/src
      - backend-data:/src/FinanceManager.API/finance_manager.db
    command: >
      sh -c "dotnet restore &&
             dotnet ef database update &&
             dotnet run --urls http://0.0.0.0:5098"
    ports:
      - "5098:5098"

  frontend:
    image: node:18
    container_name: finance-frontend
    working_dir: /usr/src/app
    volumes:
      - ./apps/frontend:/usr/src/app
      - /usr/src/app/node_modules
    command: npm install && npm start
    environment:
      - CHOKIDAR_USEPOLLING=true
    ports:
      - "3000:3000"

volumes:
  backend-data:
```

Para subir ambos:

```bash
docker-compose up --build
```

- **API**: http://localhost:5098  
- **Frontend**: http://localhost:3000  

---

## 📚 Endpoints principais

| Verbo  | Rota                                              | Descrição                                  |
| ------ | ------------------------------------------------- | ------------------------------------------ |
| POST   | `/api/contas-pagar`                               | Criar conta a pagar                        |
| GET    | `/api/contas-pagar/user/{userId}`                 | Listar contas a pagar de um usuário        |
| PUT    | `/api/contas-pagar/{id}`                          | Atualizar conta a pagar                    |
| DELETE | `/api/contas-pagar/{id}`                          | Remover conta a pagar                      |
| POST   | `/api/contas-receber`                             | Criar conta a receber                      |
| GET    | `/api/contas-receber/user/{userId}`               | Listar contas a receber de um usuário      |
| PUT    | `/api/contas-receber/{id}`                        | Atualizar conta a receber                  |
| DELETE | `/api/contas-receber/{id}`                        | Remover conta a receber                    |
| GET    | `/api/relatorios/despesas-mes/{ano}/{mes}`        | Agrupa total de despesas por categoria     |
| GET    | `/api/relatorios/saldo-mes/{ano}/{mes}`           | Totais de receitas, despesas e saldo       |
| GET    | `/api/relatorios/exportar/{ano}/{mes}`            | Exporta relatório mensal em Excel (.xlsx)  |
| GET    | `/api/compra-cartao` (query params)               | Listar compras de cartão (filtros)         |
| POST   | `/api/compra-cartao`                              | Criar compra no cartão                     |
| PUT    | `/api/compra-cartao/{id}`                         | Atualizar compra no cartão                 |
| DELETE | `/api/compra-cartao/{id}`                         | Remover compra no cartão                   |

---

## 🛠 Tecnologias

- **Backend**  
  .NET 9, ASP.NET Core, EF Core 9 + SQLite, JWT, Swagger/OpenAPI, GemBox.Spreadsheet

- **Frontend**  
  React 18, TypeScript, React Router, Axios

- **Infra & DevOps**  
  Docker, Docker Compose

---

## 👩‍💻 Guia rápido para novos devs

1. Clone o repositório:
   ```bash
   git clone <url-do-repo>
   cd finance-manager
   ```

2. **Rodar local**  
   - Backend:
     ```bash
     cd apps/backend
     dotnet run
     ```
   - Frontend:
     ```bash
     cd ../frontend
     npm start
     ```

3. **Rodar via Docker**  
   ```bash
   docker-compose up --build
   ```

4. Acesse:  
   - API Swagger: http://localhost:5098/swagger/index.html  
   - Frontend: http://localhost:3000  

---

> ⚠️ **Ambientes**  
> Ajuste variáveis (conexões, JWT secret, etc.) via `dotnet user-secrets` ou `.env` no frontend.

Bom desenvolvimento! 🚀
