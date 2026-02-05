# Web API 200 Course Summary
## ASP.NET Core Web API with Aspire, Integration Patterns & Distributed Messaging

**Course Duration:** February 2-4, 2026 (3 Days)  
**Instructor:** Jeff Gonzalez (jeff@hypertheory.com)

---

## Course Overview

This intensive 3-day course covered building modern ASP.NET Core Web APIs with a focus on local development environments using Microsoft Aspire, HTTP-based integration patterns with resiliency, and distributed messaging architectures using NATS. Students worked through a Software Catalog management system that demonstrated real-world patterns for microservices communication, event sourcing, and CQRS.

---

## Day 1 - Monday, February 2, 2026
### Foundation: ASP.NET Core APIs & Aspire Setup

#### Morning Session: Environment Setup & Fundamentals

**Topics Covered:**
- **Development Environment Configuration**
  - Virtual machine setup and Docker Desktop installation
  - Git workflow and repository management
  - Visual Studio Code configuration

- **ASP.NET Core Web API Fundamentals**
  - Project structure and minimal API patterns
  - Understanding `Program.cs` - the builder pattern
  - Configuration vs. Middleware concepts
  - Service registration and dependency injection
  - OpenAPI/Swagger integration for API documentation

- **Initial Software API Creation**
  - Created `Software.Api` project with weather forecast controller
  - HTTP files for testing API endpoints
  - Understanding launch settings and development profiles
  - Configuration management with `appsettings.json`

#### Afternoon Session: Microsoft Aspire Integration

**Topics Covered:**
- **Introduction to Microsoft Aspire**
  - Purpose: Local development orchestration for distributed applications
  - Benefits over docker-compose for .NET developers
  - Integrated observability and service discovery

- **Aspire AppHost Setup**
  - Created `AppHost` project as the orchestration entry point
  - `ServiceDefaults` project for shared configurations
  - Configured PostgreSQL database with persistent lifetime
  - Service references and wait dependencies

- **Database Integration**
  - Added PostgreSQL container via Aspire
  - Database reference pattern: `pg-server` → `software-db`
  - Connection string management through Aspire
  - Container lifetime management (persistent vs. ephemeral)

- **Aspire Extensions and Middleware**
  - Service defaults extension methods
  - Health checks integration
  - OpenTelemetry configuration for observability
  - Default middleware pipeline configuration

**Key Concepts:**
- Coupling and cohesion in distributed systems
- Containerization with Dockerfile creation
- Service orchestration patterns
- Infrastructure as Code for local development

**Deliverables:**
- Functional Software.Api with Aspire orchestration
- PostgreSQL database integration
- ServiceDefaults project with shared configurations
- AppHost with basic service topology

---

## Day 2 - Tuesday, February 3, 2026
### HTTP Integration Patterns & Resiliency

#### Morning Session: API Design & Remote Service Integration

**Topics Covered:**
- **Event Storming & Domain Modeling**
  - Business requirement: "Items can be added to the catalog, must be associated with existing vendor"
  - Domain event identification
  - Command/query separation thinking
  - API contract design

- **Catalog API Development**
  - Removed weather forecast controller (demo code)
  - Created `CatalogController` for adding items
  - Endpoint organization and routing
  - Request/response model design

- **Refactoring to Minimal APIs**
  - Moved from controller-based to endpoint-based approach
  - Created `Catalog/EndpointExtensions.cs` for organization
  - `Catalog/Operations/AddingItem.cs` for business logic
  - Benefits of vertical slice architecture

#### Afternoon Session: HTTP Client & External Service Integration

**Topics Covered:**
- **Typed HTTP Clients**
  - Created `BackingApis/Vendors.cs` typed HTTP client
  - `IHttpClientFactory` pattern and benefits
  - Configuration of base addresses in `Program.cs`
  - API key management through configuration

- **HTTP Synchronous Communication Patterns**
  - Calling external Vendor API to verify vendor exists
  - Error handling strategies for HTTP calls
  - Response status code handling
  - Request/response logging

