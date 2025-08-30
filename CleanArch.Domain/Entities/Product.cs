using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArch.Domain.Validation;

namespace CleanArch.Domain.Entities
{
    public sealed class Product : Entitiy
    {

        public Product(string name, string description, decimal price, int stock, string image)
        {
            ValidateDomain(name, description, price, stock, image); 
        }

        public Product(int id, string name, string description, decimal price, int stock, string image)
        {
            ValidateDomain(name, description, price, stock, image);
            DomainExceptionValidation.When(id < 0, "Id is invalid.");
            Id = id;
        }

        public void Update(int id, string name, string description, decimal price, int stock, string image, int categoryId)
        {
            ValidateDomain(name, description, price, stock, image);
            DomainExceptionValidation.When(id < 0, "Id is invalid.");
            CategoryId = categoryId;
            Id = id;
        }

        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }  
        public int Stock { get; private set; }
        public string Image { get; private set; }


        // relation with category
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        // validation
        private void ValidateDomain(string name, string description, decimal price, int stock, string image)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Name is required.");
            DomainExceptionValidation.When(string.IsNullOrEmpty(description), "Description is required.");
            DomainExceptionValidation.When(string.IsNullOrEmpty(image), "Image is required.");
            DomainExceptionValidation.When(image.Length > 250, "Image name is invalid.");
            DomainExceptionValidation.When(name.Length < 3, "Name is invalid.");
            DomainExceptionValidation.When(price < 0, "Price is invalid.");
            DomainExceptionValidation.When(stock < 0, "Stock is invalid.");

            Name = name;
            Description = description;
            Price = price;
            Stock = stock;
            Image = image;
        }

    }
}
