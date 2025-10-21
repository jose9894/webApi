using Microsoft.AspNetCore.Identity;

namespace AuthwebApi.Models
{
public class ApiUser : IdentityUser
    {
        // public int UserNum { get; set; }
        // public int? Amount { get; set; }
        // public int? DepositLimit { get; set; }
        // public bool? ActiveStatus { get; set; }

        public int? UserAccountId{get;set;}
        public UserAccount? UserAccount {get;set;}

    
    }

}