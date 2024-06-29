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
    public class RoleRepository : Repository<Role>, IRoleRepository
    {
        private readonly ApplicationDbContext _db;
        public RoleRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Role obj)
        {
            _db.Roles.Update(obj);
        }
    }
}
