using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Whm.Data.Entities
{
    [Table("WHM_Account")]
    public class WhmAccount : BaseModel
    {
        [Key]
        [MaxLength(20)]
        public string UserName { get; set; }
        [Required]
        [MaxLength(255)]
        public string Password { get; set; }

        public short RoleId { get; set; }
        public WhmAccount()
        {
        }

        public WhmAccount(string userName, string password, short roleId)
        {
            UserName = userName;
            Password = password;
            RoleId = roleId;
        }
    }
}
