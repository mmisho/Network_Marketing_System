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
            DocNum =   idCard.DocNum;
            ReleaseDate = idCard.ReleaseDate;
            ExpirationDate = idCard.ExpirationDate;
            IdNumber = idCard.IdNumber;
            IssuingAgency = idCard.IssuingAgency;  
        }
        public IdCardTypeEnum IdCardType { get;  set; }
        public string? DocSeries { get;  set; }
        public string? DocNum { get;  set; }
        public DateTime ReleaseDate { get;  set; }
        public DateTime ExpirationDate { get;  set; }
        public string IdNumber { get;  set; } = string.Empty;
        public string IssuingAgency { get;  set; } = string.Empty;
    }
}
