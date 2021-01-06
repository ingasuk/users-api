using System.Collections.Generic;

namespace Users.Data.Entities
{
    public class UserEntity : Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}
