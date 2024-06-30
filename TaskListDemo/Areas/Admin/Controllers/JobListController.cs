using Microsoft.AspNetCore.Mvc;
using TaskListDemo.DataAccess.Data;
using TaskListDemo.DataAccess.Repository;
using TaskListDemo.DataAccess.Repository.IRepository;
using TaskListDemo.Models;

namespace TaskListDemo.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class JobListController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public JobListController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            List<JobList> objJobList = _unitOfWork.JobList.GetAll().ToList();
            return View(objJobList);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(JobList obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.JobList.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "需求單新增成功";
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

            JobList? jobListFromDb = _unitOfWork.JobList.Get(u => u.JobId == id);

            if (jobListFromDb == null)
            {
                return NotFound();
            }

            return View(jobListFromDb);
        }
        [HttpPost]
        public IActionResult Edit(JobList obj)
        {
            if (ModelState.IsValid)
            {
                
                if (obj.Completed_at != null)
                {
                    obj.Status = JobStatus.已完成;
                }

                if (obj.Confirmed_at != null)
                {
                    obj.Status = JobStatus.已確認;
                }
                
                _unitOfWork.JobList.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "需求單修改成功";
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

            JobList? jobListFromDb = _unitOfWork.JobList.Get(u => u.JobId == id);

            if (jobListFromDb == null)
            {
                return NotFound();
            }
            return View(jobListFromDb);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            JobList? obj = _unitOfWork.JobList.Get(u => u.JobId == id);

            if (obj == null)
            {
                return NotFound();
            }

            _unitOfWork.JobList.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "需求單刪除成功";
            return RedirectToAction("Index");
        }
    }
}
