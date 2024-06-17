using Microsoft.AspNetCore.Mvc;
using TodoListDemo.Data;
using TodoListDemo.Models;

namespace TodoListDemo.Controllers
{
    public class TodoListController : Controller
    {
        private readonly ApplicationDbContext _db;
        public TodoListController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<TodoList> objTodoList = _db.todoLists.ToList();
            return View(objTodoList);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(TodoList obj)
        {
            _db.todoLists.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
