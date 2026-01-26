# 📘 StarLedger – Ledger API with Clean Architecture & CQRS

![Status](https://img.shields.io/badge/Status-Completed-success?style=flat)
![.NET](https://img.shields.io/badge/.NET-10-512BD4?style=flat&logo=dotnet&logoColor=white)
![CSharp](https://img.shields.io/badge/C%23-239120?style=flat&logo=csharp&logoColor=white)
![Architecture](https://img.shields.io/badge/Architecture-Clean%20Architecture-blue?style=flat)
![CQRS](https://img.shields.io/badge/Pattern-CQRS-orange?style=flat)

---
## 📖 About the Project

**StarLedger** is a **simple financial ledger API** built with **.NET 10**, designed as a **practical, hands-on demonstration of Clean Architecture and CQRS**.

The project focuses on **architectural clarity**, not on frameworks or external dependencies, showing how to:

- Protect the domain
- Separate read and write models
- Apply Dependency Inversion consistently
- Introduce caching **without breaking architecture**

> 🧠 “Good architecture is not about adding layers — it’s about putting decisions in the right place.”

---

## 🎯 Architectural Goals

This project was created to answer common architectural questions such as:

- Where should business rules live?
- How to separate commands from queries?
- Where does cache belong in CQRS?
- How to evolve infrastructure without touching the domain?

The solution is built upon:

- **Clean Architecture**
- **CQRS (Command Query Responsibility Segregation)**
- **Dependency Inversion Principle**
- **Explicit use cases**
- **Infrastructure as a plug-in**

---

## 🔄 CQRS in Practice

### ✍️ Commands (Write Model)

- `AddEntryUseCase`
- Responsible for:
  - Changing state
  - Enforcing business rules
  - Persisting data

### 🔍 Queries (Read Model)

- `GetLedgerEntriesHandler`
- Responsible for:
  - Returning projections
  - No business logic
  - Optimized for read

📌 **Read and Write models are intentionally separated.**

---

## ⚡ Cached Read Model

To demonstrate a real-world CQRS scenario, the project includes a **Cached Read Model**.

### Key points:

- Cache is applied **only to queries**
- Implemented using a **Decorator**
- No cache logic inside:
  - Domain
  - Use cases
- Cache is fully replaceable (Redis, SQL View, etc.)

> Cache accelerates queries, not business rules.

---

## 🔌 Dependency Injection & Composition Root

All infrastructure decisions are made at the **application boundary** (`Program.cs`):

- Decorators are composed via DI
- Interfaces are defined in the Application layer
- Implementations live in Infrastructure

This ensures:
- Low coupling
- High testability
- Easy evolution

---

## 🛠️ Technologies Used

| Technology | Description |
|----------|------------|
| **.NET 10** | Runtime & framework |
| **ASP.NET Core** | Web API |
| **C#** | Programming language |
| **IMemoryCache** | Cached read model |
| **Minimal DI** | Native container |

---

## 🚀 How to Run

```bash
git clone https://github.com/luisstarlino/StarLedger.git
cd StarLedger
dotnet run --project StarLedger.WebApi
