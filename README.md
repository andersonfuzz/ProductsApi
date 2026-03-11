HTTP Request
    ↓
Controller        → recebe a requisição, valida a rota e chama o serviço
    ↓
Service           → contém a regra de negócio, chama o repositório
    ↓
Repository        → faz as operações no banco de dados
    ↓
AppDbContext      → EF Core executa a query no InMemory
    ↓
Repository        → retorna a entidade (Product)
    ↓
Service           → mapeia a entidade para o DTO (ProductResponse)
    ↓
Controller        → retorna o IActionResult com o DTO e o status HTTP
    ↓
HTTP Response