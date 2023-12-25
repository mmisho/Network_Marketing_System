using Domain.Shared;

namespace Domain.ProductManagement
{
    public class Product : BaseEntity<Guid>
    {
        public Product()
        {
            Name = string.Empty;
            Code = string.Empty;
        }

        public void Create(string code, string name, decimal unitPrice)
        {
            ValidateProduct(name);

            Code = code;
            Name = name;
            UnitPrice = unitPrice;
        }

        public void ChangeDetails(string code, string name, decimal unitPrice)
        {
            ValidateProduct(name);

            Code = code;
            Name = name;
            UnitPrice = unitPrice;
        }

        public override Guid Id { get; set; }
        public string Code { get; private set; }
        public string Name { get; private set; }
        public decimal UnitPrice { get; private set; }

        private static void ValidateProduct(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException($"{nameof(name)} cannot be null or empty");
            }
        }
    }
}
