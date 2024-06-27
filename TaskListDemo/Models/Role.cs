using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TaskListDemo.Models
{
    public class Role
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Range(1, 100)]
        [DisplayName("顯示順序")]
        public int DisplayNum { get; set; }
        [MaxLength(30)]
        [DisplayName("角色名稱")]
        public string RoleName { get; set; }
    }
}
