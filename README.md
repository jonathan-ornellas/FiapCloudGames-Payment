# FiapCloudGames - Payment Service

Microsserviço responsável por **processamento de pagamentos, histórico de transações e notificações** da plataforma FiapCloudGames.

**Projeto de Estudo - FIAP Tech Challenge - Tarefa 3**

---

## 🚀 Execução Rápida

### Docker Compose (Recomendado)

```bash
docker-compose up -d
```

Acesse:
- **Payment API:** http://localhost:5003/swagger
- **SQL Server:** localhost:1433
- **RabbitMQ:** http://localhost:15672 (guest/guest)

---

## 📋 Pré-requisitos

- .NET 8 SDK
- Docker e Docker Compose
- Visual Studio 2022 ou VS Code
- Git
- SQL Server (LocalDB ou Express)
- RabbitMQ

---

## 🏗️ Arquitetura

### Microsserviço Payment

| Componente | Porta | Descrição |
|-----------|-------|----------|
| **Payment API** | 5003 | Processamento de pagamentos |
| **SQL Server** | 1433 | Banco de dados do Payment Service |
| **RabbitMQ** | 5672 | Fila de mensagens assíncrona |

---

## 📊 Endpoints da API

### Processamento

| Método | Endpoint | Descrição | Auth |
|--------|----------|-----------|------|
| POST | `/api/payments` | Processar pagamento | ✅ User |

### Consulta

| Método | Endpoint | Descrição | Auth |
|--------|----------|-----------|------|
| GET | `/api/payments/{id}` | Consultar pagamento específico | ✅ User/Admin |
| GET | `/api/payments/user` | Histórico de pagamentos | ✅ User |

### Administração

| Método | Endpoint | Descrição | Auth |
|--------|----------|-----------|------|
| PUT | `/api/payments/{id}/status` | Atualizar status do pagamento | ✅ Admin |

---

## 💾 Banco de Dados

### Tabelas Principais

**Payments**
- PaymentId (PK)
- UserId (FK)
- GameId (FK)
- Amount
- Status (Pending, Completed, Failed)
- PaymentMethod
- TransactionId
- CreatedAt
- UpdatedAt

---

## 🧪 Testes

### Testes Unitários

```bash
dotnet test
```

### Testes de Integração

```bash
dotnet test --filter "Integration"
```

---

## 📝 Variáveis de Ambiente

```bash
ConnectionStrings__DefaultConnection=Server=localhost;Database=FiapGamePayments;User Id=sa;Password=YourPassword;Encrypt=false;
Jwt__Key=sua-chave-secreta-aqui-com-minimo-32-caracteres
Jwt__Issuer=fiap-cloud-games
Jwt__Audience=fiap-cloud-games-api
RabbitMq__Host=localhost
RabbitMq__Port=5672
RabbitMq__Username=guest
RabbitMq__Password=guest
```

---

## 🛠️ Tecnologias

- .NET 8
- ASP.NET Core
- Entity Framework Core
- SQL Server
- RabbitMQ
- JWT Authentication
- FluentValidation
- Serilog
- Docker

---

## 👤 Autor

**Jonathan Nogueira Ornellas**
- Discord: jhonjonees#2864

---

**Última atualização:** Janeiro de 2026
