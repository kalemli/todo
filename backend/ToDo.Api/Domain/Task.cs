using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToDo.Api.Domain
{
    public class Task
    {
        public int Id { get; set; }
        public DateTime TaskDate { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public TimeSpan DelayTime { get; set; }
        public int? CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}