using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskListDemo.Models.ViewModels
{
    public class UserVM
    {
        public User User { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> RoleList {  get; set; }
    }
}
