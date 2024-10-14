using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Whm.Data.Entities
{
    [Table("WHM_ServiceType")]
    public class WhmServiceType
    {
        [Key]
        public int TypeId { get; set; }
        [Required]
        public string TypeName { get; set; }

        public virtual ICollection<WhmProductOuput> WhmProductOuput { get; set; }

        public WhmServiceType()
        {
            WhmProductOuput = new HashSet<WhmProductOuput>();
        }

        public WhmServiceType(int typeId, string typeName)
        {
            TypeId = typeId;
            TypeName = typeName;
        }
    }
}
