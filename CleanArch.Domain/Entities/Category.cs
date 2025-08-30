using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArch.Domain.Validation;

namespace CleanArch.Domain.Entities
{
    public sealed class Category : Entitiy
    {

        public Category(string name)
        {
            ValidateDomain(name);
        }

        public Category(int id, string name)
        {
            DomainExceptionValidation.When(id < 0, "Invalid id.");
            ValidateDomain(name);
        }

        public void Update(string name)
        {
            ValidateDomain(name);
        }

        public string Name { get; private set; }

        // relation with products
        public ICollection<Product> Products { get; set; }

        private void ValidateDomain(string name)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Name is required.");
            DomainExceptionValidation.When(name.Length < 3, "Invalid Name. Too short.");

            Name = name;
        }
    }
}
