using Identity.Domain;

namespace Identity.Domain;

public class Role
{
    public int Id { get; set; }
    public RoleType Type { get; set; }
    public ICollection<User> Users { get; set; } 
        = new List<User>();
}
