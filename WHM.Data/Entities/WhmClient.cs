using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Whm.Data.Entities
{
    [Table("WHM_Client")]
    public class WhmClient : BaseModel
    {
        [Key]
        public Guid ClientId { get; set; }
        [Required]
        public string DisplayName { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        [MaxLength(10)]
        public string Phone { get; set; }
        [MaxLength(255)]
        public string? Email { get; set; }
        public string? MoreInfo { get; set; }

        public virtual ICollection<WhmProductOuput> WhmProductOutputs { get; set; }

        public WhmClient()
        {
            WhmProductOutputs = new HashSet<WhmProductOuput>();
        }

        public WhmClient(Guid clientId, string displayName, string address, string phone, string email, string moreInfo)
        {
            ClientId = clientId;
            DisplayName = displayName;
            Address = address;
            Phone = phone;
            Email = email;
            MoreInfo = moreInfo;
        }
    }
}
