using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskListDemo.Models
{
    public enum JobStatus
    {
        提交中,
        已完成,
        已確認
    }
    public class JobList
    {
        [Key]
        public int JobId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public JobStatus Status { get; set; } = JobStatus.提交中;
        [Required]
        public DateTime Created_at { get; set; } = DateTime.Now;
        public DateTime? Completed_at { get; set; }
        public DateTime? Confirmed_at { get; set; }
    }
}
