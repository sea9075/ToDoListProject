using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskListDemo.DataAccess.Data;
using TaskListDemo.DataAccess.Repository.IRepository;
using TaskListDemo.Models;

namespace TaskListDemo.DataAccess.Repository
{
    public class JobListRepository : Repository<JobList>, IJobListRepository
    {
        private readonly ApplicationDbContext _db;
        public JobListRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(JobList obj)
        {
            _db.JobLists.Update(obj);
        }
    }
}
