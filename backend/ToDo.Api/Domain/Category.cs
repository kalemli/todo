using System.ComponentModel.DataAnnotations.Schema;

namespace ToDo.Api.Domain
{
    [Table("category")]
    public class Category
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("name")]
        public string Name { get; set; }
        [Column("parent_id")]
        public int ParentId { get; set; }
        public virtual Category Parent { get; set; }
        [Column("is_active")]
        public bool IsActive { get; set; }
    }
}