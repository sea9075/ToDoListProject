using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TodoListDemo.Models
{
    public class TodoList
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DisplayName("標題")]
        public string Title { get; set; }
        [DisplayName("描述")]
        public string? Description { get; set; }
        [DisplayName("狀態")]
        public bool Status {  get; set; }
        [DisplayName("開始時間")]
        public DateTime StartTime { get; set; }
        [DisplayName("結束時間")]
        public DateTime? EndTime { get; set; }
        [DisplayName("建立時間")]
        public DateTime CreateTime { get; set; }
    }
}
