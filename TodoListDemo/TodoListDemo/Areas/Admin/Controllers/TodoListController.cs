using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;
using TodoListDemo.DataAccess.Data;
using TodoListDemo.DataAccess.Repository.IRepository;
using TodoListDemo.Models;

namespace TodoListDemo.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TodoListController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public TodoListController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            List<TodoList> objTodoList = _unitOfWork.TodoList.GetAll().ToList();
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
                _unitOfWork.TodoList.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "代辦事項新增成功";
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            TodoList? todoListFromDb = _unitOfWork.TodoList.Get(u => u.Id == id);

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
                _unitOfWork.TodoList.Update(obj);
                _unitOfWork.Save();
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

            TodoList todoListFromDb = _unitOfWork.TodoList.Get(u => u.Id == id);

            if (todoListFromDb == null)
            {
                return NotFound();
            }
            return View(todoListFromDb);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            TodoList? obj = _unitOfWork.TodoList.Get(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            _unitOfWork.TodoList.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "代辦事項刪除成功";
            return RedirectToAction("Index");
        }
    }
}
