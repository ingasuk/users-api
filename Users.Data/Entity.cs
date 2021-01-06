using System;
using System.ComponentModel.DataAnnotations;

namespace Users.Data
{
    public abstract class Entity : IEntity
    {
        [Key]
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}
