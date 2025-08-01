# 📁 Web File Explorer

A full-stack application built with **.NET 9** and **Angular 20**, implementing a modern file explorer interface and backend architecture. 
The solution leverages **Clean Architecture**, **CQRS**, and **Domain-Driven Design (DDD)** principles for scalability, testability, and maintainability.

---

## 🚀 Tech Stack

### Backend
- **.NET 9** (ASP.NET Core Web API)
- **MediatR** for CQRS
- **Entity Framework Core** for persistence
- **FluentValidation** for request validation
- **AutoMapper** for DTO mappings
- **Clean Architecture** + **DDD** structure
- **Shared Kernel** for common abstractions and cross-cutting concerns

---

## 🧩 Project Structure

```bash
src/
├── WebFileExplorer.Api              # ASP.NET Core API (Presentation Layer)
├── WebFileExplorer.Application      # Application Layer (CQRS, Use Cases)
├── WebFileExplorer.Domain           # Domain Layer (Entities, Aggregates, Value Objects)
├── WebFileExplorer.Infrastructure   # Infrastructure Layer (EF Core, external services)
├── WebFileExplorer.SharedKernel     # For common abstractions and cross-cutting concerns
