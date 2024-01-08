using Elkood.Identity.Entities;

namespace Domain.Models.Security
{
    public class User : ElIdentityUserAggregate
    {
        protected User()
        {
            Id = Guid.NewGuid();
            UserName = Guid.NewGuid().ToString();
        }
        public DateOnly? BirthDate { get; set; }
        
    }
}
