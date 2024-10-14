using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Whm.Data.Entities
{
    [Table("WHM_Suplier")]
    public class WhmSuplier : BaseModel
    {
        [Key]
        public Guid SuplierId { get; set; }
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

        public virtual ICollection<WhmProductInput> WhmProductInputs { get; set; }

        public WhmSuplier(Guid suplierId, string displayName, string address, string phone, string? email, string? moreInfo)
        {
            SuplierId = suplierId;
            DisplayName = displayName;
            Address = address;
            Phone = phone;
            Email = email;
            MoreInfo = moreInfo;
        }

        public WhmSuplier()
        {
            WhmProductInputs = new HashSet<WhmProductInput>();
        }
    }
}
