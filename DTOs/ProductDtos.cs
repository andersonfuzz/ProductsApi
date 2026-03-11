namespace ProductsApi.DTOs;

public record CreateProductRequest(
    string Name,
    string Description,
    decimal Price
);

public record UpdateProductRequest(
    string Name,
    string Description,
    decimal Price
);

public record ProductResponse(
    Guid Id,
    string Name,
    string Description,
    decimal Price,
    DateTime CreatedAt,
    DateTime? UpdatedAt
);
