using System.ComponentModel.DataAnnotations.Schema;

namespace Whm.Data.Entities
{
    [Table("WHM_CategoryAttribute")]
    public class WhmCategoryAttribute : BaseModel
    {
        public Guid CategoryAttributeId { get; set; }
        //[Key]
        public Guid CategoryId { get; set; }
        //[Key]
        public Guid AttributeId { get; set; }

        public virtual WhmAttribute WhmAttribute { get; set; }
        public virtual WhmCategory WhmCategory { get; set; }

        public WhmCategoryAttribute(Guid categoryAttributeId, Guid categoryId, Guid attributeId)
        {
            CategoryAttributeId = categoryAttributeId;
            CategoryId = categoryId;
            AttributeId = attributeId;
        }

        public WhmCategoryAttribute()
        {
        }
    }
}
