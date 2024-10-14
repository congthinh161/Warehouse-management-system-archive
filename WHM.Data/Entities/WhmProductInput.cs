using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Whm.Data.Entities
{
    [Table("WHM_ProductInput")]
    public class WhmProductInput : BaseModel
    {
        [Key]
        public Guid ProdInputId { get; set; }
        [Required]
        public Guid SuplierId { get; set; }
        [Required]
        public float PreMoney { get; set; }
        public string Description { get; set; }

        public virtual ICollection<WhmProductInputDetail> WhmProductInputDetails { get; set; }
        public virtual WhmSuplier WhmSuplier { get; set; }


        public WhmProductInput(Guid prodInputId)
        {
            ProdInputId = prodInputId;
        }

        public WhmProductInput()
        {
            WhmProductInputDetails = new HashSet<WhmProductInputDetail>();
        }
    }
}