- **Service Relationship Patterns**
  - **Open Host Service**: External vendor API pattern
  - **Conformist Pattern**: Adapting to external service contracts
  - **Separate Ways**: When to avoid integration
  - Coupling analysis between services

- **HTTP Resiliency with WireMock**
  - Introduced WireMock for API mocking during development
  - Docker Compose setup for WireMock container
  - Created mock mappings for vendor endpoints:
    - `vendor-found.json` - successful vendor lookup
    - `vendors-all.json` - list all vendors
  - Benefits of contract testing and isolated development

- **Cancellation Token Pattern**
  - Proper cancellation token propagation
  - Graceful shutdown of HTTP requests
  - Resource cleanup and timeout handling
  - Best practices for async operations

- **Error Handling & Resiliency**
  - Simulating failing external services
  - Circuit breaker concepts (discussed)
  - Retry policies (conceptual)
  - Fallback strategies

**Key Concepts:**
- Asynchronous processing patterns
- HTTP client lifecycle management
- API contract testing with mocks
- Temporal coupling in distributed systems
- Request cancellation and timeouts

**Deliverables:**
- Add item to catalog endpoint with vendor validation
- Typed HTTP client for vendor service integration
- WireMock-based development environment
- Comprehensive error handling patterns

---

## Day 3 - Wednesday, February 4, 2026
### YARP Gateway, Event Sourcing, CQRS & Distributed Messaging

#### Morning Session: API Gateway & Documentation

**Topics Covered:**
- **YARP (Yet Another Reverse Proxy) Gateway**
  - Created `Gateway` project as edge service
  - `yarp-config.json` for route configuration
  - Service discovery integration with Aspire
  - Benefits: API composition, security boundary, insulation layer

- **Gateway Patterns**
  - **Insulation Layer**: Protecting internal services from external changes
  - **Facade**: Presenting unified API surface
  - **Migration Strategy**: Moving from external to internal vendor service
  - API key hiding and credential management

- **OpenAPI Documentation with Scalar**
  - Integrated Scalar UI for API documentation
  - Multi-service documentation aggregation
  - Interactive API testing interface
  - Developer experience improvements

- **NuGet Package Management**
  - Discussion of internal NuGet feeds/Artifactory
  - Sharing code between services via packages
  - Versioning strategies for shared libraries

#### Afternoon Session: Event Sourcing, CQRS & Messaging with NATS

**Topics Covered:**

**1. Event Sourcing & CQRS with Marten**
- **Vendors.Api - From Scratch with Event Sourcing**
  - Created new `Vendors.Api` project
  - Replaced mock external vendor service with internal implementation
  - **Marten** integration for event sourcing with PostgreSQL
  - Event stream management for vendor lifecycle

- **Event Sourcing Fundamentals**
  - Events as source of truth: `VendorCreated`, `VendorDeactivated`
  - Event store vs. traditional CRUD
  - Stream-based storage pattern
  - Append-only event log

- **CQRS (Command Query Responsibility Segregation)**
  - **Commands**: `CreateAVendor`, `RemoveAVendor`
  - **Events**: `VendorCreated`, `VendorDeactivated`
  - Separate read and write models
  - Command handlers with `VendorHandler.cs`

- **Projections & Read Models**
  - `ReadModels/UiVendorList.cs` - list projection
  - `ReadModels/VendorSummary.cs` - detail projection
  - Live projections for query optimization
  - Materialized views from event streams

**2. Distributed Messaging with NATS & Wolverine**
- **Created Messages Project**
  - `Messages.csproj` - shared message contracts
  - `domain-events.cs` - domain event definitions
  - `Internal.cs` - internal message types
  - Cross-service message sharing

- **Wolverine Messaging Framework**
  - Integration with Aspire for NATS
  - Message handler pattern with `VendorHandler`
  - Command cascading and orchestration
  - Automatic message routing and delivery

- **NATS Integration**
  - JetStream for reliable messaging
  - Pub/sub patterns for domain events
  - Queue groups for competing consumers
  - Stream persistence and replay

