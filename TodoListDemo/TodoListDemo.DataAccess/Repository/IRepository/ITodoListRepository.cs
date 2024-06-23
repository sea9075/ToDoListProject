using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoListDemo.Models;

namespace TodoListDemo.DataAccess.Repository.IRepository
{
    public interface ITodoListRepository : IRepository<TodoList>
    {
        void Update(TodoList obj);
    }
}
