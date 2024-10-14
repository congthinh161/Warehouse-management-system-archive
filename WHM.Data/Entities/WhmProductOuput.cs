using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Whm.Data.Entities
{
    [Table("WHM_ProductOuput")]
    public class WhmProductOuput : BaseModel
    {
        [Key]
        public Guid ProdOuputId { get; set; }
        [Required]
        public Guid ClientId { get; set; }
        public float ServiceFee { get; set; }
        public float Discount { get; set; }
        public float PrePayment { get; set; }
        public string Description { get; set; }
        public int ServiceTypeId { get; set; }

        public virtual ICollection<WhmProductOutputDetail> WhmProductOutputDetails { get; set; }
        public virtual WhmServiceType WhmServiceType { get; set; }
        public virtual WhmClient WhmClient { get; set; }

        public WhmProductOuput(Guid prodOuputId, Guid clientId, float serviceFee, float discount, float prePayment, string description, int serviceTypeId)
        {
            ProdOuputId = prodOuputId;
            ClientId = clientId;
            ServiceFee = serviceFee;
            Discount = discount;
            PrePayment = prePayment;
            Description = description;
            ServiceTypeId = serviceTypeId;
        }

        public WhmProductOuput()
        {
            WhmProductOutputDetails = new HashSet<WhmProductOutputDetail>();
        }
    }
}
