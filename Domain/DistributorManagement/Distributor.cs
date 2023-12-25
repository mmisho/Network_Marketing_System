using Domain.BonusManagement;
using Domain.DistributorManagement.Enum;
using Domain.SaleManagement;
using Domain.Shared;

namespace Domain.DistributorManagement
{
    public class Distributor : BaseEntity<Guid>
    {
        public Distributor()
        {
            FirstName = string.Empty;
            LastName = string.Empty;
            IdCardInfo = new IdCard();
            Contact = new Contact();
            Address = new Address();
            Sales = new List<Sale>();
            Bonuses = new List<Bonus>();
        }

        public void Create(string firstName, string lastName, DateTime birthDate, GenderEnum gender, byte[]? picture,
                           IdCard idCard, Contact contact, Address address, Guid? recomendatorId)
        {

            if (idCard is null)
            {
                throw new ArgumentNullException($"{nameof(idCard)} cannot be null");
            }

            if (contact is null)
            {
                throw new ArgumentNullException($"{nameof(contact)} cannot be null");
            }

            if (address is null)
            {
                throw new ArgumentNullException($"{nameof(address)} cannot be null");
            }

            ValidateDistributor(firstName, lastName);

            FirstName = firstName;
            LastName = lastName;
            BirthDate = birthDate;
            Gender = gender;
            Picture = picture;
            IdCardInfo = idCard;
            Contact = contact;
            Address = address;
            RecomendatorId = recomendatorId;
        }

        public void ChangeDetails(string firstName, string lastName, DateTime birthDate, GenderEnum gender, byte[]? picture, Guid? recomendatorId)
        {
            ValidateDistributor(firstName, lastName);

            FirstName = firstName;
            LastName = lastName;
            BirthDate = birthDate;
            Gender = gender;
            Picture = picture;
            RecomendatorId = recomendatorId;
        }

        public override Guid Id { get; set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public DateTime BirthDate { get; private set; }
        public GenderEnum Gender { get; private set; }
        public byte[]? Picture { get; private set; }
        public virtual Distributor? Recomendator { get; private set; }
        public Guid? RecomendatorId { get; private set; }
        public virtual IdCard IdCardInfo { get; private set; }
        public virtual Contact Contact { get; private set; }
        public virtual Address Address { get; private set; }
        public virtual List<Sale> Sales { get; set; }
        public virtual List<Bonus> Bonuses { get; set; }

        private void ValidateDistributor(string firstName, string lastName)
        {
            if (string.IsNullOrEmpty(firstName))
            {
                throw new ArgumentNullException($"{nameof(firstName)} cannot be null or empty");
            }

            if (firstName.Length > 50)
            {
                throw new ArgumentOutOfRangeException($"{nameof(firstName)} lenth cannot be greater than 50");
            }

            if (string.IsNullOrEmpty(lastName))
            {
                throw new ArgumentNullException($"{nameof(lastName)} cannot be null or empty");
            }

            if (lastName.Length > 50)
            {
                throw new ArgumentOutOfRangeException($"{nameof(lastName)} lenth cannot be greater than 50");
            }
        }
    }
}
