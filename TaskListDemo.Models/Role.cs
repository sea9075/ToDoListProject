using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TaskListDemo.Models
{
    public class Role
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "不能空白")]
        [Range(1, 100, ErrorMessage = "輸入範圍應該要在 1-100 之間")]
        [DisplayName("顯示順序")]
        public int DisplayNum { get; set; }
        [Required(ErrorMessage = "不能空白")]
        [MaxLength(30)]
        [DisplayName("角色名稱")]
        public string RoleName { get; set; }
    }
}
