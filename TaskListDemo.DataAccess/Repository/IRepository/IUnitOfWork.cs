using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskListDemo.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IRoleRepository Role { get; }
        IJobListRepository JobList { get; }
        IUserRepository User { get; }
        void Save();
    }
}