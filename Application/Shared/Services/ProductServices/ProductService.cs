

using Domain.ProductManagement.Repository;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlTypes;

namespace Application.Shared.Services.ProductServices
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task ProductCodeValidation(string code)
        {
            if (await NotUniqueProductCode(code))
            {
                throw new InvalidOperationException($"A product is allready registered with the code {code}");
            }
        }
        private async Task<bool> NotUniqueProductCode(string code)
        {
            return await _productRepository.Query().AnyAsync(x => x.Code == code);
        }
    }
}
