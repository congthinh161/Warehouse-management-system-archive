using System.ComponentModel.DataAnnotations.Schema;

namespace Whm.Data.Entities
{
    [Table("WHM_ProductAttributeValue")]
    public class WhmProductAttributeValue : BaseModel
    {
        //Key
        public Guid ProductId { get; set; }
        //Key
        public Guid AttributeValueId { get; set; }

        public virtual WhmProduct WhmProductNav { get; set; }
        public virtual WhmAttributeValue WhmAttributeValueNav { get; set; }

        public WhmProductAttributeValue(Guid productId, Guid attributeValueId)
        {
            ProductId = productId;
            AttributeValueId = attributeValueId;
        }

        public WhmProductAttributeValue()
        {
        }
    }
}
