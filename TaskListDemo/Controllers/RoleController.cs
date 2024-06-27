using Microsoft.AspNetCore.Mvc;
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
            if (ModelState.IsValid)
            {
                _db.Roles.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
