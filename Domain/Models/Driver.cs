using Domain.Models.Base;
using Domain.ValueObjects;
using Elkood.Domain.Primitives;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    public class Driver : Entity
    {
       
        public LanguageProperty? Name { get; set; }

        public City? City { get; set; }
        public Guid CityId { get; set; }

        public string? Email { get; set; }
        public string? MobileNumber { get; set; }
        public string? TelegramId { get; set; }
        public DateOnly? BornDate { get; set; }

        public LanguageProperty? Address { get; set; }

        public bool ProfitIsPercentage{ get; set; }

        public int ProfitAmount { get; set; }


    }
}
