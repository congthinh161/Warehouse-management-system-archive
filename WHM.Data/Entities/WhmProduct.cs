using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Whm.Data.Entities
{
    [Table("WHM_Product")]
    public class WhmProduct : BaseModel
    {
        [Key]
        public Guid ProductId { get; set; }
        public Guid CategoryId { get; set; }
        [Required]
        [MaxLength(1000)]
        public string ProductName { get; set; }
        public string? ProductDescription { get; set; }
        [Required]
        public float EstimatedPrice { get; set; }

        public virtual WhmCategory CategoryIdNavigation { get; set; }
        public virtual ICollection<WhmProductAttributeValue> WhmProductAttributeValues { get; set; }
        public virtual ICollection<WhmProductInputDetail> WhmProductInputDetails { get; set; }
        public virtual ICollection<WhmProductOutputDetail> WhmProductOutputDetails { get; set; }

        public WhmProduct()
        {
            WhmProductAttributeValues = new HashSet<WhmProductAttributeValue>();
            WhmProductInputDetails = new HashSet<WhmProductInputDetail>();
            WhmProductOutputDetails = new HashSet<WhmProductOutputDetail>();
        }

        public WhmProduct(Guid productId, Guid categoryId, string productName, string productDescription)
        {
            ProductId = productId;
            CategoryId = categoryId;
            ProductName = productName;
            ProductDescription = productDescription;
        }
    }
}
