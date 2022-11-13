using PixTest.Domain.Validation;
using System.Collections.Generic;

namespace PixTest.Domain.Entities
{
    public sealed class User
    {
        public int Id { get; private set; }

        public string Name { get; private set; }

        public string Document { get; private set; }

        public string PixKey { get; private set; }

        public ICollection<Transfer> Transfers { get; set; }

        public User(string name, string document, string pixKey)
        {
            ValidateDomain(name, document, pixKey);
        }

        public User(int id, string name, string document, string pixKey)
        {
            DomainExceptionValidation.When(id < 0, "Id invalido.");

            Id = id;

            ValidateDomain(name, document, pixKey);
        }

        public void Update(string name, string document, string pixKey)
        {
            ValidateDomain(name, document, pixKey);
        }

        private void ValidateDomain(string name, string document, string pixKey)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name),
                "Nome Invalido. Nome é requerido");

            DomainExceptionValidation.When(name.Length < 3,
                "Nome Invalido. Nome tem que ter no minimo 3 caracteres");

            DomainExceptionValidation.When(name.Length > 50,
                "Nome Invalido. Nome tem que ter no maximo 50 caracteres");

            DomainExceptionValidation.When(string.IsNullOrEmpty(document),
                "Documento invalido. Documento é requerido");

            DomainExceptionValidation.When(string.IsNullOrEmpty(pixKey),
                "Chave Pix invalida. Chave Pix é requerida");

            DomainExceptionValidation.When(pixKey.Length < 5,
                "Chave Pix invalida. Chave Pix tem que ter no minimo 5 caracteres");

            Name = name;

            Document = document;

            PixKey = pixKey;      
        }
    }
}
