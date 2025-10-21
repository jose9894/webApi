using Microsoft.AspNetCore.Identity;

namespace AuthwebApi.Models
{
public class ApiUser : IdentityUser
    {
        public int? UserAccountId{get;set;}
        public UserAccount? UserAccount {get;set;}

    
    }

}