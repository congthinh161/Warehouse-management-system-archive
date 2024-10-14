using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Whm.Data.Entities
{
    [Table("WHM_ProductOutputDetails")]
    public class WhmProductOutputDetail : BaseModel
    {
        [Key]
        public Guid ProdOutputDetailId { get; set; }

        [Required]
        public Guid ProdOutputId { get; set; }

        [Required]
        public Guid ProductId { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public float OutputPrice { get; set; }

        public virtual WhmProductOuput WhmProductOuput { get; set; }
        public virtual WhmProduct WhmProduct { get; set; }

        public WhmProductOutputDetail(Guid prodOutputDetailId, Guid prodOutputId, Guid productId, int quantity, float outputPrice)
        {
            ProdOutputDetailId = prodOutputDetailId;
            ProdOutputId = prodOutputId;
            ProductId = productId;
            Quantity = quantity;
            OutputPrice = outputPrice;
        }

        public WhmProductOutputDetail()
        {
        }
    }
}
