# 🧱 stack-erp

**Minimal ERP platform built with ASP.NET Core Minimal APIs, PostgreSQL and Angular — following Clean Architecture and high-performance design principles.**

---

## 📌 Overview

**stack-erp** é um ERP full-stack moderno, minimalista e de alta performance, criado para demonstrar:

- Arquitetura limpa e desacoplada  
- Backend com **ASP.NET Core Minimal APIs**  
- Frontend **Angular** simples (sem bibliotecas pesadas)  
- Banco de dados **PostgreSQL**  
- Boas práticas de código, versionamento e documentação  
- Estrutura profissional para portfólio

---

## 🚀 Tecnologias Principais

### Backend
- ASP.NET Core 8 Minimal APIs  
- Clean Architecture  
- PostgreSQL  
- Dapper / Entity Framework (a escolher)  
- FluentValidation  
- JWT Authentication  
- Serilog  
- Docker (opcional)

### Frontend
- Angular  
- TypeScript  
- RxJS  
- ngModel (conforme preferência)  
- HttpClient

---

## 📘 Roadmap (Backlog inicial)

- [ ] Configurar solução e estrutura inicial (src/ Api / Application / Domain / Infrastructure)  
- [ ] Criar endpoints base (HealthCheck, Version, Swagger)  
- [ ] Criar módulo de **Usuários & Autenticação (JWT)**  
- [ ] Criar módulo de **Empresas**  
- [ ] Criar módulo de **Produtos**  
- [ ] Criar módulo de **Pedidos** (Pedido + PedidoItem)  
- [ ] Criar módulo de **Estoque** (EstoqueMovimento)  
- [ ] Criar módulo de **Financeiro** (Contas a Receber)  
- [ ] Criar documentação em `/docs` (ER, decisões arquiteturais)  
- [ ] Criar frontend Angular (repo separado) e conectar com a API  
- [ ] Criar testes automatizados (xUnit)  
- [ ] Docker Compose para API + PostgreSQL

---

## 📡 Funcionalidades previstas

- 🔐 Login e autenticação JWT  
- 👥 Gestão de usuários e permissões (roles básicas)  
- 🏢 Cadastro de empresas  
- 📦 Gestão de produtos e catálogo  
- 🔁 Movimentação de estoque (entrada/saída/ajuste)  
- 🧾 Pedidos de venda com itens, cálculo de subtotal/desconto/total  
- 💳 Geração de contas a receber a partir do faturamento  
- 📊 Dashboard com KPIs simples

---

## 🗃️ Modelo de Dados (resumido)

### Produto
| Campo | Tipo |
|-------|------|
| id | int |
| nome | varchar |
| preco | numeric |
| estoqueMinimo | int |
| ativo | bool |

### Cliente
| Campo | Tipo |
|-------|------|
| id | int |
| nome | varchar |
| documento | varchar |
| email | varchar |
| telefone | varchar |

### Pedido
| Campo | Tipo |
|-------|------|
| id | int |
| idCliente | int |
| data | timestamp |
| status | varchar |
| valorTotal | numeric |
| desconto | numeric |

### PedidoItem
| Campo | Tipo |
|-------|------|
| id | int |
| idPedido | int |
| idProduto | int |
| quantidade | numeric |
| valorUnitario | numeric |
| valorTotal | numeric |

### EstoqueMovimento
| Campo | Tipo |
|-------|------|
| id | int |
| idProduto | int |
| tipo | varchar |
| quantidade | numeric |
| data | timestamp |

### ContaReceber
| Campo | Tipo |
|-------|------|
| id | int |
| idPedido | int |
| parcela | int |
| valor | numeric |
| dataVencimento | date |
| dataPagamento | date |
| status | varchar |

---

## 🛠 Como rodar (instruções iniciais)
- A definir...
