# 🧱 stack-erp

**Minimal, high-performance ERP platform built with ASP.NET Core Minimal APIs, PostgreSQL, and Angular — following Clean Architecture principles.**

---

## 📌 Overview

**stack-erp** is a modern, minimalist full-stack ERP designed to demonstrate:

- Clean, decoupled architecture  
- Backend built with **ASP.NET Core 8 Minimal APIs**  
- Lightweight **Angular** frontend (no heavy UI frameworks)  
- **PostgreSQL** as the primary database  
- Strong focus on code quality, versioning, and documentation  
- A professional, scalable structure suitable for portfolio and real-world systems  

This project is intentionally designed as a **long-living codebase**, evolving incrementally with best practices.

---

## 🚀 Tech Stack

### Backend
- ASP.NET Core 8 (Minimal APIs)  
- Clean Architecture (Domain / Application / Infrastructure / API)  
- PostgreSQL  
- Dapper and/or Entity Framework Core  
- FluentValidation  
- JWT-based Authentication  
- Serilog (structured logging)  
- Docker (optional)

### Frontend
- Angular  
- TypeScript  
- RxJS  
- ngModel (template-driven forms)  
- HttpClient  

---

## 🗂 Project Structure
```
stack-erp
│
├── backend/
│ └── src/
│ ├── StackErp.Api
│ ├── StackErp.Application
│ ├── StackErp.Domain
│ └── StackErp.Infrastructure
│
├── frontend/
│ └── stack-erp-web/
│
├── docs/
│ ├── architecture.md
│ ├── decisions.md
│ └── diagrams/
│
└── README.md
```

This structure follows an **API-first approach**, allowing backend and frontend to evolve independently.

---

## 📘 Roadmap

- [ ] Configure solution and base structure  
- [ ] Base endpoints (HealthCheck, Version, Swagger/OpenAPI)  
- [ ] **Authentication & Users** module (JWT)  
- [ ] **Companies** module  
- [ ] **Products** module  
- [ ] **Orders** module (Order + OrderItem)  
- [ ] **Inventory** module (Stock Movements)  
- [ ] **Financial** module (Accounts Receivable)  
- [ ] Documentation in `/docs` (ER diagrams, architectural decisions)  
- [ ] Integrate Angular frontend with API  
- [ ] Automated tests (xUnit)  
- [ ] Docker Compose for API + PostgreSQL  

---

## 📡 Planned Features

- 🔐 JWT-based authentication  
- 👥 User and role management  
- 🏢 Company registration and management  
- 📦 Product catalog  
- 🔁 Inventory movements (inbound / outbound / adjustments)  
- 🧾 Sales orders with discounts and totals  
- 💳 Accounts receivable generation from sales  
- 📊 Simple business KPIs dashboard  

---

## 🗃️ Data Model (Simplified)

### Product

| Field | Type |
|------|------|
| id | int |
| name | varchar |
| price | numeric |
| minimumStock | int |
| active | bool |

### Customer

| Field | Type |
|------|------|
| id | int |
| name | varchar |
| document | varchar |
| email | varchar |
| phone | varchar |

### Order

| Field | Type |
|------|------|
| id | int |
| customerId | int |
| date | timestamp |
| status | varchar |
| totalAmount | numeric |
| discount | numeric |

### OrderItem

| Field | Type |
|------|------|
| id | int |
| orderId | int |
| productId | int |
| quantity | numeric |
| unitPrice | numeric |
| totalPrice | numeric |

### InventoryMovement

| Field | Type |
|------|------|
| id | int |
| productId | int |
| type | varchar |
| quantity | numeric |
| date | timestamp |

### AccountsReceivable

| Field | Type |
|------|------|
| id | int |
| orderId | int |
| installment | int |
| amount | numeric |
| dueDate | date |
| paymentDate | date |
| status | varchar |

---

## 🛠 Running the Project

> Setup instructions will be added as the backend and infrastructure are finalized.

---

## 🎯 Project Goals

This repository is not intended to be a tutorial project.  
It exists to demonstrate:

- Software architecture decisions  
- Code organization at scale  
- Backend-first system design  
- Readable, maintainable, and testable code  
