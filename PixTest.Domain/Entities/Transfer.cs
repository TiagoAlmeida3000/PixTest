using PixTest.Domain.Validation;

namespace PixTest.Domain.Entities
{
    public sealed class Transfer
    {
        public int Id { get;  private set; }

        public decimal? Value { get; private set; }

        public string PixOriginKey { get; private set; }

        public string PixDestinationKey { get; private set; }

        public int UserId { get; set; }

        public User User { get; set; }

        public Transfer(decimal? value, string pixOriginKey, string pixDestinationKey, int userId)
        {
            ValidateDomain(value, pixOriginKey, pixDestinationKey, userId);
        }

        public Transfer(int id, decimal? value, string pixOriginKey, string pixDestinationKey, int userId)
        {
            DomainExceptionValidation.When(id < 0, "Id invalido");

            Id = id;

            ValidateDomain(value, pixOriginKey, pixDestinationKey, userId);
        }

        public void Update(decimal? value, string pixOriginKey, string pixDestinationKey, int userId)
        {
            ValidateDomain(value, pixOriginKey, pixDestinationKey, userId);
        }

        private void ValidateDomain(decimal? value, string pixOriginKey, string pixDestinationKey, int userId)
        {
            DomainExceptionValidation.When(value == null,
                "Valor invalido. Valor não pode ser nulo");

            DomainExceptionValidation.When(value == 0,
                "Valor invalido. Valor tem que ser maior que zero");

            DomainExceptionValidation.When(value < 0,
                "Valor invalido. Valor não pode ser negativo");

            DomainExceptionValidation.When(string.IsNullOrEmpty(pixOriginKey),
                "Chave Pix de origem invalida. Chave Pix de origem é requerida");

            DomainExceptionValidation.When(string.IsNullOrEmpty(pixDestinationKey),
                "Chave Pix de destino invalida. Chave Pix de destino é requerida");

            Value = value;

            PixOriginKey = pixOriginKey;

            PixDestinationKey = pixDestinationKey;

            UserId = userId;
        }
    }
}
