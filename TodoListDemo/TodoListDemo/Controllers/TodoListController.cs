using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;
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
            var showTime = new TodoList
            {
                Status = true,
                StartTime = DateTime.Now,
                CreateTime = DateTime.Now
            };
            return View(showTime);
        }
        [HttpPost]
        public IActionResult Create(TodoList obj)
        {
            if (obj.Title == null)
            {
                TempData["error"] = "請輸入標題";
                return RedirectToAction("Create");
            }

            if (ModelState.IsValid)
            {
                _db.todoLists.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "代辦事項新增成功";
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Edit(int? id)
        {
            if (id == null||id == 0)
            {
                return NotFound();
            }

            TodoList? todoListFromDb = _db.todoLists.Find(id);

            if (todoListFromDb == null) 
            {
                return NotFound();
            }
            return View(todoListFromDb);
        }
        [HttpPost]
        public IActionResult Edit(TodoList obj)
        {
            if (obj.Title == null)
            {
                TempData["error"] = "請輸入標題";
                return RedirectToAction("Edit");
            }

            if (ModelState.IsValid)
            {
                _db.todoLists.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "代辦事項修改成功";
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            TodoList todoListFromDb = _db.todoLists.Find(id);

            if (todoListFromDb == null)
            {
                return NotFound();
            }
            return View(todoListFromDb);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            TodoList? obj = _db.todoLists.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.todoLists.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "代辦事項刪除成功";
            return RedirectToAction("Index");
        }
    }
}
