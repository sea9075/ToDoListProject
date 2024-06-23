using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoListDemo.DataAccess.Data;
using TodoListDemo.DataAccess.Repository.IRepository;
using TodoListDemo.Models;

namespace TodoListDemo.DataAccess.Repository
{
    public class TodoListRepository : Repository<TodoList>, ITodoListRepository
    {
        private ApplicationDbContext _db;
        public TodoListRepository(ApplicationDbContext db):base(db)
        {
            _db = db;
        }
        public void Update(TodoList obj)
        {
            _db.todoLists.Update(obj);
        }
    }
}
