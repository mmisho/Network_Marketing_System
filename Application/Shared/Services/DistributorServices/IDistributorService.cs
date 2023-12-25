namespace Application.Shared.Services.DistributorServices
{
    public interface IDistributorService
    {
        Task ValidateRecomendatorAsync(Guid recomendatorId);
    }
}
