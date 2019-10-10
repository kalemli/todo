using System.ComponentModel.DataAnnotations.Schema;

namespace ToDo.Api.Domain
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? ParentId { get; set; }
        public virtual Category Parent { get; set; }
        public bool IsActive { get; set; }
    }
}