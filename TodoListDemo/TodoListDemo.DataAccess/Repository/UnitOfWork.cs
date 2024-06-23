using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoListDemo.DataAccess.Data;
using TodoListDemo.DataAccess.Repository.IRepository;

namespace TodoListDemo.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _db;
        public ITodoListRepository TodoList {  get; private set; }
        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            TodoList = new TodoListRepository(_db);
        }
        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
