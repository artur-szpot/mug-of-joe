using System;
using System.ComponentModel.DataAnnotations;

namespace CoffeeMugWebApi.Models.DataTypes
{
    /*
     * Represents a single Product entity.
     */
    public class Product
    {
        public Guid Id { get; set; }

        [StringLength(100, MinimumLength = 1)]
        [Required]
        public string Name { get; set; }

        [Range(0.01, 99999999.99)]
        [Required]
        public Decimal Price { get; set; }
    }
}