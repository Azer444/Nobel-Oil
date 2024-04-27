using Core.Models.Abstraction;
using Microsoft.AspNetCore.Identity;
using System;

namespace Core.Models
{
    public class User : IdentityUser, ITiming
    {
        //Timing
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
