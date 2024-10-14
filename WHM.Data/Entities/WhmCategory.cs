using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Whm.Data.Entities
{
    [Table("WHM_Category")]
    public class WhmCategory : BaseModel
    {
        [Key]
        public Guid CategoryId { get; set; }
        [Required]
        [MaxLength(500)]
        public string CategoryName { get; set; }

        public string? CategoryDescription { get; set; }

        public virtual ICollection<WhmProduct> WhmProducts { get; set; }
        public virtual ICollection<WhmCategoryAttribute> WhmCategoryAttributes { get; set; }

        public WhmCategory()
        {
            WhmProducts = new HashSet<WhmProduct>();
            WhmCategoryAttributes = new HashSet<WhmCategoryAttribute>();
        }

        public WhmCategory(Guid categoryId, string categoryName)
        {
            CategoryId = categoryId;
            CategoryName = categoryName;
        }
    }
}
