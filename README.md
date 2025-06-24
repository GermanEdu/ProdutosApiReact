# ProdutosApiReact

API REST feita com .NET 7 + SQL Server + JWT Authentication para cadastro e autenticação de usuários e gerenciamento de produtos.

---

## 🚀 Tecnologias Utilizadas
- ASP.NET Core 7
- Entity Framework Core
- SQL Server
- JWT Authentication
- Swagger (OpenAPI)

---

## 📦 Requisitos
- .NET SDK 7+
- SQL Server LocalDB ou outro
- Git

---

## 🔧 Setup do Projeto

### 1. Clone o repositório:
```bash
git clone git@github.com:GermanEdu/ProdutosApiReact.git
cd ProdutosApiReact
```

### 2. Configure a connection string no `appsettings.json`:
```json
"ConnectionStrings": {
  "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=ProdutosDb;Trusted_Connection=True;"
},
```

### 3. Crie o banco com EF Core:
```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
```

### 4. Rode a aplicação:
```bash
dotnet run
```

Swagger estará disponível em:
```
https://localhost:5001/swagger
```

---

## 🔑 Autenticação

- Rota para login: `POST /api/Usuario/login`
```json
{
  "email": "admin@email.com",
  "senha": "123456"
}
```

- Rota para cadastro: `POST /api/Usuario/register`

O token JWT retornado deve ser enviado via:
```http
Authorization: Bearer {seu_token}
```

---

## 🧪 Endpoints Produtos (com autenticação)

- `GET /api/Produtos` → listar
- `GET /api/Produtos/{id}` → buscar por ID
- `POST /api/Produtos` → criar
- `PUT /api/Produtos/{id}` → atualizar
- `DELETE /api/Produtos/{id}` → remover

Campos obrigatórios: `nome`, `categoria`, `preco > 0`

---

## 🧠 Autor
Eduardo - Desenvolvedor .NET Core + React

