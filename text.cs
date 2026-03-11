/*
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

*/

/*
1. Entity
   → é o coração do projeto, não depende de nada

2. Interface do Repository
   → define o contrato de acesso aos dados, mas ainda não implementa nada

3. DTOs
   → define o que entra e o que sai da API

4. Interface do Service
   → define o contrato da regra de negócio

5. DbContext
   → configura o EF Core com as entidades

6. Repository (implementação)
   → implementa a interface do repositório usando o DbContext

7. Service (implementação)
   → implementa a interface do serviço usando o repositório

8. Controller
   → usa o serviço para responder as requisições HTTP

9. Program.cs
   → registra tudo no container de injeção de dependência
*/