- **Message Handlers**
  - `Software.Api` → `VendorHandler.cs` subscribes to vendor events
  - Automatic handler discovery and registration
  - Transaction management with Marten
  - Error handling and retry policies

- **Transactional Outbox Pattern**
  - Publishing messages as part of transaction
  - Guaranteed message delivery with event store
  - `IMessageBus.PublishAsync()` integration
  - Consistency between state changes and messages

**3. Wolverine and NATS Demo**
- **Demo Project: `WolverineAndNats`**
  - `ApiOne` - message publisher
  - `ApiTwo` - message consumer
  - `PlainListener` - raw NATS listener comparison
  - `LateComer` - demonstrating message replay
  - Demonstrated various messaging patterns:
    - Point-to-point messaging
    - Pub/sub with multiple subscribers
    - Stream replay for late-joining consumers
    - Message correlation and tracing

**4. Decoupling with Messaging**
- **Separate Ways Pattern**
  - Software.Api no longer directly calls Vendors.Api
  - Communication via domain events
  - Autonomous service boundaries
  - Eventual consistency

- **Benefits Demonstrated**
  - Loose coupling between services
  - Independent deployability
  - Fault isolation
  - Temporal decoupling (async communication)
  - Scalability through message queuing

**5. OpenTelemetry & Observability**
- **Distributed Tracing**
  - Trace correlation across services
  - Message propagation tracking
  - Performance bottleneck identification
  - End-to-end request visibility

- **Performance Optimization**
  - Identifying slow synchronous operations
  - Moving long-running work offline (async via messages)
  - Impact analysis through traces
  - Aspire dashboard integration

#### Backend for Frontend (BFF) Introduction

**Topics Covered:**
- **BFF Pattern Overview**
  - Purpose: Tailored API for specific frontend needs
  - Gateway as BFF implementation
  - Client-specific aggregations and transformations

- **Angular Frontend Integration** (Introduction)
  - OpenAPI client generation
  - Type-safe API communication
  - Frontend/backend contract management

**Key Concepts:**
- Event sourcing as system of record
- CQRS for read/write optimization
- Eventual consistency in distributed systems
- Messaging patterns: pub/sub, queues, streams
- Transactional outbox for reliability
- API gateway patterns and responsibilities
- Developer experience with modern tooling

**Deliverables:**
- Full event-sourced Vendors.Api with CQRS
- NATS-based messaging infrastructure
- Gateway with YARP routing
- Decoupled service architecture via events
- Comprehensive demo of messaging patterns
- Production-ready patterns: outbox, projections, observability

---

## Technical Stack

### Core Technologies
- **ASP.NET Core** (Latest) - Web API framework
- **Microsoft Aspire** - Local development orchestration
- **C# 12+** - Programming language

### Data & Persistence
- **PostgreSQL** - Relational database
- **Marten** - Event sourcing and document DB for PostgreSQL
- **Entity Framework Core** - Traditional ORM (mentioned)

### Messaging & Integration
- **NATS** with JetStream - Message broker
- **Wolverine** - Messaging framework for .NET
- **YARP** (Yet Another Reverse Proxy) - API Gateway
- **WireMock** - API mocking for development

### Development & Observability
- **Docker & Docker Compose** - Containerization
- **OpenTelemetry** - Distributed tracing
- **Scalar** - OpenAPI documentation UI
- **Visual Studio Code** - Primary IDE

---

## Key Architectural Patterns Demonstrated

1. **Microservices Architecture**
   - Service decomposition
   - Independent deployability
   - Bounded contexts

2. **Event Sourcing**
   - Events as source of truth
   - Event streams and aggregates
   - Audit trail and temporal queries

3. **CQRS (Command Query Responsibility Segregation)**
   - Separate read and write models
   - Optimized projections for queries
   - Command handlers for writes

4. **API Gateway Pattern**
   - Centralized entry point
   - Service composition
   - Cross-cutting concerns (auth, logging)

