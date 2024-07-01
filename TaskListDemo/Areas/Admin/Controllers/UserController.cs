using Microsoft.AspNetCore.Mvc;
using TaskListDemo.DataAccess.Data;
using TaskListDemo.DataAccess.Repository;
using TaskListDemo.DataAccess.Repository.IRepository;
using TaskListDemo.Models;
using TaskListDemo.Models.ViewModels;

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
            List<User> objRoleList = _unitOfWork.User.GetAll().ToList();
            return View(objRoleList);
        }
        public IActionResult Create()
        {
            UserVM userVm = new()
            {
                RoleList = _unitOfWork.Role.GetAll().Select(u => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem
                {
                    Text = u.RoleName,
                    Value = u.Id.ToString()
                }),
                User = new User()
            };
            return View(userVm);
        }
        [HttpPost]
        public IActionResult Create(UserVM obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.User.Add(obj.User);
                _unitOfWork.Save();
                TempData["success"] = "角色新增成功";
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
                TempData["success"] = "角色修改成功";
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
            TempData["success"] = "角色刪除成功";
            return RedirectToAction("Index");
        }
    }
}
