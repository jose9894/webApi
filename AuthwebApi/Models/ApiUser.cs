using Microsoft.AspNetCore.Identity;

namespace AuthwebApi.Models
{
public class ApiUser : IdentityUser
    {
        double? Amount { get; set; }
    }
}