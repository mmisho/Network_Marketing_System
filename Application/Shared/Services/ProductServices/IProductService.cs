namespace Application.Shared.Services.ProductServices
{
    public interface IProductService
    {
        Task ProductCodeValidation(string code);
    }
}
