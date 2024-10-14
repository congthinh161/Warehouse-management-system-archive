using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Whm.Data.Entities
{
    [Table("WHM_Attribute")]
    public class WhmAttribute : BaseModel
    {
        [Key]
        public Guid AttributeId { get; set; }
        [Required]
        [MaxLength(300)]
        public string AttributeName { get; set; }

        public string? AttributeDescription { get; set; }

        public virtual ICollection<WhmCategoryAttribute> WhmCategoryAttributes { get; set; }
        public virtual ICollection<WhmAttributeValue> WhmAttributeValues { get; set; }

        public WhmAttribute(Guid attributeId, string attributeName, string? attributeDescription)
        {
            AttributeId = attributeId;
            AttributeName = attributeName;
            AttributeDescription = attributeDescription;
        }

        public WhmAttribute()
        {
            WhmCategoryAttributes = new HashSet<WhmCategoryAttribute>();
            WhmAttributeValues = new HashSet<WhmAttributeValue>();
        }
    }
}
