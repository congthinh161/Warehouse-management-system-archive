using System.ComponentModel.DataAnnotations;

namespace WHM.Data.Dtos.Requests
{
    public class UserRegisterRequestDto
    {
        [Required]
        [MaxLength(20)]
        public string UserName { get; set; }
        [Required]
        [MaxLength(255)]
        public string Password { get; set; }
        [Required]
        [Range(1,3)]
        public short RoleId { get; set; }
    }
}
