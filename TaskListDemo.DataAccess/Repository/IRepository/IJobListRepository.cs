using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskListDemo.Models;

namespace TaskListDemo.DataAccess.Repository.IRepository
{
    public interface IJobListRepository: IRepository<JobList>
    {
        void Update(JobList obj);
    }
}
