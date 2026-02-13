using BaseBackend.Application.DTOs;
using BaseBackend.Domain.Entities;
using BaseBackend.Domain.Interfaces;

namespace BaseBackend.Application.Services;

public class ProductService
{
    private readonly IProductRepository _productRepository;

    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<IEnumerable<ProductDto>> GetAllAsync()
    {
        var products = await _productRepository.GetAllAsync();

        return products.Select(p => new ProductDto
        {
            Id = p.Id,
            Name = p.Name,
            Price = p.Price
        });
    }

    public async Task<ProductDto?> GetByIdAsync(Guid id)
    {
        var product = await _productRepository.GetByIdAsync(id);

        if (product == null)
            return null;

        return new ProductDto
        {
            Id = product.Id,
            Name = product.Name,
            Price = product.Price
        };
    }

    public async Task CreateAsync(ProductDto dto)
    {
        var product = new Product(dto.Name, dto.Price);
        await _productRepository.AddAsync(product);
    }

    public async Task UpdateAsync(Guid id, ProductDto dto)
    {
        var product = await _productRepository.GetByIdAsync(id);

        if (product == null)
            throw new Exception("Product not found");

        product.Update(dto.Name, dto.Price);

        await _productRepository.UpdateAsync(product);
    }

    public async Task DeleteAsync(Guid id)
    {
        await _productRepository.DeleteAsync(id);
    }
}