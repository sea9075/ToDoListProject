using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskListDemo.DataAccess.Data;
using TaskListDemo.DataAccess.Repository.IRepository;

namespace TaskListDemo.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _db;
        public IRoleRepository Role {  get; private set; }
        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Role = new RoleRepository(_db);
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
