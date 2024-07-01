using Microsoft.AspNetCore.Mvc;
using TaskListDemo.DataAccess.Data;
using TaskListDemo.DataAccess.Repository;
using TaskListDemo.DataAccess.Repository.IRepository;
using TaskListDemo.Models;

namespace TaskListDemo.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public UserController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            List<User> objUserList = _unitOfWork.User.GetAll().ToList();
            return View(objUserList);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(User obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.User.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "使用者新增成功";
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

            User? userFromDb = _unitOfWork.User.Get(u => u.UserId == id);

            if (userFromDb == null)
            {
                return NotFound();
            }

            return View(userFromDb);
        }
        [HttpPost]
        public IActionResult Edit(User obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.User.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "使用者修改成功";
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

            User? userFromDb = _unitOfWork.User.Get(u => u.UserId == id);

            if (userFromDb == null)
            {
                return NotFound();
            }
            return View(userFromDb);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            User? obj = _unitOfWork.User.Get(u => u.UserId == id);

            if (obj == null)
            {
                return NotFound();
            }

            _unitOfWork.User.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "使用者刪除成功";
            return RedirectToAction("Index");
        }
    }
}
