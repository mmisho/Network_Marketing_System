using Domain.DistributorManagement.Enum;

namespace Application.DistributorManagement.Models
{
    public class IdCardModel
    {
        public IdCardTypeEnum IdCardType { get; set; }
        public string DocSeries { get; set; } = string.Empty;
        public string DocNum { get; set; } = string.Empty;
        public DateTime ReleaseDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string IdNumber { get; set; } = string.Empty;
        public string IssuingAgency { get; set; } = string.Empty;
    }
}
