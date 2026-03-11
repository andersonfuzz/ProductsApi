using ProductsApi.DTOs;
using ProductsApi.Entities;
using ProductsApi.Interfaces;

namespace ProductsApi.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _repository;

    public ProductService(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<ProductResponse>> GetAllAsync()
    {
        var products = await _repository.GetAllAsync();
        return products.Select(MapToResponse);
    }

    public async Task<ProductResponse?> GetByIdAsync(Guid id)
    {
        var product = await _repository.GetByIdAsync(id);
        return product is null ? null : MapToResponse(product);
    }

    public async Task<ProductResponse> CreateAsync(CreateProductRequest request)
    {
        var product = new Product(request.Name, request.Description, request.Price);
        var created = await _repository.AddAsync(product);
        return MapToResponse(created);
    }

    public async Task<ProductResponse?> UpdateAsync(Guid id, UpdateProductRequest request)
    {
        var product = await _repository.GetByIdAsync(id);

        if (product is null)
            return null;

        product.Update(request.Name, request.Description, request.Price);
        var updated = await _repository.UpdateAsync(product);
        return MapToResponse(updated);
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var product = await _repository.GetByIdAsync(id);

        if (product is null)
            return false;

        await _repository.DeleteAsync(product);
        return true;
    }

    private static ProductResponse MapToResponse(Product product) => new(
        product.Id,
        product.Name,
        product.Description,
        product.Price,
        product.CreatedAt,
        product.UpdatedAt
    );
}
