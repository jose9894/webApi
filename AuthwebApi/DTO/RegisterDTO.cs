using System.ComponentModel.DataAnnotations;

namespace AuthwebApi.DTO
{
    public class RegisterDTO
    {
        [Required]
        public string? UserName { get; set; }

        [Required]
        public string? Password { get; set; }

    }
}