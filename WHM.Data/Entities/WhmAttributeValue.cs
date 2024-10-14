using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Whm.Data.Entities
{
    [Table("WHM_AttributeValue")]
    public class WhmAttributeValue : BaseModel
    {
        [Key]
        public Guid AttributeValueId { get; set; }
        public Guid AttributeId { get; set; }
        [Required]
        [MaxLength(255)]
        public string AttributeValue { get; set; }
        public string? AttributeValueDescription { get; set; }

        public virtual WhmAttribute WhmAttribute { get; set; }
        public virtual ICollection<WhmProductAttributeValue> WhmProductAttributeValues { get; set; }

        public WhmAttributeValue(Guid attributeValueId, Guid attributeId, string attributeValue, string attributeValueDescription)
        {
            AttributeValueId = attributeValueId;
            AttributeId = attributeId;
            AttributeValue = attributeValue;
            AttributeValueDescription = attributeValueDescription;
        }

        public WhmAttributeValue()
        {
            WhmProductAttributeValues = new HashSet<WhmProductAttributeValue>();
        }
    }
}
