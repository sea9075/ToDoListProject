using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using TaskListDemo.Data;
using TaskListDemo.Models;

namespace TaskListDemo.Controllers
{
    public class RoleController : Controller
    {
        private readonly ApplicationDbContext _db;
        public RoleController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<Role> objRoleList = _db.Roles.ToList();
            return View(objRoleList);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Role obj)
        {
            if (obj.RoleName == obj.DisplayNum.ToString())
            {
                ModelState.AddModelError("name", "角色名稱不能跟顯示順序一致");
            }
            
            if (ModelState.IsValid)
            {
                _db.Roles.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id ==0)
            {
                return NotFound();
            }

            Role? roleFromDb = _db.Roles.Find(id);
            if (roleFromDb == null)
            {
                return NotFound();
            }
            return View(roleFromDb);
        }
    }
}
