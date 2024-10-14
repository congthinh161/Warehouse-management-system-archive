using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Whm.Data.Entities
{
    [Table("WHM_ProductInputDetails")]
    public class WhmProductInputDetail : BaseModel
    {
        [Key]
        public Guid ProdInputDetailId { get; set; }

        [Required]
        public Guid ProdInputId { get; set; }

        [Required]
        public Guid ProductId { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public float InputPrice { get; set; }

        public virtual WhmProductInput WhmProductInput { get; set; }
        public virtual WhmProduct WhmProduct { get; set; }
        public WhmProductInputDetail(Guid prodInputDetailId, Guid prodInputId, Guid productId, int quantity, float inputPrice)
        {
            ProdInputDetailId = prodInputDetailId;
            ProdInputId = prodInputId;
            ProductId = productId;
            Quantity = quantity;
            InputPrice = inputPrice;
        }

        public WhmProductInputDetail()
        {
        }
    }
}
