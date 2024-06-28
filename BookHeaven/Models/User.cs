using Microsoft.AspNetCore.Identity;

namespace BookHeaven.Models
{
    public class User : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Address { get; set; }
        //public string? City { get; set; }
        //public string? Street { get; set; }
        //public int? Number { get; set; }
        //public int? ZipCode { get; set; }

    }
}
