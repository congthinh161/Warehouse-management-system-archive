using System.ComponentModel.DataAnnotations;

namespace WHM.Data.Dtos.Requests
{
    public class UserLoginRequestDto
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
