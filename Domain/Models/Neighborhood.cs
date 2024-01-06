using Domain.Models.Base;
using Elkood.Domain.Primitives;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class Neighborhood : Entity
    {
       
        public LanguageProperty? Name { get; set; }
    }
}
