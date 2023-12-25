using Domain.DistributorManagement;
using Domain.DistributorManagement.Enum;

namespace Application.DistributorManagement.Dtos
{
    public class IdCardDtoModel
    {
        public IdCardDtoModel(IdCard idCard)
        {
            IdCardType = idCard.IdCardType;
            DocSeries = idCard.DocSeries;
            DocNum = idCard.DocNum;
            ReleaseDate = idCard.ReleaseDate;
            ExpirationDate = idCard.ExpirationDate;
            IdNumber = idCard.IdNumber;
            IssuingAgency = idCard.IssuingAgency;
        }

        public IdCardTypeEnum IdCardType { get; private set; }
        public string? DocSeries { get; private set; }
        public string? DocNum { get; private set; }
        public DateTime ReleaseDate { get; private set; }
        public DateTime ExpirationDate { get; private set; }
        public string IdNumber { get; private set; } = string.Empty;
        public string IssuingAgency { get; private set; } = string.Empty;
    }
}
