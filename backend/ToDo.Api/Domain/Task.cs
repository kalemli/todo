using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToDo.Api.Domain
{
    [Table("task")]
    public class Task
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("start_time")]
        public DateTime StartTime { get; set; }
        [Column("end_time")]
        public DateTime EndTime { get; set; }
        [Column("delay_time")]
        public DateTime DelayTime { get; set; }
        [Column("category_id")]
        public int? CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}