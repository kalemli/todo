using System;

namespace ToDo.Api.Models
{
    public class TaskModel
    {
        public int Id { get; set; }
        public DateTime TaskDate { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public DateTime DelayTime { get; set; }
        public int? CategoryId { get; set; }
    }
}