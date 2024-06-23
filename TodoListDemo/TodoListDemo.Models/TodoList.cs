using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TodoListDemo.Models
{
    public class TodoList
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        [DisplayName("標題")]
        public string Title { get; set; }
        [DisplayName("描述")]
        public string? Description { get; set; }
        [Required]
        [DisplayName("狀態")]
        public bool Status {  get; set; }
        [Required]
        [DisplayName("開始時間")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true)]
        public DateTime StartTime { get; set; }
        [DisplayName("結束時間")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true)]
        public DateTime? EndTime { get; set; }
        [Required]
        [DisplayName("建立時間")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true)]
        public DateTime CreateTime { get; set; }
    }
}
