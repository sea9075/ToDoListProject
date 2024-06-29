using Microsoft.AspNetCore.Mvc;
using TaskListDemo.DataAccess.Data;
using TaskListDemo.DataAccess.Repository;
using TaskListDemo.DataAccess.Repository.IRepository;
using TaskListDemo.Models;

namespace TaskListDemo.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RoleController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public RoleController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            List<Role> objRoleList = _unitOfWork.Role.GetAll().ToList();
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
                _unitOfWork.Role.Add(obj);
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

            Role? roleFromDb = _unitOfWork.Role.Get(u => u.Id == id);

            if (roleFromDb == null)
            {
                return NotFound();
            }

            return View(roleFromDb);
        }
        [HttpPost]
        public IActionResult Edit(Role obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Role.Update(obj);
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

            Role? roleFromDb = _unitOfWork.Role.Get(u => u.Id == id);

            if (roleFromDb == null)
            {
                return NotFound();
            }
            return View(roleFromDb);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            Role? obj = _unitOfWork.Role.Get(u => u.Id == id);

            if (obj == null)
            {
                return NotFound();
            }

            _unitOfWork.Role.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "角色刪除成功";
            return RedirectToAction("Index");
        }
    }
}
