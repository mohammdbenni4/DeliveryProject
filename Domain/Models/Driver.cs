using Domain.Models.Base;
using Elkood.Domain.Primitives;


namespace Domain.Models
{
    public class Driver : Entity
    {
        public Driver()
        {
            
        }
        
        public LanguageProperty? Name { get; set; }
        public List<string> MobileNumbers { get; set; } = new();
        public DateOnly? BirthDate { get; set; }
        public string? Email { get; set; }
        public City? City { get; set; }
        public Guid CityId { get; set; }
        public LanguageProperty? Address { get; set; }

        public List<string> WorkingDays { get; set; } = new();
        
        
        public string? TelegramId { get; set; }
        public bool ProfitIsPercentage{ get; set; }
        public int ProfitAmount { get; set; }
        public string BloodType { get; set; }

        public List<string> Documents { get; set; } =new();
        public string PhotoUrl { get; set; }

        // public void AddTime(Dictionary<TimeOnly,TimeOnly> dictionary)
        // {
        //     Times.Add(dictionary);
        // }

    }
    
   

   
  
}
