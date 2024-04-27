using System;

namespace Core.Models.Abstraction
{
    public interface ITiming
    {
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