5. **Transactional Outbox**
   - Reliable message publishing
   - Consistency between DB and messages
   - At-least-once delivery guarantees

6. **Service Relationship Patterns**
   - Open Host Service
   - Conformist
   - Separate Ways

7. **Backend for Frontend (BFF)**
   - Frontend-specific APIs
   - Client-tailored responses

8. **Observability Patterns**
   - Distributed tracing
   - Health checks
   - Structured logging

---

## Development Best Practices Covered

- **Configuration Management**: Environment-specific settings, secrets handling
- **Dependency Injection**: Service lifetime management, scoped services
- **Vertical Slice Architecture**: Feature-based organization
- **Typed HTTP Clients**: Resilient service-to-service communication
- **Cancellation Tokens**: Graceful shutdown and resource cleanup
- **Error Handling**: Retry policies, circuit breakers, fallbacks
- **Contract Testing**: WireMock for isolated development
- **Message-Driven Architecture**: Decoupling via async messaging
- **Read Model Optimization**: Projections for query performance
- **Infrastructure as Code**: Aspire for reproducible environments

---

## Course Progression Summary

**Day 1** established the foundation with ASP.NET Core APIs and Aspire, demonstrating how to orchestrate a local development environment with databases and multiple services.

**Day 2** focused on service integration patterns, teaching students how to call external APIs with resiliency, handle failures, and use mocking for development. The emphasis was on synchronous HTTP communication patterns and their tradeoffs.

**Day 3** advanced to sophisticated patterns including event sourcing, CQRS, and distributed messaging with NATS. Students learned how to decouple services using events, implement the transactional outbox pattern, and build scalable systems with eventual consistency. The day culminated in a comprehensive messaging demo and integration of all concepts into a cohesive architecture.

---

## Project Structure

```
src/SoftwareSolution/
├── AppHost/                    # Aspire orchestration host
├── ServiceDefaults/            # Shared service configurations
├── Software.Api/              # Main software catalog API
│   ├── Catalog/              # Catalog domain logic
│   └── BackingApis/          # External service clients
├── Vendors.Api/              # Event-sourced vendor service
│   └── Vendors/             # Event handlers & projections
├── Gateway/                  # YARP-based API gateway
└── Messages/                 # Shared message contracts

demos/
└── WolverineAndNats/        # Messaging patterns demonstration

mocking/
└── wiremock/                # Mock service definitions

notes/
├── design/                  # Architecture diagrams
└── *.excalidraw            # Technical diagrams
```

---

## Key Takeaways

1. **Microsoft Aspire** dramatically improves the local development experience for distributed applications with integrated observability and service orchestration.

2. **HTTP integration** requires careful attention to resiliency patterns, error handling, and coupling management between services.

3. **Event sourcing with Marten** provides a powerful pattern for building auditable, temporally-aware systems with built-in history.

4. **CQRS separates concerns** between reads and writes, allowing independent optimization of each path and better scalability.

5. **NATS with Wolverine** offers a modern, performant approach to distributed messaging with excellent .NET integration and automatic handler management.

6. **Messaging decouples services** temporally and spatially, enabling independent scaling, deployment, and failure isolation.

7. **Transactional outbox** solves the dual-write problem, ensuring consistency between database changes and message publishing.

8. **YARP provides flexible gateway capabilities** for API composition, service insulation, and migration strategies.

9. **OpenTelemetry integration** via Aspire enables comprehensive observability with minimal configuration overhead.

10. **Vertical slice architecture** and minimal APIs create more maintainable, feature-focused codebases.

---

## Additional Resources

- Course Repository: Contains all code, scripts, and design documents
- HTTP Files: Ready-to-use API testing scripts
- Excalidraw Diagrams: Visual architecture and design documentation
- Demo Projects: Standalone examples of messaging patterns
- Reset Scripts: Tools for resetting Docker and code state during learning

---

*Course materials prepared and delivered by Jeff Gonzalez (jeff@hypertheory.com)*  
*HyperTheory Labs - https://class.hypertheory-labs.com*
