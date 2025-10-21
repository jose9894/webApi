using Microsoft.AspNetCore.Identity;

namespace AuthwebApi.Models
{
    public class UserAccount
    {
        public int UserAccountId { get; set; }
        public string? UserName { get; set; }
        public int Amount { get; set; }
        public int? DepositLimit { get; set; }
        public bool ActiveStatus { get; set; }
    }
}