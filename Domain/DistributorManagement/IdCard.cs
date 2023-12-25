using Domain.DistributorManagement.Enum;
using Domain.Shared;

namespace Domain.DistributorManagement
{
    public class IdCard : BaseEntity<Guid>
    {
        public IdCard()
        {
            DocSeries = string.Empty;
            DocNum = string.Empty;
            IdNumber = string.Empty;
            IssuingAgency = string.Empty;
        }

        public void Create(IdCardTypeEnum idCardType, string docSeries, string docNum, DateTime releaseDate, DateTime expirationDate, string idNumber, string issuingAgency)
        {
            ValidateIdCard(docSeries, docNum, idNumber, issuingAgency);

            IdCardType = idCardType;
            DocSeries = docSeries;
            DocNum = docNum;
            ReleaseDate = releaseDate;
            ExpirationDate = expirationDate;
            IdNumber = idNumber;
            IssuingAgency = issuingAgency;
        }

        public void ChangeDetails(IdCardTypeEnum idCardType, string docSeries, string docNum, DateTime releaseDate, DateTime expirationDate, string idNumber, string issuingAgency)
        {
            ValidateIdCard(docSeries, docNum, idNumber, issuingAgency);

            IdCardType = idCardType;
            DocSeries = docSeries;
            DocNum = docNum;
            ReleaseDate = releaseDate;
            ExpirationDate = expirationDate;
            IdNumber = idNumber;
            IssuingAgency = issuingAgency;
        }

        public override Guid Id { get; set; }
        public IdCardTypeEnum IdCardType { get; private set; }
        public string? DocSeries { get; private set; }
        public string? DocNum { get; private set; }
        public DateTime ReleaseDate { get; private set; }
        public DateTime ExpirationDate { get; private set; }
        public string IdNumber { get; private set; }
        public string IssuingAgency { get; private set; }
        public virtual Distributor? Distributor { get; private set; }
        public Guid DistributorId { get; private set; }

        private void ValidateIdCard(string docSeries, string docNum, string idNumber, string issuingAgency)
        {
            if (docSeries.Length > 10)
            {
                throw new ArgumentOutOfRangeException($"{nameof(docSeries)} length should not be greater than 10");
            }

            if (docNum.Length > 10)
            {
                throw new ArgumentOutOfRangeException($"{nameof(docNum)} length should not be greater than 10");
            }

            if (idNumber.Length > 50)
            {
                throw new ArgumentOutOfRangeException($"{nameof(idNumber)} length should not be greater than 50");
            }

            if (issuingAgency.Length > 100)
            {
                throw new ArgumentOutOfRangeException($"{nameof(issuingAgency)} length should not be greater than 100");
            }
        }
    }
}
